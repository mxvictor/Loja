using System;
using System.Collections.Generic;
using Npgsql;
namespace LojaTeste.Modelos
{
    public class Banco : IDisposable
    {
        private static string connectionString;

        public string sql { get; set; }

        public NpgsqlDataReader dataReader { get; set; }

        public Dictionary<object,object> parametros { get; set; }

        private static NpgsqlConnection conn { get; set; }

        public Banco()
        {
            connectionString = "Server=localhost;Port=5432;User id=postgres;password=12345;database=postgres";
            conn = null;
            AbrirConexao();
            parametros = new Dictionary<object, object>();
            sql = null;
        }

        public static void AbrirConexao()
        {
            if (conn == null)
            {
                conn = new NpgsqlConnection(connectionString);
                conn.Open();
            }
        }

        public NpgsqlDataReader ExecutarReader()
        {
            if (sql == null) throw new ArgumentNullException();
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                foreach(var i in parametros)
                {
                    cmd.Parameters.AddWithValue(i.Key.ToString(), i.Value);
                }
                parametros.Clear();
                if (dataReader != null) dataReader.Close();
                dataReader = cmd.ExecuteReader();
                sql = null;
                return dataReader;
            }

        }

        public void addParametros(object s, object p)
        {
            parametros.Add(s, p);
        }

        public void Dispose()
        {
            if(conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
