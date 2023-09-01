using EspacioCadeteria;


internal class Program{
    private static void Main(string[] args){
        Console.Clear();
        Cadeteria cadeteria;
        long telefono = 5491123900033;
        cadeteria = new Cadeteria("PedidosYa", telefono);
        string archivo = "Cadetes.csv";
        cadeteria.cargarCadetesCSV(archivo);

        int opcion = 0;
        while(opcion != 5){
            Console.WriteLine("1- Agregar un pedido");
            Console.WriteLine("2- Reasignar un pedido a un cadete");
            Console.WriteLine("3- Cambiar el estado de un pedido");
            Console.WriteLine("4- Mostrar el informe");
            Console.WriteLine("5- Salir");
            bool successfullyParsed = int.TryParse(Console.ReadLine(), out opcion);

            switch(opcion){
                case 1:
                    cadeteria.AgregarPedido();
                    break;
                case 2:
                    Console.WriteLine("Ingrese el numero de pedido");
                    int numero = 0;
                    successfullyParsed = int.TryParse(Console.ReadLine(), out numero);
                    Console.WriteLine("Ingrese el id del cadete");
                    int id = 0;
                    successfullyParsed = int.TryParse(Console.ReadLine(), out id);
                    cadeteria.asignarCadeteAPedido(id, numero);
                    break;
                case 3:
                    Console.WriteLine("Ingrese el numero de pedido");
                    numero = 0;
                    successfullyParsed = int.TryParse(Console.ReadLine(), out numero);
                    cadeteria.cambiarEstadoPedido(numero);
                    break;
                case 4:
                    Console.WriteLine("Ingrese el ID del cadete que desea ver su jornal");
                    successfullyParsed = int.TryParse(Console.ReadLine(), out id);
                    int jornal = cadeteria.jornalACobrar(id);
                    Console.WriteLine($"El jornal a cobrar es {jornal}");
                    break;
            }
        }
    }
}