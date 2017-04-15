using InterfaceDAL;
using InterfacesPMS;
using ORMEntitiesPMS;
using System;
using System.Collections.Generic;

namespace BusinessLogic.PMS
{


    //this class library is to apply any kind of business logic on entity framework DAL based data fetching methods and return final outcome to controller
    public class ProjectBusinessLogic: ProjectBusinessLogicAbstract
{
        private IRepository<ProjectBase> _iRepoProjectBase;
        
        public ProjectBusinessLogic()
        {
        }

        // constructor with dependency injection using asp.net core DI
        public ProjectBusinessLogic(IRepository<ProjectBase> IRepoProjectBase)
        {
            _iRepoProjectBase = IRepoProjectBase;
        }
        #region Get Project data
        public override IEnumerable<ProjectBase> GetAllProjectList()
        {
            return _iRepoProjectBase.GetAll();
        }

        public override void AddNewProject(ProjectBase ObjProjectBase)
        {
            if(ObjProjectBase.ProjectName != "" && ObjProjectBase.ProjectDesc != "")
            _iRepoProjectBase.Add(ObjProjectBase);
            
        }


        #endregion

    }
}
