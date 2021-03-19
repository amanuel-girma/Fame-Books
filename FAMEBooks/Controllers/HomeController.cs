using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAMEBooks.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("index", "book");
                }
                else
                {
                    return RedirectToAction("index", "loan");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
    }
}
