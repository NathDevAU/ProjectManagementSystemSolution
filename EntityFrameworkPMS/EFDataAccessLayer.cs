using InterfaceDAL;
using InterfacesPMS;
using Microsoft.EntityFrameworkCore;
using ORMEntitiesPMS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkPMS
{
    //Original Class which implements the entity framework data access layer implementation to store or fetch data from SQL server database
    public class EFDataAccessLayer<Type> : IRepository<Type>
        where Type : class
    {
        DbContext dbcont = null;
        public EFDataAccessLayer() 
        {

        }
        public void Add(Type ObjectToAdd)
        {
          dbcont.Set<Type>().Add(ObjectToAdd);
        }

        public IEnumerable<Type> GetData(int DataIndex)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            dbcont.SaveChanges(); //physical committ
        }

        public void Update(Type ObjectToUpdate)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Type> GetAll()
        {
            return dbcont.Set<Type>().
                    AsQueryable<Type>().
                        ToList<Type>();
        }

        //Centralized Transaction to avoid concurrency
        public void SetUnitWork(IUow uow)
        {
            dbcont = ((EUow)uow); // Global transaction UOW
        }

    }


    //Unit of Work pattern
    public class EUow : DbContext, IUow
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                       .ToTable("Project"); // code first approach in .net core requries to install entity framework core and entity framework core relation nuget packages
        }

      
        public EUow(DbContextOptions<EUow> options) : base(options)
        {

        }
        public void Committ()
        {
            SaveChanges();
        }

        public void RollBack() // Adapter
        {
            Dispose();
        }
    }
    //This is the ORM class to map to database
   
}
