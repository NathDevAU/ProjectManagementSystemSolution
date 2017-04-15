using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.PMS;
using InterfaceDAL;
using ORMEntitiesPMS;
using EntityFrameworkPMS;
using InterfacesPMS;

namespace PMSAngularApp.Controllers
{
    public class ProjectController : Controller
    {
        IRepository<ProjectBase> _objectOfProjectRepository;
        public ProjectController(IRepository<ProjectBase> ObjectOfProjectRepository, EUow ObjectOfUnitOfWork)
        {
            //set unit of work with connection string to connect to database
            ObjectOfProjectRepository.SetUnitWork(ObjectOfUnitOfWork);
            _objectOfProjectRepository = ObjectOfProjectRepository;
        }
        

        public IActionResult ProjectList()
        {
            ProjectBusinessLogic pbl = new ProjectBusinessLogic(_objectOfProjectRepository);
            pbl.GetAllProjectList();

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
