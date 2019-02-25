using System;
using Checkpoint.Crm.Client;
using Checkpoint.Crm.Core.Commands;
using Checkpoint.Crm.Core.Models.Customers;
using Checkpoint.Crm.Core.Models.Orders;
using Checkpoint.Crm.Core.Models.Shared;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Checkpoint.Crm.Tests
{
    [TestFixture]
    public class GeneralTests
    {
        private static string Url = "http://crm-dev.logus.pro/api";
        private static string Token = "aa4484f071e2b0765812527fd1caab849c968c99";

        [Test]
        public void TestConnection()
        {
            Assert.IsNotNull(Token, "Token is undefined!");
            var cli = new CheckpointClient(Url, Token);
            var res = cli.FindPointOfSales(new PointOfSaleFilter());
            Assert.Greater(res.Count, 0);
        }

        [Test]
        public void TestPosUpdate()
        {
            var cli = new CheckpointClient(Url, Token);
            var pos = cli.CreateOrUpdatePos(new PointOfSale
            {
                Code = "c1",
                Name = "n1",
                CurrencyCode = "RUB"
            });
            Assert.Greater(pos.Id, 0);
            /*var pos2 = cli.CreateOrUpdatePos(new PointOfSale
            {
                Code = "c1",
                Name = "n1",
                CurrencyCode = "RUB"
            });
            Assert.AreSame(pos.Id, pos2.Id);*/
        }

        [Test]
        public void TestOrderSearch()
        {
            var cli = new CheckpointClient(Url, Token);
            var orders = cli.FindOrders(new OrderFilter());
            Assert.Greater(orders.Count, 0);
        }

        [Test]
        public void TestOrderCreation()
        {
            var cli = new CheckpointClient(Url, Token);
                        
            
            var order = new Order
            {                                
                ExternalId = Guid.NewGuid().ToString(),
                DateStart = DateTime.Today.AddDays(-1),
                DateEnd = DateTime.Today,
                Name = "test1",
                Customer = new Customer
                {
                    ExternalId = Guid.NewGuid().ToString(),
                    FirstName = "Serg",
                    LastName = "Zhi",
                    Email = "test123425@gmail.com",
                    Phone = "+7999112233",
                    BirthDate = DateTime.Today.AddYears(-12)
                }
            };
            
            order = cli.CreateUpdateOrder("c1", order.ExternalId, order);
            
            Assert.Greater(order.Id, 0);
        }

        [Test]
        public void TestArrayDeserialization()
        {
            var str = @"{""Array"":[1,2,3]}";
            var tc = JsonConvert.DeserializeObject<TestClass>(str);
            Assert.NotNull(tc);
            Assert.NotNull(tc.Array);
            Assert.AreEqual(3, tc.Array.Length);
            Assert.AreEqual(1, tc.Array[0]);
            Assert.AreEqual(2, tc.Array[1]);
            Assert.AreEqual(3, tc.Array[2]);
        }
    }

    public class TestClass
    {
        public byte[] Array { get; set; }
    }
}