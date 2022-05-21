using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Estado
    {
        public int id_estado { get; set; }
        [Required(ErrorMessage = "Debe ingresar Descripcion")]
        public string t_estado { get; set; }
    }
}