using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Usuario_Empresa
    {
        public int id_usuario_empresa { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Usuario")]
        public int id_usuario { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Empresa")]
        public int id_empresa { get; set; }
        [Required(ErrorMessage = "Debe seleccionar Estado")]
        public int f_estado { get; set; }
    }
}