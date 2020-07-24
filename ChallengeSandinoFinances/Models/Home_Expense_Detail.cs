namespace ChallengeSandinoFinances.Models
{
    public partial class Home_Expense_Detail
    {
        public int ID_Home_Expense_Detail { get; set; }
        public int ID_Home_Expense { get; set; }
        public string UserName { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Spent_Money { get; set; }
        public string Home_Expense_Resume { get; set; }
    }
}
