using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IDataAccess, DataAccess>();
            collection.AddScoped<IBusiness, BusinessV2>();
            collection.AddScoped<IUserInterface, UserInterface>();

            var provider = collection.BuildServiceProvider();

            IUserInterface userInterface = provider.GetService<IUserInterface>();
        }
    }

    public class UserInterface : IUserInterface
    {
        private readonly IBusiness _business;
        public UserInterface(IBusiness business)
        {
            _business = business;
        }

        public void GetData()
        {
            Console.WriteLine("Enter your username");
            var userName = Console.ReadLine();

            Console.WriteLine("Enter your password");
            var password = Console.ReadLine();

            _business.SignUp(userName, password);
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
        private readonly IDataAccess _dataAccess;
        public BusinessV2(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void SignUp(string userName, string password)
        {
            // validation
            _dataAccess.Store(userName, password);
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

    public interface IUserInterface
    {
        public void GetData();
    }
}
