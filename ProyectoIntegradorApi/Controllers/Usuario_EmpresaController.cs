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
    public class Usuario_EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public Usuario_EmpresaController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Usuario_Empresa
        [HttpGet]
        public async Task<IActionResult> GetallUsuario_Empresa()
        {
            var lista = await _DataBase.Usuario_Empresa.OrderBy(c => c.id_usuario_empresa).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO 
        [HttpGet("{id_usuario:int}")]
        public async Task<IActionResult> GetUsuario_Empresas(int id_usuario)
        {
            var lista = await _DataBase.Usuario_Empresa.Where(c => c.id_usuario == id_usuario).OrderBy(c => c.id_usuario).ToListAsync();
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO CON DOS PARAMETROS
        // GET: api/Usuario_Empresa/1/1
        [HttpGet("{id_usuario:int}/{id_empresa:int}")]
        public async Task<IActionResult> GetUsuario_Empresa(int id_usuario, int id_empresa)
        {
            var obj = await _DataBase.Usuario_Empresa.FirstOrDefaultAsync(c => c.id_usuario == id_usuario && c.id_empresa == id_empresa);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // CREA UN REGISTRO NUEVO
        // POST: api/Usuario_Empresa
        [HttpPost]
        public async Task<IActionResult> CrearUsuario_Empresa([FromBody] Usuario_Empresa entidad)
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
            return Ok("Usuario_Empresa creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO
        // PUT: api/Usuario_Empresa
        [HttpPut()]
        public async Task<Usuario_Empresa> EditarUsuario_Empresa(Usuario_Empresa entidad)
        {
            var result = await _DataBase.Usuario_Empresa.FirstOrDefaultAsync(e => e.id_usuario_empresa == entidad.id_usuario_empresa);

            if (result != null)
            {
                result.id_usuario = entidad.id_usuario;
                result.id_empresa = entidad.id_empresa;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Usuario_Empresa actualizado");
            return null;
        }

        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuario_Empresa(int id)
        {
            var obj = await _DataBase.Usuario_Empresa.FirstOrDefaultAsync(c => c.id_usuario_empresa == id);
            if (obj == null)
            {
                return BadRequest("Usuario_Empresa no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Usuario_Empresa eliminado");
        }
        #endregion
    }
}
