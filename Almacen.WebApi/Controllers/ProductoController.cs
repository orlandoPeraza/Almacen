using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.BussinesLogic;
using Almacen.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Almacen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Producto> listado =  ProductoBL.GetProductos();
            return Ok(JsonConvert.SerializeObject(listado, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Producto producto = ProductoBL.GetProducto(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(producto, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }));
        }

        [HttpPost]
        public IActionResult Post(Producto producto)
        {
            return ProductoBL.Post(producto) ? Ok("El producto se ha almacenado con éxito") : (IActionResult)NotFound();
        }

        [HttpPut]
        public IActionResult Put(Producto producto)
        {
            return ProductoBL.Put(producto) ? Ok("El producto se ha modificado con éxito") : (IActionResult)NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return ProductoBL.Delete(id) ? Ok("El producto se ha borrado con éxito") : (IActionResult)NotFound();
        }

    }
}