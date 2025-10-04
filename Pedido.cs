using System;
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
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string ReferenciaDireccionCliente { get; set; }
        public string? ObservacionPedido { get; set; }
        public Estado Estado { get; set; }
        public int? IdCadeteAsignado { get; set; }

        // Constructor vacío (para JSON)
        public Pedido() {}

        // Constructor completo
        public Pedido(int numeroPedido, string nombreCliente, string direccionCliente, int telefonoCliente, string referencia, Estado estado = Estado.Pendiente, string? observacion = null)
        {
            NumeroPedido = numeroPedido;
            NombreCliente = nombreCliente;
            DireccionCliente = direccionCliente;
            TelefonoCliente = telefonoCliente;
            ReferenciaDireccionCliente = referencia;
            Estado = estado;
            ObservacionPedido = observacion;
            IdCadeteAsignado = null;
        }
        public string VerDireccionCliente()
        {
            return DireccionCliente;
        }

        public string VerDatosCliente()
        {
            return $"Nombre: {NombreCliente}\n" +
                   $"Dirección: {DireccionCliente}\n" +
                   $"Teléfono: {TelefonoCliente}\n" +
                   $"Referencia: {ReferenciaDireccionCliente}";
        }
    }
}
