using Microsoft.EntityFrameworkCore;
using ParadiseApi.Models;

namespace ParadiseApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public DbSet<Users> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ResponceVideo> ResponceVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
