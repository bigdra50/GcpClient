using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GcpClient.GcpClient.Runtime;
using GcpClient.Runtime.Places.Photo.Request;
using UnityEngine;

namespace GcpClient.Runtime.Places.Photo
{
    public class PhotoClient
    {
        private readonly BaseHttpClient _client;
        private readonly PhotoConfig _photoConfig;

        public PhotoClient(PlacesConfig placesConfig, PhotoConfig photoConfig)
        {
            _photoConfig = photoConfig;
            _client = new BaseHttpClient(PhotoConfig.BaseUrl, new SimpleParameter("key", placesConfig.ApiKey));
        }

        public async UniTask<Texture2D> RequestAsync(
            PhotoReference photoReference,
            MaxHeight maxHeight = null,
            MaxWidth maxWidth = null,
            CancellationToken cancellationToken = default)
        {
            var photo = await _client.RequestTextureAsync(
                RequestMethod.Get,
                _photoConfig.TimeoutSec,
                cancellationToken,
                photoReference,
                maxHeight,
                maxWidth);
            return photo;
        }
    }
}