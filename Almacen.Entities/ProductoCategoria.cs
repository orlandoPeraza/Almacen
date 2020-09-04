using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.Entities
{
    public class ProductoCategoria
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
