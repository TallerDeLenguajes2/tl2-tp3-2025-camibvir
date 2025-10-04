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

        public bool DarDeAltaPedido(string nombreCliente, string direccionCliente, int telefonoCliente,
                                    string referencia, int numeroPedido, string observacion)
        {
            if (Pedidos.Exists(p => p.NumeroPedido == numeroPedido))
                return false; // ya existe ese número

            var cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, referencia);
            var pedido = new Pedido(numeroPedido, cliente, Estado.Pendiente, observacion);
            Pedidos.Add(pedido);
            return true;
        }

        public string AsignarCadeteAPedido(int numeroPedido, int idCadete)
        {
            var pedido = Pedidos.Find(p => p.NumeroPedido == numeroPedido);
            var cadete = ListadoCadetes.Find(c => c.IdCadete == idCadete);

            if (pedido != null && cadete != null)
            {
                pedido.CadeteAsignado = cadete;
                return $"Pedido N°{numeroPedido} asignado a {cadete.NombreCadete}";
            }
            return "Pedido o cadete no encontrado.";
        }

        public string ReasignarPedido(int numeroPedido, int idCadeteDestino)
        {
            var pedido = Pedidos.Find(p => p.NumeroPedido == numeroPedido);
            var cadeteDestino = ListadoCadetes.Find(c => c.IdCadete == idCadeteDestino);

            if (pedido != null && cadeteDestino != null)
            {
                pedido.CadeteAsignado = cadeteDestino;
                return $"Pedido N°{numeroPedido} reasignado a {cadeteDestino.NombreCadete}";
            }
            return "Pedido o cadete no encontrado.";
        }

        public float CalcularJornal(int idCadete)
        {
            int pedidosEntregados = Pedidos.FindAll(p =>
                p.CadeteAsignado != null &&
                p.CadeteAsignado.IdCadete == idCadete &&
                p.Estado == Estado.Entregado
            ).Count;

            return pedidosEntregados * 500;
        }

        public List<string> ObtenerPedidos()
        {
            var lista = new List<string>();
            foreach (var p in Pedidos)
            {
                string info = $"Pedido {p.NumeroPedido} - Estado: {p.Estado}";
                if (p.CadeteAsignado != null)
                    info += $" - Cadete: {p.CadeteAsignado.NombreCadete}";
                lista.Add(info);
            }
            return lista;
        }
    }
}
