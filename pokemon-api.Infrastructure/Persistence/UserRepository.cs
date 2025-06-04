using pokemon_api.Application.Common.Interfaces.Persistence;
using pokemon_api.Domain.Entities;

namespace pokemon_api.Infrastructure.Persistence;

public class UserRepository: IUserRepository
{   
    private readonly List<User> _users = new ();
    
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);    
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}