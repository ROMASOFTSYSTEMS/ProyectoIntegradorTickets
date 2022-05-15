using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Models
{
    public class Perfil
    {
        [Key]
        public int id_perfil { get; set; }
        public string t_perfil { get; set; }
        public int f_estado{ get; set; }
    }
}
