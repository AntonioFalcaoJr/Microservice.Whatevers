using System;
using Microservice.Whatevers.Domain.Abstractions.Builders;

namespace Microservice.Whatevers.Domain.Entities.Whatevers
{
    public class WhateverBuilder : Builder<WhateverBuilder, Whatever, Guid>, IWhateverBuilder
    {
        private string _name;
        private DateTime _time;
        private string _type;

        public IWhateverBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public IWhateverBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public IWhateverBuilder WithTime(DateTime time)
        {
            _time = time;
            return this;
        }

        public override Whatever Build() => new Whatever(_name, _time, _type);
    }
}