using Microsoft.EntityFrameworkCore;
namespace SistemaReservaSalas.Data;
public class ReservaServices
{
    #region Métodos privados
    private ReservaDbContext dbContext;
    #endregion

    #region Construtor
    public ReservaServices(ReservaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Metodos Publicos 
    public async Task<List<Reserva>> RetornaReservaAsync()
    {
        return await dbContext.Reserva.ToListAsync();
    }

    public async Task<Reserva> AddReservaAsync(Reserva reserva)
    {
        try
        {
            dbContext.Reserva.Add(reserva);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return reserva;
    }

    public async Task<Reserva> UpdateReservaAsync(Reserva reserva)
    {
        try
        {
            var reservaExist = dbContext.Reserva.FirstOrDefault(p => p.Id == reserva.Id);
            if (reservaExist != null)
            {
                dbContext.Update(reserva);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return reserva;
    }

    public async Task DeleteReservaAsync(Reserva reserva)
    {
        try
        {
            dbContext.Reserva.Remove(reserva);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}