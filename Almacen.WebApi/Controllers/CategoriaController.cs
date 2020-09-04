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
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Categoria> listado = CategoriaBL.GetCategorias();
            return Ok(listado);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Categoria categoria = CategoriaBL.GetCategoria(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            return CategoriaBL.Post(categoria) ? Ok("La categoria se ha agregado con éxito") : (IActionResult)NotFound();
        }

        [HttpPut]
        public IActionResult Put(Categoria categoria)
        {
            return CategoriaBL.Put(categoria) ? Ok("La categoria se ha modificado con éxito") : (IActionResult)NotFound();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return CategoriaBL.Delete(id) ? Ok("La categoria se ha borrado con éxito") : (IActionResult)NotFound();
        }
    }
}
