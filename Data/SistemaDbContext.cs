using Microsoft.EntityFrameworkCore;
namespace SistemaReservaSalas.Data;

public class SistemaDbContext : DbContext{
    #region Construtor
    public SistemaDbContext(DbContextOptions<SistemaDbContext> options): base(options){

    }
    #endregion

    #region Propriedades
    public DbSet<Sala> Sala { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Reserva> Reserva { get; set; }
    #endregion

    #region Métodos sobrecarregados
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
    }
    #endregion

}