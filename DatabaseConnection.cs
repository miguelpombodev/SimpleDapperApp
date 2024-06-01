using Dapper;
using MySql.Data.MySqlClient;
using SimpleDapperApp.Models;

namespace SimpleDapperApp
{
    public class DatabaseConnection<T> where T : class
    {
        public DatabaseConnection(string sqlFilesPath)
        {
          ConnectionString = "Server=localhost; Database=DapperDB; Uid=root; Pwd=12345;";
          DapperMySqlConnection = new MySqlConnection(ConnectionString);
          SqlFilesRootPath = $"{Environment.CurrentDirectory}/Queries";
          SqlFilesPath = string.IsNullOrEmpty(sqlFilesPath) ? FilePathNotCalledException() : $"{SqlFilesRootPath}/{sqlFilesPath}";
        }

        private string FilePathNotCalledException()
        {
          throw new ArgumentNullException("File path must be inserted");
        }

        private string SqlFilesRootPath { get; set;}
        private string SqlFilesPath { get; set;}
        private string ConnectionString { get; set; }
        private MySqlConnection DapperMySqlConnection  { get; set; }

        private string GetSqlFileContent(string PathToSqlFile) {
            string fileContent;
            using (StreamReader stream = new StreamReader($"{SqlFilesPath}/{PathToSqlFile}.sql")) {
              fileContent = stream.ReadToEnd();
            };
            
            return fileContent;
        }

        public IEnumerable<T> SelectRowsFromDatabase(string SqlFile) {
          var items = this.DapperMySqlConnection.Query<T>(GetSqlFileContent(SqlFile));
          
          return items;
        }

        public int ExecuteParameterizedInDatabase(string SqlFile, object SqlParameters)
        {
          int affectedRows = this.DapperMySqlConnection.Execute(GetSqlFileContent(SqlFile), SqlParameters);

          return affectedRows;
        }
    }
}