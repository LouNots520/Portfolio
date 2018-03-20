using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Poker_League_Statistics.Controllers
{
    public class RosterStatsController : Controller
    {
        DataSet gd = new DataSet();                                                 //Details on all games - Number and Date

        // GET: RosterStats
        // Run On Page Start
        // Will Run Stored Procedure In DataBase to Get DataSet To Display in View
        public ActionResult Index()
        {

            getGameDets();

            DataSet dt = new DataSet();
            SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "EXEC LeagueStats";
            cmd.Connection = conn;

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

            ViewBag.GAMEDETS = gd;

            return View(dt);
        }

        //Function will obtain all game numbers and corresponding dates and buy-in to a DataSet to be passed to View
        private void getGameDets()
        {
            SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DISTINCT game, Convert(varchar(10), game_date, 101) game_date, buy_in FROM Records ORDER BY game ASC";
            cmd.Connection = conn;

            conn.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(gd);
            }
            catch (Exception ex) { }
            conn.Close();
        }
    }
}