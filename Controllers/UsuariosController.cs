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
using evaluacionTecnica1.Models;

namespace pruebaapiconviews.Controllers
{
    public class UsuariosController : ApiController
    {
        private TablasDBcontext db = new TablasDBcontext();

        // GET: api/Usuarios
        [HttpGet]
        [Route("GetUser")]
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
        [HttpGet]
        [Route("GetUserforLogin/{id}")]
        public async Task<IHttpActionResult> LoginUsuarios(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);

            loginModel h = new loginModel();

            h.Usuario_Nombre = usuario.Usuario_Nombre;
            h.Contraseña = usuario.Contraseña;

            return Ok(h);
        }

        // PUT: api/Usuarios/5
        [HttpPut]
        [ResponseType(typeof(Usuario))]
        [Route("putUser")]
        public async Task<IHttpActionResult> PutUsuario(Usuario usuario)
        {
            try
            {
                usuario.Fecha_Transaccion = DateTime.Now;
                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

        // POST: api/Usuarios
        [HttpPost]
        [ResponseType(typeof(Usuario))]
        [Route("postUser")]
        public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        {
            try
            {
                usuario.Fecha_Transaccion = DateTime.Now;
                db.Usuarios.Add(usuario);

                await db.SaveChangesAsync();
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
            
        }

        // DELETE: api/Usuarios/5
        [HttpDelete]
        [ResponseType(typeof(Usuario))]
        [Route("deleteUser/{id}")]
        public async Task<IHttpActionResult> DeleteUsuario( int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(usuario);
        }
    }
}