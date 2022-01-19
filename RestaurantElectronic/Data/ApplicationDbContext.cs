using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantElectronic.Models;

namespace RestaurantElectronic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RestaurantElectronic.Models.Users> Users { get; set; }
        public DbSet<RestaurantElectronic.Models.Meniu> Meniu { get; set; }
        public DbSet<RestaurantElectronic.Models.IstoricComenzi> IstoricComenzi { get; set; }
        public DbSet<RestaurantElectronic.Models.Feedback> Feedback { get; set; }
    }
}