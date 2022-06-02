//public class Usuario_EmpresasController : ControllerBase
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
    public class Usuario_EmpresasController : ControllerBase
    {
        private IUsuario_EmpresaRepositorio _Usuario_EmpresaRepositorio;
        public Usuario_EmpresasController(IUsuario_EmpresaRepositorio repositorio)
        {
            this._Usuario_EmpresaRepositorio = repositorio;
        }

        // GET: api/ticket/5
        [HttpGet("{id_usuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Usuario_Empresa>>> GetUsuario_Empresas(int id_usuario)
        {
            try
            {
                List<Usuario_Empresa> Listado = await _Usuario_EmpresaRepositorio.GetUsuario_Empresas(id_usuario);
                return Listado;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}