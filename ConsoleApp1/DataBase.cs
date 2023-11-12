using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DataBase
    {
        private static string path = "C:\\Users\\moham\\Desktop\\Json_task.json";

        public static bool CheckFile() 
        {
            bool fileExists = File.Exists(path);

            if (!fileExists)
            { 
                File.AppendAllText(path, null);
                SetupFile();
            }
           
            return (fileExists);
        }

        public static void AddUser(User User)
        {
            List<User> myUsers = ReadFile();
            User.Id = myUsers.Count +1;
            myUsers.Add(User);
            string allUsers = JsonConvert.SerializeObject(myUsers);
            WriteFile(allUsers);

        }

        private static void SetupFile()
        {
            List<User> Users = new();
            string UsersJson = JsonConvert.SerializeObject(Users);
            WriteFile(UsersJson);
        }

        public static List<User> ReadFile()
        {
            var content = File.ReadAllText(path);
            List<User> Users = JsonConvert.DeserializeObject<List<User>>(content);
            return Users;
        }

        public static void WriteFile(string json)
        {
            File.WriteAllText(path, json);
        }
    }
}
