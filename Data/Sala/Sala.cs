namespace SistemaReservaSalas.Data;
public class Sala{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Capacidade { get; set; }
    public string? Descricao { get; set; }
    public bool Ativo { get; set; }
    public ICollection<Reserva>? Reservas { get; set; }
}