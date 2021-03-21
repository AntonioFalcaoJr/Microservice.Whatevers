using System.Net.Http;
using Microservice.Whatevers.Services.Abstractions;
using Microservice.Whatevers.Services.Models;

namespace Microservice.Whatevers.Services.Clients
{
    public class GoogleClient : ClientBase<GoogleClientModel>, IGoogleClient
    {
        public GoogleClient(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory) { }

        protected override string ClientName => "google";
        protected override string Endpoint => "search?q=.net+core+melhor+que+java";
    }
}