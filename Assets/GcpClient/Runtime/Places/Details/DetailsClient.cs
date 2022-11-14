using System.Threading;
using Cysharp.Threading.Tasks;
using GcpClient.GcpClient.Runtime;

namespace GcpClient.Runtime.Places.Details
{
    public class DetailsClient
    {
        private readonly BaseHttpClient _client;
        private readonly DetailsConfig _config;

        public DetailsClient(string apiKey)
        {
            _client = new BaseHttpClient(DetailsConfig.BaseUrl, new SimpleParameter("key", apiKey));
        }

        public async UniTask RequestAsync(
            CancellationToken cancellationToken = default)
        {
        }
    }
}