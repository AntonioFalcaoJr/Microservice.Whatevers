using System.Collections;
using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Whatevers
{
    public class WhateverValidTestData : WhateverTestData, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {Id, Name, Time, Type};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}