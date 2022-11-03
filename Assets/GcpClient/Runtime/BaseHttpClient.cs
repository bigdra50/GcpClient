using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Networking;

namespace GcpClient
{
    public class BaseHttpClient
    {
        private readonly string _baseUri;
        private readonly Dictionary<string, IParameter> _cachedParameters = new();

        public BaseHttpClient(string baseUri, params IParameter[] cacheParams)
        {
            _baseUri = baseUri;
            foreach (var cacheParam in cacheParams)
            {
                if (_cachedParameters.ContainsKey(cacheParam.Key))
                {
                    _cachedParameters[cacheParam.Key] = cacheParam;
                }

                _cachedParameters.Add(cacheParam.Key, cacheParam);
            }
        }

        public async UniTask<string> RequestAsync(
            RequestMethod requestMethod,
            float timeout = 5f,
            CancellationToken cancellationToken = default,
            params IParameter[] parameters)
        {
            if (requestMethod != RequestMethod.Get) throw new NotImplementedException();
            var uriBuilder = new System.UriBuilder(_baseUri)
            {
                Query = CreateQuery(parameters),
            };
            var timeoutTokenSource = new CancellationTokenSource();
            timeoutTokenSource.CancelAfterSlim(TimeSpan.FromSeconds(timeout));
            try
            {
                var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutTokenSource.Token);

                var request = UnityWebRequest.Get(uriBuilder.Uri);
                var response = await request.SendWebRequest().WithCancellation(linkedTokenSource.Token);
                return response.downloadHandler.text;
            }
            catch (UnityWebRequestException e)
            {
                Debug.LogError($"{e.ResponseCode} Error.");
            }
            catch (OperationCanceledException e)
            {
                if (e.CancellationToken == timeoutTokenSource.Token)
                {
                    Debug.Log("TimeOut");
                }
                else
                {
                    Debug.Log(e.Message);
                }
            }

            return null;
        }

        public async UniTask<Texture2D> RequestTextureAsync(
            RequestMethod requestMethod,
            float timeout = 5f,
            CancellationToken cancellationToken = default,
            params IParameter[] parameters)
        {
            if (requestMethod != RequestMethod.Get) throw new NotImplementedException();
            var uriBuilder = new System.UriBuilder(_baseUri)
            {
                Query = CreateQuery(parameters),
            };
            var timeoutTokenSource = new CancellationTokenSource();
            timeoutTokenSource.CancelAfterSlim(TimeSpan.FromSeconds(timeout));
            try
            {
                var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutTokenSource.Token);

                var request = UnityWebRequestTexture.GetTexture(uriBuilder.Uri);
                var response = await request.SendWebRequest().WithCancellation(linkedTokenSource.Token);
                return DownloadHandlerTexture.GetContent(response);
            }
            catch (UnityWebRequestException e)
            {
                Debug.LogError($"{e.ResponseCode} Error.\n" +
                               $"{uriBuilder.Uri}");
            }
            catch (OperationCanceledException e)
            {
                if (e.CancellationToken == timeoutTokenSource.Token)
                {
                    Debug.Log("TimeOut");
                }
                else
                {
                    Debug.Log(e.Message);
                }
            }

            return null;
        }

        private string CreateQuery(params IParameter[] parameters)
        {
            var query = System.Web.HttpUtility.ParseQueryString("");
            foreach (var cache in _cachedParameters.Values)
            {
                query.Add(cache.Key, cache.Value);
            }

            foreach (var parameter in parameters)
            {
                if (parameter == null) continue;
                query.Add(parameter.Key, parameter.Value);
            }

            return query.ToString();
        }
    }
}