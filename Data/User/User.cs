using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace SistemaReservaSalas.Data;

public class User
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public bool Ativo { get; set; }
    public bool Admin { get; set; }
    
    [NotMapped]
    public List<string> Roles { get; set; } = new();
    public ClaimsPrincipal ToClaimsPrincipal() => new(new ClaimsIdentity(new Claim[] {
        new (ClaimTypes.Sid, Id.ToString()),
        new (ClaimTypes.Name, Nome),
        new (ClaimTypes.Email, Email),
        new (ClaimTypes.Expired, Admin.ToString()),
        new (ClaimTypes.Hash, Senha),
        new (ClaimTypes.Role, IsAdminOrUser(Admin))
    }
    , "ReservaSalas"));
    public static User FromClaimsPrincipal(ClaimsPrincipal principal) => new() { 
        Id = ParseInt(principal.FindFirstValue(ClaimTypes.Sid)),
        Nome = principal.FindFirstValue(ClaimTypes.Name),
        Email = principal.FindFirstValue(ClaimTypes.Email),
        Admin = ParseBool(principal.FindFirstValue(ClaimTypes.Expired)),
        Senha= principal.FindFirstValue(ClaimTypes.Hash),
        Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList()
    };

    private static string IsAdminOrUser(bool isAdmin) {
        if(isAdmin)
            return "admin";
        
        return "user";
    }

    private static int ParseInt(string? stringToParse){

        int number;

        if(!int.TryParse(stringToParse, out number)){
            number = 0;
        }
        return number;
    }

    private static bool ParseBool(string? stringToParse){

        bool number;

        if(!bool.TryParse(stringToParse, out number)){
            number = false;
        }
        return number;
    }
}