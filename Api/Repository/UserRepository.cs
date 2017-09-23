using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repository
{
    public class UserRepository: IUserRepository
    {
        static List<User> UserList = new List<User>();

        public void Add(User item)
        {
            UserList.Add(item);
        }

        public User Find(string key)
        {
            return UserList
                .Where(e => e.UserName.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return UserList;
        }

        public void Remove(string Id)
        {
            var itemToRemove = UserList.SingleOrDefault(u => u.UserName == Id);
            if (itemToRemove != null)
            {
                UserList.Remove(itemToRemove);
            }
        }

        public void Update(User item)
        {
            var itemToUpdate = UserList.SingleOrDefault(u => u.UserName == item.UserName);

            if (itemToUpdate != null)
            {
                itemToUpdate.UserName = itemToUpdate.UserName;
                itemToUpdate.Password = itemToUpdate.Password;
            }
        }
    }
}
