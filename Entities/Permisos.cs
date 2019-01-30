using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Permisos
    {
        [Key]
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public Permisos()
        {
            ID = 0;
            Descripcion = string.Empty;
        }
    }
}
