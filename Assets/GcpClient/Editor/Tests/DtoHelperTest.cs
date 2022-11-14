using System.Collections;
using GcpClient.Runtime.Places.Utils;
using NUnit.Framework;
using UnityEditor;
using UnityEngine.TestTools;
using Assert = UnityEngine.Assertions.Assert;

namespace GcpClient.Editor.Tests
{
    public class DtoHelperTest
    {
        [Test]
        public void SimpleCase()
        {
            var rfc3339 = "2010-12-31";
            var datetime = DtoHelper.Rfc3339ToDateTime(rfc3339);
            Assert.AreEqual(2010, datetime.Year);
            Assert.AreEqual(12, datetime.Month);
            Assert.AreEqual(31, datetime.Day);
        }
    }
}