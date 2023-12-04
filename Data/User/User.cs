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
    public ICollection<Reserva>? Reservas { get; set; }
    public ClaimsPrincipal ToClaimsPrincipal() => new(new ClaimsIdentity(new Claim[] {
        new (ClaimTypes.Name, Email),
        new (ClaimTypes.Hash, Senha),
    }, "ReservaSalas"));
    public static User FromClaimsPrincipal(ClaimsPrincipal principal) => new() { 
        Email = principal.FindFirstValue(ClaimTypes.Name),
        Senha= principal.FindFirstValue(ClaimTypes.Hash),
    };
}