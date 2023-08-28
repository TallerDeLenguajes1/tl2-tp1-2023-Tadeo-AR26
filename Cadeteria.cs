namespace EspacioCadeteria{
    public class Cadeteria{
        private string? nombre;
        private long telefono;
        private List<Cadete> listaCadetes;

        public string? Nombre { get => nombre; set => nombre = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }

        public Cadeteria(string nombre, long telefono){
            this.nombre = nombre;
            this.telefono = telefono;
        }
        public void AgregarCadete(int id, string nombre, string direccion, long telefono){
            Cadete NuevoCadete;
            NuevoCadete = new Cadete(id, nombre, direccion, telefono);
            listaCadetes.Add(NuevoCadete);
        }
        
        public void AgregarPedido(int id, int numero, string observacion, string nombreCliente, string direccion, long telefono, string referencia_direccion){
            listaCadetes[id].AgregarPedido(numero, observacion, nombreCliente, direccion, telefono, referencia_direccion);
        }

        public void CambiarPedidoDeCadete(int numeroPedido, Cadete nuevoCadete){
            foreach (Cadete cadete in listaCadetes){
                Pedido pedidoEncontrado = cadete.ListaPedidos.Find(pedido => pedido.Numero == numeroPedido);
                if (pedidoEncontrado != null){
                    cadete.ListaPedidos.Remove(pedidoEncontrado);
                    nuevoCadete.ListaPedidos.Add(pedidoEncontrado);
                    Console.WriteLine($"El pedido {numeroPedido} se ha cambiado de cadete.");
                    return;
                }
            }
            Console.WriteLine($"No se encontró el pedido {numeroPedido}");
        }
    }
}