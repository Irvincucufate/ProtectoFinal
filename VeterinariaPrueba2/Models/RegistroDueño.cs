using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaPrueba2.Models
{
    [Table("tblRegistroDueño")]
    public class RegistroDueño
    {
        public int Id { get; set; }

        public int? tblRegistroPersonalId { get; set; }


        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Calle")]
        public int Calle { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

        public RegistroPersonal tblRegistroPersonal { get; set; }
    }
}