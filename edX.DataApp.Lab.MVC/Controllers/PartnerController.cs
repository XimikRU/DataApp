using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edX.DataApp.Lab.MVC.Models;

namespace edX.DataApp.Lab.MVC.Controllers
{
    public class PartnerController : Controller
    {
        // GET: Partner
        public ActionResult Index()
        {
            List<Partner> model = new List<Partner>();
            using (ContosoContext context = new ContosoContext())
            {
                model.AddRange(context.Partners);
            }
            return View(model);
        }  
    }
}