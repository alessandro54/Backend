using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Publication> Publications { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Code).IsRequired();
        builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        //relationships
        builder.Entity<User>()
            .HasMany(p => p.Publications)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);

        builder.Entity<Publication>().ToTable("Publications");
        builder.Entity<Publication>().HasKey(p => p.Id);
        builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Publication>().Property(p => p.Description).IsRequired();
        
        //aply snake case naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}