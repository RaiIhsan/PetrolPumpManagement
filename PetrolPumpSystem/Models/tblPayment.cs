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
    
    public partial class tblPayment
    {
        public int PayId { get; set; }
        public Nullable<double> PaidAmount { get; set; }
        public string AmountType { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public Nullable<int> CustId { get; set; }
    
        public virtual tblCustomer tblCustomer { get; set; }
    }
}
