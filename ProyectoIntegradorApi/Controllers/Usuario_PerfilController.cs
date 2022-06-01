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
    public class Usuario_PerfilController : ControllerBase
    {
        //private readonly ApplicationDbContext _DataBase;
        private IUsuario_PerfilRepositorio _Usuario_PerfilRepositorio;
        public Usuario_PerfilController(IUsuario_PerfilRepositorio repositorio)
        {
            this._Usuario_PerfilRepositorio = repositorio;
        }

        // GET: api/ticket
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Usuario_Perfil>>> Get()
        {
            try
            {
                List<Usuario_Perfil> Listado = await _Usuario_PerfilRepositorio.GetUsuario_Perfil_Listado();
                return Listado;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        //// GET: api/ticket/5
        //[HttpGet("{id_usuario}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<List<Usuario_Perfil>>> GetUsuario_Perfiles(int id_usuario)
        //{
        //    try
        //    {
        //        List<Usuario_Perfil> Listado2 = await _Usuario_PerfilRepositorio.GetUsuario_Perfiles(id_usuario);
        //        return Listado2;
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
        public async Task<ActionResult<Usuario_Perfil>> Get(int id)
        {
            try
            {
                Usuario_Perfil entidad = await _Usuario_PerfilRepositorio.GetUsuario_PerfilId(id);
                return entidad;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> Post(Usuario_Perfil entidad)
        {
            try
            {
                bool result = await _Usuario_PerfilRepositorio.Grabar(entidad);
                return result;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        #region PUT ACTUALIZA REGISTRO - MODIFICA UN REGISTRO ESPECIFICO
        // PUT: api/Usuario_Perfil
        [HttpPut()]
        public async Task<bool> Put(Usuario_Perfil entidad)
        {
            try
            {
                bool result = await _Usuario_PerfilRepositorio.Grabar(entidad);
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
                bool result = await _Usuario_PerfilRepositorio.Eliminar(id);
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
