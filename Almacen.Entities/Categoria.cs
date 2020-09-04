using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Almacen.Entities
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        public virtual ICollection<ProductoCategoria> CategoriaProductos { get; set; }
    }
}
