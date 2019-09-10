using System;
using System.IO;
namespace WebLocalBlock.Entities.Class
{
    public static class Init
    {
        private static DBManager _dbManager = new DBManager();

        public static void Initializing()
        {
            CheckFiles();
            CheckDataBase();
        }
        private static void CheckFiles()
        {
            try
            {
                if (!Directory.Exists(Properties.Resources.RootPathFolder))
                {
                    CreateFolder();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inicializar arquivos. Detais: {ex.Message}");
            }
        }
        private static void CheckDataBase()
        {
            try
            {
                if (!File.Exists(Properties.Resources.RootPathFolder+"\\"+ Properties.Resources.DBFile))
                {
                    _dbManager.CreateDataBase();
                    _dbManager.CreateTable();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar banco de dados! Detalhes: {ex.Message}");
            }
        }
        private static void CreateFolder()
        {
            Directory.CreateDirectory(Properties.Resources.RootPathFolder);
        }
    }
}
