using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services.Clients;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services
{
    public class GoogleService : IGoogleService
    {
        private readonly IGoogleClient _googleClient;

        public GoogleService(IGoogleClient googleClient)
        {
            _googleClient = googleClient;
        }

        public async Task<GoogleClientModel> GetAsync(CancellationToken cancellationToken) =>
            await _googleClient.GetAsync(cancellationToken);
    }
}