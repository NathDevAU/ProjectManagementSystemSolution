using InterfaceDAL;
using ORMEntitiesPMS;
using System;
using System.Collections.Generic;

namespace BusinessLogic.PMS
{
    //this class library is to apply any kind of business logic on entity framework DAL based data fetching methods and return final outcome to controller
    public class ProjectBusinessLogic
    {
        private IRepository<Project> _Idal;
        
        public ProjectBusinessLogic(IRepository<Project> idal)
        {
            _Idal = idal;
        }

        public IEnumerable<Project> getMethodData()
        {
          return _Idal.GetAll();
        }
    }
}
