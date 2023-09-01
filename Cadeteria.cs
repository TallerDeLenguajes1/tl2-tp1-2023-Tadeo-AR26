using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace EspacioCadeteria{
    public class Cadeteria{
        private string? nombre;
        private long telefono;
        private List<Cadete> listaCadetes;
        private List<Pedido> listaPedidos = new List<Pedido>();

        public string? Nombre { get => nombre; set => nombre = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadeteria(string nombre, long telefono){
            this.nombre = nombre;
            this.telefono = telefono;
        }
        public void AgregarCadete(int id, string nombre, string direccion, long telefono){
            Cadete NuevoCadete;
            NuevoCadete = new Cadete(id, nombre, direccion, telefono);
            listaCadetes.Add(NuevoCadete);
        }
        
        public void AgregarPedido(){
            int id, numero;
            string? observacion, nombreCliente, direccion, referencia_direccion;
            long telefono;
            Console.WriteLine("Ingrese el ID del cadete:");
            bool successfullyParsed = int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Ingrese el numero de pedido");
            successfullyParsed = int.TryParse(Console.ReadLine(), out numero);
            Console.WriteLine("Ingrese la observación del pedido");
            observacion = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del cliente");
            nombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección del cliente");
            direccion = Console.ReadLine();
            Console.WriteLine("Ingrese el teléfono del cliente");
            successfullyParsed = long.TryParse(Console.ReadLine(), out telefono);
            Console.WriteLine("Ingrese una referencia para la dirección");
            referencia_direccion = Console.ReadLine();
            Pedido NuevoPedido;
            NuevoPedido = new Pedido(numero, observacion, nombreCliente, direccion, telefono, referencia_direccion);
            listaPedidos.Add(NuevoPedido);
        }

        public void CambiarPedidoDeCadete(int numeroPedido, int idNuevoCadete){
            Cadete nuevoCadete = listaCadetes.Find(cadete => cadete.Id == idNuevoCadete);
            if(nuevoCadete != null){
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
            else{
                Console.WriteLine($"No se encontró el cadete {idNuevoCadete}");
            }
        }

        public void cambiarEstadoPedido(int numeroPedido){  
            Pedido pedidoEncontrado = ListaPedidos.Find(pedido => pedido.Numero == numeroPedido);
                if(pedidoEncontrado != null){
                    if(pedidoEncontrado.Estado == "Pendiente"){
                        pedidoEncontrado.Estado = "Entregado";
                        Console.WriteLine("El pedido se marcó como entregado");
                    }
                    else{
                        Console.WriteLine("Este pedido ya fue entregado");
                    }
            }
        }

        public void cargarCadetesCSV(string archivo){
            List<Cadete> cadetes = new List<Cadete>();
            var cadetesCargados = File.ReadAllLines(archivo)
            .Skip(1).                           //Saltea el encabezado
            Select(line => line.Split(',')).
            Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], long.Parse(parts[3])));
            cadetes.AddRange(cadetesCargados);
            ListaCadetes = cadetes;
            Console.WriteLine("Cadetes cargados correctamente");
        }

        public void mostrarDatosCadete(){
            foreach(Cadete cadete in listaCadetes){
                cadete.mostrarDatosCadete();
            }
        }

        public void informe(){
            int jornal = 0;
            foreach(Cadete cadete in listaCadetes){
                jornal = cadete.jornalACobrar();
                Console.WriteLine($"Nombre: {cadete.Nombre} - Total de envíos {jornal/500} - Jornal a cobrar {jornal}");
            }
        }
    }
}