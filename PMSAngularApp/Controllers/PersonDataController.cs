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
        private PersonBusinessLogic _ObjectOfPersonBusinessLogic;

        //public constructor with DI using asp.net core DI services
        public PersonDataController(IRepository<PersonBase> ObjectOfPersonRepository, EUow ObjectOfUnitOfWork)
        {
            //set unit of work with connection string to connect to database
            _ObjectUnitOfWork = ObjectOfUnitOfWork;
            ObjectOfPersonRepository.SetUnitWork(_ObjectUnitOfWork);
            _objectOfPersonRepository = ObjectOfPersonRepository;
            _ObjectOfPersonBusinessLogic = new PersonBusinessLogic(_objectOfPersonRepository);
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
            return _ObjectOfPersonBusinessLogic.GetAllPersonList();
        }


        [HttpPost("[action]")]
        public void PostPersonToProject([FromBody] ProjectPersonBase ObjProjectPersonToAdd)
        {
           
        }


        
    }
}
