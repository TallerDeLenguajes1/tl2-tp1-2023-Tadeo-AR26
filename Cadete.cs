namespace EspacioCadeteria{
    public class Cadete{
        private int id;
        private string? nombre;
        private string? direccion;
        private int telefono;
        List<Pedido> listaPedidos;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadete(int id, string nombre, string direccion, int telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public void agregarPedido(int numero, string observacion, string nombreCliente, string direccion, int telefono, string referencia_direccion){
            Pedido NuevoPedido;
            NuevoPedido = new Pedido(numero, observacion, nombreCliente, direccion, telefono, referencia_direccion);
            listaPedidos.Add(NuevoPedido);
        }
    }
}