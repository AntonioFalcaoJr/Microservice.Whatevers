using System;
using Microservice.Whatevers.Domain.Abstractions;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public class Whatever : EntityBase<Guid>
    {
        internal Whatever(Guid id, string name, DateTime time, string type)
        {
            SetId(id);
            SetName(name);
            SetTime(time);
            SetType(type);
        }

        protected Whatever() { }

        public string Name { get; private set; }
        public DateTime Time { get; private set; }
        public string Type { get; private set; }

        protected sealed override void SetId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                Notification.AddError(DomainResource.Whatever_Identifier_invalid);
                return;
            }

            Id = id;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Notification.AddError(DomainResource.Whatever_Name_invalid);
                return;
            }

            Name = name;
        }

        private void SetTime(DateTime time)
        {
            if (time.Equals(DateTime.MinValue))
            {
                Notification.AddError(DomainResource.Whatever_Time_invalid);
                return;
            }

            Time = time;
        }

        private void SetType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                Notification.AddError(DomainResource.Whatever_Type_invalid);
                return;
            }

            Type = type;
        }
    }
}