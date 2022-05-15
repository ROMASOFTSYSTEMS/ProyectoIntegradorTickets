using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoIntegradorApi.Models
{
    public class Usuario_Empresa
    {
        [Key]
        public int id_usuario_empresa { get; set; }
        public int id_usuario { get; set; }
        public int id_empresa { get; set; }
        public int f_estado { get; set; }
    }
}
