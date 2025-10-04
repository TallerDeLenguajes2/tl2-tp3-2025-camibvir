using System;
using ClienteApp;
using EspacioCadete;
namespace PedidoApp
{
    public enum Estado
    {
        Pendiente,
        EnCamino,
        Entregado,
        Cancelado
    }

    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public string? ObservacionPedido { get; set; }
        public ClienteApp.Cliente Cliente { get; set; }
        public Estado Estado { get; set; }

        public Cadete? CadeteAsignado{get; set;}

        public Pedido(int numeroPedido, ClienteApp.Cliente cliente, Estado estado = Estado.Pendiente, string? observacion = null)
        {
            this.NumeroPedido = numeroPedido;
            this.Cliente = cliente;
            this.Estado = estado;
            this.ObservacionPedido = observacion;
            CadeteAsignado = null;
        }

        public string VerDireccionCliente()
        {
            return Cliente.DireccionCliente;
        }

        public string VerDatosCliente()
        {
            return $"Nombre: {Cliente.NombreCliente}\n" +
            $"Dirección: {Cliente.DireccionCliente}\n" +
            $"Teléfono: {Cliente.TelefonoCliente}\n" +
            $"Referencia: {Cliente.ReferenciaDireccionCliente}";
        }

    }
}
