using ApiDotNet.Persons;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet.Data;

public class AppDbContext : DbContext {
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=;Database=;Uid=;Pwd=;");
        base.OnConfiguring(optionsBuilder);
    }
}