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

        IList<ProjectBase> IenumOfProjectBase= new List<ProjectBase>();
        private static ProjectBusinessLogic _ObjProjectBusinessLogic;
        Mock<IRepository<ProjectBase>> _iRepoProjectBase;
        Mock<ProjectBusinessLogic> mockProjectBusinesslogic;
        [SetUp]
        public void ReinitalizeTest()
        {
            IenumOfProjectBase.Add(new ProjectBase { ProjectID = 1, ProjectName = "Project 1", ProjectDesc = "Project 1" });
        }

        [Test]
        public void GetProjectsListTest()
        {
            //Preparing for Unit Testing
           _iRepoProjectBase = new Mock<IRepository<ProjectBase>>();
            _iRepoProjectBase.Setup(x => x.GetAll()).Returns(() => IenumOfProjectBase.AsEnumerable());
            mockProjectBusinesslogic = new Mock<ProjectBusinessLogic>();
            mockProjectBusinesslogic.SetupSequence(x=>x.GetAllProjectList()).Returns(_iRepoProjectBase.Object.GetAll());

           //Assert
            Assert.IsNotNull(mockProjectBusinesslogic.Object.GetAllProjectList());



        }
    }
}