using pokemon_api.Domain.Entities;

namespace pokemon_api.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}