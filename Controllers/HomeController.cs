using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers {
  public class HomeController : Controller {
    // GET: Index
    public ActionResult Index() {
      return View();
    }

    [HttpPost]
    public ActionResult Index(IndexViewModel Model) {
      // Depending on your preference, you can either set the user agent here,
      //  or inside the model class itself (see IndexModels.cs).
      Model.UserAgent = Request.UserAgent;

      Model.SendEmail();

      return View(Model);
    }
  }
}