//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace opr.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emp_Basic_Pay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emp_Basic_Pay()
        {
            this.Emp_BPS = new HashSet<Emp_BPS>();
        }
    
        public int Id { get; set; }
        public Nullable<decimal> Emp_Salary_BasicPay { get; set; }
        public Nullable<decimal> Emp_Salary_House_Allowance { get; set; }
        public Nullable<decimal> Emp_Salary_Medical { get; set; }
        public Nullable<decimal> Emp_Salary_Bonus { get; set; }
        public Nullable<System.DateTime> Emp_Salary_Paydate { get; set; }
        public Nullable<bool> IsDelete_ { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Emp_Salary_PayType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emp_BPS> Emp_BPS { get; set; }
    }
}
