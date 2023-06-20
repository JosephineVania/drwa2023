using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UasDrwaApi{
    public class User
    {
        public string UserName { get; set; }
    
        public string Password { get; set; } = null!;

        public User(string userName, string password){
            UserName = userName;
            Password = password;
        }
    }
}