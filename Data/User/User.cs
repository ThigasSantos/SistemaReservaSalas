namespace SistemaReservaSalas.Data;

public class User{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public bool Ativo { get; set; }
    public bool Admin { get; set; }
    public ICollection<Reserva>? Reservas { get; set; }
}