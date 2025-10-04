using System.IO;
using System.Collections.Generic;
using EspacioCadete;
using PedidoApp;
using ClienteApp;

public class AccesoADatosCSV : IAccesoADatos
{
    public List<Cadete> CargarCadetes(string ruta)
    {
        var lista = new List<Cadete>();
        foreach (var linea in File.ReadAllLines(ruta))
        {
            var campos = linea.Split(',');
            lista.Add(new Cadete(
                int.Parse(campos[0]),
                campos[1],
                campos[2],
                int.Parse(campos[3])
            ));
        }
        return lista;
    }

    public List<Pedido> CargarPedidos(string ruta)
    {
        var lista = new List<Pedido>();
        foreach (var linea in File.ReadAllLines(ruta))
        {
            var campos = linea.Split(',');
            var cliente = new Cliente(campos[2], campos[3], int.Parse(campos[4]), campos[5]);
            lista.Add(new Pedido(int.Parse(campos[0]), cliente, Estado.Pendiente, campos[1]));
        }
        return lista;
    }

    public void GuardarPedidos(List<Pedido> pedidos, string ruta)
    {
        using (var writer = new StreamWriter(ruta))
        {
            foreach (var p in pedidos)
            {
                writer.WriteLine($"{p.NumeroPedido},{p.ObservacionPedido},{p.Cliente.NombreCliente},{p.Cliente.DireccionCliente},{p.Cliente.TelefonoCliente},{p.Cliente.ReferenciaDireccionCliente},{p.Estado}");
            }
        }
    }
}
