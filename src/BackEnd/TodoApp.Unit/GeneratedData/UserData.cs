using Bogus;
using TodoApp.Api.Models.Users;

namespace TodoApp.Unit.GeneratedData;

public class UserData
{
    private static readonly Faker<User> ValidUserDataFaker = new Faker<User>().RuleFor(x => x.Id, Guid.NewGuid())
        .RuleFor(x => x.EmailAddress, x => x.Person.Email)
        .RuleFor(x => x.Password, x => x.Person.UserName)
        .RuleFor(x => x.Username, x => x.Person.UserName)
        .RuleFor(x => x.FirstName, x => x.Person.FirstName)
        .RuleFor(x => x.LastName, x => x.Person.LastName)
        .RuleFor(x => x.CreatedDate, DateTime.Now)
        .RuleFor(x => x.UpdatedDate, DateTime.Now.AddDays(10))
        .RuleFor(x => x.UpdatedDate, DateTime.Now.AddDays(10));

    public static IEnumerable<User> Generate(uint count)
    {
        return ValidUserDataFaker.Generate(10);
    }
}