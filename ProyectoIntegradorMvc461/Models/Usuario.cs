using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar Usuario")]
        public string c_usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar Password")]
        public string t_password { get; set; }
        [Required(ErrorMessage = "Debe ingresar Nombre")]
        public string t_nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar correo electrónico")]
        public string t_correo { get; set; }
        [Required(ErrorMessage = "Debe seleccionar estado")]
        public int f_estado{ get; set; }
    }
}