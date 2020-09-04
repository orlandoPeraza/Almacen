using Almacen.DataMapper;
using Almacen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.BussinesLogic
{
    public static class ProductoBL
    {
        public static IEnumerable<Producto> GetProductos()
        {
            return ProductoMapper.GetProductos();

        }

        public static Producto GetProducto(int id)
        {
            return ProductoMapper.GetProducto(id);
        }

        public static bool Post(Producto producto)
        {
            return ProductoMapper.Post(producto);
        }

        public static bool Put(Producto producto)
        {
            return ProductoMapper.Put(producto);
        }

        public static bool Delete(int id)
        {
            return ProductoMapper.Delete(id);
        }
    }
}
