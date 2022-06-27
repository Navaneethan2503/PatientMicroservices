using PatientManagement.Domain.Aggregates;
using PatientManagement.Domain.Entities;
using PatientManagement.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Interfaces
{
    public interface IRepository<T> where T : EntityBase, IAggregateRoot
    {
        T Add(T item);
        T Remove(T item);
        T Update(T item);
        IReadOnlyCollection<T> Get();
        T GetById(int id);
        IReadOnlyCollection<T> GetBySpec(SpecificationBase<T> spec);
        Task<int> SaveAsync();
    }
}
