namespace ChallengeSandinoFinances.Models
{
    public partial class Expense_Detail
    {
        public int ID_Expense_Detail { get; set; }
        public int ID_Expense { get; set; }
        public string UserName { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Spent_Money { get; set; }
        public string Expense_Resume { get; set; }
    }
}
