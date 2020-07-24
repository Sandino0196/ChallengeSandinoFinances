using ChallengeSandinoFinances.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ChallengeSandinoFinances.Controllers
{
    public class Home_ExpensesController : ApiController
    {
        public Home_ExpensesController()
        {

        }

        // GET: api/Home_Expenses
        public IEnumerable<Home_Expenses> Get()
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Home_Expenses.ToList();
            }
        }

        // GET: api/Home_Expenses/5
        public Home_Expenses Get(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Home_Expenses.FirstOrDefault(e => e.ID_Home_Expense == id);
            }
        }

        // POST: api/Home_Expenses
        public void Post([FromBody]Home_Expenses value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                entities.Home_Expenses.Add(value);
                entities.SaveChanges();
            }
        }

        // PUT: api/Home_Expenses/5
        public void Put(int id, [FromBody]Home_Expenses value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                if(value.ID_Home_Expense == id)
                {
                    entities.Entry(value).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                }
            }
        }

        // DELETE: api/Home_Expenses/5
        public void Delete(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                var temp = entities.Home_Expenses.FirstOrDefault(e => e.ID_Home_Expense == id);
                if (temp.ID_Home_Expense == id)
                {
                    entities.Home_Expenses.Remove(temp);
                    entities.SaveChanges();
                }
            }
        }
    }
}
