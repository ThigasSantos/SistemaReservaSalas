using SistemaReservaSalas.Data; //seu namespace
namespace SistemaReservaSalas.Shared; //seu namespace
public class StateContainer {
public Sala? sala { get; set; }
    public void AtualizaValor(Sala valor){
        this.sala = valor;
    }   
}