using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Repository
{
    public interface IUserRepository
    {
        void Add(User item);
        IEnumerable<User> GetAll();
        User Find(string key);
        void Remove(string Id);
        void Update(User item);
    }
}
