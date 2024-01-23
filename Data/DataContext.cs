using Microsoft.EntityFrameworkCore;

namespace SQLiteTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles => Set<Article>();
    }
}
