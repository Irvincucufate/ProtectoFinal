using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace VeterinariaPrueba2.Models
{
    [Table("tblRegistroPersonal")]
    public class RegistroPersonal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Documento de identificacion")]
        public int DocumentoIdentificacion { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Ingreso")]
        public System.DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }


        [Required(ErrorMessage = "{0} es requerido")]
        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; }
    }
}