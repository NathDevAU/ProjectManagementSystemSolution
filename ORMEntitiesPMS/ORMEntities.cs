using InterfacesPMS;
using System;
using System.ComponentModel.DataAnnotations;

namespace ORMEntitiesPMS
{
    #region base implementation of interfaces to map with EF to sql server tables
    //Here need to use Normal class to map it to SQL server Table as EF does not allow mapping of interface to Tables in database
    public class ProjectBase : IProject
    {
        
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
    }

    public class PersonBase: IPerson
    {
        [Key]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public int PositionID { get; set; }
    }

    public class PositionBase: IPosition
    {
        [Key]
        public int PositionId { get; set; }
        public string PositionName { get; set; }

    }

    public class ProjectPersonBase: IProjectPerson
    {
        [Key]
        public int ProjectPersonID { get; set; }
        public int ProjectID { get; set; }
        public int PersonID { get; set; }
    }
    #endregion

}
