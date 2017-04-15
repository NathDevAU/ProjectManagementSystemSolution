using InterfaceDAL;
using NUnit.Framework;
using ORMEntitiesPMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.PMS.UnitTesting
{
    [TestFixture]
    public class BusinessLogicUnitTesting
    {
        IRepository<ProjectBase> _iRepoProjectBase = null;


        [SetUp]
        public void ReinitalizeTest()
        {

        }
        [Test]
        public void GetProjectsListTest()
        {
            ProjectBusinessLogic ObjProjectBusinessLogic = new ProjectBusinessLogic(_iRepoProjectBase);
            var res = ObjProjectBusinessLogic.GetAllProjectList();

        }
    }
}
