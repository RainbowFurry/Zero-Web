using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Zero_Web.database;

namespace Zero_Web.Models.Accounts
{
    public class UserModel
    {

        public List<User> listAccounts = new List<User>();

        public UserModel()
        {
            listAccounts = MongoDBManager.Instance.GetDatabase().GetCollection<User>("User").Find<User>(new BsonDocument()).ToList();
        }

        public void UpdateAccountList()
        {
            listAccounts = MongoDBManager.Instance.GetDatabase().GetCollection<User>("User").Find<User>(new BsonDocument()).ToList();
        }

        public User Find(string username)
        {
            return listAccounts.Where(acc => acc.NickName.Equals(username)).FirstOrDefault();
        }

        public User Login(string identifier, string password)
        {
            UpdateAccountList();
            User user = listAccounts.Where(acc => acc.NickName.Equals(identifier) && acc.Password.Equals(password)).FirstOrDefault();
            if (user == null)
                user = listAccounts.Where(acc => acc.Email.Equals(identifier) && acc.Password.Equals(password)).FirstOrDefault();
            return user;
        }
    }
}