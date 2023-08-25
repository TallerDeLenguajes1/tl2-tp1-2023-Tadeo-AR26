using EspacioCadeteria;

namespace Espacio.Pedido{
    public class Pedido{
        private int numero;
        private string? observacion;
        private Cliente cliente;

        private string? estado;

        public int Numero { get => numero; set => numero = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
    }
}