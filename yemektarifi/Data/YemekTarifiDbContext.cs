using Microsoft.EntityFrameworkCore;

namespace Namespace;
public class YemekTarifiDbContext : DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;database=YemekDB;UID=sa;PWD=0900tgbyhn.,!;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<ApiKeysTable> keysTable;
    public DbSet<UsersTable> usersTable;
}
