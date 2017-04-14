using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.PMS;
using InterfaceDAL;
using ORMEntitiesPMS;
using EntityFrameworkPMS;

namespace PMSAngularApp.Controllers
{
    public class HomeController : Controller
    {

       public HomeController(IRepository<Project> de, EUow ctx)
        {
            de.SetUnitWork(ctx);
            dd = de;
        }
        IRepository<Project> dd;

        public IActionResult Index()
        {
            ProjectBusinessLogic pbl = new ProjectBusinessLogic(dd);
            pbl.getMethodData();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
