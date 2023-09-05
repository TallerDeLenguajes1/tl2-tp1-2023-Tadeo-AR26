using EspacioCadeteria;


internal class Program{
    private static void Main(string[] args){
        Console.Clear();
        Cadeteria cadeteria;
        long telefono = 5491123900033;
        cadeteria = new Cadeteria("PedidosYa", telefono);
        cadeteria.cargarCadetes();
        cadeteria.mostrarDatosCadete();

        int opcion = 0;
        while(opcion != 6){
            Console.WriteLine("1- Agregar un pedido");
            Console.WriteLine("2- Asignar un cadete a un pedido");
            Console.WriteLine("3- Cambiar el estado de un pedido");
            Console.WriteLine("4- Mostrar el jornal de un cadete");
            Console.WriteLine("5- Reasignar un pedido a otro cadete");
            Console.WriteLine("6- Salir");
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
                case 5:
                    Console.WriteLine("Ingrese el ID del nuevo cadete");
                    successfullyParsed = int.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine("Ingrese el número del nuevo pedido");
                    successfullyParsed = int.TryParse(Console.ReadLine(), out numero);
                    cadeteria.reasignarCadete(id, numero);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}