using ConsoleApp1.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Type = ConsoleApp1.DAL.Entity.Type;

namespace ConsoleApp1.DAL;

public class ApiContext : DbContext
{
    public DbSet<Type> Types { get; set; }
    public DbSet<Operation> Operations { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }
}