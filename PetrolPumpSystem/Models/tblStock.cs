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
    
    public partial class tblStock
    {
        public int StId { get; set; }
        public Nullable<int> PId { get; set; }
        public Nullable<double> StQuantity { get; set; }
        public Nullable<double> StRate { get; set; }
        public Nullable<System.DateTime> StDate { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
    }
}