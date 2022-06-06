using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using ProyectoIntegradorApi.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;
//using ProyectoIntegradorApi.DAL.Tickets;
using ProyectoIntegradorApi.Tickets;
using System.Collections.Generic;


namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsPorEmpresaController : ControllerBase
    {
        private ITicketsPorEmpresaRepositorio _TicketPorEmpresaRepositorio;
        public TicketsPorEmpresaController(ITicketsPorEmpresaRepositorio repositorio)
        {
            this._TicketPorEmpresaRepositorio = repositorio;
        }
        //// GET: api/ticket
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<List<Ticket>>> Get()
        //{
        //    try
        //    {
        //        List<Ticket> tickets = await _TicketPorEmpresaRepositorio.GetListadoTicketsPorEmpresa();
        //        return tickets;
        //    }
        //    catch (System.Exception)
        //    {
        //        return BadRequest();
        //    }
        //}
        
        // GET: api/ticket/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Ticket>>> Get(int id)
        {
            try
            {
                List<Ticket> tickets = await _TicketPorEmpresaRepositorio.GetListadoTicketsPorEmpresa(id);
                return tickets;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
