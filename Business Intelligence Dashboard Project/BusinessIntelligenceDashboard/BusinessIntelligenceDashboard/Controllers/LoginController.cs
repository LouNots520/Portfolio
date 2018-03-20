using System.Web.Mvc;
using BusinessIntelligenceDashboard.Models;

namespace BusinessIntelligenceDashboard.Controllers
{
    //Login Page
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel u)
        {
            if(Models.Session.Connect(u.username, u.password, u.organization))
            {
                Session["User"] = u;
                return RedirectToAction("Load", "Graph");
            }
            ViewBag.FailedMsg = "There was an error with your credentials.";
            return View();
        }
    }
}