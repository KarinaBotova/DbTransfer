using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TRRP0
{
    public partial class Form1 : Form
    {
        private List<RecordStudents> _records;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void changeFileButton_Click(object sender, EventArgs e)
        {
            openFileDb.Filter = @"SQLite DB files (*.sqlite)|*.sqlite";
            openFileDb.Multiselect = false;
            openFileDb.ShowDialog();
            pathFileText.Text = openFileDb.FileName;
        }

        private void StartNormalize_Click(object sender, EventArgs e)
        {
            Normalize();
            
        }

        private void Normalize()
        {
            //создаем соединение с БД
            using var connect = new SQLiteConnection($@"Data Source={pathFileText.Text};");
            try
            {
                //открываем ее
                connect.Open();

                //создаем список, даем команду получить все записи из таблицы
                _records = new List<RecordStudents>();
                var getRecords = new SQLiteCommand
                {
                    Connection = connect,
                    CommandText = @"SELECT * FROM students"
                };
                var sqlReader = getRecords.ExecuteReader();
                while (sqlReader.Read())//считываем все строки из sqlite
                {
                    _records.Add(new RecordStudents(sqlReader));
                }

                _records.ForEach(record => record.WriteToNormalizedDb());
                MessageBox.Show(@"Данные успешно добавлены!", @"Успех!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, @"Ошибка");
            }
            finally
            {
                connect.Close();
            }
        }

        
    }
}
