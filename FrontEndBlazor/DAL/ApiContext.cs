
using BlazorApp2.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Type = System.Type;


namespace BlazorApp2.DAL;

public class ApiContext : DbContext
{
    public DbSet<Type> Types { get; set; }
    public DbSet<Operation> Operations { get; set; }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }
}