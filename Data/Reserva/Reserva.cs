namespace SistemaReservaSalas.Data;

public class Reserva{
    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public User User { get; set; }
    public Sala Sala { get; set; }
}
