using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Espacio.Cadeteria;

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
            Console.WriteLine("Ingrese el numero de pedido");
            bool successfullyParsed = int.TryParse(Console.ReadLine(), out numero);
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

        /*public void CambiarPedidoDeCadete(int numeroPedido, int idNuevoCadete){
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
        } */

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

        public void cargarCadetes(){
            int opcion;
            Console.WriteLine("Cargar datos desde:");
            Console.WriteLine("1- CSV");
            Console.WriteLine("2- JSON");
            bool successfullyParsed = int.TryParse(Console.ReadLine(), out opcion);
            AccesoADatos acceso = new AccesoADatos();
            string archivo = "Cadetes";
            switch(opcion){
                case 1:
                    acceso = new AccesoCSV();
                    break;
                case 2:
                    acceso = new AccesoJSON();
                    break;
            }
            listaCadetes = acceso.cargarCadetes(archivo);
        }

        public void mostrarDatosCadete(){
            foreach(Cadete cadete in listaCadetes){
                cadete.mostrarDatosCadete();
            }
        }

        /* public void informe(){
            int jornal = 0;
            foreach(Cadete cadete in listaCadetes){
                jornal = cadete.jornalACobrar();
                Console.WriteLine($"Nombre: {cadete.Nombre} - Total de envíos {jornal/500} - Jornal a cobrar {jornal}");
            }
        } */

        public int jornalACobrar(int idCadete){
            int jornal = 0;
            int montoPorPedido = 500;
            jornal = listaPedidos
            .Where(pedido => pedido.Cadete != null && pedido.Cadete.Id == idCadete && pedido.Estado == "Entregado")
            .Sum(pedido => montoPorPedido);
            return jornal;
        }

        public void asignarCadeteAPedido(int idCadete, int idPedido){
            Pedido pedidoEncontrado = listaPedidos.Find(pedido => pedido.Numero == idPedido);
            Cadete cadeteEncontrado = listaCadetes.Find(cadete => cadete.Id == idCadete);
            pedidoEncontrado.Cadete = cadeteEncontrado;
        }

        public void reasignarCadete(int idCadete, int numero){
            Pedido pedidoEncontrado = listaPedidos.Find(pedido => pedido.Numero == numero);
            Cadete cadeteEncontrado = listaCadetes.Find(cadete => cadete.Id == idCadete);
            pedidoEncontrado.Cadete = cadeteEncontrado;
        }
    }
}