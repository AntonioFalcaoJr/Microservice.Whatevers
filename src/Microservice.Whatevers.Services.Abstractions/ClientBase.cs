using System.Net.Http;
using System.Threading.Tasks;

namespace Microservice.Whatevers.Services.Abstractions
{
    public abstract class ClientBase<TClientModel> where TClientModel : ClientModelBase, new()
    {
        private readonly IHttpClientFactory _httpClientFactory;
        protected abstract string Endpoint { get; }
        protected abstract string ClientName { get; }

        protected ClientBase(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;
        
        private HttpClient GetClient() => _httpClientFactory.CreateClient(ClientName);

        public async Task<TClientModel> GetAsync()
        {
            var responseMessage = await GetClient().GetAsync(Endpoint);

            return responseMessage.IsSuccessStatusCode
                ? await OnSuccess(responseMessage)
                : OnError(responseMessage);
        }

        private TClientModel OnError(HttpResponseMessage responseMessage)
        {
            var model = new TClientModel();
            model.AddError(responseMessage.ToString());
            return model;
        }

        private async Task<TClientModel> OnSuccess(HttpResponseMessage responseMessage)
        {
            var resultAsString = await responseMessage.Content.ReadAsStringAsync();
            return new TClientModel { Result = resultAsString };
        }
    }
}