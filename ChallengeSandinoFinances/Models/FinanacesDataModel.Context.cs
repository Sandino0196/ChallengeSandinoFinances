namespace ChallengeSandinoFinances.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class FinancesChallengeDBEntities : DbContext
    {
        public FinancesChallengeDBEntities()
            : base("name=FinancesChallengeDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Expense_Detail> Expense_Detail { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Home_Expense_Detail> Home_Expense_Detail { get; set; }
        public virtual DbSet<Home_Expenses> Home_Expenses { get; set; }
    }
}
