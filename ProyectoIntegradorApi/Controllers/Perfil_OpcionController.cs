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
    public class Perfil_OpcionController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public Perfil_OpcionController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // TRAER TODOS LOS REGISTROS
        // GET: api/<Perfil_OpcionController>
        [HttpGet]
        public async Task<IActionResult> GetallPerfil_Opcion()
        {
            var lista = await _DataBase.Perfil_Opcion.OrderBy(c => c.id_perfil_opcion).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO 
        [HttpGet("{id_perfil:int}")]
        public async Task<IActionResult> GetPerfil_Opciones(int id_perfil)
        {
            var lista = await _DataBase.Perfil_Opcion.Where(c => c.id_perfil == id_perfil).OrderBy(c => c.id_perfil_opcion).ToListAsync();

            //var obj = await _DataBase.Perfil_Opcion.Fi .FirstOrDefaultAsync(c => c.id_perfil == id_perfil);
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO CON DOS PARAMETROS
        // TRAER UN REGISTRO ESPECIFICO
        // GET: api/<Perfil_OpcionController>/5
        //[HttpGet("{id_usuario:int}")]
        //[HttpGet("{id:int}")]
        //[Route("api/Perfil_Opcion/{c_usuario:string}/{t_password:string}")]
        //[HttpGet("{c_usuario:string}/{t_password:string}")]
        //[HttpGet("GetPerfil_OpcionPassword/{c_usuario}/{t_password}")]
        [HttpGet("{id_perfil:int}/{id_opcion:int}")]
        public async Task<IActionResult> GetPerfil_OpcionPerfil_Opcion(int id_perfil, int id_opcion)
        {
            //var obj = _DataBase.Perfil_Opcion.Where(c => c.id_perfil == id_perfil && c.id_opcion == id_opcion).First();
            //if (obj == null)
            //{
            //    return NotFound();
            //}
            //return Ok(obj);
            var obj = await _DataBase.Perfil_Opcion.FirstOrDefaultAsync(c => c.id_perfil == id_perfil && c.id_opcion == id_opcion);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // CREA UN REGISTRO NUEVO
        // POST: api/<Perfil_OpcionController>
        [HttpPost]
        public async Task<IActionResult> CrearPerfil_Opcion([FromBody] Perfil_Opcion usuario)
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
            return Ok("Perfil_Opcion creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO
        // MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/<Perfil_OpcionController>
        //[HttpPut("{id_usuario:int}")]
        [HttpPut()]     // "{id:int}"
        public async Task<Perfil_Opcion> EditarPerfil_Opcion(Perfil_Opcion perfilopcion) 
        {
            var result = await _DataBase.Perfil_Opcion.FirstOrDefaultAsync(e => e.id_perfil_opcion == perfilopcion.id_perfil_opcion);

            if (result != null)
            {
                result.id_perfil = perfilopcion.id_perfil;
                result.id_opcion = perfilopcion.id_opcion;
                result.f_estado = perfilopcion.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Perfil_Opcion actualizado");
            return null;
        }

        #endregion
        #region ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPerfil_Opcion(int id)
        {
            var obj = await _DataBase.Perfil_Opcion.FirstOrDefaultAsync(c => c.id_perfil_opcion == id);
            if (obj == null)
            {
                return BadRequest("Perfil_Opcion no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Perfil_Opcion eliminado");
        }
        #endregion
    }
}
