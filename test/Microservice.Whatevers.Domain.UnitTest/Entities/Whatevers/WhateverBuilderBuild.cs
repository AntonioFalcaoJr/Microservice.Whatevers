using System;
using FluentAssertions;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Xunit;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Whatevers
{
    public class WhateverBuilderBuild
    {
        // Given
        [Theory, ClassData(typeof(WhateverInvalidTestData))]
        public void Should_Build_Invalid_Domain_With_Incorrect_Input(Guid id, string name, DateTime time, string type, string erroEsperado)
        {
            // When
            var whatever = BuildWhatever(id, name, time, type);

            // Then
            whatever.Valid.Should().BeFalse();
            whatever.Notification.Errors.Should().Contain(erroEsperado);
        }

        // Given
        [Theory, ClassData(typeof(WhateverValidTestData))]
        public void Should_Build_Valid_Domain_With_Correct_Input(Guid id, string name, DateTime time, string type)
        {
            // When
            var whatever = BuildWhatever(id, name, time, type);

            // Then
            whatever.Valid.Should().BeTrue();
            whatever.Id.Should().Be(id);
            whatever.Name.Should().Be(name);
            whatever.Time.Should().Be(time);
            whatever.Type.Should().Be(type);
        }

        private static Whatever BuildWhatever(Guid id, string name, DateTime time, string type)
            => new WhateverBuilder()
               .WithId(id)
               .WithName(name)
               .WithTime(time)
               .WithType(type)
               .Build();
    }
}