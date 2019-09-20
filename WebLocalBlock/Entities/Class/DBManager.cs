using System;
using System.Data.SQLite;
using System.Data;

namespace WebLocalBlock.Entities.Class
{
    public class DBManager
    {
        private SQLiteCommand _cmd;
        private string QueryCreateTable { get; } = @"CREATE Table Data (ID INTEGER PRIMARY KEY AUTOINCREMENT, URL NVARCHAR(50), Locked BIT)";
        private string QueryReadTable { get; } = @"SELECT * FROM Data";
        private string QueryInsertTable { get; } = @"INSERT INTO Data (URL, Locked) VALUES (@url, @locked)";
        private string QueryUpdateTable { get; } = @"UPDATE Data SET URL = @url, Locked = @locked WHERE ID = @id";
        private string QueryDeleteTable { get; } = @"DELETE FROM Data WHERE ID = @id";

        public DBManager()
        {
            _cmd = new SQLiteCommand();
        }

        private string Connection {
            get { return @"Data Source=" + Properties.Resources.RootPathFolder + "\\" + Properties.Resources.DBFile + "; Version=3;"; }
        }
        public void CreateDataBase()
        {
            try
            {
                SQLiteConnection.CreateFile(Properties.Resources.RootPathFolder+"\\"+Properties.Resources.DBFile);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar arquivo de banco de dados. Detalhes: {ex.Message}");
            }
        }
        public void CreateTable()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Connection))
                {
                    conn.Open();
                    _cmd.CommandText = QueryCreateTable;
                    _cmd.Connection = conn;
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar tabelas. Detalhes: {ex.Message}");
            }
        }
        //public DataGridView ReadDataOld(DataGridView gridView)
        //{
        //    try
        //    {
        //        using (SQLiteConnection conn = new SQLiteConnection(Connection))
        //        {
        //            conn.Open();
        //            _cmd.Connection = conn;
        //            _cmd.CommandText = QueryReadTable;
        //            SQLiteDataReader reader = _cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                gridView.Rows.Add(new object[]
        //                {
        //                    reader.GetValue(reader.GetOrdinal("ID")),
        //                    reader.GetValue(reader.GetOrdinal("URL")),
        //                    reader.GetValue(reader.GetOrdinal("Locked"))
        //                });
        //            }
        //            return gridView;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Erro na leitura do banco de dados! Detalhes: {ex.Message}");
        //    }
        //}
        //public DataTable ReadData() {
        //    DataTable dadosTabela = new DataTable();
        //    try {
        //        using (SQLiteConnection conn = new SQLiteConnection(Connection)) {
        //            conn.Open();
        //            _cmd.Connection = conn;
        //            _cmd.CommandText = QueryReadTable;
        //            dadosTabela.Load(_cmd.ExecuteReader());
        //            return dadosTabela;
        //        }
        //    } catch (Exception ex) {
        //        throw new Exception($"Erro na leitura do banco de dados! Detalhes: {ex.Message}");
        //    }
        //}
        public void InsertData(string url, bool locked)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Connection))
                {
                    conn.Open();
                    _cmd.Connection = conn;
                    _cmd.CommandText = QueryInsertTable;
                    _cmd.Parameters.Add(new SQLiteParameter("@url", url));
                    _cmd.Parameters.Add(new SQLiteParameter("@locked", locked));
                    _cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir dados! Datalhes: {ex.Message}");
            }
        }
        public void UpdateData(int id, string url, bool locked) {
            try {
                using (SQLiteConnection conn = new SQLiteConnection(Connection)) {
                    conn.Open();
                    _cmd.Connection = conn;
                    _cmd.CommandText = QueryUpdateTable;
                    _cmd.Parameters.Add(new SQLiteParameter("@url",url));
                    _cmd.Parameters.Add(new SQLiteParameter("@locked",locked));
                    _cmd.Parameters.Add(new SQLiteParameter("@id", id));
                    _cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                throw new Exception($"Erro ao atualizar dados! Detalhes: {ex.Message}");
            }
        }
        public void DeleteData(int id) {
            try {
                using (SQLiteConnection conn = new SQLiteConnection(Connection)) {
                    conn.Open();
                    _cmd.Connection = conn;
                    _cmd.CommandText = QueryDeleteTable;
                    _cmd.Parameters.Add(new SQLiteParameter("@id",id));
                    _cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                throw new Exception($"Erro ao deletar dados! Detalhes: {ex.Message}");
            }
        }
        public DataTable SearchData(string url = null)
        {
            DataTable dadosTabela = new DataTable();
            string QuerySearchTable = @"SELECT * FROM Data WHERE (URL LIKE '%"+url+"%')";
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Connection))
                {
                    conn.Open();
                    _cmd.Connection = conn;
                    _cmd.CommandText = QuerySearchTable;
                    dadosTabela.Load(_cmd.ExecuteReader());
                    return dadosTabela;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na leitura do banco de dados! Detalhes: {ex.Message}");
            }
        }
    }
}
