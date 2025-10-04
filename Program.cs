using System;
using EspacioCadeteria;
using PedidoApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Seleccione tipo de datos (1=CSV, 2=JSON): ");
        int tipo = int.Parse(Console.ReadLine());

        IAccesoADatos acceso;
        string rutaCadetes;
        string rutaPedidos;

        if (tipo == 1)
        {
            acceso = new AccesoADatosCSV();
            rutaCadetes = "cadetes.csv";
            rutaPedidos = "pedidos.csv";
        }
        else
        {
            acceso = new AccesoADatosJSON();
            rutaCadetes = "cadetes.json";
            rutaPedidos = "pedidos.json";
        }

        // Crear cadetería y cargar datos
        Cadeteria cadeteria = new Cadeteria("Mi Cadetería", 123456);
        cadeteria.ListadoCadetes = acceso.CargarCadetes(rutaCadetes);
        cadeteria.Pedidos = acceso.CargarPedidos(rutaPedidos);

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1) Dar de alta pedido");
            Console.WriteLine("2) Asignar pedido a cadete");
            Console.WriteLine("3) Cambiar estado de pedido");
            Console.WriteLine("4) Reasignar pedido");
            Console.WriteLine("5) Mostrar informe");
            Console.WriteLine("0) Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    Console.Write("Número de pedido: ");
                    int num = int.Parse(Console.ReadLine());

                    Console.Write("Nombre cliente: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Dirección cliente: ");
                    string direccion = Console.ReadLine();

                    Console.Write("Teléfono cliente: ");
                    int tel = int.Parse(Console.ReadLine());

                    Console.Write("Referencia: ");
                    string referencia = Console.ReadLine();

                    Console.Write("Observación: ");
                    string obs = Console.ReadLine();

                    cadeteria.darDeAltaPedido(nombre, direccion, tel, referencia, num, obs);
                    break;

                case "2":
                    Console.Write("Número de pedido: ");
                    int numP = int.Parse(Console.ReadLine());

                    Console.Write("ID cadete: ");
                    int idCad = int.Parse(Console.ReadLine());

                    cadeteria.AsignarCadeteAPedido(numP, idCad);
                    break;

                case "3":
                    Console.Write("Número de pedido: ");
                    int numPCambiar = int.Parse(Console.ReadLine());

                    Console.WriteLine("Estado (0=Pendiente, 1=EnCamino, 2=Entregado, 3=Cancelado): ");
                    int estado = int.Parse(Console.ReadLine());

                    var pedido = cadeteria.Pedidos.Find(p => p.NumeroPedido == numPCambiar);
                    if (pedido != null)
                    {
                        pedido.Estado = (Estado)estado;
                        Console.WriteLine($"Estado del pedido N°{numPCambiar} actualizado a {(Estado)estado}");
                    }
                    else
                    {
                        Console.WriteLine("Pedido no encontrado.");
                    }
                    break;

                case "4":
                    Console.Write("Número de pedido: ");
                    int numPR = int.Parse(Console.ReadLine());

                    Console.Write("ID cadete destino: ");
                    int idDest = int.Parse(Console.ReadLine());

                    cadeteria.ReasignarPedido(numPR, idDest);
                    break;

                case "5":
                    Console.WriteLine("\n===== INFORME DE JORNADA =====");
                    float total = 0;

                    foreach (var c in cadeteria.ListadoCadetes)
                    {
                        float jornal = cadeteria.JornalACobrar(c.IdCadete);
                        int entregados = cadeteria.Pedidos.FindAll(p => 
                            p.CadeteAsignado != null && 
                            p.CadeteAsignado.IdCadete == c.IdCadete &&
                            p.Estado == Estado.Entregado).Count;

                        total += jornal;

                        Console.WriteLine($"Cadete: {c.NombreCadete} - Pedidos entregados: {entregados} - Jornal: ${jornal}");
                    }

                    int totalEntregados = cadeteria.Pedidos.FindAll(p => p.Estado == Estado.Entregado).Count;
                    Console.WriteLine($"TOTAL JORNADA: ${total}");
                    Console.WriteLine($"Promedio de envíos por cadete: {(float)totalEntregados / cadeteria.ListadoCadetes.Count}");
                    break;

                case "0":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
