using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            foreach(Cadete cadete in listaCadetes){
                Pedido pedidoEncontrado = cadete.ListaPedidos.Find(pedido => pedido.Numero == numeroPedido);
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
        }

        public void cargarCadetesCSV(string archivo){
            var cadetesCargados = File.ReadAllLines(archivo)
            .Skip(1).                           //Saltea el encabezado
            Select(line => line.Split(',')).
            Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], long.Parse(parts[3])));
            listaCadetes.AddRange(cadetesCargados);
        }
    }
}