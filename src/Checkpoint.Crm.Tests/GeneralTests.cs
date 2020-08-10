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
        private static string Url = "http://localhost:8000/api";
        private static string Token = Environment.GetEnvironmentVariable("CheckpointToken");

        [Test]
        public void TestConnection()
        {
            Assert.IsNotNull(Token, "Token is undefined!");
            var cli = new CheckpointClient(Url, Token);
            var res = cli.FindPointOfSales(new PointOfSaleFilter());
            Assert.Greater(res.Count, 0);
        }


        [Test]
        public void TestOrderSearch()
        {
            var cli = new CheckpointClient(Url, Token);
            var orders = cli.FindOrders(new OrderFilter());
            Assert.Greater(orders.Count, 0);
            Assert.IsNotNull(orders.Results);
            foreach (var order in orders.Results)
            {
                Assert.Greater(order.Id, 0);
                var ord = cli.GetOrder(order.Id);
                Assert.IsNotNull(ord);
            }
        }
        
        [Test]
        public void TestPricePrecision()
        {
            var cli = new CheckpointClient(Url, Token);
            var res = cli.PreviewPromoOffers(new ApplyPromoOffersRequest
            {
                Order = new Order
                {
                    PosCode = "MAIN",
                    Name = "order1",
                    ExternalId = "1",
                    DateStart = DateTime.Today,
                    DateEnd = null,
                    Items = new []
                    {
                        new OrderItem
                        {
                            Date = DateTime.Today,
                            Code="123",
                            Name="Text",
                            Amount = 10,
                            AmountBeforeDiscount = 10.123456m
                        }
                    }
                }
            });
        }

        [Test]
        public void TestTiersSearch()
        {
            var cli = new CheckpointClient(Url, Token);
            var tiers = cli.GetTiers();
            Assert.Greater(tiers.Count, 0);
            foreach (var tier in tiers.Results)
            {
                Assert.Greater(tier.Id, 0);
            }
        }

        [Test]
        public void TestCustomerAndAccountOperations()
        {
            var cli = new CheckpointClient(Url, Token);
            
            var order = new Order
            {                                
                ExternalId = Guid.NewGuid().ToString(),
                DateStart = DateTime.Today.AddDays(-1),
                DateEnd = DateTime.Today,
                Name = "Reservation",
                Customer = new Customer
                {
                    ExternalId = Guid.NewGuid().ToString(),
                    FirstName = "Serg",
                    LastName = "Zhi",
                    Email = "test1234256@gmail.com",
                    Phone = "+7999112244",
                    BirthDate = new DateTime(1981, 12, 11)
                }
            };
            
            order = cli.CreateUpdateOrder("MAIN", order.ExternalId, order);
            
            var customers = cli.FindCustomers(new CustomerFilter());
            Assert.Greater(customers.Count, 0);
            var customer = cli.GetCustomer(customers.Results[0].Id);
            Assert.IsNotNull(customer.Cards);
            Assert.Greater(customer.Cards.Length, 0);
            var card = customer.Cards[0];
            var pointOperation = cli.ChargePoints(new ChargePointsRequest("Points test", "MAIN", order.ExternalId, card.Account.Id, 10, "test user"));
            Assert.IsNotNull(pointOperation);
            Assert.Greater(pointOperation.Id, 0);
            
            cli.ChargedPointsDelete(pointOperation.Id);

            cli.DeleteOrder(order.Id);
        }
        
        [Test]
        public void TestCustomerSearch()
        {
            var cli = new CheckpointClient(Url, Token);
            var customers = cli.FindCustomers(new CustomerFilter
            {
                BirthDate = new DateTime(2020, 1, 1)
            });
            Assert.Greater(customers.Count, 0);
        }

        /*[Test]
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
        }*/

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