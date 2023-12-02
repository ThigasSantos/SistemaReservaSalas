using Microsoft.EntityFrameworkCore;
namespace SistemaReservaSalas.Data;

public class SalaDbContext : DbContext{
    #region Construtor
    public SalaDbContext(DbContextOptions<SalaDbContext> options): base(options){

    }
    #endregion

    #region Propriedades
    public DbSet<Sala> Sala { get; set; }
    #endregion

    #region Métodos sobrecarregados
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Sala>();
        base.OnModelCreating(modelBuilder);
    }
    #endregion

}