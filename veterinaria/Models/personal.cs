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
    
    public partial class personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personal()
        {
            this.consultaMedica = new HashSet<consultaMedica>();
        }
    
        public int idPersonal { get; set; }
        public string nombre { get; set; }
        public string identificacion { get; set; }
        public System.DateTime fechaIngreso { get; set; }
        public System.DateTime fechaNacimiento { get; set; }
        public string especializacion { get; set; }
        public double salario { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consultaMedica> consultaMedica { get; set; }
    }
}
