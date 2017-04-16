using InterfaceDAL;
using InterfacesPMS;
using Microsoft.EntityFrameworkCore;
using ORMEntitiesPMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        public  IEnumerable<Type> GetFilteredData(
    Expression<Func<Type, bool>> filter = null,
    Func<IQueryable<Type>, IOrderedQueryable<Type>> orderBy = null,
    string includeProperties = "")
        {
            IQueryable<Type> query = dbcont.Set<Type>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<Type> GetData(int DataIndex)
        {
            //return dbcont.Set<Type>().Find(DataIndex);
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
            //need to map with actual class because EF cannot allow to map with interface here 
            modelBuilder.Entity<ProjectBase>()
                       .ToTable("Project"); // code first approach in .net core requries to install entity framework core and entity framework core relation nuget packages

           
            modelBuilder.Entity<PersonBase>()
                      .ToTable("Person");
            modelBuilder.Entity<ProjectPersonBase>()
                     .ToTable("ProjectPerson");
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
