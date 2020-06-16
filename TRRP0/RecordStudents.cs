using System;
using System.Data;
using Npgsql;

namespace TRRP0
{
    internal class RecordStudents
    {
        
        string fio, zachet_book, group, faculty, speciality,cafedra,tel,adress_fac;

        public RecordStudents(IDataRecord sqlReader)
        {
            fio = sqlReader[0].ToString();
            zachet_book = sqlReader[1].ToString();
            group = sqlReader[2].ToString();
            faculty = sqlReader[3].ToString();
            speciality = sqlReader[4].ToString();
            cafedra = sqlReader[5].ToString();
            tel = sqlReader[6].ToString();
            adress_fac = sqlReader[7].ToString();
        }

        public void WriteToNormalizedDb()
        {
            //устанавливаем соединение с БД
            using var conn = new NpgsqlConnection(DbConst.ConnString);
            
            // открываем соединение
            conn.Open();

          
            using var transaction = conn.BeginTransaction();
            
            //добавление данных табличек
            //Факультет
            try
            {
                var sqlCommand = new NpgsqlCommand("INSERT INTO faculties VALUES (@name, @adress_fac) ON CONFLICT DO NOTHING", conn);
                sqlCommand.Parameters.AddWithValue("@name", faculty);
                sqlCommand.Parameters.AddWithValue("@adress_fac", adress_fac);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            

            // Кафедра
            try
            {
                var sqlCommand = new NpgsqlCommand("INSERT INTO cafedries VALUES(@id, @tel, @faculty) ON CONFLICT DO NOTHING", conn);
                sqlCommand.Parameters.AddWithValue("@id", cafedra);
                sqlCommand.Parameters.AddWithValue("@tel", tel);
                sqlCommand.Parameters.AddWithValue("@faculty", faculty);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            

            //Специальность
            try
            {
                var sqlCommand = new NpgsqlCommand("INSERT INTO specialities VALUES (@name, @cafedra) ON CONFLICT DO NOTHING", conn);
                sqlCommand.Parameters.AddWithValue("@name", speciality);
                sqlCommand.Parameters.AddWithValue("@cafedra", cafedra);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            
            //Группа
            try
            {
                var sqlCommand = new NpgsqlCommand("INSERT INTO groups VALUES (@id, @speciality) ON CONFLICT DO NOTHING", conn);
                sqlCommand.Parameters.AddWithValue("@id", group);
                sqlCommand.Parameters.AddWithValue("@speciality", speciality);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            

            //ФИО
            try
            {
                var sqlCommand = new NpgsqlCommand("INSERT INTO students VALUES (@fio, @zachet_book, @group) ON CONFLICT DO NOTHING", conn);
                sqlCommand.Parameters.AddWithValue("@fio", fio);
                sqlCommand.Parameters.AddWithValue("@zachet_book", zachet_book);
                sqlCommand.Parameters.AddWithValue("@group", group);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            
            // подтверждение транзакции
            transaction.Commit();
        }
    }
}