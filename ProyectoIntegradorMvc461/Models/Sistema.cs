using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Sistema
    {
        public int id_sistema { get; set; }
        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string t_sistema { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }
    }
}