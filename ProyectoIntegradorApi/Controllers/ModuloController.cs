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
    public class ModuloController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public ModuloController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // TRAER TODOS LOS REGISTROS
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> GetallModulos()
        {
            var lista = await _DataBase.Modulo.OrderBy(c => c.t_modulo).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // TRAER UN REGISTRO ESPECIFICO
        // GET: api/<UsuarioController>/5
        //[HttpGet("{id_modulo:int}")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetModulo(int id)
        {
            var obj = await _DataBase.Modulo.FirstOrDefaultAsync(c => c.id_modulo == id);
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
        public async Task<IActionResult> CrearModulo([FromBody] Modulo entidad)
        {
            if (entidad == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _DataBase.AddAsync(entidad);
            await _DataBase.SaveChangesAsync();
            return Ok("Modulo creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO
        // MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/<ModuloController>
        [HttpPut()]
        public async Task<Modulo> EditarModulo(Modulo entidad)
        {
            var result = await _DataBase.Modulo.FirstOrDefaultAsync(e => e.id_modulo == entidad.id_modulo);

            if (result != null)
            {
                result.t_modulo = entidad.t_modulo;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Modulo actualizada");
            return null;
        }

        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id_modulo}")]
        public async Task<IActionResult> EliminarModulo(int id_modulo)
        {
            var obj = await _DataBase.Modulo.FirstOrDefaultAsync(c => c.id_modulo == id_modulo);
            if (obj == null)
            {
                return BadRequest("Modulo no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Modulo eliminado");
        }
        #endregion
    }
}