using Almacen.DataMapper;
using Almacen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.BussinesLogic
{
    public static class CategoriaBL
    {
        public static IEnumerable<Categoria> GetCategorias()
        {
            return CategoriaMapper.GetCategorias();
        }

        public static Categoria GetCategoria(int id)
        {
            return CategoriaMapper.GetCategoria(id);
        }

        public static bool Post(Categoria categoria)
        {
            return CategoriaMapper.Post(categoria);
        }

        public static bool Put(Categoria categoria)
        {
            return CategoriaMapper.Put(categoria);
        }

        public static bool Delete(int id)
        {
            return CategoriaMapper.Delete(id);
        }
    }
}
