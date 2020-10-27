using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDtoFIle.Models
{
    public class UserRepository : IUserRepo
    {
        public List<User> Users { get; set; }

        public UserRepository()
        {
            Users = new List<User>();
            User user = new User();
            user.Id = 1; user.Email = "an@gmail.com"; user.Name = "Ann"; user.Age = 37;
            Users.Add(user);
        }

        public UserRepository(List<User> users)
        {
            this.Users = users;
        }

        public void add(User user)
        {
            Users.Add(user);
        }

        public void update(string email, User user)
        {
            int index = -1;
            foreach (User u in Users)
            {
                if (u.Email.Equals(email))
                {
                    index = Users.IndexOf(u);
                    break;
                }
            }
            if (index != -1)
            {
                Users[index] = user;
            }
        }

        public User get(string email)
        {
            foreach (User u in Users)
            {
                if (u.Email.Equals(email))
                {
                    return u;
                }
            }
            return null;
        }

        public List<User> getAll()
        {
            return Users;
        }
        public void delete(string email)
        {
            User found = null;
            foreach (User u in Users)
            {
                if (u.Email.Equals(email))
                {
                    found = u;
                }
            }
            if (found != null)
            {
                Users.Remove(found);
            }
        }

    }
}
