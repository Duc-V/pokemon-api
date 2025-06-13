using pokemon_api.Domain.Common.Models;
using pokemon_api.Domain.Menu.ValueObjects;

namespace pokemon_api.Domain.Menu.Entities;
public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description)
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }
    
    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}

