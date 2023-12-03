using Microsoft.EntityFrameworkCore;
namespace SistemaReservaSalas.Data;
public class SalaServices
{
    #region Métodos privados
    private SalaDbContext dbContext;
    #endregion

    #region Construtor
    public SalaServices(SalaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Metodos Publicos 
    public async Task<List<Sala>> RetornaSalaAsync()
    {
        return await dbContext.Sala.ToListAsync();
    }

    public async Task<Sala> AddRoomAsync(Sala sala)
    {
        try
        {
            dbContext.Sala.Add(sala);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return sala;
    }

    public async Task<Sala> UpdateRoomAsync(Sala sala)
    {
        try
        {   
            Console.WriteLine("salaID: {0}", sala.Id);
            Console.WriteLine("salaCapacidade: {0}", sala.Capacidade);
            Console.WriteLine("salaDescricao: {0}", sala.Descricao);
            
            var salaExist = dbContext.Sala.FirstOrDefault(p => p.Id == sala.Id);
            Console.WriteLine("salaExist: {0}", salaExist);
            if (salaExist != null)
            {
                dbContext.Update(sala);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        return sala;
    }

    public async Task DeleteRoomAsync(Sala sala)
    {
        try
        {
            dbContext.Sala.Remove(sala);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}