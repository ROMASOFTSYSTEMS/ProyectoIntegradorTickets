using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Empresa
    {
        public int id_empresa { get; set; }
        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string t_empresa { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }
        public Estado dataEstado { get; set; }
    }
}