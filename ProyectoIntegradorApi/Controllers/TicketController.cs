using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using ProyectoIntegradorApi.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;
using ProyectoIntegradorApi.DAL.Tickets;
using System.Collections.Generic;

namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        //private readonly ApplicationDbContext _DataBase;
        private ITicketRepositorio _TicketRepositorio;
        public TicketController(ITicketRepositorio repositorio)
        {
            this._TicketRepositorio = repositorio;
        }
        #region Anterior
        //// METODOS EN GENERAL 
        //#region GET TODOS
        //// GET: api/Ticket
        //[HttpGet]
        //public async Task<IActionResult> GetallTickets()
        //{
        //    var lista = await _DataBase.Ticket.OrderBy(c => c.id_ticket).ToListAsync();
        //    return Ok(lista);
        //}
        //#endregion
        //#region GET ESPECIFICO
        //// GET: api/Ticket/5
        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetTicket(int id)
        //{
        //    var obj = await _DataBase.Ticket.FirstOrDefaultAsync(c => c.id_ticket == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(obj);
        //}
        //#endregion
        //#region POST NUEVO
        //// POST: api/Ticket
        //[HttpPost]
        //public async Task<IActionResult> CrearTicket([FromBody] Ticket entidad)
        //{
        //    if (entidad == null)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    await _DataBase.AddAsync(entidad);
        //    await _DataBase.SaveChangesAsync();
        //    return Ok("Ticket creado");
        //}

        //#endregion
        //#region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        //// PUT: api/Ticket
        //[HttpPut()]     // "{id:int}"
        //public async Task<Ticket> EditarTicket(Ticket entidad)
        //{
        //    var result = await _DataBase.Ticket.FirstOrDefaultAsync(e => e.id_tipo_ticket == entidad.id_tipo_ticket);

        //    if (result != null)
        //    {
        //        //result.id_ticket = entidad.id_ticket;
        //        result.id_empresa = entidad.id_empresa;
        //        result.id_usuario = entidad.id_usuario;
        //        result.id_sistema = entidad.id_sistema;
        //        result.id_modulo = entidad.id_modulo;
        //        result.id_tipo_ticket = entidad.id_tipo_ticket;
        //        result.id_estado_ticket = entidad.id_estado_ticket;
        //        result.t_observacion = entidad.t_observacion;
        //        result.f_estado = entidad.f_estado;
        //        await _DataBase.SaveChangesAsync();
        //        return result;
        //    }
        //    //return Ok("Ticket actualizada");
        //    return null;
        //}
        //#endregion
        //#region DELETE ELIMINAR REGISTRO
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> EliminarTicket(int id)
        //{
        //    var obj = await _DataBase.Ticket.FirstOrDefaultAsync(c => c.id_ticket == id);
        //    if (obj == null)
        //    {
        //        return BadRequest("Ticket no encontrado");
        //    }
        //    _DataBase.Remove(obj);
        //    await _DataBase.SaveChangesAsync();
        //    return Ok("Ticket eliminado");
        //}
        //#endregion
        #endregion

        // GET: api/ticket
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<ProyectoIntegradorApi.DAL.Models.Ticket>>> Get()
        {
            try
            {
                List<ProyectoIntegradorApi.DAL.Models.Ticket> tickets = await _TicketRepositorio.GetListadoTickets();
                return tickets;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/ticket/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProyectoIntegradorApi.DAL.Models.Ticket>> Get(int id)
        {
            try
            {
                DAL.Models.Ticket ticket = await _TicketRepositorio.GetTicketId(id);
                return ticket;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/ticket
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<bool> Post(DAL.Models.Ticket ticket)
        //{
        //    try
        //    {
        //        bool result = await _TicketRepositorio.Grabar(ticket);
        //        return result;
        //    }
        //    catch (System.Exception)
        //    {
        //        return false;
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DAL.Models.Ticket entidad)
        {
            if (entidad == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await _TicketRepositorio.Grabar(entidad);
            //await _DataBase.AddAsync(entidad);
            //await _DataBase.SaveChangesAsync();
            return Ok("Modulo creado");
        }


        // DELETE: api/ticket/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _TicketRepositorio.Eliminar(id);
                if (!result)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}