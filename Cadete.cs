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

        public Cadete(int IdCadete, string NombreCadete, string DireccionCadete, int TelefonoCadete)
        {
            this.IdCadete = IdCadete;
            this.NombreCadete = NombreCadete;
            this.DireccionCadete = DireccionCadete;
            this.TelefonoCadete = TelefonoCadete;
        }
    }
}