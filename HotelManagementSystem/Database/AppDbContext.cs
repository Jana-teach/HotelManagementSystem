using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> departments { get; set; }
        public DbSet<Staff> Staff {  get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Guest> guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .HasMany(s => s.Staff)
                .WithMany(g => g.guests)
                .UsingEntity(j => j.ToTable("GuestStaff"));

            modelBuilder.Entity<Guest>()
                .HasOne(r => r.Room)
                .WithOne(g => g.Guest)
                .HasForeignKey<Room>(x => x.GuestId);

            modelBuilder.Entity<Department>()
                .HasMany(s => s.Staff)
                .WithOne(d => d.Department);

            modelBuilder.Entity<Guest>()
                .HasData(
                new Guest { Id = 1, Name = "Jana", Email = "jana@gmail.com" },
                new Guest { Id = 2, Name = "Mohammed", Email = "mohammed@gmail.com" },
                new Guest { Id = 3, Name = "Rawan", Email = "rawan@gmail.com" }
                );

            modelBuilder.Entity<Department>()
                .HasData(
                new Department { Id = 1 , Name = "Food" , Description = "first"},
                new Department { Id = 2 , Name = "Wash" , Description = "Second"}
                );

            modelBuilder.Entity<Staff>()
                .HasData(
                new Staff { Id = 1, Name = "Mo3az" , Email = "mo3az@gmail.com" , phone = "01234567890" , DepartmentId = 1},
                new Staff { Id = 2, Name = "Mai" , Email = "mai@gmail.com" , phone = "01234567890" , DepartmentId = 1},
                new Staff { Id = 3, Name = "Eman" , Email = "eman@gmail.com" , phone = "01234567890" , DepartmentId = 2}
                );

            modelBuilder.Entity<Room>()
                .HasData(
                new Room { Id = 1, RoomNumber = "101", Type = "Single", GuestId = 1 },
                new Room { Id = 2, RoomNumber = "102", Type = "Single", GuestId = 3 },
                new Room { Id = 3, RoomNumber = "103", Type = "Double", GuestId = 2 }
                );
        }
    }
}
