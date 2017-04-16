using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InterfaceDAL
{
    //Generic Repository Pattern used here using .NET generics
    public interface IRepository<Type>
    {
        void Add(Type ObjectToAdd); //In Memory
        void Update(Type ObjectToUpdate); // In Memory
        IEnumerable<Type> GetData(int DataIndex);
        void Save(); // Physical Commit
        IEnumerable<Type> GetAll();
        IEnumerable<Type> GetFilteredData(
   Expression<Func<Type, bool>> filter = null,
   Func<IQueryable<Type>, IOrderedQueryable<Type>> orderBy = null,
   string includeProperties = "");

        void SetUnitWork(IUow uow); // To implement the Unit of Work where to avoid concurrency issue with transactions
    }
    // Design pattern :- Unit of Work pattern
    public interface IUow
    {
        void Committ();
        void RollBack();
    }
}
