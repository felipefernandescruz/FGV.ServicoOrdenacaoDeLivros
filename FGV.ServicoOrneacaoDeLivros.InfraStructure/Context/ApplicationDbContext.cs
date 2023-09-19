using FGV.ServicoOrneacaoDeLivros.InfraStructure.Map;
using Microsoft.EntityFrameworkCore;

namespace FGV.ServicoOrneacaoDeLivros.InfraStructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderTypeMap());
        }
    }
}
