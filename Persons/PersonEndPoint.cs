using ApiDotNet.Data;
using ApiDotNet.Requests;
using ApiDotNet.Models.Dtos;
using ApiDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet.Persons;

public static class PersonEndpoint
{

    public static void AddPersonEndPoint(this WebApplication app)
    {
        var routes = app.MapGroup("/person");

        routes.MapGet("/list", async (AppDbContext context) =>
        {
            var listPerson = await context.Persons.Select(person =>  new PersonDto(person.Id, person.Name)).ToListAsync();

            if (listPerson.Count != 0) return Results.Ok(listPerson);

            return Results.BadRequest("Not found!");
        });

        routes.MapGet("/show/{name}", async (string name, AppDbContext context) =>
        {
            var listPerson = await context.Persons.Where(person => person.Name == name).Select(person => new PersonDto(person.Id, person.Name)).ToListAsync();

            if (listPerson.Count != 0) return Results.Ok(listPerson);

            return Results.BadRequest("Not found!");
        });

        routes.MapPost("/add", async (AddPersonRequest request, AppDbContext context) =>
        {
            var alreadyExists = await context.Persons.AnyAsync(person => person.Name == request.Name);

            if (alreadyExists) return Results.Conflict("Already Exists!");

            var newPerson = new Person(request.Name, request.Age);
            await context.Persons.AddAsync(newPerson);
            await context.SaveChangesAsync();

            return Results.Ok(new PersonDto(newPerson.Id, newPerson.Name));
        });

        routes.MapPut("/change/{id}", async (Guid id, UpdatePersonRequest request, AppDbContext context) =>
        {
            var person = await context.Persons.SingleOrDefaultAsync(person => person.Id == id);

            if (person == null) return Results.BadRequest("Not Allow");

            var alreadyExists = await context.Persons.AnyAsync(person => person.Name == request.Name);

            if (alreadyExists) return Results.Conflict("Already Exists!");

            person.UpdatePerson(request.Name, request.Age);
            await context.SaveChangesAsync();

            return Results.Ok(new PersonDto(person.Id, person.Name));
        });

        routes.MapDelete("/remove/{id}", async (Guid id, AppDbContext context) =>
        {
            var person = await context.Persons.SingleOrDefaultAsync(person => person.Id == id);

            if (person == null) return Results.BadRequest("Not Allow");

            await context.Persons.Where(person => person.Id == id).ExecuteDeleteAsync();

            await context.SaveChangesAsync();

            return Results.Ok("Removed!");
        });
    }

}