//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChallengeSandinoFinances.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Home_Expense_Detail
    {
        public int ID_Home_Expense_Detail { get; set; }
        public int ID_Home_Expense { get; set; }
        public string ID_User { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Spent_Money { get; set; }
    }
}
