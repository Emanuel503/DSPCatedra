//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace veterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class consultaMedica
    {
        public int idCita { get; set; }

        [Required(ErrorMessage = "El campo mascota es obligatorio.")]
        public Nullable<int> idMascota { get; set; }

        [Required(ErrorMessage = "El campo personal es obligatorio.")]
        public Nullable<int> idPersonal { get; set; }

        [Required(ErrorMessage = "El campo tipo de descripcion es obligatorio.")]
        [RegularExpression(@"^[áéíóúña-zA-Z.\s]+$", ErrorMessage = "Ingrese una descripcion de animal valido")]
        public string descripcionConsulta { get; set; }

        [Required(ErrorMessage = "El campo fecha de la consulta es obligatorio.")]
        [RegularExpression(@"^([0-2][0-9])\/(0[123456789]|10|11|12)\/[0-9]{4}$", ErrorMessage = "Ingrese un fecha de la consulta valida (DD/MM/AAAA)")]
        public string fechaConsulta { get; set; }

        [Required(ErrorMessage = "El campo costo es obligatorio.")]
        [RegularExpression(@"^[0-9.]+$", ErrorMessage = "Ingrese un costo valido")]
        public double costoConsulta { get; set; }
    
        public virtual mascota mascota { get; set; }
        public virtual personal personal { get; set; }
    }
}
