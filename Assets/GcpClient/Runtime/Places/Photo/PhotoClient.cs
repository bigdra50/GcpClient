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

        public PhotoClient(string apiKey, PhotoConfig photoConfig)
        {
            _client = new BaseHttpClient(PhotoConfig.BaseUrl, new SimpleParameter("key", apiKey));
            _photoConfig = photoConfig;
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
                _photoConfig.TimeoutSec,
                cancellationToken);
            return photo;
        }

        public async UniTask<Texture2D> RequestAsync(
            PhotoReference photoReference,
            MaxWidth maxWidth,
            CancellationToken cancellationToken = default)
        {
            Debug.Log("Request Async");
            var photo = await _client.RequestTextureAsync(
                RequestMethod.Get,
                new IParameter[]
                {
                    photoReference, maxWidth
                },
                _photoConfig.TimeoutSec,
                cancellationToken);
            if(photo==null) Debug.Log("photo is null");
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
                _photoConfig.TimeoutSec,
                cancellationToken);
            return photo;
        }
    }
}