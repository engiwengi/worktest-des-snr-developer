using System;
using System.Collections.Generic;
using System.Linq;
using des_library_api.Domain;

namespace des_library_api.Infra.Repository
{
    public class UserRepository
    {
        private readonly IDictionary<Guid, User> _users;

        public UserRepository(List<User> users)
        {
            _users = users.ToDictionary(user => user.Id);
        }

        public User Get(Guid id)
        {
            _users.TryGetValue(id, out var value);
            return value;
        }

        public User Create()
        {
            var guid = Guid.NewGuid();
            var user = new User() { Id = guid };
            _users.Add(user.Id, user);
            return user;
        }
    }
}
