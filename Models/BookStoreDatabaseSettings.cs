using System.Configuration;

namespace LESSION_WEB_API_DEMO.Models
{
    public class BookStoreDatabaseSettings
    {
        public string BookCollectionName { get; }
        public string ConnectionString { get; }
        public string DataBaseName { get; }

        public BookStoreDatabaseSettings()
        {
            DataBaseName =ConfigurationManager.AppSettings["MongoDbName"];
            ConnectionString = ConfigurationManager.AppSettings["MongoDbConnectionString"];
            BookCollectionName = ConfigurationManager.AppSettings["BookCollectionName"];
        }
    }
}