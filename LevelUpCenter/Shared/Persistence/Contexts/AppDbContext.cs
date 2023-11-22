using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Security.Domain.Models;
using LevelUpCenter.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LevelUpCenter.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Publication> Publications { get; set; }
    public DbSet<Game> Games { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Learner> Learners { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // User model
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<Comment>()
            .HasOne(c => c.Author)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Course model
        builder.Entity<Course>().ToTable("Courses");
        builder.Entity<Course>().HasKey(p => p.Id);
        builder.Entity<Course>().Property(p => p.Title).IsRequired();
        // One Course has many Publications
        builder.Entity<Publication>()
            .HasOne(e => e.Course)
            .WithMany(course => course.Publications)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Publication model
        builder.Entity<Publication>().ToTable("Publications");
        builder.Entity<Publication>().HasKey(p => p.Id);
        builder.Entity<Publication>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Publication>().Property(p => p.Title).IsRequired();
        // One Publication has many Comments
        builder.Entity<Comment>()
            .HasOne(c => c.Publication)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.PublicationId)
            .OnDelete(DeleteBehavior.Cascade);

        // * Learner model
        builder.Entity<Learner>().ToTable("Learners");
        builder.Entity<Learner>().HasKey(p => p.Id);
        builder.Entity<Learner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Learner>().Property(p => p.Nickname).IsRequired();
        builder.Entity<Learner>().HasIndex(p => p.Nickname).IsUnique();

        // ? One Learner has a User
        builder.Entity<Learner>()
            .HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<Learner>(c => c.UserId);
        // ? One Learner has many Enrollments
        builder.Entity<Enrollment>()
            .HasOne(e => e.Learner)
            .WithMany(l => l.Enrollments)
            .HasForeignKey(e => e.LearnerId)
            .OnDelete(DeleteBehavior.Cascade);

        // * End Learner model

        // * Coach model
        builder.Entity<Coach>().ToTable("Coaches");
        builder.Entity<Coach>().HasKey(p => p.Id);
        builder.Entity<Coach>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Coach>().Property(p => p.Nickname).IsRequired();
        builder.Entity<Coach>().HasIndex(p => p.Nickname).IsUnique();

        // ? One Coach has a User
        builder.Entity<Coach>()
            .HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<Coach>(c => c.UserId);
        // ? One Coach has many Courses
        builder.Entity<Course>()
            .HasOne(c => c.Coach)
            .WithMany(coach => coach.Courses)
            .HasForeignKey(c => c.CoachId)
            .OnDelete(DeleteBehavior.Cascade);

        // * End Coach model

        // Enrollment model
        builder.Entity<Enrollment>().HasKey(e => new { e.CourseId, e.LearnerId });
        builder.Entity<Enrollment>().HasIndex(e => new { e.CourseId, e.LearnerId }).IsUnique();

        // Many Courses have many Apprentices
        builder.Entity<Enrollment>()
            .HasOne(e => e.Learner)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.LearnerId);
        builder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);

        // Game model
        builder.Entity<Game>().ToTable("Games");
        builder.Entity<Game>().HasKey(p => p.Id);
        builder.Entity<Game>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Game>().Property(p => p.Name).IsRequired();
        builder.Entity<Game>().HasIndex(p => p.Name).IsUnique();
        builder.Entity<Game>().Property(p => p.Description).IsRequired();
        // One Game has many Courses
        builder.Entity<Course>()
            .HasOne(p => p.Game)
            .WithMany(p => p.Courses)
            .HasForeignKey(c => c.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comment model
        builder.Entity<Comment>().ToTable("Comments");
        builder.Entity<Comment>().HasKey(p => p.Id);
        builder.Entity<Comment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comment>()
            .HasOne(c => c.Parent)
            .WithMany()
            .HasForeignKey(c => c.ParentId);

        //Apply snake case naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}
