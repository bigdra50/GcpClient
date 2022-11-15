using System.Collections;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime.Places;
using GcpClient.Runtime.Places.Details;
using GcpClient.Runtime.Places.Details.Request;
using GcpClient.Runtime.Places.Field;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace GcpClient.Editor.Tests
{
    public class ContactDataFieldTest
    {
        private PlacesConfig _placesConfig;

        [OneTimeSetUp]
        public void ContactDataFieldTestOneTimeSetUp()
        {
            _placesConfig = Resources.Load<PlacesConfig>("Places/PlacesConfig");
        }

        [OneTimeTearDown]
        public void ContactDataFieldTestOneTimeTearDown()
        {
        }

        [SetUp]
        public void ContactDataFieldTestSetup()
        {
        }

        [TearDown]
        public void ContactDataFieldTestTearDown()
        {
        }

        [Test]
        public void ContactDataFieldTestSimplePasses()
        {
        }

        [Test]
        public void BasicAllFieldsParameterTest()
        {
            var fields = new Fields(BasicCategory.All);
            Debug.Log($"{fields.Key}={fields.Value}");
        }

        [Test]
        public void MultipleAllFieldsParameterTest()
        {
            var fields = new Fields(BasicCategory.All, ContactCategory.All, AtmosphereCategory.All);
            Debug.Log($"{fields.Key}={fields.Value}");
        }

        [UnityTest]
        public IEnumerator ContactDataFieldTestWithEnumeratorPasses() =>
            UniTask.ToCoroutine(async () => { await UniTask.Yield(); });
    }
}