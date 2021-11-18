using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaPrueba2.Models
{
    [Table("tblRegistroAnimales")]
    public class RegistroAnimales
    {
        public int Id { get; set; }

        public int? tblRegistroDueñoId { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Animal")]
        public string ClaseAnimal { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Raza")]
        public string Raza { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Edad ")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Estatura")]
        public int Estatura { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha a programar la cita")]
        public System.DateTime FechaCita { get; set; }

        public RegistroDueño tblRegistroDueño { get; set; }
    }
}