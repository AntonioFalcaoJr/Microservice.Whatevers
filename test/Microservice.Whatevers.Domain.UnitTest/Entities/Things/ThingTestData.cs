using System;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Things
{
    public abstract class ThingTestData
    {
        protected readonly Guid Id = Guid.NewGuid();
        protected const string Name = "Name";
        protected const string Type = "Type";
        protected const double Value = 1;
    }
}