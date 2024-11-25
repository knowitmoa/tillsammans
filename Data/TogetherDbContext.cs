using Microsoft.EntityFrameworkCore;
using Together2._0.Models;

namespace Together2._0.Data;

public class TogetherDbContext : DbContext
{
    public TogetherDbContext(DbContextOptions<TogetherDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Owner)
            .WithMany()  // You can define a navigation property for Users owned by them if needed
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete if needed

        modelBuilder.Entity<Activity>()
            .HasMany(a => a.Participants)
            .WithMany() // Define a join table or many-to-many if needed
            .UsingEntity(j => j.ToTable("ActivityParticipants"));
    }
}