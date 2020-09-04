using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Almacen.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        [ForeignKey("BodegaId")]
        public int BodegaId { get; set; }
        [ForeignKey("ImagenId")]
        public int ImagenId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double? Precio { get; set; }
        public virtual Imagen Imagen { get; set; }
        public virtual Bodega Bodega { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductoCategoria> CategoriasProducto { get; set; }


    }
}
