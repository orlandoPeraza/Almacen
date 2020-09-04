using Almacen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Almacen.DataMapper
{
    public static class CategoriaMapper
    {
        public static IEnumerable<Categoria> GetCategorias()
        {
            IEnumerable<Categoria> categorias;
            using (var model = new AlmacenDBContext())
            {
                categorias = model.Categorias
                    .OrderBy(c => c.CategoriaId)
                    .Include(c => c.Nombre)
                    .Include(c => c.CategoriaProductos)
                    .ToArray();
            }
            return categorias;
        }

        public static Categoria GetCategoria(int id)
        {
            Categoria categoria = new Categoria();
            using (var model = new AlmacenDBContext())
            {
                categoria = model.Categorias
                    .Include(c => c.Nombre)
                    .Include(c => c.CategoriaProductos)
                    .Where(c => c.CategoriaId == id)
                  .FirstOrDefault();
            }
            return categoria;
        }

        public static bool Post(Categoria categoria)
        {
            using (var model = new AlmacenDBContext())
            {
                model.Categorias.Add(categoria);
                model.SaveChanges();
            }
            return Convert.ToBoolean(categoria.CategoriaId);
        }

        public static bool Delete(int id)
        {
            int returnValue;
            Categoria categoria = new Categoria()
            {
                CategoriaId = id
            };
            using (var model = new AlmacenDBContext())
            {
                model.Remove(categoria);
                returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }

        public static bool Put(Categoria categoria)
        {
            int returnValue;
            using (var model = new AlmacenDBContext())
            {

                model.Attach(categoria);
                model.Entry(categoria).Property("Nombre").IsModified = !(String.IsNullOrEmpty(categoria.Nombre));
                model.Entry(categoria).Property("CategoriaProductos").IsModified = (categoria.CategoriaProductos != null);
                model.SaveChanges();
                model.Categorias.Add(categoria);
                returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }
    }
}
