using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Configuration;
using Zero_Web.Models.Accounts;

namespace Zero_Web.database
{
    public class MongoDBManager
    {
#if DEBUG
        private static protected readonly string user = ConfigurationManager.AppSettings["MongoDB_User_Debug"];
        private static protected readonly string password = ConfigurationManager.AppSettings["MongoDB_Password_Debug"];
        private static protected readonly string host = ConfigurationManager.AppSettings["MongoDB_Host_Debug"];
        private static protected readonly string port = ConfigurationManager.AppSettings["MongoDB_Port_Debug"];
        private static protected readonly string database = ConfigurationManager.AppSettings["MongoDB_Database_Debug"];
#else
 private static protected readonly string user = ConfigurationManager.AppSettings["MongoDB_User"];
        private static protected readonly string password = ConfigurationManager.AppSettings["MongoDB_Password"];
        private static protected readonly string host = ConfigurationManager.AppSettings["MongoDB_Host"];
        private static protected readonly string port = ConfigurationManager.AppSettings["MongoDB_Port"];
        private static protected readonly string database = ConfigurationManager.AppSettings["MongoDB_Database"];
#endif

        public static MongoDBManager Instance { get; set; }
        public UserModel UserModel { get; set; }
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private static protected readonly string connectionString = "mongodb://" + user + ":" + password + "@" + host + ":" + port + "/" + database;

        public MongoDBManager()
        {
            Instance = this;
            client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
            UserModel = new UserModel();
        }

        /// <summary>
        /// Create a new MongoDB Table Value
        /// </summary>
        /// <param name="searchWord"></param>
        /// <param name="result"></param>
        public bool CreateEntry(string table, string searchWord, string result)
        {
            try
            {
                var things = db.GetCollection<BsonDocument>(table);

                BsonDocument bDocument = new BsonDocument(searchWord, result);
                things.InsertOne(bDocument);

                System.Diagnostics.Debug.WriteLine("MongoDB Entry created successfull!");
                return true;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("MongoDB Entry created Error!");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="bsonDocument"></param>
        /// <returns></returns>
        public bool CreateEntry(string collection, BsonDocument bsonDocument)
        {
            try
            {
                db.GetCollection<BsonDocument>(collection).InsertOne(bsonDocument);
                System.Diagnostics.Debug.WriteLine("MongoDB Entry created successfull!");
                return true;
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("MongoDB Entry created Error!");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="identifier"></param>
        /// <param name="bsonDocument"></param>
        public void UpdateEntry(string collection, string identifier, BsonDocument bsonDocument)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteEntry()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMongoDatabase GetDatabase()
        {
            return db;
        }

    }
}