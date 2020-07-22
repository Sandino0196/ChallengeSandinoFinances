using ChallengeSandinoFinances.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ChallengeSandinoFinances.Controllers
{
    public class Home_Expense_DetailController : ApiController
    {
        public Home_Expense_DetailController()
        {

        }

        // GET: api/Home_Expense_Detail
        public IEnumerable<Home_Expense_Detail> Get()
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Home_Expense_Detail.ToList();
            }
        }

        // GET: api/Home_Expense_Detail/5
        public Home_Expense_Detail Get(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Home_Expense_Detail.FirstOrDefault(e => e.ID_Home_Expense_Detail == id);
            }
        }

        // POST: api/Home_Expense_Detail
        public void Post([FromBody]Home_Expense_Detail value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                entities.Home_Expense_Detail.Add(value);
                entities.SaveChanges();
            }
        }

        // PUT: api/Home_Expense_Detail/5
        public void Put(int id, [FromBody]Home_Expense_Detail value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                if(value.ID_Home_Expense_Detail == id)
                {
                    entities.Entry(value).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                }                
            }
        }

        // DELETE: api/Home_Expense_Detail/5
        public void Delete(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                var temp = entities.Home_Expense_Detail.FirstOrDefault(e => e.ID_Home_Expense_Detail == id);
                if(temp.ID_Home_Expense_Detail == id)
                {
                    entities.Home_Expense_Detail.Remove(temp);
                    entities.SaveChanges();
                }
            }
        }
    }
}
