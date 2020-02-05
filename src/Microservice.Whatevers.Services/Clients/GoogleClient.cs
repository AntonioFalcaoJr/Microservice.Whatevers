using System.Net.Http;
using Microservice.Whatevers.Services.Abstractions;

namespace Microservice.Whatevers.Services.Clients
{
    public class GoogleClient : ClientBase<ClientModelBase>, IGoogleClient<ClientModelBase>
    {
        protected override string Endpoint => "search?q=.net+core+melhor+que+java";
        protected override string ClientName => "google";
        
        public GoogleClient(IHttpClientFactory httpClientFactory) 
            : base(httpClientFactory) { }
    }
}