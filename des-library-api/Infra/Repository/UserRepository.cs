using System;
using System.Collections.Generic;
using System.Linq;
using des_library_api.Domain;

namespace des_library_api.Infra.Repository
{
    public class UserRepository
    {
        public static Guid ExampleUser = Guid.NewGuid();
        private readonly IDictionary<Guid, User> _users;

        public UserRepository()
        {
            _users = Enumerable.Repeat(new User() { Id = ExampleUser }, 1).ToDictionary(user => user.Id);
        }

        public User Get(Guid id)
        {
            _users.TryGetValue(id, out var value);
            return value;
        }

        public IEnumerable<Guid> GetAll()
        {
            return _users.Keys;
        }

        public User Create()
        {
            var guid = Guid.NewGuid();
            Console.WriteLine($"new user: {guid}");
            var user = new User() { Id = guid };

            _users.Add(user.Id, user);
            return user;
        }
    }
}
