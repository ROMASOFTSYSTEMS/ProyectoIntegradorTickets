using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Usings
using ProyectoIntegradorApi.Models;
using ProyectoIntegradorApi.Tickets;
//using ProyectoIntegradorApi.Repositorios;

namespace ProyectoIntegradorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario_PerfilesController : ControllerBase
    {
        private IUsuario_PerfilRepositorio _Usuario_PerfilRepositorio;
        public Usuario_PerfilesController(IUsuario_PerfilRepositorio repositorio)
        {
            this._Usuario_PerfilRepositorio = repositorio;
        }

        // GET: api/ticket/5
        [HttpGet("{id_usuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Usuario_Perfil>>> GetUsuario_Perfiles(int id_usuario)
        {
            try
            {
                List<Usuario_Perfil> Listado = await _Usuario_PerfilRepositorio.GetUsuario_Perfiles(id_usuario);
                return Listado;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
