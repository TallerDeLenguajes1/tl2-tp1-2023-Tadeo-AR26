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
    }
}