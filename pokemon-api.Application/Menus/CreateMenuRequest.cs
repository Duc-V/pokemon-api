using pokemon_api.Domain.Menu.Entities;

namespace pokemon_api.Application.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSection> Sections 
);

public record MenuSection
(
    string Name,
    string Description,
    List<MenuItem> Items
);

public record MenuItem(
    string Name,
    string Description

);
