using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Almacen.Entities
{
    public class Imagen
    {
        [Key]
        public int ImagenId { get; set; }
        [Required]
        public int Tipo { get; set; }
        //public Image MyProperty { get; set; }
    }
}
