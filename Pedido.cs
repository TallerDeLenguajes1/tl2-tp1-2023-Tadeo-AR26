namespace EspacioCadeteria{
    public class Pedido{
        private int numero;
        private string? observacion;
        private Cliente cliente;

        private string? estado;

        public int Numero { get => numero; set => numero = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        public string? Estado { get => estado; set => estado = value; }

        public Pedido(int numero, string observacion, string nombreCliente, string direccion, int telefono, string referencia_direccion)
        {
            cliente = new Cliente( nombreCliente,  direccion,  telefono,  referencia_direccion);
            Numero = numero;
            Observacion = observacion;
            Estado = "Pendiente";
        }
    }
}