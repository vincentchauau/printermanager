using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using OpenHtmlToPdf;
using System.Collections.Generic;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading;

namespace QuanLyInAn
{
    public partial class fMain : Form
    {
        public void html2pdf(String htmlFile, String pdfFile, Dictionary<String, String> keyValues)
        {
            string html = File.ReadAllText(htmlFile);
            foreach (KeyValuePair<String, String> keyValue in keyValues)
            {
                html = html.Replace(keyValue.Key, keyValue.Value);
            }
            var pdf = Pdf.From(html).OfSize(PaperSize.A4).WithGlobalSetting("orientation", "Landscape").WithObjectSetting("web.defaultEncoding", "utf-8");
            File.WriteAllBytes(pdfFile, pdf.Content());
        }
        public string inputDialog(String title)
        {
            Size size = new Size(200, 70);
            Form form = new Form();
            form.FormBorderStyle = FormBorderStyle.Fixed3D;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ClientSize = size;
            form.Text = title;
            TextBox textBox = new TextBox();
            textBox.Size = new Size(size.Width - 10, 23);
            textBox.Location = new Point(5, 5);
            form.Controls.Add(textBox);
            Button btYes = new Button();
            btYes.DialogResult = DialogResult.OK;
            btYes.Name = "btYes";
            btYes.Size = new Size(75, 23);
            btYes.Text = "&Yes";
            btYes.Location = new Point(size.Width - 80 - 80, 39);
            form.Controls.Add(btYes);
            Button btNo = new Button();
            btNo.DialogResult = DialogResult.Cancel;
            btNo.Name = "btNo";
            btNo.Size = new Size(75, 23);
            btNo.Text = "&No";
            btNo.Location = new Point(size.Width - 80, 39);
            form.Controls.Add(btNo);
            form.AcceptButton = btYes;
            form.CancelButton = btNo;
            DialogResult result = form.ShowDialog();
            return textBox.Text;
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=inan.accdb");
        public String getRows(String table, String[] columns, Boolean[] types, String[] values)
        {
            String sql = "";
            String[] tokens;
            for (int i = 0; i < columns.Length; ++i)
            {
                if (values[i] != "")
                {
                    tokens = values[i].Split('-');
                    if (tokens.Length == 1)
                    {
                        if (values[i].StartsWith("\'") && values[i].EndsWith("\'")) //exact
                        {
                            values[i] = values[i].Substring(1, values[i].Length - 1);
                            if (types[i] == false)
                            {
                                sql += String.Format("{0} = {1} AND ", columns[i], values[i]);
                            }
                            else
                            {
                                sql += String.Format("{0}='{1}' AND ", columns[i], values[i]);
                            }
                        }
                        else // approximate 
                        {
                            sql += String.Format("{0} LIKE '%{1}%' AND ", columns[i], values[i]);
                        }
                    }
                    else
                    {
                        if (types[i] == false)
                        {
                            sql += String.Format("{0} >= {1} AND {2} <= {3} AND ", columns[i], tokens[0], columns[i], tokens[1]);
                        }
                        else
                        {
                            sql += String.Format("{0} >= '{1}' AND {2} <= '{3}' AND ", columns[i], tokens[0], columns[i], tokens[1]);
                        }
                    }
                }
                else
                {
                }
            }
            if (sql != "")
            {
                sql = " WHERE " + sql.Substring(0, sql.Length - 5);
            }
            else
            {
            }
            sql = String.Format("SELECT * FROM {0}{1}", table, sql);
            return sql;
        }
        public String insertRows(String table, String[] columns, bool[] types, String[] values)
        {
            String column = "", value = "";
            for (int i = 0; i < columns.Length; ++i)
            {
                column += columns[i] + ",";
                value += String.Format("'{0}',", values[i]);
            }
            column = column.Substring(0, column.Length - 1);
            value = value.Substring(0, value.Length - 1);
            return String.Format("INSERT INTO {0}({1}) VALUES ({2})", table, column, value);
        }
        public String deleteRows(String table, String value)
        {
            if (value == "")
            {
                return String.Format("DELETE FROM {0}", table);
            }
            else
            {
                return String.Format("DELETE FROM {0} WHERE ID = '{1}'", table, value);
            }
        }
        public DataTable query(String sql)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand(sql, connection);
                DataTable dataTable = new DataTable();
                if (sql.StartsWith("SELECT"))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataTable);
                    connection.Close();
                }
                else
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return dataTable;

            }
            catch (Exception error)
            {
                connection.Close();
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
            return null;
        }
        public List<DataTable> query(String[] sqls)
        {
            try
            {
                List<DataTable> results = new List<DataTable>();
                connection.Open();
                foreach (string sql in sqls)
                {
                    OleDbCommand command = new OleDbCommand(sql, connection);
                    if (sql.StartsWith("SELECT"))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        results.Add(dataTable);
                    }
                    else
                    {
                        command.ExecuteNonQuery();
                    }
                }
                connection.Close();
                return results;
            }
            catch (Exception error)
            {
                connection.Close();
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
            return null;
        }
        public int getRowCount()
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT COUNT(*) FROM HOPDONG", connection);
            int count = (int)command.ExecuteScalar();
            connection.Close();
            return count;
        }
        public List<String> getValuesByColumn(String column)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand(String.Format("SELECT DISTINCT {0} FROM HOPDONG", column), connection);
            List<String> result = new List<string>();
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader[column].ToString());
                }
            }
            connection.Close();
            return result;
        }

        public fMain()
        {
            InitializeComponent();
        }
        String ID = "", path = "";
        Dictionary<String, String> keyValues = new Dictionary<string, string>();

        // Search contracts
        string table = "HOPDONG";
        string[] columns = new string[26];
        bool[] types;
        private void fMain_Load(object sender, EventArgs e)
        {
            // Config
            if (File.Exists("config.txt"))
            {
                StreamReader reader = new StreamReader("config.txt");
                path = reader.ReadLine();
                if (path == null)
                {
                    path = Application.StartupPath;
                }
                else { }
                reader.Close();
            }
            else
            {
                path = Application.StartupPath;
            }
            
            // Table InAn
            gvInAn.DataSource = query("SELECT * FROM HOPDONG");
            for (int i = 0; i < gvInAn.ColumnCount; ++i)
            {
                gvInAn.Columns[i].Width = 140;
                columns[i] = gvInAn.Columns[i].Name;
                keyValues.Add(columns[i], "");
                gvRow.Columns.Add(columns[i], gvInAn.Columns[i].HeaderText);
            }
            types = new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, true, true, true };
            gvInAn.Columns["ThanhToan"].ReadOnly = true;
            gvInAn.Columns["BaoTri"].ReadOnly = true;
            gvInAn.Columns["HoTro"].ReadOnly = true;

            // Table Row
            if (gvInAn.RowCount > 1)
            {
                gvRow.Rows.Add();
                for (int i = 0; i < gvRow.ColumnCount; ++i)
                {
                    gvRow.Rows[0].Cells[i].Value = gvInAn.Rows[0].Cells[i].Value;
                }
            }
            else { }

            // Extra Key Values
            keyValues.Add("Ngay", "");
            keyValues.Add("ThongTin", "");
            keyValues.Add("Mode", "");
            keyValues.Add("CounterDTBD", "");
            keyValues.Add("CounterMBD", "");
            keyValues.Add("CounterDTKT", "");
            keyValues.Add("CounterMKT", "");
            keyValues.Add("CounterDTDD", "");
            keyValues.Add("CounterMDD", "");
            keyValues.Add("VuotDinhMucDT", "");
            keyValues.Add("VuotDinhMucM", "");
            keyValues.Add("PhiDTDM", "");
            keyValues.Add("PhiMDM", "");
            keyValues.Add("PhiDTVDM", "");
            keyValues.Add("PhiMVDM", "");
            keyValues.Add("TongPhiDT", "");
            keyValues.Add("TongPhiM", "");
            keyValues.Add("TongPhiChuaThue", "");
            keyValues.Add("ThueGTGT", "");
            keyValues.Add("TongPhiCoThue", "");
        }
        private void gvRow_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    clearToolStripMenuItem_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    searchToolStripMenuItem_Click(sender, e);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }
        // Select a contract
        private void gvInAn_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ID = gvInAn.CurrentRow.Cells["ID"].Value.ToString();
                Text = ID;
                for (int i = 0; i < gvRow.ColumnCount; ++i)
                {
                    gvRow.Rows[0].Cells[i].Value = gvInAn.CurrentRow.Cells[i].Value;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        // Edit a contract
        private void gvInAn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox autoText = e.Control as TextBox;
                String column = gvInAn.Columns[gvInAn.CurrentCell.ColumnIndex].Name;
                List<String> columns = new List<String> { "KhuVucBT", "NhanVienHT", "NhanVienBT", "TenSP", "DonGiaDTDM", "DonGiaDTVDM", "DonGiaMDM", "DonGiaMVDM", };
                if (columns.Contains(column))
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    data.AddRange(getValuesByColumn(column).ToArray());
                    autoText.AutoCompleteCustomSource = data;
                }
                else { }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }
        private void gvInAn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = gvInAn.Rows[e.RowIndex];
                String column = gvInAn.Columns[e.ColumnIndex].Name;
                String cell = row.Cells[e.ColumnIndex].Value.ToString();
                List<String> columns = new List<String> { "TenKH", "DienThoai", "Email", "DiaChiKD", "DiaChiLD", "SerialSP" };
                if (columns.Contains(column) && getValuesByColumn(column).Contains(cell))
                {
                    MessageBox.Show("Dữ liệu đã bị trùng lắp", "Thông Báo", MessageBoxButtons.OK);
                }
                else { }
                String sql;
                if (ID == "")
                {
                    ID = String.Format("HD {0:D5}", getRowCount() + 1);
                    if (e.ColumnIndex == 0)
                    {
                        sql = String.Format(@"INSERT INTO HOPDONG(ID) VALUES ('{0}')", ID);
                    }
                    else
                    {
                        sql = String.Format(@"INSERT INTO HOPDONG(ID, {0}) VALUES ('{1}', '{2}')", column, ID, cell);
                    }
                    row.Cells[0].Value = ID;
                }
                else
                {
                    sql = String.Format(@"UPDATE HOPDONG SET {0}='{1}' WHERE ID='{2}'", column, cell, ID);
                }
                query(sql);
                if (column == "NgayHD" || column == "ThoiHanHD" || column == "ChuKyBT" || column == "ChuKyTT")
                {
                    int iThoiHanHD = int.Parse(row.Cells["ThoiHanHD"].Value.ToString());
                    DateTime ngayHD = DateTime.Parse(row.Cells["NgayHD"].Value.ToString());
                    if (column == "ThoiHanHD" || column == "NgayHD")
                    {
                        int iChuKyBT = int.Parse(row.Cells["ChuKyBT"].Value.ToString());
                        String result = "Ngay,ThongTin;";
                        for (int i = 0; i <= Math.Ceiling((double)iThoiHanHD / iChuKyBT); ++i)
                        {
                            result += String.Format("{0},;", ngayHD.AddMonths(i * iChuKyBT).ToShortDateString());
                        }
                        row.Cells["BaoTri"].Value = result.Substring(0, result.Length - 1);
                        int iChuKyTT = int.Parse(row.Cells["ChuKyTT"].Value.ToString());
                        result = "Ngay,CounterDTBD,CounterMBD,CounterDTKT,CounterMKT;";
                        for (int i = 0; i <= Math.Ceiling((double)iThoiHanHD / iChuKyTT); ++i)
                        {
                            result += String.Format("{0},,,,;", ngayHD.AddMonths(i * iChuKyTT).ToShortDateString());
                        }
                        row.Cells["ThanhToan"].Value = result.Substring(0, result.Length - 1);
                        result = "Ngay,ThongTin;";
                        for (int i = 0; i < 10; ++i)
                        {
                            result += String.Format(",;");
                        }
                        row.Cells["HoTro"].Value = result.Substring(0, result.Length - 1);
                    }
                    else if (column == "ChuKyBT")
                    {
                        int iChuKyBT = int.Parse(row.Cells["ChuKyBT"].Value.ToString());
                        String result = "Ngay,ThongTin;";
                        for (int i = 0; i <= Math.Ceiling((double)iThoiHanHD / iChuKyBT); ++i)
                        {
                            result += String.Format("{0},;", ngayHD.AddMonths(i * iChuKyBT).ToShortDateString());
                        }
                        row.Cells["BaoTri"].Value = result.Substring(0, result.Length - 1);
                    }
                    else if (column == "ChuKyTT")
                    {
                        int iChuKyTT = int.Parse(row.Cells["ChuKyTT"].Value.ToString());
                        String result = "Ngay,CounterDTBD,CounterMBD,CounterDTKT,CounterMKT;";
                        for (int i = 0; i <= Math.Ceiling((double)iThoiHanHD / iChuKyTT); ++i)
                        {
                            result += String.Format("{0},,,,;", ngayHD.AddMonths((i + 1) * iChuKyTT).ToShortDateString());
                        }
                        row.Cells["ThanhToan"].Value = result.Substring(0, result.Length - 1);
                    }
                    else { }
                }
                else { }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        private string mode = "HopDong";
        private void gvInAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 0)
                {
                    DataGridViewRow row = gvInAn.Rows[e.RowIndex];
                    String column = gvInAn.Columns[e.ColumnIndex].Name;
                    String cell = row.Cells[e.ColumnIndex].Value.ToString();
                    if (column == "ThanhToan" || column == "BaoTri" || column == "HoTro")
                    {
                        mode = column;
                        String[] rows = gvInAn.CurrentCell.Value.ToString().Split(';');
                        DataTable table = new DataTable();
                        String[] columns = rows[0].Split(',');
                        if (columns.Length > 1)
                        {
                            for (int i = 0; i < columns.Length; ++i)
                            {
                                table.Columns.Add(columns[i]);
                            }
                            for (int i = 1; i < rows.Length; ++i)
                            {
                                table.Rows.Add(rows[i].Split(','));
                            }
                            gvPopup.DataSource = table;
                            gvPopup.Columns[0].Width = 140;
                            gvPopup.Visible = true;
                        }
                        else
                        {
                            int iThoiHanHD = int.Parse(row.Cells["ThoiHanHD"].Value.ToString());
                            DateTime ngayHD = DateTime.Parse(row.Cells["NgayHD"].Value.ToString());
                            if (column == "ThoiHanHD")
                            {
                                int iChuKyBT = int.Parse(row.Cells["ChuKyBT"].Value.ToString());
                                String result = "Ngay,ThongTin;";
                                for (int i = 0; i < Math.Ceiling((double)iThoiHanHD / iChuKyBT); ++i)
                                {
                                    result += String.Format("{0},;", ngayHD.AddMonths((i + 1) * iChuKyBT).ToShortDateString());
                                }
                                row.Cells["BaoTri"].Value = result.Substring(0, result.Length - 1);
                                int iChuKyTT = int.Parse(row.Cells["ChuKyTT"].Value.ToString());
                                result = "Ngay,CounterDTBD,CounterMBD,CounterDTKT,CounterMKT;";
                                for (int i = 0; i < Math.Ceiling((double)iThoiHanHD / iChuKyTT); ++i)
                                {
                                    result += String.Format("{0},,,,;", ngayHD.AddMonths((i + 1) * iChuKyTT).ToShortDateString());
                                }
                                row.Cells["ThanhToan"].Value = result.Substring(0, result.Length - 1);
                                result = "Ngay,ThongTin;";
                                for (int i = 0; i < 10; ++i)
                                {
                                    result += String.Format(",;");
                                }
                                row.Cells["HoTro"].Value = result.Substring(0, result.Length - 1);
                            }
                            else if (column == "ChuKyBT")
                            {
                                int iChuKyBT = int.Parse(row.Cells["ChuKyBT"].Value.ToString());
                                String result = "Ngay,ThongTin;";
                                for (int i = 0; i < Math.Ceiling((double)iThoiHanHD / iChuKyBT); ++i)
                                {
                                    result += String.Format("{0},;", ngayHD.AddMonths((i + 1) * iChuKyBT).ToShortDateString());
                                }
                                row.Cells["BaoTri"].Value = result.Substring(0, result.Length - 1);
                            }
                            else if (column == "ChuKyTT")
                            {
                                int iChuKyTT = int.Parse(row.Cells["ChuKyTT"].Value.ToString());
                                String result = "Ngay,CounterDTBD,CounterMBD,CounterDTKT,CounterMKT;";
                                for (int i = 0; i < Math.Ceiling((double)iThoiHanHD / iChuKyTT); ++i)
                                {
                                    result += String.Format("{0},,,,;", ngayHD.AddMonths((i + 1) * iChuKyTT).ToShortDateString());
                                }
                                row.Cells["ThanhToan"].Value = result.Substring(0, result.Length - 1);
                            }
                            else { }
                        }
                    }
                    else { }
                }
                else { }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }
        private void gvPopup_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    mode = "HopDong";
                    String result = "";
                    for (int i = 0; i < gvPopup.ColumnCount; ++i)
                    {
                        result += gvPopup.Columns[i].Name + ",";
                    }
                    result = result.Substring(0, result.Length - 1) + ";";
                    for (int i = 0; i < gvPopup.RowCount; ++i)
                    {
                        for (int j = 0; j < gvPopup.ColumnCount; ++j)
                        {
                            result += gvPopup.Rows[i].Cells[j].Value.ToString() + ",";
                        }
                        result = result.Substring(0, result.Length - 1) + ";";
                    }
                    gvInAn.CurrentCell.Value = result.Substring(0, result.Length - 1);
                    gvPopup.Visible = false;
                }
                else { }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }
        private void gvInAn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnInAn.Show(gvInAn, new Point(e.X, e.Y));
            }
        }
        private void gvRow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnRow.Show(gvRow, new Point(e.X, e.Y));
            }
        }
        private void gvPopup_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnPopup.Show(gvPopup, new Point(e.X, e.Y));
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(import));
            //thread.IsBackground = true;
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.Start();
            print();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ttTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearToolStripMenuItem_Click(sender, e);
            DateTime now = DateTime.Now;
            gvRow.Rows[0].Cells["ThanhToan"].Value = now.ToShortDateString();
            searchToolStripMenuItem_Click(sender, e);
        }

        private void btTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearToolStripMenuItem_Click(sender, e);
            DateTime now = DateTime.Now;
            gvRow.Rows[0].Cells["BaoTri"].Value = now.ToShortDateString();
            searchToolStripMenuItem_Click(sender, e);
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvRow.ColumnCount; ++i)
            {
                gvRow.Rows[0].Cells[i].Value = "";
            }
        }
        
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(import));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(export));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter("config.txt");
                writer.WriteLine(folderDlg.SelectedPath);
                writer.Close();
            }
            else { }
        }
        public void import()
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = path;
                fileDialog.Filter = "XLS files (*.xlsx;*.xls;*.csv)|*.xlsx;*.xls;*.csv";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application app = new Excel.Application();
                    app.Visible = false;
                    app.UserControl = false;
                    Excel.Workbook workbook = app.Workbooks.Open(fileDialog.FileName);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<String> sqls = new List<string>();
                    sqls.Add(deleteRows(table, ""));
                    for (int i = 1; i <= range.Rows.Count; i++)
                    {
                        List<String> values = new List<string>();
                        for (int j = 1; j <= 26; j++)
                        {
                            values.Add(range.Cells[i, j].Text.ToString());
                        }
                        sqls.Add(insertRows(table, columns, types, values.ToArray()));
                    }
                    query(sqls.ToArray());
                    workbook.Close(true, null, null);
                    app.Quit();
                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(app);
                    MessageBox.Show("Imported successfully", "Thông Báo", MessageBoxButtons.OK);
                }
                else { }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }
        public void export()
        {
            try
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.InitialDirectory = path;
                fileDialog.Filter = "XLS files (*.xls)|*.xls|XLSX files (*.xlsx)|*.xls|CSV files (*.csv)|*.csv";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application app = new Excel.Application();
                    Excel.Workbook workbook = app.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    app.Visible = false;
                    app.UserControl = false;
                    for (int i = 0; i < gvInAn.RowCount - 1; ++i)
                    {
                        for (int j = 0; j < gvInAn.ColumnCount; ++j)
                        {
                            worksheet.Cells[i + 1, j + 1] = gvInAn.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    switch (fileDialog.FilterIndex)
                    {
                        case 1:
                            workbook.SaveAs(fileDialog.FileName, Excel.XlFileFormat.xlExcel8);
                            break;
                        case 2:
                            workbook.SaveAs(fileDialog.FileName, Excel.XlFileFormat.xlExcel12);
                            break;
                        case 3:
                            workbook.SaveAs(fileDialog.FileName, Excel.XlFileFormat.xlCSV);
                            break;
                    }
                    workbook.Close();
                    app.Quit();
                    Marshal.ReleaseComObject(worksheet);
                    Marshal.ReleaseComObject(workbook);
                    Marshal.ReleaseComObject(app);
                    MessageBox.Show("Exported successfully", "Thông Báo", MessageBoxButtons.OK);
                }
                else { }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void gvInAn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                query(deleteRows(table, gvInAn.CurrentRow.Cells["ID"].Value.ToString()));
            }
            else { }
        }

        private void searchAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearToolStripMenuItem_Click(sender, e);
            searchToolStripMenuItem_Click(sender, e);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] values = new string[gvRow.ColumnCount];
            for (int i = 0; i < gvRow.ColumnCount; ++i)
            {
                values[i] = gvRow.Rows[0].Cells[i].Value.ToString();
            }
            gvInAn.DataSource = query(getRows(table, columns, types, values));
        }

        private void gvInAn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvInAn.Rows[e.RowIndex].Cells[e.ColumnIndex] == gvInAn.CurrentCell)
                e.CellStyle.BackColor = Color.Black;
        }

        private void gvInAn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try {
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }

        public void print()
        {
            try
            {
                if (gvPopup.CurrentRow != null)
                {
                    DataGridViewRow row = gvInAn.CurrentRow;
                    for (int i = 0; i < gvInAn.ColumnCount; ++i)
                    {
                        keyValues[gvInAn.Columns[i].Name] = row.Cells[i].Value.ToString();
                    }
                    keyValues["Ngay"] = gvPopup.CurrentRow.Cells[0].Value.ToString();
                    String pdfFile = "";
                    switch (mode)
                    {
                        case "ThanhToan":
                            MessageBox.Show("Thanh Cong");
                            keyValues["Mode"] = "THANH TOÁN";
                            keyValues["CounterDTBD"] = gvPopup.CurrentRow.Cells[1].Value.ToString();
                            keyValues["CounterMBD"] = gvPopup.CurrentRow.Cells[2].Value.ToString();
                            keyValues["CounterDTKT"] = gvPopup.CurrentRow.Cells[3].Value.ToString();
                            keyValues["CounterMKT"] = gvPopup.CurrentRow.Cells[4].Value.ToString();
                            int counterDTDD = int.Parse(keyValues["CounterDTBD"]) - int.Parse(keyValues["CounterDTKT"]);
                            int counterMDD = int.Parse(keyValues["CounterMBD"]) - int.Parse(keyValues["CounterMKT"]);
                            keyValues["CounterDTDD"] = counterDTDD.ToString();
                            keyValues["CounterMDD"] = counterMDD.ToString();
                            int dinhMucDT = int.Parse(keyValues["DinhMucDT"]);
                            int dinhMucM = int.Parse(keyValues["DinhMucDT"]);
                            int vuotDinhMucDT = int.Parse(keyValues["CounterDTKT"]) - int.Parse(keyValues["DinhMucDT"]);
                            int vuotDinhMucM = int.Parse(keyValues["CounterMKT"]) - int.Parse(keyValues["DinhMucM"]);
                            double donGiaDTDM = double.Parse(keyValues["DonGiaDTDM"]);
                            double donGiaDTVDM = double.Parse(keyValues["DonGiaDTVDM"]);
                            double donGiaMDM = double.Parse(keyValues["DonGiaMDM"]);
                            double donGiaMVDM = double.Parse(keyValues["DonGiaMVDM"]);
                            if (counterDTDD >= 0 && counterMDD >= 0 && donGiaDTDM >= 0 && donGiaDTVDM >= 0 && donGiaMDM >= 0 && donGiaMVDM >= 0 && dinhMucDT >= 0 && dinhMucM >= 0)
                            {
                                if (vuotDinhMucDT < 0)
                                {
                                    vuotDinhMucDT = 0;
                                }
                                else { }
                                if (vuotDinhMucM < 0)
                                {
                                    vuotDinhMucM = 0;
                                }
                                else { }
                                keyValues["VuotDinhMucDT"] = vuotDinhMucDT.ToString();
                                keyValues["VuotDinhMucM"] = vuotDinhMucM.ToString();
                                double phiDTDM = dinhMucDT * donGiaDTDM;
                                double phiDTVDM = vuotDinhMucDT * donGiaDTVDM;
                                double phiMDM = dinhMucM * donGiaMDM;
                                double phiMVDM = vuotDinhMucM * donGiaMVDM;
                                double tongPhiDT = phiDTDM + phiDTVDM;
                                double tongPhiM = phiMDM + phiMVDM;
                                double tongPhiChuaThue = tongPhiDT + tongPhiM;
                                double thueGTGT = tongPhiChuaThue * 0.1;
                                double tongPhiCoThue = tongPhiChuaThue * 1.1;
                                keyValues["PhiDTDM"] = String.Format("{0:#,0}", phiDTDM);
                                keyValues["PhiDTVDM"] = String.Format("{0:#,0}", phiDTVDM);
                                keyValues["PhiMDM"] = String.Format("{0:#,0}", phiMDM);
                                keyValues["PhiMVDM"] = String.Format("{0:#,0}", phiMVDM);
                                keyValues["TongPhiDT"] = String.Format("{0:#,0}", tongPhiDT);
                                keyValues["TongPhiM"] = String.Format("{0:#,0}", tongPhiM);
                                keyValues["TongPhiChuaThue"] = String.Format("{0:#,0}", tongPhiChuaThue);
                                keyValues["ThueGTGT"] = String.Format("{0:#,0}", thueGTGT);
                                keyValues["TongPhiCoThue"] = String.Format("{0:#,0}", tongPhiCoThue);
                            }
                            pdfFile = String.Format("{0}\\{1}_TT_{2}.pdf", path, keyValues["ID"], keyValues["Ngay"]).Replace("/", "_");
                            html2pdf("thanhtoan.html", pdfFile, keyValues);
                            break;
                        case "BaoTri":
                            keyValues["Mode"] = "BẢO TRÌ";
                            keyValues["ThongTin"] = gvPopup.CurrentRow.Cells[1].Value.ToString();
                            pdfFile = String.Format("{0}\\{1}_BT_{2}.pdf", path, keyValues["ID"], keyValues["Ngay"]).Replace("/", "_");
                            html2pdf("baotri.html", pdfFile, keyValues);
                            break;
                        case "HoTro":
                            keyValues["Mode"] = "HỖ TRỢ";
                            keyValues["ThongTin"] = gvPopup.CurrentRow.Cells[1].Value.ToString();
                            pdfFile = String.Format("{0}\\{1}_HT_{2}.pdf", path, keyValues["ID"], keyValues["Ngay"]).Replace("/", "_");
                            html2pdf("hotro.html", pdfFile, keyValues);
                            break;
                    }
                }
                else { }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Thông Báo", MessageBoxButtons.OK);
            }
        }
    }
}
