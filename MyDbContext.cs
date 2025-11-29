using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Passenger> Passengers { get; set; } // Full Passenger model
}
