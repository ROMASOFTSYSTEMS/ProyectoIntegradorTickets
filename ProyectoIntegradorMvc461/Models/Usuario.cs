using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string c_usuario { get; set; }
        public string t_password { get; set; }
        public string t_nombre { get; set; }
        public string t_correo { get; set; }
        public int f_estado{ get; set; }
    }
}