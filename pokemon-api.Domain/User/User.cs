﻿using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.User.ValueObjects;

namespace pokemon_api.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(UserId userId, string firstName, string lastName, string email, string password, DateTime createdDateTime, DateTime updatedDateTime)
    : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User (UserId.CreateUnique(), firstName, lastName, email, password, DateTime.UtcNow, DateTime.UtcNow);
    }
}


//public class User
//{
//    public Guid Id { get; set; } = Guid.NewGuid();

//    public string FirstName { get; set; } = null!;
//    public string LastName { get; set; } = null!;
//    public string Email { get; set; } = null!;
//    public string Password { get; set; } = null!;
//}

