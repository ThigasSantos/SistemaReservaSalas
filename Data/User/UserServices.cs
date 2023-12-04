using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaReservaSalas.Pages;
namespace SistemaReservaSalas.Data;
public class UserServices
{
    #region Métodos privados
    private SistemaDbContext dbContext;

    private readonly ProtectedLocalStorage protectedLocalStorage;

    private readonly string userStorageKey = "SistemaReservaDeSala";
    #endregion

    #region Construtor
    public UserServices(SistemaDbContext dbContext, ProtectedLocalStorage protectedLocalStorage)
    {
        this.dbContext = dbContext;
        this.protectedLocalStorage = protectedLocalStorage;
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

    public async Task<User> Login(string email, string senha)
    {
        var user = dbContext.User.FirstOrDefault(p => p.Email == email && p.Senha == senha);
        if (user != null)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task PersistUserToBrowserAsync(User user)
    {
        string userJson = JsonConvert.SerializeObject(user);
        await protectedLocalStorage.SetAsync(userStorageKey, userJson);
    }

    public async Task<User?> FetchUserFromBrowserAsync()
    {
        try
        {
            var storedUserResult = await protectedLocalStorage.GetAsync<string>(userStorageKey);
            if(storedUserResult.Success && !string.IsNullOrEmpty(storedUserResult.Value))
            {
                var user = JsonConvert.DeserializeObject<User>(storedUserResult.Value);
                return user;
            }
        }
        catch (System.Exception)
        {
            
            
        }
        return null;
    }

    public async Task ClearBrowserUserDataAsync() => await protectedLocalStorage.DeleteAsync(userStorageKey);

    #endregion
}