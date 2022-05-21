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
    public class PerfilController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public PerfilController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Perfil
        [HttpGet]
        public async Task<IActionResult> GetallPerfils()
        {
            var lista = await _DataBase.Perfil.OrderBy(c => c.t_perfil).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // GET: api/Perfil/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPerfil(int id)
        {
            var obj = await _DataBase.Perfil.FirstOrDefaultAsync(c => c.id_perfil == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // POST: api/Perfil
        [HttpPost]
        public async Task<IActionResult> CrearPerfil([FromBody] Perfil entidad)
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
            return Ok("Perfil creada");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Perfil
        [HttpPut()]     // "{id:int}"
        public async Task<Perfil> EditarPerfil(Perfil entidad) 
        {
            var result = await _DataBase.Perfil.FirstOrDefaultAsync(e => e.id_perfil == entidad.id_perfil);

            if (result != null)
            {
                result.t_perfil = entidad.t_perfil;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Perfil actualizada");
            return null;
        }
        #endregion
        #region DELETE ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPerfil(int id)
        {
            var obj = await _DataBase.Perfil.FirstOrDefaultAsync(c => c.id_perfil == id);
            if (obj == null)
            {
                return BadRequest("Perfil no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Perfil eliminado");
        }
        #endregion
    }
}