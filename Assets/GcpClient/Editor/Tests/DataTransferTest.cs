using System.Collections;
using System.Linq;
using Cysharp.Threading.Tasks;
using GcpClient.Runtime.Places.Response;
using NUnit.Framework;
using UnityEditor;
using UnityEngine.TestTools;

namespace GcpClient.Editor.Tests
{
    public class DataTransferTest
    {
        [UnityTest]
        public IEnumerator AddressComponent2AddressInfoTest() => UniTask.ToCoroutine(async () =>
        {
            //var mock = new AddressComponent
            //{
            //    long_name = "Cruise Bar",
            //    types = new[] { "bar", "restaurant", "food", "point_of_interest", "establishment" }
            //};
            //var addressInfo = mock.ToAddressInfo();
            //Assert.AreEqual("Cruise Bar", addressInfo.LongName);
            //Assert.AreEqual(5, addressInfo.Types.Length);
            //Assert.IsTrue(addressInfo.Types.Contains());
        });
    }
}