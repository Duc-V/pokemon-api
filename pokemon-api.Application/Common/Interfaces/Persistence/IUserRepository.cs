
using pokemon_api.Domain.User;

namespace pokemon_api.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}