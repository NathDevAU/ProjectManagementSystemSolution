using Moq;
using NUnit.Common;
using NUnit.Framework;
using NUnitLite;

using System;
using System.Reflection;
using EntityFrameworkPMS;

using InterfaceDAL;
using InterfacesPMS;
using ORMEntitiesPMS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.PMS.Test
{
    class Program
    {
        static int Main(string[] args)
        {
            // NUnitlite with NUnit common used to unit test the project which produces the outcome in windows console with result status for each test
            return new AutoRun(typeof(Program).GetTypeInfo().Assembly)
                .Execute(args, new ExtendedTextWrapper(Console.Out), Console.In);
        }
    }


    [TestFixture]
    public class BusinessLogicUnitTesting
    {
        //DbContextOptions<EUow> options = new DbContextOptions<EntityFrameworkPMS.EUow>();
        #region for project 
        IList<ProjectBase> IenumOfProjectBase= new List<ProjectBase>();
        Mock<IRepository<ProjectBase>> _iRepoProjectBase;
        Mock<ProjectBusinessLogic> mockProjectBusinesslogic;
        #endregion  
        #region for project person
        IList<ProjectPersonBase> IenumOfProjectPersonBase = new List<ProjectPersonBase>();
        Mock<IRepository<ProjectPersonBase>> _iRepoProjectPersonBase;
        Mock<ProjectPersonBusinessLogic> mockProjectPersonBusinesslogic;
        #endregion
        #region for person
        IList<PersonBase> IenumOfPersonBase = new List<PersonBase>();
        Mock<IRepository<PersonBase>> _iRepoPersonBase;
        Mock<PersonBusinessLogic> mockPersonBusinesslogic;
        #endregion
        [SetUp]
        public void ReinitalizeTest()
        {
            IenumOfPersonBase = new List<PersonBase>();
            IenumOfProjectPersonBase = new List<ProjectPersonBase>();
            IenumOfProjectBase = new List<ProjectBase>();

            //inimitialization of Person list records to mock the database table 
            IenumOfPersonBase.Add(new PersonBase { PersonID = 1, FirstName = "P1", LastName = "surname 1" });
            IenumOfPersonBase.Add(new PersonBase { PersonID = 2, FirstName = "P2", LastName = "surname 2" });
            IenumOfPersonBase.Add(new PersonBase { PersonID = 3, FirstName = "P3", LastName = "surname 3" });

            //initialization of ProjectBase records
            IenumOfProjectBase.Add(new ProjectBase { ProjectID = 1, ProjectName = "Project 1", ProjectDesc = "Project 1" });
            IenumOfProjectBase.Add(new ProjectBase { ProjectID = 2, ProjectName = "Project 2", ProjectDesc = "Project 2" });
            IenumOfProjectBase.Add(new ProjectBase { ProjectID = 3, ProjectName = "Project 3", ProjectDesc = "Project 3" });

            //initialization of project person recordsd    
            IenumOfProjectPersonBase.Add(new ProjectPersonBase { PersonID = 1, ProjectID =1 , ProjectPersonID=1 });
            IenumOfProjectPersonBase.Add(new ProjectPersonBase { PersonID = 2, ProjectID = 2, ProjectPersonID = 2 });
            IenumOfProjectPersonBase.Add(new ProjectPersonBase { PersonID = 3, ProjectID = 1, ProjectPersonID = 3 });
            IenumOfProjectPersonBase.Add(new ProjectPersonBase { PersonID = 1, ProjectID = 2, ProjectPersonID = 4 });
        }

        #region Projects list test
        [Test]
        public void GetProjectsListTest()
        {
            //Preparing for Unit Testing
           _iRepoPersonBase = new Mock<IRepository<PersonBase>>();
            _iRepoPersonBase.Setup(x => x.GetAll()).Returns(() => IenumOfPersonBase.AsEnumerable());
            mockPersonBusinesslogic = new Mock<PersonBusinessLogic>();
            mockPersonBusinesslogic.SetupSequence(x=>x.GetAllPersonList()).Returns(_iRepoPersonBase.Object.GetAll());

           //Assert
            Assert.IsNotNull(mockPersonBusinesslogic.Object.GetAllPersonList());

        }
        #endregion
        #region Person list test
        [Test]
        public void GetPersonListTest()
        {
            //Preparing for Unit Testing
            _iRepoProjectBase = new Mock<IRepository<ProjectBase>>();
            _iRepoProjectBase.Setup(x => x.GetAll()).Returns(() => IenumOfProjectBase.AsEnumerable());
            mockProjectBusinesslogic = new Mock<ProjectBusinessLogic>();
            mockProjectBusinesslogic.SetupSequence(x => x.GetAllProjectList()).Returns(_iRepoProjectBase.Object.GetAll());

            //Assert
            Assert.IsNotNull(mockProjectBusinesslogic.Object.GetAllProjectList());
        }
        #endregion

        #region TestCaseData for Number To Words Test
        //TestCase Source for Number to word function
        private static IEnumerable<TestCaseData> TestCaseDataForProjectPerson
        {
            get
            {
                yield return new TestCaseData(1, 2); // ProjectID is 1 then it should return 2 count 
                
            }
        }
        //Test Case Source for checking the input of Number 

        #endregion


        #region Testing the filtered Project Person list test
        [Test,TestCaseSource("TestCaseDataForProjectPerson")]
        public void GetProjectPersonList(int ProjectID,int returnValue)
        {
           
            //Preparing for Unit Testing
            _iRepoProjectPersonBase = new Mock<IRepository<ProjectPersonBase>>();
            _iRepoProjectPersonBase.Setup(x => x.GetAll()).Returns(() => IenumOfProjectPersonBase.AsEnumerable());
            mockProjectPersonBusinesslogic = new Mock<ProjectPersonBusinessLogic>();
            mockProjectPersonBusinesslogic.Setup(x => x.GetProjectPersons(ProjectID)).Returns(_iRepoProjectPersonBase.Object.GetAll().Where(x=>x.ProjectID == ProjectID));

            //Assert
            var res = mockProjectPersonBusinesslogic.Object.GetProjectPersons(ProjectID);
            Assert.IsNotNull(mockProjectPersonBusinesslogic.Object.GetProjectPersons(ProjectID));
            Assert.AreEqual(mockProjectPersonBusinesslogic.Object.GetProjectPersons(ProjectID).Count(), returnValue);
        }
        #endregion

    }
}