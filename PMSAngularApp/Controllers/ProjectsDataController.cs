using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ORMEntitiesPMS;
using InterfaceDAL;
using EntityFrameworkPMS;
using BusinessLogic.PMS;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMSAngularApp.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsDataController : Controller
    {
       private IUow _ObjectUnitOfWork;
       private IRepository<ProjectBase> _objectOfProjectRepository;
        private ProjectBusinessLogic _ObjectOfProjectBusinessLogic;
        public ProjectsDataController(IRepository<ProjectBase> ObjectOfProjectRepository, EUow ObjectOfUnitOfWork)
        {
            //set unit of work with connection string to connect to database
            _ObjectUnitOfWork = ObjectOfUnitOfWork;
            ObjectOfProjectRepository.SetUnitWork(_ObjectUnitOfWork);
            _objectOfProjectRepository = ObjectOfProjectRepository;
            _ObjectOfProjectBusinessLogic = new ProjectBusinessLogic(_objectOfProjectRepository);
        }
        // GET: api/values
        [HttpGet("[action]")]
        public IEnumerable<ProjectBase> GetProjectsList()
        {
           return  _ObjectOfProjectBusinessLogic.GetAllProjectList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void PostProject(ProjectBase ObjProjectToAdd)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void PutProject(ProjectBase ObjProjectToUpdate)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
