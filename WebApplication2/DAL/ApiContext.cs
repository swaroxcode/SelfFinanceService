using Microsoft.EntityFrameworkCore;

namespace WebApplication2;

public class ApiContext : DbContext
{
    
    public DbSet<Type> Types{ get; set; }
    public DbSet<Operation> Operations { get; set; }
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options){}

}