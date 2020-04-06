using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services.Clients;
using Microservice.Whatevers.Services.Interfaces;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public class GoogleClientService : IGoogleClientService
    {
        private readonly IGoogleClient _googleClient;

        public GoogleClientService(IGoogleClient googleClient) => _googleClient = googleClient;

        public async Task<GoogleClientModel> GetAsync(CancellationToken cancellationToken) => 
            await _googleClient.GetAsync(cancellationToken);
    }
}