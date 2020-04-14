using System;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Domain.Abstractions.Notifications;

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

        protected Thing(){}

        public string Name { get; private set; }
        public string Type { get; private set; }
        public double Value { get; private set; }

        protected sealed override void SetId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                
                Notification.AddError(DomainResource.Thing_Identifier_invalid);
                return;
            }

            Id = id;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Notification.AddError(DomainResource.Thing_Name_invalid);
                return;
            }

            Name = name;
        }

        private void SetType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                Notification.AddError(DomainResource.Thing_Type_invalid);
                return;
            }

            Type = type;
        }

        private void SetValue(double value)
        {
            if (value <= 0)
            {
                Notification.AddError(DomainResource.Thing_Value_less_than_zero);
                return;
            }

            Value = value;
        }
    }
}