using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Models;

namespace WritersWalk.Application.Database;

/// <summary>
/// The DbContext class for the SQLite database.
/// </summary>
public sealed class SqliteDbContext : DbContext
{
    public DbSet<Assignment> Assignments { get; set; } = null!;
    public DbSet<Surrounding> Surroundings { get; set; } = null!;
    public DbSet<Topic> Topics { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<AssignmentTopic> AssignmentTopics { get; set; } = null!;
    public DbSet<AssignmentSurrounding> AssignmentSurroundings { get; set; } = null!;
    public DbSet<AssignmentUser> AssignmentUsers { get; set; } = null!;


    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=writersWalk.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Database model configuration code
        modelBuilder.Entity<AssignmentTopic>()
       .HasIndex(at => new { at.AssignmentId, at.TopicId })
       .IsUnique();

        modelBuilder.Entity<AssignmentSurrounding>()
            .HasIndex(at => new { at.AssignmentId, at.SurroundingsId })
            .IsUnique();

        modelBuilder.Entity<AssignmentUser>()
            .HasIndex(at => new { at.AssignmentId, at.UserId })
            .IsUnique();

        // Data seeding code
        modelBuilder.Entity<User>().HasData(new User("1", "admin", "admin"), new User("2", "user", "user"));

        modelBuilder.Entity<Surrounding>().HasData(
            new Surrounding(1, "Bakke"),
            new Surrounding(2, "Mark"),
            new Surrounding(3, "Skov"),
            new Surrounding(4, "Strand"),
            new Surrounding(5, "By"),
            new Surrounding(6, "Vand"),
            new Surrounding(7, "Åbent land")
        );

        modelBuilder.Entity<Topic>().HasData(new Topic(1, "Skriv dig til klarhed"), new Topic(2, "Styrk din skrivning"),
            new Topic(3, "Skriv din livshistorie"));



        modelBuilder.Entity<Assignment>().HasData(
            new Assignment(1, "Et træ", "Hvis du var et træ, hvordan så du så ud? Beskriv dig selv og dine omgivelser. Hvor står du? Hvilken slags træ er du? Hvad er dine kendetegn? Se på træerne omkring dig for at finde inspiration. Brug dine sanser."),
            new Assignment(2, "Veje og vildveje", "Tænk på en skillevej, du har mødt, hvor du valgte at gå én vej frem for en anden. Er det længe siden? Hvad skete der? Fulgte du den vej, andre allerede havde betrådt mange gange eller den mere ’vilde’ vej? Skriv hvad du kommer til at tænke på."),
            new Assignment(3, "En udfordring", "Hvornår har du stået overfor en udfordring, som du er kommet igennem? Skriv om den: hvad skete der? Hvad gjorde du?"),
            new Assignment(4, "En ny begyndelse", "Hver ny dag bringer noget nyt – eller gør den? Hvornår er du sidst begyndt forfra? Er det nemt eller svært at starte på noget nyt? Hvad får udtrykket ”en ny begyndelse” dig til at tænke på?"),
            new Assignment(5, "Skriv et brev til stilheden – start med ’Kære Stilhed’", "Skriv som var stilheden en person, der har gået sammen med os på vores vandring. Nu har den forladt os – hvad efterlod den hos dig og hvor gik den hen?"),
            new Assignment(6, "Ildsjæl", "Skriv om en ildsjæl du kender. En, der brænder for noget og sætter alt ind for at arbejde med det, vedkommende tror på eller elsker at lave. Kan du genkende noget hos dig selv i vedkommende?"),
            new Assignment(7, "Efterår i skoven", "Beskriv det sted du er lige nu og den tur, du har gået herhen. Fortæl om noget ved denne tid på året, der gør dig glad."),
            new Assignment(8, "Hvad ser du i horisonten", "Skriv om det, der er på den anden side af havet. Det, du ikke kan se, men forestiller dig – eller drømmer om. "),
            new Assignment(9, "Naturen – Et dagbogsnotat", "Skriv i din dagbog, hvad du har oplevet på en dag alene i naturen.  Hvordan ville du klare dig, hvis du skulle være her alene i tre dage? Ville det være en glæde eller en udfordring?"),
            new Assignment(10, "Sommerminder", "Tænk på en sommerdag, da du var barn. Hvad er det første du kommer til at tænke på? Skriv om det. Hvem er med i dit minde? Beskriv vedkommende, hvis der er nogen, og hvis det kun er dig, så beskriv også, hvordan du selv ser ud.")
            );

        modelBuilder.Entity<AssignmentTopic>().HasData(
            new AssignmentTopic()
            {
                Id = 1,
                AssignmentId = 1,
                TopicId = 1
            },
            new AssignmentTopic()
            {
                Id = 2,
                AssignmentId = 2,
                TopicId = 1
            },
            new AssignmentTopic()
            {
                Id = 3,
                AssignmentId = 3,
                TopicId = 1
            },
            new AssignmentTopic()
            {
                Id = 4,
                AssignmentId = 4,
                TopicId = 2
            },
            new AssignmentTopic()
            {
                Id = 5,
                AssignmentId = 5,
                TopicId = 2
            },
            new AssignmentTopic()
            {
                Id = 6,
                AssignmentId = 6,
                TopicId = 2
            },
            new AssignmentTopic()
            {
                Id = 7,
                AssignmentId = 7,
                TopicId = 3
            },
            new AssignmentTopic()
            {
                Id = 8,
                AssignmentId = 8,
                TopicId = 3
            },
            new AssignmentTopic()
            {
                Id = 9,
                AssignmentId = 9,
                TopicId = 3
            },
            new AssignmentTopic()
            {
                Id = 10,
                AssignmentId = 10,
                TopicId = 3
            }
            );

        modelBuilder.Entity<AssignmentSurrounding>().HasData(
            new AssignmentSurrounding()
            {
                Id = 1,
                AssignmentId = 1,
                SurroundingsId = 1
            },
            new AssignmentSurrounding()
            {
                Id = 2,
                AssignmentId = 2,
                SurroundingsId = 1
            },
            new AssignmentSurrounding()
            {
                Id = 3,
                AssignmentId = 3,
                SurroundingsId = 1
            },
            new AssignmentSurrounding()
            {
                Id = 4,
                AssignmentId = 4,
                SurroundingsId = 1
            },
            new AssignmentSurrounding()
            {
                Id = 5,
                AssignmentId = 5,
                SurroundingsId = 2
            },
            new AssignmentSurrounding()
            {
                Id = 6,
                AssignmentId = 6,
                SurroundingsId = 2
            },
            new AssignmentSurrounding()
            {
                Id = 7,
                AssignmentId = 7,
                SurroundingsId = 2
            },
            new AssignmentSurrounding()
            {
                Id = 8,
                AssignmentId = 8,
                SurroundingsId = 2
            },
            new AssignmentSurrounding()
            {
                Id = 9,
                AssignmentId = 9,
                SurroundingsId = 3
            },
            new AssignmentSurrounding()
            {
                Id = 10,
                AssignmentId = 10,
                SurroundingsId = 3
            },
            new AssignmentSurrounding()
            {
                Id = 11,
                AssignmentId = 1,
                SurroundingsId = 4
            },
            new AssignmentSurrounding()
            {
                Id = 12,
                AssignmentId = 2,
                SurroundingsId = 4
            },
            new AssignmentSurrounding()
            {
                Id = 13,
                AssignmentId = 3,
                SurroundingsId = 4
            },
            new AssignmentSurrounding()
            {
                Id = 14,
                AssignmentId = 4,
                SurroundingsId = 4
            },
            new AssignmentSurrounding()
            {
                Id = 15,
                AssignmentId = 5,
                SurroundingsId = 5
            },
            new AssignmentSurrounding()
            {
                Id = 16,
                AssignmentId = 6,
                SurroundingsId = 5
            },
            new AssignmentSurrounding()
            {
                Id = 17,
                AssignmentId = 7,
                SurroundingsId = 5
            },
            new AssignmentSurrounding()
            {
                Id = 18,
                AssignmentId = 8,
                SurroundingsId = 5
            },
            new AssignmentSurrounding()
            {
                Id = 19,
                AssignmentId = 9,
                SurroundingsId = 6
            },
            new AssignmentSurrounding()
            {
                Id = 20,
                AssignmentId = 10,
                SurroundingsId = 6
            },
            new AssignmentSurrounding()
            {
                Id = 21,
                AssignmentId = 1,
                SurroundingsId = 7
            },
            new AssignmentSurrounding()
            {
                Id = 22,
                AssignmentId = 2,
                SurroundingsId = 7
            },
            new AssignmentSurrounding()
            {
                Id = 23,
                AssignmentId = 3,
                SurroundingsId = 7
            },
            new AssignmentSurrounding()
            {
                Id = 24,
                AssignmentId = 4,
                SurroundingsId = 7
            }
            );

    }
}