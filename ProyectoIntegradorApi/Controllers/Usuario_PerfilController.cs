using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using ProyectoIntegradorApi.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;

namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario_PerfilController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public Usuario_PerfilController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Usuario_Perfil
        [HttpGet]
        public async Task<IActionResult> GetallUsuario_Perfil()
        {
            var lista = await _DataBase.Usuario_Perfil.OrderBy(c => c.id_usuario_perfil).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO 
        [HttpGet("{id_usuario:int}")]
        public async Task<IActionResult> GetUsuario_Perfiles(int id_usuario)
        {
            var lista = await _DataBase.Usuario_Perfil.Where(c => c.id_usuario == id_usuario).OrderBy(c => c.id_usuario).ToListAsync();
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO CON DOS PARAMETROS
        // GET: api/Usuario_Perfil/1/1
        [HttpGet("{id_usuario:int}/{id_perfil:int}")]
        public async Task<IActionResult> GetUsuario_PerfilUsuario_Perfil(int id_usuario, int id_perfil)
        {
            var obj = await _DataBase.Usuario_Perfil.FirstOrDefaultAsync(c => c.id_usuario == id_usuario && c.id_perfil == id_perfil);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // CREA UN REGISTRO NUEVO
        // POST: api/Usuario_Perfil
        [HttpPost]
        public async Task<IActionResult> CrearUsuario_Perfil([FromBody] Usuario_Perfil usuario)
        {
            if (usuario == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _DataBase.AddAsync(usuario);
            await _DataBase.SaveChangesAsync();
            return Ok("Usuario_Perfil creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO
        // PUT: api/Usuario_Perfil
        [HttpPut()]
        public async Task<Usuario_Perfil> EditarUsuario_Perfil(Usuario_Perfil entidad)
        {
            var result = await _DataBase.Usuario_Perfil.FirstOrDefaultAsync(e => e.id_usuario_perfil == entidad.id_usuario_perfil);

            if (result != null)
            {
                result.id_usuario = entidad.id_usuario;
                result.id_perfil = entidad.id_perfil;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Usuario_Perfil actualizado");
            return null;
        }

        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario_Perfil(int id)
        {
            var obj = await _DataBase.Usuario_Perfil.FirstOrDefaultAsync(c => c.id_usuario_perfil == id);
            if (obj == null)
            {
                return BadRequest("Usuario_Perfil no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Usuario_Perfil eliminado");
        }
        #endregion
    }
}
