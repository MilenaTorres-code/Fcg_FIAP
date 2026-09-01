using Fcg.Domain.Entities;
using Fcg.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fcg.Infrastructure.Data;

public class FcgDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public FcgDbContext(DbContextOptions<FcgDbContext> options)
        : base(options)
    {
    }

    public DbSet<Jogo> Jogos { get; set; }
    public DbSet<Aquisicao> Aquisicoes { get; set; }
    public DbSet<Promocao> Promocoes { get; set; }

}