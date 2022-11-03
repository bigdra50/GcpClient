using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime.Places;
using GcpClient.Runtime.Places.Photo;
using GcpClient.Runtime.Places.Photo.Request;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;

namespace GcpClient.Editor.Tests
{
    public class PlacesTest
    {
        [UnityTest]
        public IEnumerator PhotoRequestTest() => UniTask.ToCoroutine(async () =>
        {
            var placesConfig = Resources.Load<PlacesConfig>("Places/PlacesConfig");
            var photoConfig = Resources.Load<PhotoConfig>("Places/PhotoConfig");
            await UniTask.Delay(TimeSpan.FromSeconds(.1f));
            Assert.NotNull(placesConfig, "placesConfig != null");
            Assert.NotNull(photoConfig, "photoConfig != null");
            var client = new PhotoClient(placesConfig, photoConfig);
            var photo = await client.RequestAsync(
                photoReference: new PhotoReference(
                    "Aap_uEA7vb0DDYVJWEaX3O-AtYp77AaswQKSGtDaimt3gt7QCNpdjp1BkdM6acJ96xTec3tsV_ZJNL_JP-lqsVxydG3nh739RE_hepOOL05tfJh2_ranjMadb3VoBYFvF0ma6S24qZ6QJUuV6sSRrhCskSBP5C1myCzsebztMfGvm7ij3gZT"),
                maxWidth: new MaxWidth(400));
            Assert.NotNull(photo, "photo != null");
            Assert.Greater(photo.width, 0);
        });
    }
}