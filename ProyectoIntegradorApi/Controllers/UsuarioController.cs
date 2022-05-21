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
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public UsuarioController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // TRAER TODOS LOS REGISTROS
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> GetallUsuarios()
        {
            var lista = await _DataBase.Usuario.OrderBy(c => c.c_usuario).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO 
        // TRAER UN REGISTRO ESPECIFICO
        // GET: api/<UsuarioController>/5
        //[HttpGet("{id_usuario:int}")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var obj = await _DataBase.Usuario.FirstOrDefaultAsync(c => c.id_usuario == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region GET ESPECIFICO CON DOS PARAMETROS
        // TRAER UN REGISTRO ESPECIFICO
        // GET: api/<UsuarioController>/5
        //[HttpGet("{id_usuario:int}")]
        //[HttpGet("{id:int}")]
        //[Route("api/Usuario/{c_usuario:string}/{t_password:string}")]
        //[HttpGet("{c_usuario:string}/{t_password:string}")]
        //[HttpGet("GetUsuarioPassword/{c_usuario}/{t_password}")]
        [HttpGet("{c_usuario}/{t_password}")]
        public async Task<IActionResult> GetUsuarioPassword(string c_usuario, string t_password)
        {
            DbSet<Usuario> data = _DataBase.Usuario;
            var obj = (Usuario)_DataBase.Usuario.Where(c => c.c_usuario == c_usuario && c.t_password == t_password).First();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // CREA UN REGISTRO NUEVO
        // POST: api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
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
            return Ok("Usuario creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO
        // MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/<UsuarioController>
        //[HttpPut("{id_usuario:int}")]
        [HttpPut()]     // "{id:int}"
        public async Task<Usuario> EditarUsuario(Usuario usuario)       // int id_usuario
        {
            var result = await _DataBase.Usuario.FirstOrDefaultAsync(e => e.id_usuario == usuario.id_usuario);

            if (result != null)
            {
                result.c_usuario = usuario.c_usuario;
                result.t_password = usuario.t_password;
                result.t_nombre = usuario.t_nombre;
                result.t_correo = usuario.t_correo;
                result.f_estado = usuario.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Usuario actualizado");
            return null;
        }

        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var obj = await _DataBase.Usuario.FirstOrDefaultAsync(c => c.id_usuario == id);
            if (obj == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Usuario eliminado");
        }
        #endregion
    }
}
