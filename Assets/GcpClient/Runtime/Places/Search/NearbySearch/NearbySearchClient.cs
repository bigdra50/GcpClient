using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GcpClient.GcpClient.Runtime;
using GcpClient.Runtime.Places.Response;
using GcpClient.Runtime.Places.Search.NearbySearch.Request;

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


        public async UniTask<List<PlaceInfo>> RequestAsync(
            Location location,
            IEnumerable<IParameter> optionals,
            CancellationToken cancellationToken = default)
        {
            // Requiredなクエリはシグネチャで表現したいが､optionalなクエリと合成する負荷がきになる
            var queries = new List<IParameter>(optionals)
            {
                location
            };
            var json = await _client.RequestAsync(
                RequestMethod.Get,
                queries,
                5f,
                cancellationToken);
            // TODO: deserialise json
            throw new NotImplementedException();
        }
    }
}