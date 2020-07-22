using ChallengeSandinoFinances.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChallengeSandinoFinances.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    [Authorize]
    public class Expense_DetailController : ApiController
    {
        public Expense_DetailController()
        {

        }

        // GET: api/Expense_Detail
        public IEnumerable<Expense_Detail> Get()
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Expense_Detail.ToList();
            }
        }

        // GET: api/Expense_Detail/5
        public Expense_Detail Get(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Expense_Detail.FirstOrDefault(e => e.ID_Expense_Detail == id);
            }
        }

        // POST: api/Expense_Detail
        public void Post([FromBody]Expense_Detail value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                entities.Expense_Detail.Add(value);
                entities.SaveChanges();
            }
        }

        // PUT: api/Expense_Detail/5
        public void Put(int id, [FromBody]Expense_Detail value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                if(value.ID_Expense_Detail == id)
                {
                    entities.Entry(value).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                }                
            }
        }

        // DELETE: api/Expense_Detail/5
        public void Delete(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                var temp = entities.Expense_Detail.FirstOrDefault(e => e.ID_Expense_Detail == id);
                if (temp.ID_Expense_Detail == id)
                {
                    entities.Expense_Detail.Remove(temp);
                    entities.SaveChanges();
                }
            }
        }
    }
}
