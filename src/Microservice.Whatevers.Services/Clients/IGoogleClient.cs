using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Clients
{
    public interface IGoogleClient
    {
        Task<GoogleClientModel> GetAsync(CancellationToken cancellationToken);
    }
}