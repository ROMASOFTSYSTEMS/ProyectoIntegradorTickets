using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegradorApi.Models
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string c_usuario { get; set; }
        public string t_password { get; set; }
        public string t_nombre { get; set; }
        public string t_correo { get; set; }
        public int f_estado { get; set; }
    }
}
