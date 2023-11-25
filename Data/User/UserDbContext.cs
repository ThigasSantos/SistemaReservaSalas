using Microsoft.EntityFrameworkCore;
namespace SistemaReservaSalas.Data;

public class UserDbContext : DbContext{
    #region Construtor
    public UserDbContext(DbContextOptions<UserDbContext> options): base(options){

    }
    #endregion

    #region Propriedades
    public DbSet<User> User { get; set; }
    #endregion

    #region Métodos sobrecarregados
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<User>();
        base.OnModelCreating(modelBuilder);
    }
    #endregion
}