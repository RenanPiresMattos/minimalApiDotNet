using ApiDotNet.Data;
using ApiDotNet.Persons;

namespace ApiDotNet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<AppDbContext>();
        var app = builder.Build();

        app.AddPersonEndPoint();

        app.Run();
    }
}



