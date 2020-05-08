using System;
using System.Collections;
using System.Collections.Generic;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Whatevers
{
    public class WhateverInvalidTestData : WhateverTestData, IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                Guid.Empty, Name, Time, Type, DomainResource.Whatever_Identifier_invalid
            };
            
            yield return new object[]
            {
                Id, string.Empty, Time, Type, DomainResource.Whatever_Name_invalid
            };
            
            yield return new object[]
            {
                Id, Name, DateTime.MinValue, Type, DomainResource.Whatever_Time_invalid
            };
            
            yield return new object[]
            {
                Id, Name, Time, string.Empty, DomainResource.Whatever_Type_invalid
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}