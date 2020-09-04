using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace Almacen.Entities
{
    public class Bodega
    {
        [Key]
        public int BodegaId{ get; set; }
        [ForeignKey("ImagenId")]
        public int ImagenId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public virtual Imagen Imagen { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
