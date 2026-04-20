using Microsoft.EntityFrameworkCore;

namespace robot_controller_api.Persistence
{
    public class RobotContext : DbContext
    {
        public RobotContext() { }

        public DbSet<Robotcommand> Robotcommands { get; set; }
        public DbSet<Map> Maps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql("Host=localhost;Database=sit331;Username=postgres;Password=Pass123")
                    .LogTo(Console.WriteLine)
                    .EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robotcommand>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("robotcommand");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Ismovecommand).HasColumnName("ismovecommand");
                entity.Property(e => e.Createddate).HasColumnName("createddate");
                entity.Property(e => e.Modifieddate).HasColumnName("modifieddate");
                entity.Property(e => e.Description).HasColumnName("description");
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("map");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("Name");
                entity.Property(e => e.Columns).HasColumnName("columns");
                entity.Property(e => e.Rows).HasColumnName("rows");
                entity.Property(e => e.Createddate).HasColumnName("createddate");
                entity.Property(e => e.Modifieddate).HasColumnName("modifieddate");
                entity.Property(e => e.Description).HasColumnName("description");
            });
        }
    }

    public class Robotcommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Ismovecommand { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime Modifieddate { get; set; }
        public string? Description { get; set; }
    }

    public class Map
    {
        public int Id { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public string Name { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime Modifieddate { get; set; }
        public string? Description { get; set; }
    }
}