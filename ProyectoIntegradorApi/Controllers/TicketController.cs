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
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _DataBase;
        public TicketController(ApplicationDbContext db)
        {
            _DataBase = db;
        }

        // METODOS EN GENERAL 
        #region GET TODOS
        // GET: api/Ticket
        [HttpGet]
        public async Task<IActionResult> GetallTickets()
        {
            var lista = await _DataBase.Ticket.OrderBy(c => c.id_ticket).ToListAsync();
            return Ok(lista);
        }
        #endregion
        #region GET ESPECIFICO
        // GET: api/Ticket/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var obj = await _DataBase.Ticket.FirstOrDefaultAsync(c => c.id_ticket == id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        #endregion
        #region POST NUEVO
        // POST: api/Ticket
        [HttpPost]
        public async Task<IActionResult> CrearTicket([FromBody] Ticket entidad)
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
            return Ok("Ticket creado");
        }

        #endregion
        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Ticket
        [HttpPut()]     // "{id:int}"
        public async Task<Ticket> EditarTicket(Ticket entidad)
        {
            var result = await _DataBase.Ticket.FirstOrDefaultAsync(e => e.id_tipo_ticket == entidad.id_tipo_ticket);

            if (result != null)
            {
                //result.id_ticket = entidad.id_ticket;
                result.id_empresa = entidad.id_empresa;
                result.id_usuario = entidad.id_usuario;
                result.id_sistema = entidad.id_sistema;
                result.id_modulo = entidad.id_modulo;
                result.id_tipo_ticket = entidad.id_tipo_ticket;
                result.id_estado_ticket = entidad.id_estado_ticket;
                result.t_observacion = entidad.t_observacion;
                result.f_estado = entidad.f_estado;
                await _DataBase.SaveChangesAsync();
                return result;
            }
            //return Ok("Ticket actualizada");
            return null;
        }
        #endregion
        #region DELETE ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTicket(int id)
        {
            var obj = await _DataBase.Ticket.FirstOrDefaultAsync(c => c.id_ticket == id);
            if (obj == null)
            {
                return BadRequest("Ticket no encontrado");
            }
            _DataBase.Remove(obj);
            await _DataBase.SaveChangesAsync();
            return Ok("Ticket eliminado");
        }
        #endregion
    }
}