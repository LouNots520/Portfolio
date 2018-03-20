using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Poker_League_Statistics.Controllers
{
    public class GameHistoryController : Controller
    {
        // GET: GameHistory
        //Will get game record for passed game number by calling stored procedure and populate Dataset to pass to partial view.
        public ActionResult Index(DataRow param)
        {
            DataSet dt = new DataSet();
            SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "EXEC GameResult @Num";
            cmd.Connection = conn;

            cmd.Parameters.Add("@Num", SqlDbType.SmallInt);
            cmd.Parameters["@Num"].Value = param["game"]; ;

            conn.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                conn.Close();
            }

            conn.Close();

            ViewBag.NUM = param["game"];                                            //Game Number
            ViewBag.DATE = param["game_date"];                                      //Game Date
            ViewBag.BUY = Convert.ToInt16(param["buy_in"]);                         //Buy In

            return View(dt);
        }
    }
}