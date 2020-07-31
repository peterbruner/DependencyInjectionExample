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

            IBusiness business = new BusinessV2();
            business.SignUp(userName, password);
        }
    }
    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void SignUp(string userName, string password)
        {
            // validation
            _dataAccess.Store(userName, password);
        }
    }

    public class BusinessV2 : IBusiness
    {
        public void SignUp(string userName, string password)
        {
            // validation
            var dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }

    public class DataAccess : IDataAccess
    {
        public void Store(string userName, string password)
        {
            // write the data to db
        }
    }

    public interface IBusiness
    {
        public void SignUp(string userName, string password);
    }

    public interface IDataAccess
    {
        public void Store(string userName, string password);
    }
}
