using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class UserInterface
    {
        public void GetData()
        {
            Console.WriteLine("Enter your username");
            var userName = Console.ReadLine();

            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();

            var business = new Business();
            business.SignUp(userName, password);
        }
    }
    public class Business
    {
        public void SignUp(string userName, string password)
        {
            // validation
            var dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }

    public class DataAccess
    {
        public void Store(string userName, string password)
        {
            // write the data to db
        }
    }
}
