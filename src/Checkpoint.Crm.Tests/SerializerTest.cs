using Checkpoint.Crm.Client.Json;
using NUnit.Framework;

namespace Checkpoint.Crm.Tests
{
    [TestFixture]
    public class SerializerTest
    {
        [Test]
        public void DecimalTest()
        {
            var s = new NewtonsoftJsonSerializer();
            var res = s.Serialize(new
            {
                a = 0.123456m
            });
            
            Assert.AreEqual("{\r\n  \"a\": 0.12346\r\n}", res);
        }
    }
}