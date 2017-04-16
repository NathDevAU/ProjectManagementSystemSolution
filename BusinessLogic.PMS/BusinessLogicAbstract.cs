using ORMEntitiesPMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.PMS
{
    // This Abstract class need to help implementing the Mock Unit Testing using virtual methods 
    public abstract class ProjectBusinessLogicAbstract
    {
        public abstract IEnumerable<ProjectBase> GetAllProjectList();
        public abstract void AddNewProject(ProjectBase ObjProjectBase);
    }


    public abstract class PersonBusinessLogicAbstract
    {
        public abstract IEnumerable<PersonBase> GetAllPersonList();
        public abstract void AddNewPerson(PersonBase ObjPersonBase);
    }

    public abstract class ProjectPersonBusinessLogicAbstract
    {
        public abstract int AddNewPersonToProject(ProjectPersonBase ObjProjectPersonToAdd);

        public abstract IEnumerable<ProjectPersonBase> GetProjectPersons(int ProjectID);
    }
}
