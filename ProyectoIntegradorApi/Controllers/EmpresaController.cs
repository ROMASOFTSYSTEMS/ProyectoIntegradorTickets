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
        // TRAER TODOS LOS REGISTROS
        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<IActionResult> GetallEmpresas()
        {
            var lista = await _DataBase.Empresa.OrderBy(c => c.t_empresa).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // TRAER UN REGISTRO ESPECIFICO
        // GET: api/<UsuarioController>/5
        //[HttpGet("{id_empresa:int}")]
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
        // CREA UN REGISTRO NUEVO
        // POST: api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> CrearEmpresa([FromBody] Empresa empresa)
        {
            if (empresa == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _DataBase.AddAsync(empresa);
            await _DataBase.SaveChangesAsync();
            return Ok("Empresa creada");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO
        // MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/<UsuarioController>
        //[HttpPut("{id_empresa:int}")]
        [HttpPut()]     // "{id:int}"
        public async Task<Empresa> EditarEmpresa(Empresa empresa)       // int id_empresa
        {
            var result = await _DataBase.Empresa.FirstOrDefaultAsync(e => e.id_empresa == empresa.id_empresa);

            if (result != null)
            {
                result.t_empresa = empresa.t_empresa;
                #region Back
                //result.LastName = employee.LastName;
                //result.Email = employee.Email;
                //result.DateOfBrith = employee.DateOfBrith;
                //result.Gender = employee.Gender;
                //result.DepartmentId = employee.DepartmentId;
                //result.PhotoPath = employee.PhotoPath;
                #endregion
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Empresa actualizada");
            return null;
        }

        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id_empresa}")]
        public async Task<IActionResult> EliminarEmpresa(int id_empresa)
        {
            var obj = await _DataBase.Empresa.FirstOrDefaultAsync(c => c.id_empresa == id_empresa);
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
