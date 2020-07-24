using ChallengeSandinoFinances.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace ChallengeSandinoFinances.Controllers
{
    //[Authorize]
    public class Home_Expense_DetailController : ApiController
    {
        public Home_Expense_DetailController()
        {

        }

        [HttpGet]
        [Route("api/Home_Expense_Detail/GetDetail/{UserName}")]
        public IEnumerable<Home_Expense_DetailModel> GetDetail(string UserName)
        {
            string db = "Data Source=sandino.database.windows.net;Initial Catalog=FinancesChallengeDB;Persist Security Info=True;User ID=sandino96;Password=Neggo.69";
            SqlConnection conn = new SqlConnection(db);
            string sql = "select [Description_Home_Expense] as 'Expense', [Date] as 'Date', " +
                "[Spent_Money] as 'Mount', [Home_Expense_Resume] as 'Description' " +
                "from[dbo].[Home_Expense_Detail] a inner join[dbo].[Home_Expenses] " +
                "b on a.ID_Home_Expense = b.ID_Home_Expense inner join[dbo].[AspNetUsers] c on " +
                "c.UserName = a.UserName where a.[UserName] = '" + UserName+ "' order by [Date] desc";
            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();
            List<Home_Expense_DetailModel> list = new List<Home_Expense_DetailModel>();

            SqlDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new Home_Expense_DetailModel()
                {
                    Description_Home_Expense = rd.GetString(rd.GetOrdinal("Expense")),
                    Date = rd.GetDateTime(rd.GetOrdinal("Date")),
                    Spent_Money = rd.GetDecimal(rd.GetOrdinal("Mount")),
                    Home_Expense_Resume = rd.GetString(rd.GetOrdinal("Description"))
                });
            }
            conn.Close();
            return list;
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
