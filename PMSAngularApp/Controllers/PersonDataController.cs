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
    public class PersonDataController : Controller
    {
        private IUow _ObjectUnitOfWork;
        private IRepository<PersonBase> _objectOfPersonRepository;
        private IRepository<ProjectPersonBase> _objectOfProjectPersonRepository;
        private PersonBusinessLogic _ObjectOfPersonBusinessLogic;
        private ProjectPersonBusinessLogic _ObjectOfProjectPersonBusinessLogic;

        //public constructor with DI using asp.net core DI services
        public PersonDataController(IRepository<PersonBase> ObjectOfPersonRepository, IRepository<ProjectPersonBase> ObjectOfProjectPersonRepository, EUow ObjectOfUnitOfWork)
        {
            //set unit of work with connection string to connect to database
            _ObjectUnitOfWork = ObjectOfUnitOfWork;
            ObjectOfPersonRepository.SetUnitWork(_ObjectUnitOfWork);
            ObjectOfProjectPersonRepository.SetUnitWork(_ObjectUnitOfWork);
            _objectOfPersonRepository = ObjectOfPersonRepository;
            _objectOfProjectPersonRepository = ObjectOfProjectPersonRepository;
            _ObjectOfPersonBusinessLogic = new PersonBusinessLogic(_objectOfPersonRepository);
            _ObjectOfProjectPersonBusinessLogic = new ProjectPersonBusinessLogic(_objectOfProjectPersonRepository);
        }
        // GET: api/PersonData
        [HttpGet("[action]")]
        public IEnumerable<PersonBase> GetPersonList()
        {
            return _ObjectOfPersonBusinessLogic.GetAllPersonList();
        }
        [HttpGet("[action]")]
        public IEnumerable<PersonBase> GetPersonListToAddInProject(int ProjectID)
        {
            return GetFilteredPersonList(ProjectID);

        }

        //private method to retrieve not added person for the project so only new persons can be added in to project
        private IEnumerable<PersonBase> GetFilteredPersonList(int ProjectID)
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
                        if (ObjPerson.PersonID == lstOfProjectPerson.Where(x => x.PersonID == ObjPerson.PersonID).FirstOrDefault().PersonID) ;
                        else
                            lstOfPersonBase.Add(ObjPerson);
                    }
                    catch {; }
                }
            }
            else
                return lstOfAllPerson;
            return lstOfPersonBase.AsEnumerable();
        }

        [HttpPost("[action]")]
        public void PostPersonToProject([FromBody] ProjectPersonBase ObjProjectPersonToAdd)
        {
           
        }

        // POST api/Persondata/PostPerson
        [HttpPost("[action]")]
        public void PostPerson([FromBody]PersonBase ObjPersonToAdd)
        {
            _ObjectOfPersonBusinessLogic.AddNewPerson(ObjPersonToAdd);
            _ObjectUnitOfWork.Committ();
        }

    }
}
