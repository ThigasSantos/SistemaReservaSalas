using Microsoft.EntityFrameworkCore;
namespace SistemaReservaSalas.Data;

public class ReservaDbContext : DbContext{
    #region Construtor
    public ReservaDbContext(DbContextOptions<ReservaDbContext> options): base(options){

    }
    #endregion

    #region Propriedades
    public DbSet<Reserva> Reserva { get; set; }
    #endregion

    #region Métodos sobrecarregados
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Reserva>();
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}