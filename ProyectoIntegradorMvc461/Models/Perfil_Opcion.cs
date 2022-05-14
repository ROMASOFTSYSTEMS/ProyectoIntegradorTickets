using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIntegradorMvc461.Models
{
    public class Perfil_Opcion
    {
        public int id_perfil_opcion { get; set; }
        public int id_perfil { get; set; }
        public int id_opcion { get; set; }
        public int f_estado { get; set; }
    }
}