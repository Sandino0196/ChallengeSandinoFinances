﻿using ChallengeSandinoFinances.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChallengeSandinoFinances.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    //[Authorize]
    public class Expense_DetailController : ApiController
    {
        public Expense_DetailController()
        {

        }
        [HttpGet]
        [Route("api/Expense_Detail/GetDetail")]
        public IEnumerable<Expense_DetailModel> GetDetail()
        {
            string db = "Data Source=.;Initial Catalog=FinancesChallengeDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(db);
            string sql = "select [Description_Expense] as 'Expense', [Date] as 'Date', " +
                "[Spent_Money] as 'Mount' from[dbo].[Expense_Detail] a inner join[dbo].[Expenses] " +
                "b on a.ID_Expense = b.ID_Expense inner join[dbo].[AspNetUsers] c on " +
                "c.Id = a.ID_User where[UserName] = 'sandino'";
            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();
            List<Expense_DetailModel> list = new List<Expense_DetailModel>();

            SqlDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Expense_DetailModel()
                {
                    Description_Expense = rd.GetString(rd.GetOrdinal("Expense")),
                    Date = rd.GetDateTime(rd.GetOrdinal("Date")),
                    Spent_Money = rd.GetDecimal(rd.GetOrdinal("Mount"))
                });
            }
            conn.Close();
            return list;
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
