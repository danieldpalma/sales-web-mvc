using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data;

public class SalesWebMvcContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Department> Departments { get; set; } = default!;
    public DbSet<Seller> Sellers { get; set; } = default!;
    public DbSet<SalesRecord> SalesRecords { get; set; } = default!;

    public SalesWebMvcContext(DbContextOptions<SalesWebMvcContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SalesWebMvcContext") ?? throw new InvalidOperationException("Connection string 'SalesWebMvcContext' not found."));
    }

}
