//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetrolPumpSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Machine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Machine()
        {
            this.tblNetSales = new HashSet<tblNetSale>();
            this.tblMachineReadings = new HashSet<tblMachineReading>();
        }
    
        public int MachinId { get; set; }
        public string MachineName { get; set; }
        public Nullable<int> PId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblNetSale> tblNetSales { get; set; }
        public virtual tblProduct tblProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMachineReading> tblMachineReadings { get; set; }
    }
}
