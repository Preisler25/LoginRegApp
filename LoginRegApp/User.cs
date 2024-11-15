using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegApp
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }

        //user from reg form
        public User(string username, string password, string password2, string email, string realName)
        {
            Username = username;
            Password = password;
            Email = email;
            RealName = realName;
        }

        //user from txt
        public User(string username, string password, string email, string realName)
        {
            Username = username;
            Password = password;
            Email = email;
            RealName = realName;
        }

        //user from login form
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //user from fromString
        public static User FromString(string fromString)
        {
            var parts = fromString.Split(',');
            if (parts.Length != 4) {
                throw new FormatException("Invalid string format");
            }
            return new User(parts[0], parts[1], parts[2], parts[3]);
        }

        public static List<User> FromFile(string path)
        {
            var users = new List<User>();
            if (File.Exists(path)){
                var lines = System.IO.File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    users.Add(FromString(line));
                }
            }
            return users;
        }

        public void SaveToFile(string path)
        {
            System.IO.File.AppendAllText(path, $"{this.ToString()}\n");
        }


        public override string ToString()
        {
            return $"{Username},{Password},{Email},{RealName}";
        }
    }
}
