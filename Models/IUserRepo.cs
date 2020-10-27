using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDtoFIle.Models
{
    public interface IUserRepo
    { 
        public void add(User user);
        public void update(string email, User user);
        public User get(string email);
        public List<User> getAll();
        public void delete(string email);
    }
}