using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Abstractions
{
    public abstract class ClientBase<TClientModel>
        where TClientModel : ClientModelBase, new()
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected ClientBase(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected abstract string ClientName { get; }
        protected abstract string Endpoint { get; }

        public async Task<TClientModel> GetAsync(CancellationToken cancellationToken)
        {
            var responseMessage = await GetClient().GetAsync(Endpoint, cancellationToken);

            return responseMessage.IsSuccessStatusCode
                ? await OnSuccessAsync(responseMessage).ConfigureAwait(false)
                : OnError(responseMessage);
        }

        private HttpClient GetClient() => _httpClientFactory.CreateClient(ClientName);

        private static TClientModel OnError(HttpResponseMessage responseMessage) =>
            new TClientModel {Result = responseMessage.ToString()};

        private static async Task<TClientModel> OnSuccessAsync(HttpResponseMessage responseMessage)
        {
            var resultAsString = await responseMessage.Content.ReadAsStringAsync();
            return new TClientModel {Result = resultAsString};
        }
    }
}