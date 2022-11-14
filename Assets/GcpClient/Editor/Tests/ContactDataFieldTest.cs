using System.Collections;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime.Places;
using GcpClient.Runtime.Places.Details;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace GcpClient.Editor.Tests
{
    public class ContactDataFieldTest
    {
        private PlacesConfig _placesConfig;
        private DetailsConfig _detailsConfig;

        [OneTimeSetUp]
        public void ContactDataFieldTestOneTimeSetUp()
        {
            _placesConfig = Resources.Load<PlacesConfig>("Places/PlacesConfig");
            _detailsConfig = _placesConfig.DetailsConfig;
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

        [UnityTest]
        public IEnumerator ContactDataFieldTestWithEnumeratorPasses() =>
            UniTask.ToCoroutine(async () => { await UniTask.Yield(); });
    }
}