using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C.Project.Generic
{
    public class UserRepository
    {
        public List<User> Entities { get; set; } = new List<User>();


        public User GetUserById(int id)
        {

            var u = Entities.Find(a => a.Id == id);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            return u;
        }
        public void UpdateUser(User user)
        {
            var existingUser = Entities.Find(a => a.Id == user.Id);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }
            existingUser.Name = user.Name;

        }

        public List<User> GetAllUsers()
        {
            return Entities;
        }


        public void AddUser(User user)
        {
            Entities.Add(user);
        }

        public void Remove(User user)
        {
            Entities.Remove(user);
        }

    }
}
