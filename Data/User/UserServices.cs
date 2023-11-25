using Microsoft.EntityFrameworkCore;
using SistemaReservaSalas.Pages;
namespace SistemaReservaSalas.Data;
public class UserServices
{
    #region Métodos privados
    private UserDbContext dbContext;
    #endregion

    #region Construtor
    public UserServices(UserDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Metodos Publicos 
    public async Task<List<User>> RetornaUserAsync()
    {
        return await dbContext.User.ToListAsync();
    }

    public async Task<User> AddUserAsync(User user)
    {
        try
        {
            dbContext.User.Add(user);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        try
        {
            var userExist = dbContext.User.FirstOrDefault(p => p.Id == user.Id);
            if (userExist != null)
            {
                dbContext.Update(user);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return user;
    }

    public async Task DeleteUserAsync(User user)
    {
        try
        {
            dbContext.User.Remove(user);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<User> GetUserAsync(int id)
    {
        return await dbContext.User.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> Login(User login)
    {
        var user = dbContext.User.FirstOrDefault(p => p.Email == login.Email && p.Senha == login.Senha);
        if (user != null)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    #endregion
}