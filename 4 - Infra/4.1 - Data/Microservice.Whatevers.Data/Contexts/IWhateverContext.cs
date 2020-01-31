using Microservice.Whatevers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Whatevers.Data.Contexts
{
    public interface IWhateverContext : IDbContext
    {
        DbSet<Thing> Things { get; set; }
        DbSet<Whatever> Whatevers { get; set; }
    }
}