using LojaAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace LojaAPI.Data;

public class LojaDbContext : DbContext
{
    public LojaDbContext (DbContextOptions<LojaDbContext> options) : base(options)
    {
    }
    
    public DbSet<Cliente> Clientes { get; set; }
}