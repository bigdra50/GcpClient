using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GcpClient.GcpClient.Runtime;
using GcpClient.Runtime.Places.Details.Request;
using GcpClient.Runtime.Places.Response;
using UnityEngine;

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

        public async UniTask<(PlaceDetailsMeta meta, PlaceInfo place)> RequestAsync(
            PlaceId placeId,
            IEnumerable<IParameter> optionals = default,
            CancellationToken cancellationToken = default)
        {
            var queries = optionals == null
                ? new List<IParameter> { placeId }
                : new List<IParameter>(optionals) { placeId };

            var json = await _client.RequestAsync(
                RequestMethod.Get,
                queries,
                5f,
                cancellationToken);

            Debug.Log(json);
            var result = JsonUtility.FromJson<PlaceDetailsResponse>(json).ToPlaceInfo();
            return result;
        }
    }
}