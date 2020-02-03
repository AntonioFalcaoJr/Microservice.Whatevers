namespace Microservice.Whatevers.Domain.Entities
{
    public class Thing : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Value { get; set; }
        public virtual Whatever Whatever { get; set; }
    }
}