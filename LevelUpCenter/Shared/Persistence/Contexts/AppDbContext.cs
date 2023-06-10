using LevelUpCenter.Home.Domain.Models;
using LevelUpCenter.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<UserType> Users { get; set; }
    public DbSet<Publication> Publications { get; set; }
    

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserType>().ToTable("User Type");
        builder.Entity<UserType>().HasKey(p => p.Id);
        builder.Entity<UserType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<UserType>().Property(p => p.TypeOfUser).IsRequired();
        //relationships
        builder.Entity<UserType>()
            .HasMany(p => p.Publications)
            .WithOne(p => p.UserType)
            .HasForeignKey(p => p.UserId);

        builder.Entity<Publication>().ToTable("Publications");
        builder.Entity<Publication>().HasKey(p => p.Id);
        builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Publication>().Property(p => p.Description).IsRequired();
        
        //aply snake case naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}