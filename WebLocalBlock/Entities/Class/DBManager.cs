using System;
using System.Data.SQLite;

namespace WebLocalBlock.Entities.Class
{
    public class DBManager
    {
        private SQLiteCommand _cmd;
        private string QueryCreateTable { get; } = @"CREATE Table Data (ID INTEGER PRIMARY KEY AUTOINCREMENT, URL NVARCHAR(50), Locked BIT)";

        public DBManager()
        {
            _cmd = new SQLiteCommand();
        }

        private string Connection {
            get { return @"Data Source=" + Properties.Resources.DBFile + "; Version=3;"; }
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
                    _cmd = new SQLiteCommand();
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
    }
}
