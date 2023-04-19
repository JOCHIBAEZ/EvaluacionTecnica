using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using pruebaapiconviews.Models;
using pruebaapiconviews.capaDatos;

namespace pruebaapiconviews.Controllers
{
    public class RolController : ApiController
    {
        private TablasDBcontext db = new TablasDBcontext();

        // GET: api/Rol
        [HttpGet]
        [Route("GetRol")]
        public IQueryable<Rol> GetRoles()
        {
            return db.Roles;
        }

        // GET: api/Rol/5
        [ResponseType(typeof(Rol))]
        [HttpGet]
        [Route("GetRol/{id}")]
        public async Task<IHttpActionResult> GetRol(int id)
        {
            Rol rol = await db.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        // PUT: api/Rol/5
        [ResponseType(typeof(Rol))]
        [HttpPut]
        [Route("putRol")]
        public async Task<IHttpActionResult> PutRol( Rol rol)
        {
            try
            {
                db.Entry(rol).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(rol);
            }
            catch (Exception e)
            {

                return Ok(e);
            }
            
         
        }

        // POST: api/Rol
        [ResponseType(typeof(Rol))]
        [HttpPost]
        [Route("postRol")]
        public async Task<IHttpActionResult> PostRol(Rol rol)
        {
            try
            {
                rol.Fecha_Transaccion = DateTime.Now;
                db.Roles.Add(rol);

                await db.SaveChangesAsync();
                return Ok(rol);
            }
            catch (Exception e)
            {

                return Ok(e);
            }
            
        }

        // DELETE: api/Rol/5
        [ResponseType(typeof(Rol))]
        [HttpDelete]
        [Route("deleteRol/{id}")]
        public async Task<IHttpActionResult> DeleteRol(int id)
        {
            Rol rol = await db.Roles.FindAsync(id);
            db.Roles.Remove(rol);
            await db.SaveChangesAsync();

            return Ok(rol);
        }
    }
}