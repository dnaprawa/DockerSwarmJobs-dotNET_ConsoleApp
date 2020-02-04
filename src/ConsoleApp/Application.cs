using Domain;
using Infrastructure;
using Microsoft.Extensions.Logging;
using System;

namespace ConsoleApp
{
    public interface IApplication
    {
        void Run();
    }

    public class Application : IApplication
    {
        private readonly MyDbContext _dbContext;
        public Application(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Run()
        {
            Console.WriteLine("Trying to save data");
            
            var random = new Random();
            var value = random.Next();
            _dbContext.Add(new Counter(value));
            _dbContext.SaveChanges();

            Console.WriteLine($"Data {value} saved sucessfully.");
        }
    }
}
