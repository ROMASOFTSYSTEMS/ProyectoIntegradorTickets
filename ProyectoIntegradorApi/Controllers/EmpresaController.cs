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
    public class EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public EmpresaController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Empresa
        [HttpGet]
        public async Task<IActionResult> GetallEmpresas()
        {
            var lista = await _DataBase.Empresa.OrderBy(c => c.t_empresa).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // GET: api/Empresa/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmpresa(int id)
        {
            var obj = await _DataBase.Empresa.FirstOrDefaultAsync(c => c.id_empresa == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // POST: api/Empresa
        [HttpPost]
        public async Task<IActionResult> CrearEmpresa([FromBody] Empresa entidad)
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
            return Ok("Empresa creada");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Empresa
        [HttpPut()]     // "{id:int}"
        public async Task<Empresa> EditarEmpresa(Empresa entidad)       // int id_empresa
        {
            var result = await _DataBase.Empresa.FirstOrDefaultAsync(e => e.id_empresa == entidad.id_empresa);

            if (result != null)
            {
                result.t_empresa = entidad.t_empresa;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Empresa actualizada");
            return null;
        }
        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEmpresa(int id)
        {
            var obj = await _DataBase.Empresa.FirstOrDefaultAsync(c => c.id_empresa == id);
            if (obj == null)
            {
                return BadRequest("Empresa no encontrada");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Empresa eliminada");
        }
        #endregion
    }
}
