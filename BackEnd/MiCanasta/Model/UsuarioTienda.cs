﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiCanasta.MiCanasta.Model
{
    public class UsuarioTienda
    {
        public int UsuarioTiendaId { get; set; }

        public int Dni { get; set; }
        
        public Usuario Usuario { get; set; }

        public int RolPerfilId { get; set; }
        //public RolPerfil RolPerfil { get; set; }

        public int TiendaId { get; set; }

        //public Tienda Tienda { get; set; }
    }
}
