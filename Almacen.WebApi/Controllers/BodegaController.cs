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
    public class BodegaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Bodega> listado = BodegaBL.GetBodegas();
            return Ok(JsonConvert.SerializeObject(listado, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Bodega bodega = BodegaBL.GetBodega(id);
            if (bodega == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(bodega, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            }));
        }

        [HttpPost]
        public IActionResult Post(Bodega bodega)
        {
            return BodegaBL.Post(bodega) ? Ok("La bodega se ha agregado con éxito") : (IActionResult)NotFound();
        }

        [HttpPut]
        public IActionResult Put(Bodega bodega)
        {
            return BodegaBL.Put(bodega) ? Ok("La bodega se ha modificado con éxito") : (IActionResult)NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return BodegaBL.Delete(id) ? Ok("La bodega se ha borrado con éxito") : (IActionResult)NotFound();
        }
    }
}