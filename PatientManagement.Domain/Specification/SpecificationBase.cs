using PatientManagement.Domain.Aggregates;
using PatientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PatientManagement.Domain.Specification
{
    public abstract class SpecificationBase<T> where T : EntityBase, IAggregateRoot
    {
        public abstract Expression<Func<T, bool>> ToExpression();
        public List<string> Includes { get; } = new List<string>();
    }
}

