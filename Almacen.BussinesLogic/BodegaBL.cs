using Almacen.DataMapper;
using Almacen.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Almacen.BussinesLogic
{
    public static class BodegaBL
    {
        public static IEnumerable<Bodega> GetBodegas()
        {
            return BodegaMapper.GetBodegas();
        }

        public static Bodega GetBodega(int id)
        {
            return BodegaMapper.GetBodega(id);
        }

        public static bool Post(Bodega bodega)
        {
            return BodegaMapper.Post(bodega);
        }

        public static bool Put(Bodega bodega)
        {
            return BodegaMapper.Put(bodega);
        }

        public static bool Delete(int id)
        {
            return BodegaMapper.Delete(id);
        }
    }
}
