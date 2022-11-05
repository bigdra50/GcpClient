﻿using System.Collections.Generic;
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

        public PhotoClient(string apiKey)
        {
            _client = new BaseHttpClient(PhotoConfig.BaseUrl, new SimpleParameter("key", apiKey));
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
            var photo = await _client.RequestTextureAsync(
                RequestMethod.Get,
                new IParameter[]
                {
                    photoReference, maxWidth
                },
                _photoConfig.TimeoutSec,
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
                _photoConfig.TimeoutSec,
                cancellationToken);
            return photo;
        }
    }
}