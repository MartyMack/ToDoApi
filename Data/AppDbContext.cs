using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;
using ToDoApi.Data;

namespace ToDoApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Todo> Todos => Set<Todo>();
}