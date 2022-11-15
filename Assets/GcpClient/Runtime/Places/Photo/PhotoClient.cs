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
        private readonly PlacesConfig _config;

        public PhotoClient(string apiKey, PlacesConfig config)
        {
            _client = new BaseHttpClient(PlacesConfig.PhotoUrl, new SimpleParameter("key", apiKey));
            _config = config;
        }

        public async UniTask<Texture2D> RequestAsync(
            PhotoReference photoReference,
            MaxHeight maxHeight,
            CancellationToken cancellationToken = default)
        {
            var photo = await _client.RequestTextureAsync(
                RequestMethod.Get,
                new IParameter[]
                {
                    photoReference,
                    maxHeight
                },
                _config.TimeoutSec,
                cancellationToken);
            return photo;
        }

        public async UniTask<Texture2D> RequestAsync(
            PhotoReference photoReference,
            MaxWidth maxWidth,
            CancellationToken cancellationToken = default)
        {
            var photo = await _client.RequestTextureAsync(
                RequestMethod.Get,
                new IParameter[]
                {
                    photoReference, maxWidth
                },
                _config.TimeoutSec,
                cancellationToken);
            return photo;
        }

        public async UniTask<Texture2D> RequestAsync(
            PhotoReference photoReference,
            MaxHeight maxHeight,
            MaxWidth maxWidth,
            CancellationToken cancellationToken = default)
        {
            var photo = await _client.RequestTextureAsync(
                RequestMethod.Get,
                new IParameter[]
                {
                    photoReference,
                    maxHeight,
                    maxWidth
                },
                _config.TimeoutSec,
                cancellationToken);
            return photo;
        }
    }
}