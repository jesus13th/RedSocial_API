using MongoDB.Bson;
using MongoDB.Driver;

using RedSocial_API.Models;

namespace RedSocial_API.Services {
    public class UserService {
        private IMongoCollection<User> _users;

        public UserService(IRedSocialSettings settings) {
            var client = new MongoClient(settings.Server);
            _users = client.GetDatabase("Red_Social").GetCollection<User>("Users");
        }
        public List<User> Get() {
            return _users.Find(d => true).ToList();
        }
        public User Create(User user) {
            _users.InsertOne(user);
            return user;
        }
        public void Update(string id, User user) {
            _users.ReplaceOne(user => user.Id == id, user);
        }
        public void Delete(string id) {
            _users.DeleteOne(user => user.Id == id);
        }
    }
}
