using System;
using System.Collections.Generic;

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
        void SetUnitWork(IUow uow); // To implement the Unit of Work where to avoid concurrency issue with transactions
    }
    // Design pattern :- Unit of Work pattern
    public interface IUow
    {
        void Committ();
        void RollBack();
    }
}
