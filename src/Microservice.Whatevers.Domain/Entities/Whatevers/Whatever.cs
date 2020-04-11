using System;
using System.Collections.Generic;
using Microservice.Whatevers.Domain.Abstractions;
using Microservice.Whatevers.Domain.Entities.Things;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public class Whatever : EntityBase<Guid>
    {
        public string Name { get; private set; }
        public ICollection<Thing> Things { get; set; }
        public DateTime Time { get; private set; }
        public string Type { get; private set; }

        internal Whatever(string name, DateTime time, string type)
        {
            SetName(name);
            SetTime(time);
            SetType(type);
        }

        private void SetTime(DateTime time)
        {
            if (time.Equals(DateTime.MinValue))
            {
                AddError(DomainResource.Whatever_Time_invalid);
                return;
            }
            
            Time = time;
        }

        protected sealed override void SetId(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                AddError(DomainResource.Whatever_Identifier_invalid);
                return;
            }

            Id = id;
        }
        
        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                AddError(DomainResource.Whatever_Name_invalid);
                return;
            }

            Name = name;
        }

        private void SetType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                AddError(DomainResource.Whatever_Type_invalid);
                return;
            }

            Type = type;
        }
    }
}