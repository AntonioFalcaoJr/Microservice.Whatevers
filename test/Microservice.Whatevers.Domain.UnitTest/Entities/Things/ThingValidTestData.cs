using System.Collections;
using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Things
{
    public class ThingValidTestData : ThingTestData, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {Id, Name, Type, Value};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}