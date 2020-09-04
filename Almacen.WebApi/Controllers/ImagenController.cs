using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Almacen.BussinesLogic;
using Almacen.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Almacen.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Imagen> listado = ImagenBL.GetImagenes();
            return Ok(listado);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Imagen imagen = ImagenBL.GetImagen(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return Ok(imagen);
        }

        [HttpPost]
        public IActionResult Post(Imagen imagen)
        {
            return ImagenBL.Post(imagen) ? Ok("La imagen se ha agregado con éxito") : (IActionResult)NotFound();
        }

        [HttpPut]
        public IActionResult Put(Imagen imagen)
        {
            return ImagenBL.Put(imagen) ? Ok("La imagen se ha modificado con éxito") : (IActionResult)NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return ImagenBL.Delete(id) ? Ok("La imagen se ha borrado con éxito") : (IActionResult)NotFound();
        }
    }
}