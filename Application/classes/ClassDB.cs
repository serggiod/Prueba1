using System;
using System.Data;
using MySql.Data.MySqlClient;
using Application.@struct;

namespace Application.classes
{
    public class ClassDB
    {
        private MySqlConnection Connection;

        public ClassDB()
        {
            string s = "Server=127.0.0.1; database=test; UID=test; password=test;";
            this.Connection = new MySqlConnection(s);
        }

        public bool Open()
        {
            bool r = false;
            try
            {
                this.Connection.Open();
                r = true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        Console.WriteLine("ERROR: No se puede conectar al servidor.");
                        break;

                    case 1045:
                        Console.WriteLine("ERROR: Error en el usuario o el password.");
                        break;
                }
                r = false;
            }

            return r;

        }

        public bool Close()
        {
            try
            {
                this.Connection.Close();
                return true;
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public string ToMD5(string s)
        {
            string r = string.Empty;

            if (this.Open())
            {
                string sql = string.Empty;
                sql += "SELECT ";
                sql += " MD5('" + s + "') AS md5";

                MySqlCommand cmd = new MySqlCommand(sql, this.Connection);
                cmd.CommandText = sql;
                cmd.Connection = this.Connection;

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) r = reader["md5"].ToString();
                reader.Dispose();

                this.Close();
            }

            return r;
        }

        public DataResponse Insert(string sql)
        {
            DataResponse response = new DataResponse();
            response.result = false;
            response.rows = new DataTable();

            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = this.Connection;

                int AffectedRows = cmd.ExecuteNonQuery();

                if (AffectedRows >= 1)
                {
                    DataColumn col1 = new DataColumn();
                    col1.DataType = typeof(string);
                    col1.ColumnName = "AffectedRows";
                    response.rows.Columns.Add(col1);

                    DataColumn col2 = new DataColumn();
                    col2.DataType = typeof(string);
                    col2.ColumnName = "LastInsertID";
                    response.rows.Columns.Add(col2);

                    DataRow row = response.rows.NewRow();
                    row["AffectedRows"] = AffectedRows.ToString();
                    row["LastInsertID"] = cmd.LastInsertedId.ToString();

                    response.result = true;
                    response.rows.Rows.Add(row);
                }
                this.Close();
            }
            return response;
        }

        public DataResponse Update(string sql)
        {
            DataResponse response = new DataResponse();
            response.result = false;
            response.rows = new DataTable();

            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = this.Connection;

                int AffectedRows = cmd.ExecuteNonQuery();

                if (AffectedRows >= 1)
                {
                    DataColumn col1 = new DataColumn();
                    col1.DataType = typeof(string);
                    col1.ColumnName = "AffectedRows";
                    response.rows.Columns.Add(col1);

                    DataRow row = response.rows.NewRow();
                    row["AffectedRows"] = AffectedRows.ToString();

                    response.result = true;
                    response.rows.Rows.Add(row);
                }
                this.Close();
            }
            return response;
        }

        public DataResponse Delete(string sql)
        {
            DataResponse response = new DataResponse();
            response.result = false;
            response.rows = new DataTable();

            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = this.Connection;

                int AffectedRows = cmd.ExecuteNonQuery();

                if (AffectedRows >= 1)
                {
                    DataColumn col1 = new DataColumn();
                    col1.DataType = typeof(string);
                    col1.ColumnName = "AffectedRows";
                    response.rows.Columns.Add(col1);

                    DataRow row = response.rows.NewRow();
                    row["AffectedRows"] = AffectedRows.ToString();

                    response.result = true;
                    response.rows.Rows.Add(row);
                }
                this.Close();
            }
            return response;
        }

        public DataResponse Select(string sql)
        {
            DataResponse response = new DataResponse();
            response.result = false;
            response.rows = new DataTable();

            if (this.Open() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = this.Connection;

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == true)
                {
                    string[] Fields = new string[reader.FieldCount];

                    for (int i = 0; i < reader.FieldCount; i++) Fields[i] = reader.GetName(i);

                    for (int i = 0; i < Fields.Length; i++)
                    {
                        DataColumn column = new DataColumn();
                        column.DataType = typeof(string);
                        column.ColumnName = Fields[i];
                        response.rows.Columns.Add(column);
                    }

                    while (reader.Read())
                    {
                        DataRow row = response.rows.NewRow();
                        for (int i = 0; i < Fields.Length; i++) row[Fields[i]] = reader.GetString(i);
                        response.rows.Rows.Add(row);
                    }

                    reader.Dispose();
                    response.result = true;
                }
                this.Close();
            }
            return response;
        }
    }
}
