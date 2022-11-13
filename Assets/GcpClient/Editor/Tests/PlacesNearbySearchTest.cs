using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime;
using GcpClient.Runtime.Places;
using GcpClient.Runtime.Places.Search.NearbySearch;
using GcpClient.Runtime.Places.Search.NearbySearch.Request;
using NUnit.Framework;
using UnityEngine;

namespace GcpClient.Editor.Tests
{
    public class PlacesNearbySearchTest
    {
        private PlacesConfig _placesConfig;
        private string _mockLocation = "35.7375750771276,139.65359324873822";

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _placesConfig = Resources.Load<PlacesConfig>("Places/PlacesConfig");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        [Test]
        public void ValidateConfig()
        {
            Assert.NotNull(_placesConfig, "placesConfig != null");
            Assert.IsFalse(string.IsNullOrEmpty(_placesConfig.ApiKey), "string.IsNullOrEmpty(_placesConfig.ApiKey)");
        }


        [UnityEngine.TestTools.UnityTest]
        public IEnumerator NearbySearchTest1() => UniTask.ToCoroutine(async () =>
        {
            var client = new NearbySearchClient(_placesConfig.ApiKey);
            var searchResult = await client.RequestAsync(
                new Location(_mockLocation),
                new List<IParameter>
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