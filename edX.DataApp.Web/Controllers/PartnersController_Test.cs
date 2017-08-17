using edX.DataApp.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using edX.DataApp.Web.Models;

namespace edX.DataApp.Web.Controllers
{
    [TestClass]
    public class PartnersController_Test
    {
        [TestMethod]
        public void IndexHome_ShouldReturnAll()
        {
            TestContosoContext context = new TestContosoContext();
            context.Partners.Add(new Partner { Name = "Test" });
            context.SaveChanges();

            PartnersController controller = new PartnersController(context);
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
            Assert.AreEqual((result.Model as IEnumerable<Partner>).Count(), 1);
        }
    }
}