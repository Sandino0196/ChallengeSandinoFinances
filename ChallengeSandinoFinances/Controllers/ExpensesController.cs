using ChallengeSandinoFinances.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChallengeSandinoFinances.Controllers
{
    public class ExpensesController : ApiController
    {
        public ExpensesController()
        {

        }

        // GET: api/Expenses
        public IEnumerable<Expenses> Get()
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Expenses.ToList();
            }
        }

        // GET: api/Expenses/5
        public Expenses Get(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                return entities.Expenses.FirstOrDefault(e => e.ID_Expense == id);
            }
        }

        // POST: api/Expenses
        public void Post([FromBody]Expenses value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                entities.Expenses.Add(value);
                entities.SaveChanges();
            }
        }

        // PUT: api/Expenses/5
        public void Put(int id, [FromBody]Expenses value)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                if(value.ID_Expense == id)
                {
                    entities.Entry(value).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                }                
            }
        }

        // DELETE: api/Expenses/5
        public void Delete(int id)
        {
            using (FinancesChallengeDBEntities entities = new FinancesChallengeDBEntities())
            {
                var temp = entities.Expenses.FirstOrDefault(e => e.ID_Expense == id);
                if (temp.ID_Expense == id)
                {
                    entities.Expenses.Remove(temp);
                    entities.SaveChanges();
                }
            }
        }
    }
}
