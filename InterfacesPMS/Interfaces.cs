using System;

namespace InterfacesPMS
{
    #region interfaces
    public interface IProject
    {
        int ProjectID { get; set; }
        string ProjectName { get; set; }
        string ProjectDesc { get; set; }

    }

    public interface IPerson
    {
        int PersonID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MobileNo { get; set; }
        
    }

    public interface IPosition
    {
        int PositionId { get; set; }
        string PositionName { get; set; }

    }

    public interface IProjectPerson
    {
        int ProjectID { get; set; }
        int PersonID { get; set; }
    }
    #endregion

}
