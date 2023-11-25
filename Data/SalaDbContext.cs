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
        modelBuilder.Entity<Sala>().HasData(RetornaSalas());
        base.OnModelCreating(modelBuilder);
    }
    #endregion


    #region Métodos privados
    private List<Sala> RetornaSalas(){
        return new List<Sala>{
            new Sala{
                Id = 1,
                Nome = "Sala 1",
                Capacidade = 10,
                Descricao = "Sala de aula",
                Ativo = true
            },
            new Sala{
                Id = 2,
                Nome = "Sala 2",
                Capacidade = 20,
                Descricao = "Sala de aula",
                Ativo = true
            },
            new Sala{
                Id = 3,
                Nome = "Lab Comp 1",
                Capacidade = 20,
                Descricao = "Laboratório de computação",
                Ativo = true
            }
        };
    }
    #endregion
}