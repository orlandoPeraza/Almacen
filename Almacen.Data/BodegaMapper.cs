using Almacen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Almacen.DataMapper
{
    public static class BodegaMapper
    {
        public static IEnumerable<Bodega> GetBodegas()
        {
            IEnumerable<Bodega> bodegas;
            using (var model = new AlmacenDBContext())
            {
                bodegas = model.Bodegas.OrderBy(b => b.BodegaId)
                    .Include(b => b.Imagen)
                    .Include(b => b.Productos)
                    .ToArray();
            }
            return bodegas;
        }

        public static Bodega GetBodega(int id)
        {
            Bodega bodega = new Bodega();
            using (var model = new AlmacenDBContext())
            {
                bodega = model.Bodegas.Include(b => b.Imagen)
                    .Include(b => b.Productos)
                    .Where(b => b.BodegaId == id)
                  .FirstOrDefault();
            }
            return bodega;
        }

        public static bool Post(Bodega bodega)
        {
            using (var model = new AlmacenDBContext())
            {
                model.Bodegas.Add(bodega);
                model.SaveChanges();
            }
            return Convert.ToBoolean(bodega.BodegaId);
        }

        public static bool Put(Bodega bodega)
        {
            int returnValue;
            using (var model = new AlmacenDBContext())
            {

                model.Attach(bodega);
                model.Entry(bodega).Property("Nombre").IsModified = !(String.IsNullOrEmpty(bodega.Nombre));                
                model.Entry(bodega).Property("Imagen").IsModified = (bodega.Imagen != null);
                model.Entry(bodega).Property("Productos").IsModified = (bodega.Productos != null);
                model.SaveChanges();
                model.Bodegas.Add(bodega);
                returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }

        public static bool Delete(int id)
        {
            int returnValue;
            Bodega bodega = new Bodega()
            {
                BodegaId = id
            };
            using (var model = new AlmacenDBContext())
            {
                model.Remove(bodega);
                returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }
    }
}
