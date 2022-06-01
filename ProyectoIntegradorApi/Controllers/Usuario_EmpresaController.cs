using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Usings
using ProyectoIntegradorApi.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorApi.Models;
using System.Collections.Generic;
using ProyectoIntegradorApi.Tickets;
using ProyectoIntegradorApi.Repositorios;
namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario_EmpresaController : ControllerBase
    {
        //private readonly ApplicationDbContext _DataBase;
        private IUsuario_EmpresaRepositorio _Usuario_EmpresaRepositorio;
        public Usuario_EmpresaController(IUsuario_EmpresaRepositorio repositorio)
        {
            this._Usuario_EmpresaRepositorio = repositorio;
        }

        // GET: api/ticket
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Usuario_Empresa>>> Get()
        {
            try
            {
                List<Usuario_Empresa> Listado = await _Usuario_EmpresaRepositorio.GetUsuario_Empresa_Listado();
                return Listado;
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
        public async Task<ActionResult<Usuario_Empresa>> Get(int id)
        {
            try
            {
                Usuario_Empresa ticket = await _Usuario_EmpresaRepositorio.GetUsuario_EmpresaId(id);
                return ticket;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/ticket
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Post(Usuario_Empresa entidad)
        {
            try
            {
                bool result = await _Usuario_EmpresaRepositorio.Grabar(entidad);
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Usuario_Empresa
        [HttpPut()]
        public async Task<bool> Put(Usuario_Empresa entidad)
        {
            try
            {
                bool result = await _Usuario_EmpresaRepositorio.Grabar(entidad);
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        #endregion

        // DELETE: api/ticket/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _Usuario_EmpresaRepositorio.Eliminar(id);
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
