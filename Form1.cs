using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using Dapper;


namespace SQL_Dapper
{
    public partial class Form1 : Form
    {
        public string FileName { get; set; }
        public int InsertInformation { get; set; }
        public List<TemperatureRecord> TemperatureRecords { get; set; }
        public List<CsvFormat> CsvFormats { get; set; }
        public string DeleteRowSelect { get; set; }
        public string DbPath = @"C:\Users\xps15\source\repos\SQLite_Re\SQLite_Re\bin\Debug\database.sqlite3";
       
        public Form1()
        {
            InitializeComponent();
        }

        private void openCSV_Click(object sender, EventArgs e)
        {
            TemperatureRecords?.Clear();
            CsvFormats?.Clear();
            try
            {
                using (var ofd = new OpenFileDialog(){Filter="CSV|*.csv",ValidateNames = true, Multiselect = false})
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        TemperatureRecords?.Clear();
                        using (var reader = new StreamReader(ofd.FileName))
                        using (var csv = new CsvReader(reader))
                        {
                            var records = csv.GetRecords<CsvFormat>();
                            CsvFormats = records.ToList();
                            dataGridView1.DataSource = CsvFormats;
                            FileName = ofd.FileName;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (FileName == null)
            {
                MessageBox.Show("Select CSV File First");
            }

            else
            {
                var query = "INSERT INTO temperature (ID,時間,第1段溫度顯示值,第2段溫度顯示值,第3段溫度顯示值,第4段溫度顯示值,第5段溫度顯示值,第6段溫度顯示值) VALUES (@ID,@時間,@第1段溫度顯示值,@第2段溫度顯示值,@第3段溫度顯示值,@第4段溫度顯示值,@第5段溫度顯示值,@第6段溫度顯示值)";

                using (var cn = new SQLiteConnection($"Data Source = {DbPath}"))
                {
                    cn.Open();
                    try
                    {
                        using (var trans = cn.BeginTransaction())
                        {
                            foreach (var item in CsvFormats)
                            {
                                var key = Guid.NewGuid().ToString();
                                if (item == null) continue;
                                var affectedRows = cn.Execute(query, new {ID=key,時間 = item.時間, 第1段溫度顯示值 = item.第1段溫度顯示值, 第2段溫度顯示值 = item.第2段溫度顯示值, 第3段溫度顯示值 = item.第3段溫度顯示值, 第4段溫度顯示值 = item.第4段溫度顯示值, 第5段溫度顯示值 = item.第5段溫度顯示值, 第6段溫度顯示值 = item.第6段溫度顯示值 });
                            }
                            trans.Commit();
                        }

                        MessageBox.Show("Insert Completed");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                dataGridView1.ClearSelection();
                TemperatureRecords?.Clear();
                CsvFormats?.Clear();
                using (var cn = new SQLiteConnection($"Data Source = {DbPath}"))
                {
                    var list = cn.Query<TemperatureRecord>(
                        "select * from temperature");
                    var csvFormat = cn.Query<CsvFormat>(
                        "select * from temperature");
                    TemperatureRecords = list.ToList();
                    CsvFormats = csvFormat.ToList();
                    dataGridView1.DataSource = TemperatureRecords;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.ReadOnly = true;
                }
            }   

            

        }

        private void database_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            TemperatureRecords?.Clear();
            using (var cn = new SQLiteConnection($"Data Source = {DbPath}"))
            {
                var list = cn.Query<TemperatureRecord>(
                    "select * from temperature");
                var csvFormat = cn.Query<CsvFormat>(
                    "select * from temperature");
                TemperatureRecords = list.ToList();
                CsvFormats = csvFormat.ToList();
                dataGridView1.DataSource = TemperatureRecords;
                dataGridView1.Columns["ID"].Visible = false;
                dataGridView1.ReadOnly = true;
                //dataGridView1.Enabled = false;
            }
        }

        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var index = TemperatureRecords[e.RowIndex].ID;
            var changeIndex = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            if (index.ToString() ==  changeIndex.ToString())
            {
                

                using (var cn = new SQLiteConnection($"Data Source = {DbPath}"))
                {
                    cn.Open();
                    try
                    {
                        var query = "UPDATE temperature SET 時間 = @時間,第1段溫度顯示值 = @第1段溫度顯示值,第2段溫度顯示值 = @第2段溫度顯示值,第3段溫度顯示值 = @第3段溫度顯示值,第4段溫度顯示值 = @第4段溫度顯示值,第5段溫度顯示值 = @第5段溫度顯示值,第6段溫度顯示值 = @第6段溫度顯示值 WHERE ID = @ID ";
                        var result = cn.Execute(query, new
                        {
                            ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value,
                            時間 = dataGridView1.Rows[e.RowIndex].Cells[1].Value,
                            第1段溫度顯示值 = dataGridView1.Rows[e.RowIndex].Cells[2].Value,
                            第2段溫度顯示值 = dataGridView1.Rows[e.RowIndex].Cells[3].Value,
                            第3段溫度顯示值 = dataGridView1.Rows[e.RowIndex].Cells[4].Value,
                            第4段溫度顯示值 = dataGridView1.Rows[e.RowIndex].Cells[5].Value,
                            第5段溫度顯示值 = dataGridView1.Rows[e.RowIndex].Cells[6].Value,
                            第6段溫度顯示值 = dataGridView1.Rows[e.RowIndex].Cells[7].Value
                        });
                        //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (DeleteRowSelect == null)
                MessageBox.Show("Please select the row first !");
            if (DeleteRowSelect != null)
            {
                using (var cn = new SQLiteConnection($"Data Source = {DbPath}"))
                {
                    cn.Open();
                    try
                    {
                        var query = $"DELETE FROM temperature WHERE ID = @ID";
                        var result = cn.Execute(query, new
                        {
                            ID = DeleteRowSelect
                        });
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                dataGridView1.ClearSelection();
                TemperatureRecords?.Clear();
                using (var cn = new SQLiteConnection($"Data Source = {DbPath}"))
                {
                    var list = cn.Query<TemperatureRecord>(
                        "select * from temperature");
                    var csvFormat = cn.Query<CsvFormat>(
                        "select * from temperature");
                    TemperatureRecords = list.ToList();
                    CsvFormats = csvFormat.ToList();
                    dataGridView1.DataSource = TemperatureRecords;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.ReadOnly = true;
                }
            }
            
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var indexID = TemperatureRecords[e.RowIndex].ID;
            DeleteRowSelect = indexID.ToString();
            MessageBox.Show(DeleteRowSelect);
        }

        private void download_Click(object sender, EventArgs e)
        {
            if (TemperatureRecords != null)
            {
                var sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        //var header = TemperatureRecords.First().GetType().GetProperties().Select(p => p.Name).Aggregate((p1,p2) => p1 + ";" + p2);
                        //var writer = header.Substring(3);
                        //foreach (var item in TemperatureRecords)
                        //{
                        //    writer += "\n";
                        //    writer += $"{item.時間};{item.第1段溫度顯示值};{item.第2段溫度顯示值};{item.第3段溫度顯示值};{item.第4段溫度顯示值};{item.第5段溫度顯示值};{item.第6段溫度顯示值}";
                        //}

                        using (var csvWriter = new CsvWriter(writer))
                        {
                            csvWriter.Configuration.Delimiter = ",";
                            csvWriter.Configuration.HasHeaderRecord = true;
                            csvWriter.Configuration.AutoMap<CsvFormat>();
                            
                            csvWriter.WriteHeader<CsvFormat>();
                            csvWriter.NextRecord();
                            foreach (var item in CsvFormats)
                            {
                                csvWriter.WriteRecord(item);
                                csvWriter.NextRecord();
                            }
                            
                            
                            writer.Flush();
                        }

                        MessageBox.Show("Download Complete");

                    }
                    
                }
                
            }
        }
        
        private void search_Click(object sender, EventArgs e)
        {
            if (TemperatureRecords == null)
            {
                MessageBox.Show("You have to open database first !");
            }

            if (comboBox1.SelectedIndex == 0)
            {
                
                var select = comboBox1.SelectedItem;
                var timeFrom = Convert.ToDateTime(txtFrom.Text.ToString());
                var timeTo = Convert.ToDateTime(txtTo.Text.ToString());
                    
                var selectList = TemperatureRecords.Where(x => x.時間 >= timeFrom && x.時間 <= timeTo ).ToList();
                dataGridView1.DataSource = selectList;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                var timeFrom = Convert.ToDouble(txtFrom.Text);
                var timeTo = Convert.ToDouble(txtTo.Text);
                    
                var selectList = TemperatureRecords.Where(x => x.第1段溫度顯示值 >= timeFrom && x.第1段溫度顯示值 <= timeTo ).ToList();
                dataGridView1.DataSource = selectList;
            } 
            if (comboBox1.SelectedIndex == 2)
            {
                var timeFrom = Convert.ToDouble(txtFrom.Text);
                var timeTo = Convert.ToDouble(txtTo.Text);
                    
                var selectList = TemperatureRecords.Where(x => x.第2段溫度顯示值 >= timeFrom && x.第2段溫度顯示值 <= timeTo ).ToList();
                dataGridView1.DataSource = selectList;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                var timeFrom = Convert.ToDouble(txtFrom.Text);
                var timeTo = Convert.ToDouble(txtTo.Text);
                    
                var selectList = TemperatureRecords.Where(x => x.第3段溫度顯示值 >= timeFrom && x.第3段溫度顯示值 <= timeTo ).ToList();
                dataGridView1.DataSource = selectList;
            } 
            if (comboBox1.SelectedIndex == 4)
            {
                var timeFrom = Convert.ToDouble(txtFrom.Text);
                var timeTo = Convert.ToDouble(txtTo.Text);
                    
                var selectList = TemperatureRecords.Where(x => x.第4段溫度顯示值 >= timeFrom && x.第4段溫度顯示值 <= timeTo ).ToList();
                dataGridView1.DataSource = selectList;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                var timeFrom = Convert.ToDouble(txtFrom.Text);
                var timeTo = Convert.ToDouble(txtTo.Text);
                    
                var selectList = TemperatureRecords.Where(x => x.第5段溫度顯示值 >= timeFrom && x.第5段溫度顯示值 <= timeTo ).ToList();
                dataGridView1.DataSource = selectList;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                var timeFrom = Convert.ToDouble(txtFrom.Text);
                var timeTo = Convert.ToDouble(txtTo.Text);
                    
                var selectList = TemperatureRecords.Where(x => x.第6段溫度顯示值 >= timeFrom && x.第6段溫度顯示值 <= timeTo ).ToList();
                dataGridView1.DataSource = selectList;
            }

           
           
        }
    }
}
