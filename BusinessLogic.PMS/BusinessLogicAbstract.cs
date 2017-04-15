﻿using ORMEntitiesPMS;
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
}
