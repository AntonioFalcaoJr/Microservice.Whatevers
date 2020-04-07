using System;
using Microservice.Whatevers.Domain.Abstractions;

namespace Microservice.Whatevers.Domain.Entities.Things
{
    public class Thing : EntityBase<Guid>
    {
        internal Thing(Guid id, string name, string type, double value)
        {
            SetId(id);
            SetName(name);
            SetType(type);
            SetValue(value);
        }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public double Value { get; private set; }

        public sealed override void SetId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                AddError(DomainResource.Identifier_invalid);
                return;
            }

            Id = id;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                AddError(DomainResource.Thing_Name_invalid);
                return;
            }

            Name = name;
        }

        public void SetType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                AddError(DomainResource.Thing_Type_invalid);
                return;
            }

            Type = type;
        }

        public void SetValue(double value)
        {
            if (value <= 0)
            {
                AddError(DomainResource.Thing_Value_less_than_zero);
                return;
            }

            Value = value;
        }
    }
}