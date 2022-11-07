using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime;
using GcpClient.Runtime.Places;
using GcpClient.Runtime.Places.Photo;
using GcpClient.Runtime.Places.Photo.Request;
using GcpClient.Runtime.Places.Search.NearbySearch;
using GcpClient.Runtime.Places.Search.NearbySearch.Request;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace GcpClient.Editor.Tests
{
    public class PlacesTest
    {
        private PlacesConfig _placesConfig;
        private string _mockLocation = "35.7375750771276,139.65359324873822";

        [SetUp]
        public void Setup()
        {
            _placesConfig = Resources.Load<PlacesConfig>("Places/PlacesConfig");
        }


        [UnityTest]
        public IEnumerator PhotoRequestTest() => UniTask.ToCoroutine(async () =>
        {
            var photoConfig = _placesConfig.PhotoConfig;
            await UniTask.Delay(TimeSpan.FromSeconds(.5f));
            Assert.NotNull(_placesConfig, "placesConfig != null");
            Assert.NotNull(photoConfig, "photoConfig != null");
            var client = new PhotoClient(_placesConfig.ApiKey);
            var photo = await client.RequestAsync(
                photoReference: new PhotoReference(
                    "Aap_uEA7vb0DDYVJWEaX3O-AtYp77AaswQKSGtDaimt3gt7QCNpdjp1BkdM6acJ96xTec3tsV_ZJNL_JP-lqsVxydG3nh739RE_hepOOL05tfJh2_ranjMadb3VoBYFvF0ma6S24qZ6QJUuV6sSRrhCskSBP5C1myCzsebztMfGvm7ij3gZT"),
                maxWidth: new MaxWidth(400));
            Assert.NotNull(photo, "photo != null");
            Assert.Greater(photo.width, 0);
        });

        [UnityTest]
        public IEnumerator NearbySearchTest1() => UniTask.ToCoroutine(async () =>
        {
            Assert.NotNull(_placesConfig, "placesConfig != null");
            Assert.IsNotEmpty(_placesConfig.ApiKey);
            var client = new NearbySearchClient(_placesConfig.ApiKey);
            var searchResult = await client.RequestAsync(
                new Location(_mockLocation),
                new List<IParameter>()
                {
                    new Radius(300),
                    new Language(LanguageType.Ja)
                }
            );
            var meta = searchResult.meta;
            Assert.AreEqual(PlacesSearchStatus.Ok, meta.Status);
            if (meta.Status != PlacesSearchStatus.Ok)
            {
                Debug.Log(meta.ErrorMessages);
                Debug.Log(meta.InfoMessages.Aggregate("", (current, x) => current + (x + "\n")));
                Debug.Log(meta.NextPageToken);
                Debug.Log(meta.HtmlAttributions);
            }

            foreach (var place in searchResult.places)
            {
                Debug.Log(place.ToString());
            }
        });
    }
}