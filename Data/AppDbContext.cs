using ApiDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet.Data;

public class AppDbContext : DbContext {
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mydb.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}