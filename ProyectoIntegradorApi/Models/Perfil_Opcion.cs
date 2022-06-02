using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Models
{
    public class Perfil_Opcion
    {
        [Key]
        public int id_perfil_opcion { get; set; }
        public int id_perfil { get; set; }
        public int id_opcion { get; set; }
        public string t_opcion { get; set; }
        public int f_estado { get; set; }
    }
}
