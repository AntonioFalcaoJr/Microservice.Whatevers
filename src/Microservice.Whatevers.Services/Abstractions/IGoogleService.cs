using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Abstractions
{
    public interface IGoogleService
    {
        Task<GoogleClientModel> GetAsync(CancellationToken cancellationToken);
    }
}