using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime;
using GcpClient.Runtime.Places;
using GcpClient.Runtime.Places.Details;
using GcpClient.Runtime.Places.Details.Request;
using GcpClient.Runtime.Places.Field;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace GcpClient.Editor.Tests
{
    public class DetailsTest
    {
        private PlacesConfig _placesConfig;
        private DetailsClient _client;

        [OneTimeSetUp]
        public void DetailsTestOneTimeSetUp()
        {
            _placesConfig = Resources.Load<PlacesConfig>("Places/PlacesConfig");
            _client = new DetailsClient(_placesConfig.ApiKey);
        }

        [OneTimeTearDown]
        public void DetailsTestOneTimeTearDown()
        {
        }

        [SetUp]
        public void DetailsTestSetup()
        {
        }

        [TearDown]
        public void DetailsTestTearDown()
        {
        }


        [Test]
        public void DetailsTestSimplePasses()
        {
        }

        [UnityTest]
        public IEnumerator DetailsTestWithEnumeratorPasses() => UniTask.ToCoroutine(async () =>
        {
            var details = await _client.RequestAsync(new PlaceId("ChIJN1t_tDeuEmsRUsoyG83frY4"),
                new List<IParameter>
                {
                    new Fields(BasicCategory.Name, ContactCategory.FormattedPhoneNumber, AtmosphereCategory.Rating)
                });
            var meta = details.meta;
            Assert.AreEqual(PlaceDetailsStatus.Ok, meta.Status);
            if (meta.Status != PlaceDetailsStatus.Ok)
            {
                Debug.Log(meta.Status);
                Debug.Log(meta.InfoMessages);
                Debug.Log(meta.HtmlAttributions);
            }

            Assert.NotNull(details.place, "placeInfo != null");
            Assert.NotNull(details.place.Basic.Name, "placeInfo.Basic.Name != null");
            Assert.NotNull(details.place.Contact.FormattedPhoneNumber);
        });
    }
}