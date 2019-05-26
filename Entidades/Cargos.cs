using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shurth.Entidades
{
    public class Cargos
    {
        [Key]
        public int CargoId { get; set; }
        public string Descripcion { get; set; }

        public Cargos()
        {
            this.CargoId = 0;
            this.Descripcion = string.Empty;
        }
    }
}
