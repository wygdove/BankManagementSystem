//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankManagementSystem.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalLoanInfo
    {
        public int PlId { get; set; }
        public string PlAccountNumber { get; set; }
        public string PlWork { get; set; }
        public Nullable<decimal> PlSalary { get; set; }
    
        public virtual UserAccountInfo UserAccountInfo { get; set; }
    }
}