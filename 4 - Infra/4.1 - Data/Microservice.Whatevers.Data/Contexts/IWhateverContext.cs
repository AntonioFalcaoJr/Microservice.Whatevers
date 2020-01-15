using Microsoft.EntityFrameworkCore;
using Microservice.Whatevers.Domain.Entities;

namespace Microservice.Whatevers.Data.Contexts
{
    public interface IWhateverContext : IDbContext
    {
         DbSet<Whatever> Whatevers {get;set;}
         DbSet<Thing> Things { get; set; }      
    }
}