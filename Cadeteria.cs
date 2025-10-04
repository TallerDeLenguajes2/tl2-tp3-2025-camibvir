using System;
using System.Collections.Generic;
using System.IO;
using PedidoApp;
using EspacioCadete;
using ClienteApp;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        public string NombreCadeteria { get; set; }
        public int TelefonoCadeteria { get; set; }
        public List<Cadete> ListadoCadetes { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Cadeteria(string nombre, int telefono)
        {
            NombreCadeteria = nombre;
            TelefonoCadeteria = telefono;
            ListadoCadetes = new List<Cadete>();
            Pedidos = new List<Pedido>();
        }

        // Alta manual de pedidos desde consola
        public void darDeAltaPedido(string nombreCliente, string direccionCliente, int telefonoCliente,
                                    string referencia, int numeroPedido, string observacion)
        {
            var cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, referencia);
            var pedido = new Pedido(numeroPedido, cliente, Estado.Pendiente, observacion);
            Pedidos.Add(pedido);

            Console.WriteLine($"Pedido N°{numeroPedido} dado de alta con éxito.");
        }

        // Asignar un cadete a un pedido
        public void AsignarCadeteAPedido(int numeroPedido, int idCadete)
        {
            var pedido = Pedidos.Find(p => p.NumeroPedido == numeroPedido);
            var cadete = ListadoCadetes.Find(c => c.IdCadete == idCadete);

            if (pedido != null && cadete != null)
            {
                pedido.CadeteAsignado = cadete;
                Console.WriteLine($"Pedido N°{numeroPedido} asignado a {cadete.NombreCadete}");
            }
            else
            {
                Console.WriteLine("Pedido o cadete no encontrado.");
            }
        }

        // Reasignar un pedido a otro cadete
        public void ReasignarPedido(int numeroPedido, int idCadeteDestino)
        {
            var pedido = Pedidos.Find(p => p.NumeroPedido == numeroPedido);
            var cadeteDestino = ListadoCadetes.Find(c => c.IdCadete == idCadeteDestino);

            if (pedido != null && cadeteDestino != null)
            {
                pedido.CadeteAsignado = cadeteDestino;
                Console.WriteLine($"Pedido N°{numeroPedido} reasignado a {cadeteDestino.NombreCadete}");
            }
            else
            {
                Console.WriteLine("Pedido o cadete no encontrado.");
            }
        }

        // Calcular jornal de un cadete
        public float JornalACobrar(int idCadete)
        {
            int pedidosEntregados = Pedidos.FindAll(p =>
                p.CadeteAsignado != null &&
                p.CadeteAsignado.IdCadete == idCadete &&
                p.Estado == Estado.Entregado
            ).Count;

            return pedidosEntregados * 500;
        }
    }
}
