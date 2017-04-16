using InterfaceDAL;
using InterfacesPMS;
using ORMEntitiesPMS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.PMS
{


    //this class library is to apply any kind of business logic on entity framework DAL based data fetching methods and return final outcome to controller
    #region Project Business Logic Implementation
    public class ProjectBusinessLogic : ProjectBusinessLogicAbstract
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
            if (ObjProjectBase.ProjectName != "" && ObjProjectBase.ProjectDesc != "")
                _iRepoProjectBase.Add(ObjProjectBase);

        }


        #endregion

    }
    #endregion

    #region Person Business Logic Implementation
    public class PersonBusinessLogic : PersonBusinessLogicAbstract
    {
        private IRepository<PersonBase> _iRepoPersonBase;

        public PersonBusinessLogic()
        {
        }

        // constructor with dependency injection using asp.net core DI
        public PersonBusinessLogic(IRepository<PersonBase> IRepoPersonBase)
        {
            _iRepoPersonBase = IRepoPersonBase;
        }
        #region Get Project data
        public override IEnumerable<PersonBase> GetAllPersonList()
        {
            return _iRepoPersonBase.GetAll();
        }

        public override void AddNewPerson(PersonBase ObjPersonBase)
        {
            if (ObjPersonBase.FirstName != "" && ObjPersonBase.LastName != "")
                _iRepoPersonBase.Add(ObjPersonBase);

        }


        #endregion

    }

    #endregion


    #region Project Person Business Logic Implementation
    public class ProjectPersonBusinessLogic : ProjectPersonBusinessLogicAbstract
    {
        private IRepository<ProjectPersonBase> _iRepoProjectPersonBase;

        public ProjectPersonBusinessLogic()
        {
        }

        // constructor with dependency injection using asp.net core DI
        public ProjectPersonBusinessLogic(IRepository<ProjectPersonBase> IRepoProjectPersonBase)
        {
            _iRepoProjectPersonBase = IRepoProjectPersonBase;
        }
        #region Get Project data
       
        public override int AddNewPersonToProject(ProjectPersonBase ObjProjectPersonToAdd)
        {
            if (ObjProjectPersonToAdd.PersonID != 0 && ObjProjectPersonToAdd.ProjectID != 0)
            {
                //Check for already exists person if exists then dont allow to add the person again
                if (GetProjectPersons(ObjProjectPersonToAdd.ProjectID).Where(x => x.PersonID == ObjProjectPersonToAdd.PersonID).Count() > 0)
                    return -1;
                else
                    _iRepoProjectPersonBase.Add(ObjProjectPersonToAdd);
            }
            return 0;
        }

        public override IEnumerable<ProjectPersonBase> GetProjectPersons(int ProjectID)
        {
          return  _iRepoProjectPersonBase.GetFilteredData( filter: x => x.ProjectID == ProjectID);
        }

        #endregion

    }

    #endregion
}
