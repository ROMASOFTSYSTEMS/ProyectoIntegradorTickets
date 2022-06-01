using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Usuario_Perfil
    {
        public int id_usuario_perfil { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Usuario")]
        public int id_usuario { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Perfil")]
        public string c_usuario { get; set; }
        public int id_perfil { get; set; }
        public string t_perfil { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }

    }
}