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
    public class SistemaController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public SistemaController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // TRAER TODOS LOS REGISTROS
        // GET: api/Sistema
        [HttpGet]
        public async Task<IActionResult> GetallSistemas()
        {
            var lista = await _DataBase.Sistema.OrderBy(c => c.t_sistema).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // TRAER UN REGISTRO ESPECIFICO
        // GET: api/Sistema/5
        //[HttpGet("{id_empresa:int}")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSistema(int id)
        {
            var obj = await _DataBase.Sistema.FirstOrDefaultAsync(c => c.id_sistema== id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // CREA UN REGISTRO NUEVO
        // POST: api/Sistema
        [HttpPost]
        public async Task<IActionResult> CrearSistema([FromBody] Sistema entidad)
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
            return Ok("Sistema creada");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO
        // MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Sistema
        //[HttpPut("{id_empresa:int}")]
        [HttpPut()]     // "{id:int}"
        public async Task<Sistema> EditarSistema(Sistema entidad)
        {
            var result = await _DataBase.Sistema.FirstOrDefaultAsync(e => e.id_sistema == entidad.id_sistema);

            if (result != null)
            {
                result.t_sistema = entidad.t_sistema;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Sistema actualizada");
            return null;
        }

        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id_sistema}")]
        public async Task<IActionResult> EliminarSistema(int id_sistema)
        {
            var obj = await _DataBase.Sistema.FirstOrDefaultAsync(c => c.id_sistema == id_sistema);
            if (obj == null)
            {
                return BadRequest("Sistema no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Sistema eliminado");
        }
        #endregion
    }
}