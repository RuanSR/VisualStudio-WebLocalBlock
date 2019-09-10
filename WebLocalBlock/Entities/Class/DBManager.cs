using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WebLocalBlock.Entities.Class
{
    public class DBManager
    {
        private SQLiteCommand _cmd;
        private string QueryCreateTable { get; } = @"CREATE Table Data (ID INTEGER PRIMARY KEY AUTOINCREMENT, URL NVARCHAR(50), Locked BIT)";
        private string QueryReadTable { get; } = @"SELECT * FROM Data";
        private string QueryInsertTable { get; }
        private string QueryUpdateTable { get; }
        private string QueryDeleteTable { get; }

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
        public DataGridView ReadTable(DataGridView gridView)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Connection))
                {
                    conn.Open();
                    _cmd.CommandText = QueryReadTable;
                    _cmd.Connection = conn;
                    SQLiteDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        gridView.Rows.Add(new object[]
                        {
                            reader.GetValue(reader.GetOrdinal("ID")),
                            reader.GetValue(reader.GetOrdinal("URL")),
                            reader.GetValue(reader.GetOrdinal("Locked"))
                        });
                    }
                }
                return gridView;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na leitura do banco de dados! Detalhes: {ex.Message}");
            }
        }
    }
}
