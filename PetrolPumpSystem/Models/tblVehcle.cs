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
    
    public partial class tblVehcle
    {
        public int VId { get; set; }
        public string VNumber { get; set; }
        public string VType { get; set; }
        public Nullable<int> CustId { get; set; }
    
        public virtual tblCustomer tblCustomer { get; set; }
    }
}
