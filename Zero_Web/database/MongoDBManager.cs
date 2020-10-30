using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Zero_Web.Controllers;
using Zero_Web.Models.Accounts;
using Zero_Web.Models.Store;

namespace Zero_Web.database
{
    public class MongoDBManager
    {

        private static protected readonly string user = ConfigurationManager.AppSettings["MongoDB_User"];
        private static protected readonly string password = ConfigurationManager.AppSettings["MongoDB_Password"];
        private static protected readonly string host = ConfigurationManager.AppSettings["MongoDB_Host"];
        private static protected readonly string port = ConfigurationManager.AppSettings["MongoDB_Port"];
        private static protected readonly string database = ConfigurationManager.AppSettings["MongoDB_Database"];

        public static MongoDBManager Instance { get; set; }
        public UserModel UserModel { get; set; }
        private readonly MongoClient client;
        private readonly IMongoDatabase db;
        private protected readonly string connectionString = "mongodb://" + user + ":" + password + "@" + host + ":" + port + "/" + database;

        public MongoDBManager()
        {
            Instance = this;
            client = new MongoClient(connectionString);
            db = client.GetDatabase(database);
            UserModel = new UserModel();
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

        public IMongoCollection<StoreItem> GetStoreItemCollection()
        {
            return db.GetCollection<StoreItem>("StoreItemTEMP");
        }

        public IMongoCollection<StoreItemPrice> GetStoreItemPriceCollection()
        {
            return db.GetCollection<StoreItemPrice>("StoreItemPriceTEMP");
        }

        public List<StoreItem> GetAllStoreItems()
        {
            return GetStoreItemCollection().Find(Builders<StoreItem>.Filter.Empty).ToList();
        }

        public ArrayList GetFreeStoreItems()
        {
            var tempList = new ArrayList();
            var listOfDocuments = GetStoreItemPriceCollection().Find(item => item.price[0].Free).ToList();
            listOfDocuments.ForEach(document =>
            {
                tempList.Add(GetStoreItemCollection().Find(item => item.ID == document.ID).ToList().First());
            });
            return tempList;
        }

        public ArrayList GetSaleStoreItems()
        {
            var tempList = new ArrayList();
            var listOfDocuments = GetStoreItemPriceCollection().Find(item => item.price[0].GamePrice == "").ToList();
            listOfDocuments.ForEach(document =>
            {
                tempList.Add(GetStoreItemCollection().Find(item => item.ID == document.ID).ToList().First());
            });
            return tempList;
        }

        public StoreItem GetRandomStoreItem()
        {
            var listOfDocuments = StoreController.GetContent();
            if (listOfDocuments.Count == 0)
                return new StoreItem();
            return listOfDocuments[new Random().Next(0, listOfDocuments.Count - 1)] as StoreItem;
        }

        public StoreItemPrice GetStoreItemPrice(StoreItem storeItem)
        {
            if (storeItem.ID == null)
                return new StoreItemPrice();
            return GetStoreItemPriceCollection().Find(item => item.ID == storeItem.ID).First();
        }

        public IMongoCollection<StoreItemLanguage> GetStoreItemLanguageCollection()
        {
            return db.GetCollection<StoreItemLanguage>("StoreItemLanguageTEMP");
        }

        public StoreItemLanguage GetStoreItemLanguage(StoreItem storeItem)
        {
            return GetStoreItemLanguageCollection().Find(item => item.ID == storeItem.ID).First();
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