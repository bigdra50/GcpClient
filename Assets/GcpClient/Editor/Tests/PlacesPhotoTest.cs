using System.Collections;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime.Places;
using GcpClient.Runtime.Places.Photo;
using GcpClient.Runtime.Places.Photo.Request;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace GcpClient.Editor.Tests
{
    public class PlacesPhotoTest
    {
        private PlacesConfig _placesConfig;

        [SetUp]
        public void PlacesPhotoTestSetup()
        {
        }

        [TearDown]
        public void PlacesPhotoTestTearDown()
        {
        }

        [UnitySetUp]
        public IEnumerator PlacesPhotoTestUnitySetup()
        {
            yield break;
        }

        [UnityTearDown]
        public IEnumerator PlacesPhotoTestUnityTearDown()
        {
            yield break;
        }

        [OneTimeSetUp]
        public void PlacesPhotoTestOneTimeSetUp()
        {
            _placesConfig = Resources.Load<PlacesConfig>("Places/PlacesConfig");
        }

        [OneTimeTearDown]
        public void PlacesPhotoTestOneTimeTearDown()
        {
        }

        [Test]
        public void PlacesPhotoTestSimplePasses()
        {
        }

        [Test]
        public void ValidatePlacesConfig()
        {
            Assert.NotNull(_placesConfig, "placesConfig != null");
            Assert.IsFalse(string.IsNullOrEmpty(_placesConfig.ApiKey), "string.IsNullOrEmpty(_placesConfig.ApiKey)");
            Assert.NotNull(_placesConfig.PhotoConfig, "_placesConfig.PhotoConfig != null");
        }

        [UnityTest]
        public IEnumerator PhotoRequestTest() => UniTask.ToCoroutine(async () =>
        {
            var client = new PhotoClient(_placesConfig.ApiKey, _placesConfig.PhotoConfig);
            var photo = await client.RequestAsync(
                new PhotoReference(
                    "Aap_uEA7vb0DDYVJWEaX3O-AtYp77AaswQKSGtDaimt3gt7QCNpdjp1BkdM6acJ96xTec3tsV_ZJNL_JP-lqsVxydG3nh739RE_hepOOL05tfJh2_ranjMadb3VoBYFvF0ma6S24qZ6QJUuV6sSRrhCskSBP5C1myCzsebztMfGvm7ij3gZT"),
                new MaxWidth(400));
            Assert.NotNull(photo, "photo != null");
            Assert.Greater(photo.width, 0);
        });
    }
}