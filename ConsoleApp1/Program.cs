namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Homework();
        }
        public static void Homework()
        {
            DataBase.CheckFile();

            bool whileLoop = true;
            int userCount = 1;
            Console.WriteLine("Hello, please enter your name");
            string userName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Hi ");

            while (whileLoop)
            {
                Console.WriteLine($"{userName} What do you want to do?");
                Console.WriteLine("1: See the list of Users");
                Console.WriteLine("2: Add a new user to the list");
                Console.WriteLine("3: Close the application");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        ShowList();
                        break;
                    case "2":
                        AddUsers(userCount);
                        userCount++;
                        break;
                    case "3":
                        whileLoop = false;
                        break;
                    default:
                        Console.WriteLine("Error . Please enter a valid option.");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        public static void ShowList()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("List of the Users:");

            List<User> users = DataBase.ReadFile();

            if (users != null && users.Count > 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    User user = users[i];
                    Console.WriteLine($"User{user.Id}: {user.Name}, {user.Age}, {user.Nationality}, {user.Gender}");
                }
            }
            else
            {
                Console.WriteLine("No users found.");
            }

            Console.WriteLine("-------------------------------");
        }

        public static void AddUsers(int userCount)
        {
            User user = new User();
            Console.WriteLine($"Enter the information for User{userCount}:");

            Console.WriteLine("Enter the name:");
            user.Name = Console.ReadLine();

            Console.WriteLine("Enter the age:");
            user.Age = Console.ReadLine();

            Console.WriteLine("Enter the Nationality:");
            user.Nationality = Console.ReadLine();

            Console.WriteLine("Enter the Gender:");
            user.Gender = Console.ReadLine();

            Console.WriteLine("");

            DataBase.AddUser(user);
        }
    }
}