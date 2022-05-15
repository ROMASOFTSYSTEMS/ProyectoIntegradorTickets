using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Usuario_Perfil
    {
        public int id_usuario_perfil { get; set; }
        public int id_usuario { get; set; }
        public int id_perfil { get; set; }
        public int f_estado { get; set; }
    }
}