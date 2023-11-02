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
        SeedCoach();
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
                IconUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/5ab19f85-6c25-4d8d-a4d5-9e8070c3164c/d6w0695-1892f196-2ac3-4889-9f72-f2c11a27b31c.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7InBhdGgiOiJcL2ZcLzVhYjE5Zjg1LTZjMjUtNGQ4ZC1hNGQ1LTllODA3MGMzMTY0Y1wvZDZ3MDY5NS0xODkyZjE5Ni0yYWMzLTQ4ODktOWY3Mi1mMmMxMWEyN2IzMWMucG5nIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmZpbGUuZG93bmxvYWQiXX0.n-tG_jJvdWEXT36j0di-JiT1SkHKZ33AEdLeyrslBVI",
                BannerUrl = _faker.Image.PicsumUrl(),
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

    private void SeedCoach()
    {
        var user = _context.Users.Add(new User
        {
            Username = "coach",
            FirstName = "Michael",
            LastName = "Campos",
            Role = UserRole.Coach,
            PasswordHash = BCryptNet.HashPassword("12345678")
        });

        var coach = new Coach
        {
            Nickname = "coach777",
            User = user.Entity
        };

        _context.Coaches.Add(coach);

    }
}
