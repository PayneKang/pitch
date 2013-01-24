using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Pitch;

namespace PitchUnitTests
{
    [TestClass]
    public class HmacUnitTests
    {
        [TestMethod]
        public void TestHmacNormalizedRequestString()
        {
					Assert.AreEqual("1336363200\ndj83hs9s\nGET\n/resource/1?b=1&a=2\nexample.com\n80\n\n",
						HmacUtils.GetNormalizedRequestString(
						"1336363200",
						"dj83hs9s",
						"GET",
						"/resource/1?b=1&a=2",
						"example.com",
						80));
					Assert.AreEqual("264095\n7d8f3e4a\nPOST\n/request?b5=%3D%253D&a3=a&c%40=&a2=r%20b&c2&a3=2+q\nexample.com\n80\n\n",
						HmacUtils.GetNormalizedRequestString(
						"264095",
						"7d8f3e4a",
						"POST",
						"/request?b5=%3D%253D&a3=a&c%40=&a2=r%20b&c2&a3=2+q",
						"example.com",
						80));
        }
    }
}
