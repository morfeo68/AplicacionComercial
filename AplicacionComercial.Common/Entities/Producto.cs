﻿using AplicacionComercial.Common.Interfaces;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AplicacionComercial.Common.Entities
{
    public class Producto : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="El {0} no puede contener más de 50 carácteres")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public int Iddepartamento { get; set; }

        [Required]
        [Display(Name = "IVA")]
        public int Idiva { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }


        public string Notas { get; set; }
       // public string Imagen { get; set; }

        [Required]
        [Display(Name = "Medida")]
        public int Idmedida { get; set; }

        [Required]
        [Display(Name = "Unidades")]
        public double Cantidad { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }


        [DisplayName("Número imágenes producto")]
        public int NumeroImagenesProducto => ImagenesProducto == null ? 0 : ImagenesProducto.Count;

        //[Required]
        //[Display(Name = "Departamento")]
        //[NotMapped]
        public virtual Departamento Departamento { get; set; }

        //[Required]
        //[Display(Name = "IVA")]
        //[NotMapped]
        public virtual  Iva Iva { get; set; }

        ////[Required]
        ////[Display(Name = "Medida")]
        //[NotMapped]
        public virtual Medida Medida { get; set; }

        public ICollection<ImagenProducto> ImagenesProducto { get; set; }
        //public ICollection<BodegaProducto> BodegaProductos { get; set; }

        //TODO:Pendiente de cambio de ruta.
        [Display(Name = "Image")]
        public string ImageFullPath => ImagenesProducto == null || ImagenesProducto.Count == 0
        ? $"https://localhost:44334/images/noimage/noimage.png"
        : ImagenesProducto.FirstOrDefault().ImageFullPath;
    }
}
