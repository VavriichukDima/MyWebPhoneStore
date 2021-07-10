using Microsoft.EntityFrameworkCore;

namespace MyWebPhoneStoreApi.Data
{
    public class MyWebPhoneStoreApiDbContext : DbContext
    {
        public MyWebPhoneStoreApiDbContext(DbContextOptions<MyWebPhoneStoreApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyWebPhoneStoreApiEntity> Phones { get; set; } = null!;
    }
}