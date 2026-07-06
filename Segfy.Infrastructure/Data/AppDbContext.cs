using Microsoft.EntityFrameworkCore;
using Segfy.Domain.Entities;

namespace Segfy.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Apolice> Apolices { get; set; }
}