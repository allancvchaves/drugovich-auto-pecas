using DrugovichAutoPecas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugovichAutoPecas.API.Context
{
    public class AutoPecasContext : DbContext
    {
        public AutoPecasContext(DbContextOptions<AutoPecasContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
    }
}
