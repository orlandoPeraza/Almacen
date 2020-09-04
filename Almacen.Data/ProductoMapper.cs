using Almacen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Almacen.DataMapper
{
    public static class ProductoMapper
    {
        public static IEnumerable<Producto> GetProductos()
        {
            IEnumerable<Producto> productos;
            using (var model = new AlmacenDBContext())
            {
                productos = model.Productos.OrderBy(p => p.ProductoId)
                    .Include(p => p.Bodega)
                    .Include(p => p.Imagen)
                    .Include(p => p.CategoriasProducto)
                    .ToArray();
            }
            return productos;
        }

        public static Producto GetProducto(int id)
        {
            Producto producto = new Producto();
            using (var model = new AlmacenDBContext())
            {
                producto = model.Productos
                    .Include(p => p.Bodega)
                    .Include(p => p.Imagen)
                    .Include(p => p.CategoriasProducto)
                    .Where(p => p.ProductoId == id)
                  .FirstOrDefault();
            }
            return producto;
        }

        public static bool Delete(int id)
        {
            int returnValue;
            Producto producto = new Producto()
            {
                ProductoId = id
            };            
            using (var model = new AlmacenDBContext())
            {
                model.Remove(producto);
               returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }

        public static bool Put(Producto producto)
        {
            int returnValue;
            using (var model = new AlmacenDBContext())
            {              

                model.Attach(producto);
                model.Entry(producto).Property("Nombre").IsModified = !(String.IsNullOrEmpty(producto.Nombre));
                model.Entry(producto).Property("Descripcion").IsModified = !(String.IsNullOrEmpty(producto.Descripcion));
                model.Entry(producto).Property("Precio").IsModified = (producto.Precio != null);
                model.Entry(producto).Property("Imagen").IsModified = (producto.Imagen != null);
                model.Entry(producto).Property("Bodega").IsModified = (producto.Bodega != null);
                model.Entry(producto).Property("CategoriasProducto").IsModified = (producto.CategoriasProducto != null);
                model.SaveChanges();
                model.Productos.Add(producto);
                returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }

        public static bool Post(Producto producto)
        {
            using (var model = new AlmacenDBContext())
            {
                model.Productos.Add(producto);
                model.SaveChanges();
            }
            return Convert.ToBoolean(producto.ProductoId);
        }
    }
}
