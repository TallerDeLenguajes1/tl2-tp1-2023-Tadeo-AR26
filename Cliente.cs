namespace EspacioCadeteria{
    public class Cliente{
        private string? nombre;
        private string? direccion;
        private int telefono;
        private string? referencia_direccion;

        public string? Nombre { get => nombre; }
        public string? Direccion { get => direccion; }
        public int Telefono { get => telefono; }
        public string? Referencia_direccion { get => referencia_direccion; }


        public Cliente(string nombre, string direccion, int telefono, string referencia_direccion){
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.referencia_direccion = referencia_direccion;
        }
    }
}