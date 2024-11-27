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
            .WithMany()  
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Activity>()
            .HasMany(a => a.Participants)
            .WithMany() 
            .UsingEntity(j => j.ToTable("ActivityParticipants"));
    }
}