using System;

namespace ClienteApp
{
    public class Cliente //Declaro propiedades de cliente
    {
        public string NombreCliente { get; set; }
        public string DireccionCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string ReferenciaDireccionCliente { get; set; }

        public Cliente(string nombre, string direccion, int telefono, string referenciaDireccion) //Constructores de cliente
        {   
            NombreCliente = nombre;
            DireccionCliente = direccion;
            TelefonoCliente = telefono;
            ReferenciaDireccionCliente = referenciaDireccion;
        }
    }
}
