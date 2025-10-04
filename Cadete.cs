using System;
using PedidoApp;
using ClienteApp;
using System.Collections.Generic;

namespace EspacioCadete
{
    public class Cadete
    {
        public int IdCadete {get; set;}
        public string NombreCadete {get; set;}
        public string DireccionCadete {get; set;}
        public int TelefonoCadete {get; set;}

        public Cadete(int id, string nombre, string direccion, int telefono)
        {
            IdCadete = id;
            NombreCadete = nombre;
            DireccionCadete = direccion;
            TelefonoCadete = telefono;
        }
    }
}