﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Configuration;

namespace Zero_Web.database
{
    public class MongoDBManager
    {
#if !DEBUG
        private static protected readonly string user = ConfigurationManager.AppSettings["MongoDB_User"];
        private static protected readonly string password = ConfigurationManager.AppSettings["MongoDB_Password"];
        private static protected readonly string host = ConfigurationManager.AppSettings["MongoDB_Host"];
        private static protected readonly string port = ConfigurationManager.AppSettings["MongoDB_Port"];
        private static protected readonly string database = ConfigurationManager.AppSettings["MongoDB_Database"];
        private static protected readonly string connectionString = "mongodb://" + user + ":" + password + "@" + host + ":" + port + "/" + database;
#else
        private static protected readonly string user = ConfigurationManager.AppSettings["MongoDB_User_Debug"];
        private static protected readonly string password = ConfigurationManager.AppSettings["MongoDB_Password_Debug"];
        private static protected readonly string host = ConfigurationManager.AppSettings["MongoDB_Host_Debug"];
        private static protected readonly string port = ConfigurationManager.AppSettings["MongoDB_Port_Debug"];
        private static protected readonly string database = ConfigurationManager.AppSettings["MongoDB_Database_Debug"];
        private static protected readonly string connectionString = "mongodb://" + user + ":" + password + "@" + host + ":" + port + "/" + database;
#endif
        private static MongoClient client;
        private static IMongoDatabase db;

        /// <summary>
        /// Create a Connection to MongoDB
        /// </summary>
        public void createConnection()
        {

            try
            {
                client = new MongoClient(connectionString);
                db = client.GetDatabase(database);
                System.Diagnostics.Debug.WriteLine("MongoDB Connection created successfull!");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("MongoDB Connection created Error!");
            }

        }

        /// <summary>
        /// Create a new MongoDB Table Value
        /// </summary>
        /// <param name="searchWord"></param>
        /// <param name="result"></param>
        public void createEntry(string table, string searchWord, string result)
        {

            try
            {
                var things = db.GetCollection<BsonDocument>(table);

                BsonDocument bDocument = new BsonDocument(searchWord, result);
                things.InsertOne(bDocument);

                System.Diagnostics.Debug.WriteLine("MongoDB Entry created successfull!");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("MongoDB Entry created Error!");
            }

        }

        public void createEntry(string table, BsonDocument json)
        {
            var things = db.GetCollection<BsonDocument>(table);
            things.InsertOneAsync(json);
        }

        public void updateEntry()
        {

        }

        public void deleteEntry()
        {

        }

    }
}