using ErrorOr;

namespace pokemon_api.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicatedEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description:"Email is already in use");
    }
}