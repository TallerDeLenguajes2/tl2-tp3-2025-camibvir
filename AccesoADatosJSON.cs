using System.Text.Json;
using System.Collections.Generic;
using EspacioCadete;
using PedidoApp;
using ClienteApp;

public class AccesoADatosJSON : IAccesoADatos
{
    public List<Cadete> CargarCadetes(string ruta)
    {
        string json = File.ReadAllText(ruta);
        return JsonSerializer.Deserialize<List<Cadete>>(json);
    }

    public List<Pedido> CargarPedidos(string ruta)
    {
        string json = File.ReadAllText(ruta);
        return JsonSerializer.Deserialize<List<Pedido>>(json);
    }

    public void GuardarPedidos(List<Pedido> pedidos, string ruta)
    {
        string json = JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ruta, json);
    }
}
