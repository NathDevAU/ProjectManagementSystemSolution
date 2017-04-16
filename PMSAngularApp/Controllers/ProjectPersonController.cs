using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InterfaceDAL;
using ORMEntitiesPMS;
using EntityFrameworkPMS;
using BusinessLogic.PMS;

// For more information on enabling Web API for empty Persons, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMSAngularApp.Controllers
{
    [Route("api/[controller]")]
    public class ProjectPersonDataController : Controller
    {
        private IUow _ObjectUnitOfWork;
        private IRepository<ProjectPersonBase> _objectOfProjectPersonRepository;
        private ProjectPersonBusinessLogic _ObjectOfProjectPersonBusinessLogic;

        //public constructor with DI using asp.net core DI services
        public ProjectPersonDataController(IRepository<ProjectPersonBase> ObjectOfProjectPersonRepository, EUow ObjectOfUnitOfWork)
        {
            //set unit of work with connection string to connect to database
            _ObjectUnitOfWork = ObjectOfUnitOfWork;
            ObjectOfProjectPersonRepository.SetUnitWork(_ObjectUnitOfWork);
            _objectOfProjectPersonRepository = ObjectOfProjectPersonRepository;
            _ObjectOfProjectPersonBusinessLogic = new ProjectPersonBusinessLogic(_objectOfProjectPersonRepository);
        }
       
        [HttpPost("[action]")]
        public void PostPersonToProject([FromBody] ProjectPersonBase ObjProjectPersonToAdd)
        {

            _ObjectOfProjectPersonBusinessLogic.AddNewPersonToProject(ObjProjectPersonToAdd);
            _ObjectUnitOfWork.Committ(); // final physical commit here 
        }



    }
}
