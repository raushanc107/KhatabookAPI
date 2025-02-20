using KhataBookApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KhataBookApi.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Khata> Khata { get; set; }

    public DbSet<Transactions> Transactions {get;set;}
    public DbSet<Users> Users {get;set;}
    public DbSet<Cars> Cars {get;set;}
    public DbSet<City> City {get;set;}
    public DbSet<RentalDetails> RentDetails {get;set;}
    public DbSet<Booking> Booking {get;set;}

}

