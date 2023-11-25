using SistemaReservaSalas.Data;
namespace SistemaReservaSalas.Shared; 
public class StateContainer {
public Sala? sala { get; set; }
    public void AtualizaSala(Sala valor){
        this.sala = valor;
    }   

public Reserva? reserva { get; set; }
    public void AtualizaReserva(Reserva valor){
        this.reserva = valor;
    }

public User? user { get; set; }
    public void AtualizaUser(User valor){
        this.user = valor;
    }
}

