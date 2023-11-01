using System.Collections.ObjectModel;
using Bogus;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Shared.Persistence.Contexts;
using BCryptNet = BCrypt.Net.BCrypt;

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
        SeedAdmin();
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
                LogoUrl = _faker.Image.PicsumUrl(),
                SplashUrl = "https://static-cdn.jtvnw.net/ttv-boxart/21779-285x380.jpg",
                Rating = _faker.Random.Decimal(4, 5)
            };
            _games.Add(game);
        }
    }

    private void SeedAdmin()
    {
        var admin = new User
        {
            Username = "admin",
            FirstName = "Alessandro",
            LastName = "Chumpitaz",
            Role = UserRole.Admin,
            PasswordHash = BCryptNet.HashPassword("12345678")
        };

        _context.Users.Add(admin);

    }
}
