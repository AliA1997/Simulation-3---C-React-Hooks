using Halo.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Halo.Data
{
    public class HaloContext : DbContext
    {
        public HaloContext(DbContextOptions<HaloContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();

            builder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithOne()
                .HasForeignKey<Post>(po => po.UserId);

            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithOne()
                .HasForeignKey<Comment>(co => co.PostId);

            builder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithOne()
                .HasForeignKey<Comment>(co => co.UserId);

           
        }
    }
}
