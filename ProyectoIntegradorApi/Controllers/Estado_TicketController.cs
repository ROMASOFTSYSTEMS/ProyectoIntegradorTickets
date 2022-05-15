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
    public class Estado_TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public Estado_TicketController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Estado_Ticket
        [HttpGet]
        public async Task<IActionResult> GetallEstado_Tickets()
        {
            var lista = await _DataBase.Estado_Ticket.OrderBy(c => c.t_estado_ticket).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // GET: api/Estado_Ticket/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEstado_Ticket(int id)
        {
            var obj = await _DataBase.Estado_Ticket.FirstOrDefaultAsync(c => c.id_estado_ticket == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // POST: api/Estado_Ticket
        [HttpPost]
        public async Task<IActionResult> CrearEstado_Ticket([FromBody] Estado_Ticket entidad)
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
            return Ok("Estado_Ticket creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Estado_Ticket
        [HttpPut()]     // "{id:int}"
        public async Task<Estado_Ticket> EditarEstado_Ticket(Estado_Ticket entidad)
        {
            var result = await _DataBase.Estado_Ticket.FirstOrDefaultAsync(e => e.id_estado_ticket == entidad.id_estado_ticket);

            if (result != null)
            {
                result.t_estado_ticket = entidad.t_estado_ticket;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Estado_Ticket actualizada");
            return null;
        }
        #endregion
        #region DELETE ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEstado_Ticket(int id)
        {
            var obj = await _DataBase.Estado_Ticket.FirstOrDefaultAsync(c => c.id_estado_ticket == id);
            if (obj == null)
            {
                return BadRequest("Estado_Ticket no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Estado_Ticket eliminado");
        }
        #endregion
    }
}