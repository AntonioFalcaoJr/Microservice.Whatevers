using System.Collections;
using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Things
{
    public class ThingInvalidTestData : ThingTestData, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                null, Name, Type, Value, DomainResource.Thing_Identifier_invalid
            };

            yield return new object[]
            {
                Id, string.Empty, Type, Value, DomainResource.Thing_Name_invalid
            };

            yield return new object[]
            {
                Id, Name, string.Empty, Value, DomainResource.Thing_Type_invalid
            };

            yield return new object[]
            {
                Id, Name, Type, 0, DomainResource.Thing_Value_less_than_zero
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}