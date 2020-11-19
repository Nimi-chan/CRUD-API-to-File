using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAPI_Main.Models
{
    public interface IUserRepo
    { 
        public void add(User user);
        public void update(User user);
        public Task<User> get(string email);
        public Task<List<User>> getAll();
        public void delete(string email);
    }
}