namespace EspacioCadeteria{
    public class Cadeteria{
        private string? nombre;
        private int telefono;
        private List<Cadete> listaCadetes;

        public string? Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
    }
}