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
        IUow _ObjectUnitOfWork;
        IRepository<ProjectBase> _objectOfProjectRepository;
        public ProjectController(IRepository<ProjectBase> ObjectOfProjectRepository, EUow ObjectOfUnitOfWork)
        {
            //set unit of work with connection string to connect to database
            _ObjectUnitOfWork = ObjectOfUnitOfWork;
            ObjectOfProjectRepository.SetUnitWork(_ObjectUnitOfWork);
            _objectOfProjectRepository = ObjectOfProjectRepository;
        }
        

        public IActionResult ProjectList()
        {
            ProjectBusinessLogic pbl = new ProjectBusinessLogic(_objectOfProjectRepository);
            ProjectBase pb = new ProjectBase { ProjectName="asd",ProjectDesc="gg" };
            pbl.AddNewProject(pb);
            _ObjectUnitOfWork.Committ(); // here finally after adding the project physical commit is happening
            pbl.GetAllProjectList();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
