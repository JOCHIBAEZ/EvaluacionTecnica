using pruebaapiconviews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pruebaapiconviews.capaDatos
{
    public class TablasDBcontext : DbContext
    {
        public TablasDBcontext() : base(cadenaConexion.cConexion)
        {
            
        }
        public System.Data.Entity.DbSet<Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<Rol> Roles { get; set; }
    }
}