using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
