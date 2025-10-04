using System.Collections.Generic;
using EspacioCadete;
using PedidoApp;
//Es como un "contrato" que define qué operaciones debe tener cualquier clase que maneje archivos de datos (CSV o JSON).
public interface IAccesoADatos
{
    List<Cadete> CargarCadetes(string ruta);
    List<Pedido> CargarPedidos(string ruta);
    void GuardarPedidos(List<Pedido> pedidos, string ruta);
}
