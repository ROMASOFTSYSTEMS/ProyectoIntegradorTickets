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
    public class Tipo_TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public Tipo_TicketController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Tipo_Ticket
        [HttpGet]
        public async Task<IActionResult> GetallTipo_Tickets()
        {
            var lista = await _DataBase.Tipo_Ticket.OrderBy(c => c.t_tipo_ticket).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // GET: api/Tipo_Ticket/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTipo_Ticket(int id)
        {
            var obj = await _DataBase.Tipo_Ticket.FirstOrDefaultAsync(c => c.id_tipo_ticket == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // POST: api/Tipo_Ticket
        [HttpPost]
        public async Task<IActionResult> CrearTipo_Ticket([FromBody] Tipo_Ticket entidad)
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
            return Ok("Tipo_Ticket creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Tipo_Ticket
        [HttpPut()]     // "{id:int}"
        public async Task<Tipo_Ticket> EditarTipo_Ticket(Tipo_Ticket entidad)
        {
            var result = await _DataBase.Tipo_Ticket.FirstOrDefaultAsync(e => e.id_tipo_ticket == entidad.id_tipo_ticket);

            if (result != null)
            {
                result.t_tipo_ticket = entidad.t_tipo_ticket;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Tipo_Ticket actualizada");
            return null;
        }
        #endregion
        #region DELETE ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTipo_Ticket(int id)
        {
            var obj = await _DataBase.Tipo_Ticket.FirstOrDefaultAsync(c => c.id_tipo_ticket == id);
            if (obj == null)
            {
                return BadRequest("Tipo_Ticket no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Tipo_Ticket eliminado");
        }
        #endregion
    }
}