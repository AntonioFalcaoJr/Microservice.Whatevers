using System;
using FluentAssertions;
using Microservice.Whatevers.Domain.Entities.Things;
using Xunit;

namespace Microservice.Whatevers.Domain.UnitTest.Entities.Things
{
    public class ThingBuilderBuild
    {
        // Given
        [Theory, ClassData(typeof(ThingValidTestData))]
        public void Should_Build_Valid_Domain_With_Correct_Input(Guid id, string name, string type, double value)
        {
           
            // When 
            var thing = BuildThing(id, name, type, value);
            
            // Then
            thing.Valid.Should().BeTrue();
            thing.Id.Should().Be(id);
            thing.Name.Should().Be(name);
            thing.Type.Should().Be(type);
            thing.Value.Should().Be(value);
        }
        
        // Given
        [Theory, ClassData(typeof(ThingInvalidTestData))]
        public void Should_Build_Invalid_Domain_With_Incorrect_Input(Guid id, string name, string type, double value, string erroEsperado)
        {
            // When 
            var thing = BuildThing(id, name, type, value);
            
            // Then
            thing.Valid.Should().BeFalse();
            thing.Notification.Errors.Should().Contain(erroEsperado);
        }

        private  Thing BuildThing(Guid id, string name, string type, double value)
            => new ThingBuilder()
               .WithId(id)
               .WithName(name)
               .WithType(type)
               .WithValue(value)
               .Build();
    }
}