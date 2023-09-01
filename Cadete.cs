namespace EspacioCadeteria{
    public class Cadete{
        private int id;
        private string? nombre;
        private string? direccion;
        private long telefono;
        //List<Pedido> listaPedidos = new List<Pedido>();

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        //public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadete(int id, string nombre, string direccion, long telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public void AgregarPedido(int numero, string observacion, string nombreCliente, string direccion, long telefono, string referencia_direccion){
            Pedido NuevoPedido;
            NuevoPedido = new Pedido(numero, observacion, nombreCliente, direccion, telefono, referencia_direccion);
            listaPedidos.Add(NuevoPedido);
        }

        public void mostrarDatosCadete(){
            Console.WriteLine($"ID: {id} - Nombre: {nombre} - Dirección: {direccion} - Telefono: {telefono}");
        }

        public int jornalACobrar(){
            int jornal = 0;
            foreach(Pedido pedido in ListaPedidos){
                if(pedido.Estado == "Entregado"){
                    jornal += 500;
                }
            }
            return jornal;
        }
    }
}