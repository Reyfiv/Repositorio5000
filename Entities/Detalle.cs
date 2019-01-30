using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Detalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public int ID { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("ID")]
        public virtual Permisos Permisos { get; set; }

        public Detalle(int IdDetalle, int id, string descripcion)
        {
            this.IdDetalle = IdDetalle;
            ID = id;
            Descripcion = descripcion;
        }

        public Detalle()
        {
            IdDetalle = 0;
            ID = 0;
            Descripcion = string.Empty;
        }
    }
}
