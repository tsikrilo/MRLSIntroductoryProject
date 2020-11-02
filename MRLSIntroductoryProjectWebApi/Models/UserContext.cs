using Microsoft.EntityFrameworkCore;

namespace MLRSIntroductoryWebApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserTitle> UserTitle { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}

