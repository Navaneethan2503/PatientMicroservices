using System;
using System.Collections.Generic;
using System.Text;

namespace PatientManagement.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public EntityBase() { }
        //public List<EventBase> DomainEvents = new List<EventBase>();
        public override bool Equals(object obj)
        {
            EntityBase entityBase = obj as EntityBase;
            if (ReferenceEquals(this, entityBase))
                return true;
            else if (ReferenceEquals(entityBase, null))
                return false;
            else if (this.GetType().Name != entityBase.GetType().Name)
                return false;

            return this.Id == entityBase.Id;
        }
        public override int GetHashCode()
        {
            return (this.GetType().FullName + this.Id).GetHashCode();
        }
    }
}
