namespace SistemaReservaSalas.Data;

public class Reserva{
    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int UserId { get; set; }
    public int SalaId { get; set; }
}

public class PrepareReserva {
    public int Id { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public User User { get; set; }
    public Sala Sala { get; set; }
    public bool MostrarBotaoReservar { get; set; }
    public bool MostrarBotaoRemoverReserva { get; set; }
    public bool MostrarMensagemReservaDeOutroUsuario { get; set; }
    public Reserva reserva { get; set; }
}