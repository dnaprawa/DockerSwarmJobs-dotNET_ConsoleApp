using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure
{
    public class MyDbContextInitializer
    {
        private MyDbContext _dbContext;
        public MyDbContextInitializer(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ExecuteMigrations()
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
                _dbContext.Database.Migrate();
        }
    }
}
