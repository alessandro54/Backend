using System.Collections.ObjectModel;
using Bogus;
using LevelUpCenter.LookUrClimb.Domain.Models;
using LevelUpCenter.Shared.Persistence.Contexts;

namespace LevelUpCenter.Shared.Persistence;

public class Seeder
{
    private readonly AppDbContext _context;
    private readonly Faker _faker = new("en");
    private readonly ICollection<Game> _games = new Collection<Game>();

    private string[] _multiplayerGames = {
        "Fortnite",
        "Call of Duty: Warzone",
        "Apex Legends",
        "Valorant",
        "Dota 2",
        "Rocket League",
        "Overwatch 2",
        "Counter-Strike: Global Offensive"
    };

    public Seeder(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        SeedGames();
        _context.Games.AddRange(_games);
        _context.SaveChanges();
    }

    private void SeedGames()
    {

        for (var i = 0; i < 7; i++)
        {
            var game = new Game
            {
                Name = _multiplayerGames[i],
                Description = _faker.Commerce.ProductDescription(),
                ReleaseYear = _faker.Random.Int(2000, 2021),
                ImageUrl = _faker.Image.PicsumUrl(),
                Rating = _faker.Random.Decimal(4, 5)
            };
            _games.Add(game);
        }
    }
}
