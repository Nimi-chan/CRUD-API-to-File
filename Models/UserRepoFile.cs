using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUDAPI_Main.Models
{
    public class UserRepoFile : IUserRepo
    {
        private string fileName;

        public UserRepoFile(string fileName)
        {
            this.fileName = fileName;
        }

        public UserRepoFile() : this("default.json") { }

        public async void add(User user)
        {
            List<User> users = await load();
            users.Add(user);
            save(users);
        }

        public async void update(User user)
        {
            List<User> users = await load();
            int index = -1;
            foreach (User u in users)
            {
                if (u.Email.Equals(user.Email))
                {
                    index = users.IndexOf(u);
                    break;
                }
            }
            if (index != -1)
            {
                users[index] = user;
            }
            else
            {
                users.Add(user);
            }
            save(users);
        }

        public async Task<User> get(string email)
        {
            List<User> users = await load();
            foreach (User u in users)
            {
                if (u.Email.Equals(email))
                {
                    return u;
                }
            }
            return null;
        }

        public async Task<List<User>> getAll()
        {
            return await load();
        }

        public async void delete(string email)
        {
            List<User> users = await load();
            User found = null;
            foreach (User u in users)
            {
                if (u.Email.Equals(email))
                {
                    found = u;
                }
            }
            if (found != null)
            {
                users.Remove(found);
            }
            save(users);
        }

        private async Task<List<User>> load()
        {
            List<User> users;
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    users = await JsonSerializer.DeserializeAsync<List<User>>(fs);
                }
                else
                {
                    users = new List<User>();
                }
            }
            return users;
        }

        private async void save(List<User> users)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create)) // is there a way to not delete the file and still fully overwrite it?
            {
                await JsonSerializer.SerializeAsync<List<User>>(fs, users);
            }
        }
    }
    
}
