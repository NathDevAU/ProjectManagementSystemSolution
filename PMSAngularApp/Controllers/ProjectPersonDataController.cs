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
        private IRepository<PersonBase> _objectOfPersonRepository;
        private ProjectPersonBusinessLogic _ObjectOfProjectPersonBusinessLogic;
        private PersonBusinessLogic _ObjectOfPersonBusinessLogic;
        //public constructor with DI using asp.net core DI services
        public ProjectPersonDataController(IRepository<ProjectPersonBase> ObjectOfProjectPersonRepository, IRepository<PersonBase> ObjectOfPersonRepository, EUow ObjectOfUnitOfWork)
        {
            //set unit of work with connection string to connect to database
            _ObjectUnitOfWork = ObjectOfUnitOfWork;
            ObjectOfProjectPersonRepository.SetUnitWork(_ObjectUnitOfWork);
            ObjectOfPersonRepository.SetUnitWork(_ObjectUnitOfWork);
            _objectOfProjectPersonRepository = ObjectOfProjectPersonRepository;
            _objectOfPersonRepository = ObjectOfPersonRepository;
            _ObjectOfProjectPersonBusinessLogic = new ProjectPersonBusinessLogic(_objectOfProjectPersonRepository);
            _ObjectOfPersonBusinessLogic = new PersonBusinessLogic(_objectOfPersonRepository);
        }
       
        [HttpPost("[action]")]
        public void PostPersonToProject([FromBody] ProjectPersonBase ObjProjectPersonToAdd)
        {

            _ObjectOfProjectPersonBusinessLogic.AddNewPersonToProject(ObjProjectPersonToAdd);
            _ObjectUnitOfWork.Committ(); // final physical commit here 
        }

        [HttpGet("[action]")]
        public IEnumerable<PersonBase> GetProjectPersonList(int ProjectID)
        {
            return GetProjectPersons(ProjectID);

        }

       
        //private method to retrieve person which are assigned to project passed
        private IEnumerable<PersonBase> GetProjectPersons(int ProjectID)
        {
            var lstOfProjectPerson = _ObjectOfProjectPersonBusinessLogic.GetProjectPersons(ProjectID);
            var lstOfAllPerson = _ObjectOfPersonBusinessLogic.GetAllPersonList();
            IList<PersonBase> lstOfPersonBase = new List<PersonBase>();
            if (lstOfProjectPerson.Count() > 0)
            {
                foreach (var ObjPerson in lstOfAllPerson)
                {
                    try
                    {
                        if (ObjPerson.PersonID == lstOfProjectPerson.Where(x => x.PersonID == ObjPerson.PersonID).FirstOrDefault().PersonID) 
                            lstOfPersonBase.Add(ObjPerson);
                    }
                    catch {; }
                }
            }
            return lstOfPersonBase;
          
        }

       
    }
}
