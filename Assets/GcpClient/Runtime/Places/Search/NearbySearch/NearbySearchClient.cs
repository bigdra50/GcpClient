using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GcpClient.GcpClient.Runtime;
using GcpClient.Runtime.Places.Response;
using GcpClient.Runtime.Places.Search.NearbySearch.Request;
using UnityEngine;

namespace GcpClient.Runtime.Places.Search.NearbySearch
{
    public class NearbySearchClient
    {
        private readonly BaseHttpClient _client;
        private readonly NearbySearchConfig _config;

        public NearbySearchClient(string apiKey)
        {
            _client = new BaseHttpClient(NearbySearchConfig.BaseUrl, new SimpleParameter("key", apiKey));
        }


        public async UniTask<(PlaceSearchMeta meta, List<PlaceInfo> places)> RequestAsync(
            Location location,
            IEnumerable<IParameter> optionals = default,
            CancellationToken cancellationToken = default)
        {
            var queries = optionals == null
                ? new List<IParameter> { location }
                : new List<IParameter>(optionals) { location };

            var json = await _client.RequestAsync(
                RequestMethod.Get,
                queries,
                5f,
                cancellationToken);

            var result = JsonUtility.FromJson<PlacesNearbySearchResponseDto>(json).ToPlaceInfo();
            return result;
        }
    }
}