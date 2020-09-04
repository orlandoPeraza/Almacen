using Almacen.DataMapper;
using Almacen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.BussinesLogic
{
    public static class ImagenBL
    {
        public static IEnumerable<Imagen> GetImagenes()
        {
            return ImagenMapper.GetImagenes();
        }

        public static Imagen GetImagen(int id)
        {
            return ImagenMapper.GetImagen(id);
        }

        public static bool Post(Imagen imagen)
        {
            return ImagenMapper.Post(imagen);
        }

        public static bool Put(Imagen imagen)
        {
            return ImagenMapper.Put(imagen);
        }

        public static bool Delete(int id)
        {
            return ImagenMapper.Delete(id);
        }
    }
}
