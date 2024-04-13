using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class AppDataContext(DbContextOptions<AppDataContext> options) : IdentityDbContext(options)
{
    public DbSet<AddressEntity> Addresses { get; set; }



}
