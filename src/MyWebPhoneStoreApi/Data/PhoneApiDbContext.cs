using Microsoft.EntityFrameworkCore;

namespace PhoneApi.Data
{
    public class PhoneApiDbContext : DbContext
    {
        public PhoneApiDbContext(DbContextOptions<PhoneApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneApiEntity> Phones { get; set; } = null!;
    }
}