using Almacen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Almacen.DataMapper
{
    public static class ImagenMapper
    {
        public static IEnumerable<Imagen> GetImagenes()
        {
            IEnumerable<Imagen> imagenes;
            using (var model = new AlmacenDBContext())
            {
                imagenes = model.Imagenes
                    .OrderBy(i => i.ImagenId)
                    .ToArray();
            }
            return imagenes;
        }

        public static Imagen GetImagen(int id)
        {
            Imagen imagen = new Imagen();
            using (var model = new AlmacenDBContext())
            {
                imagen = model.Imagenes
                    .Where(i => i.ImagenId == id)
                  .FirstOrDefault();
            }
            return imagen;
        }

        public static bool Post(Imagen imagen)
        {
            using (var model = new AlmacenDBContext())
            {
                model.Imagenes.Add(imagen);
                model.SaveChanges();
            }
            return Convert.ToBoolean(imagen.ImagenId);
        }

        public static bool Put(Imagen imagen)
        {
            int returnValue;
            using (var model = new AlmacenDBContext())
            {

                model.Attach(imagen);
                model.Entry(imagen).Property("Tipo").IsModified = (imagen.Tipo != 0);
                model.SaveChanges();
                model.Imagenes.Add(imagen);
                returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }

        public static bool Delete(int id)
        {
            int returnValue;
            Imagen imagen = new Imagen()
            {
                ImagenId = id
            };
            using (var model = new AlmacenDBContext())
            {
                model.Remove(imagen);
                returnValue = model.SaveChanges();
            }
            return Convert.ToBoolean(returnValue);
        }
    }
}
