using Microsoft.EntityFrameworkCore;
namespace SistemaReservaSalas.Data;
public class ReservaServices
{
    #region Métodos privados
    private SistemaDbContext dbContext;
    #endregion

    #region Construtor
    public ReservaServices(SistemaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Metodos Publicos 
    public async Task<List<Reserva>> RetornaReservaAsync()
    {
        return await dbContext.Reserva.ToListAsync();
    }

    public async Task<List<Reserva>> RetornaReservasAsyncByDateAndRoom(int roomId, DateTime diaBase){
        
        return await dbContext.Reserva.AsNoTracking().Where(res => res.SalaId == roomId && res.DataInicio.DayOfYear == diaBase.DayOfYear && res.DataInicio.Year == diaBase.Year).ToListAsync();
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

        Console.WriteLine("chegou aqui");
        try
        {
            
            dbContext.Reserva.Remove(reserva);
            dbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}