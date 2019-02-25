using System;
using System.Net;
using System.Web;
using Checkpoint.Crm.Client.Json;
using Checkpoint.Crm.Core;
using Checkpoint.Crm.Core.Commands;
using Checkpoint.Crm.Core.Exceptions;
using Checkpoint.Crm.Core.Models.Base;
using Checkpoint.Crm.Core.Models.Cards;
using Checkpoint.Crm.Core.Models.Customers;
using Checkpoint.Crm.Core.Models.Orders;
using Checkpoint.Crm.Core.Models.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestRequest = RestSharp.RestRequest;

namespace Checkpoint.Crm.Client
{
    public class CheckpointClient : ILoyaltyService
    {
        private static readonly JsonSerializer JsonSerializer = new JsonSerializer
        {
            ContractResolver = new CheckpointContractResolver()
                .AddSettings<Customer>(c =>
                {
                    c.RuleFor(ct => ct.BirthDate).Converter(new DateFormatter());
                    c.RuleFor(ct => ct.DocIssueDate).Converter(new DateFormatter());
                    c.RuleFor(ct => ct.DocExpirationDate).Converter(new DateFormatter());
                }),
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            Formatting = Formatting.Indented,
            Converters =
            {
                new StringEnumConverter()
            }
        };

        private readonly string _baseUrl;
        private readonly string _token;
        private readonly RestClient _restClient;
        private bool _debugMode;

        /// <summary>
        /// Creates client service
        /// </summary>
        /// <param name="url">URL to loyalty server</param>
        /// <param name="token">Auth token to login</param>
        /// <param name="debugMode">If set, requests may be logged on server side (can be slower, avoid production usage)</param>
        public CheckpointClient(string url, string token, bool debugMode = false)
        {
            _debugMode = debugMode;
            if (!url.EndsWith("/"))
                url += "/";
            _baseUrl = new Uri(url).GetLeftPart(UriPartial.Authority);
            _token = token;
            _restClient = new RestClient(url);
            var serializer = new NewtonsoftJsonSerializer(JsonSerializer);
            _restClient.AddHandler("application/json", serializer);
            _restClient.AddHandler("text/json", serializer);
        }

        public ApplicablePromoOffersResponse GetApplicablePromoOffers(GetApplicablePromoOffersRequest request)
        {
            var req = BuildRequest("offers", Method.POST);
            req.AddBody(request);
            var response = _restClient.Execute<ApplicablePromoOffersResponse>(req);
            AssertOk(response);
            return response.Data;
        }

        public ApplyPromoOffersResponse ApplyPromoOffers(ApplyPromoOffersRequest request)
        {
            var req = BuildRequest("apply-offers", Method.POST);
            req.AddBody(request);
            var response = _restClient.Execute<ApplyPromoOffersResponse>(req);
            AssertOk(response);
            return response.Data;
        }

        public ApplyPromoOffersResponse PreviewPromoOffers(ApplyPromoOffersRequest request)
        {
            var req = BuildRequest("apply-offers/preview/", Method.POST);
            req.AddBody(request);
            var response = _restClient.Execute<ApplyPromoOffersResponse>(req);
            AssertOk(response);
            return response.Data;
        }

        public AccountOperation ChargePoints(ChargePointsRequest request)
        {
            var req = BuildRequest("accounts/charge/", Method.POST);
            req.AddBody(request);
            var response = _restClient.Execute<AccountOperation>(req);
            AssertOk(response);
            return response.Data;
        }

        public AccountOperationList FindAccountOperations(AccountOperationFilter filter)
        {
            var req = BuildRequest("account-operations", Method.GET, filter);

            if (!string.IsNullOrEmpty(filter.PointOfSaleCode))
                req.AddQueryParameter("point_of_sale__code", filter.PointOfSaleCode);

            if (!string.IsNullOrEmpty(filter.ExternalId))
                req.AddQueryParameter("external_id", filter.ExternalId);

            if (filter.AccountId != null)
                req.AddQueryParameter("account_id", filter.AccountId.Value.ToString());

            var res = _restClient.Execute<AccountOperationList>(req);
            AssertOk(res);
            return res.Data;
        }

        public void ChargedPointsDelete(int accountOperationId)
        {
            var req = BuildRequest($"account-operations/{accountOperationId}/", Method.DELETE);
            
            AssertOk(_restClient.Execute(req));
        }

        public PointOfSaleList FindPointOfSales(PointOfSaleFilter filter)
        {
            var req = BuildRequest("point-of-sales", Method.GET, filter);

            if (!string.IsNullOrEmpty(filter.Code))
                req.AddQueryParameter("code", filter.Code);

            if (!string.IsNullOrEmpty(filter.Name))
                req.AddQueryParameter("name", filter.Name);

            var res = _restClient.Execute<PointOfSaleList>(req);
            AssertOk(res);
            return res.Data;
        }

        public PointOfSale CreateOrUpdatePos(PointOfSale request)
        {
            var req = BuildRequest(request.Id == 0 ? "point-of-sales" : $"point-of-sales/{request.Id}/", request.Id == 0 ? Method.POST : Method.PUT);
            req.AddBody(request);
            var res = _restClient.Execute<PointOfSale>(req);
            AssertOk(res);
            return res.Data;
        }

        public PointOfSale GetPointOfSale(long pointOfSaleId)
        {
            var req = BuildRequest($"point-of-sales/{pointOfSaleId}/", Method.GET);            
            var res = _restClient.Execute<PointOfSale>(req);
            AssertOk(res);
            return res.Data;
        }

        public Order GetOrder(string pointOfSaleCode, string externalOrderId)
        {
            var req = BuildRequest($"point-of-sales/{HttpUtility.UrlEncode(pointOfSaleCode)}/orders/eid/{HttpUtility.UrlEncode(externalOrderId)}/", Method.GET);
            var res = _restClient.Execute<Order>(req);
            AssertOk(res);
            return res.Data;
        }

        public OrderList FindOrders(OrderFilter filter)
        {
            var req = BuildRequest("orders", Method.GET, filter);

            if (filter.CustomerId != null)
                req.AddQueryParameter("customer", filter.CustomerId.ToString());

            var res = _restClient.Execute<OrderList>(req);
            AssertOk(res);
            return res.Data;
        }

        public Order CreateUpdateOrder(string pointOfSaleCode, string externalOrderId, Order order)
        {
            var req = BuildRequest($"point-of-sales/{HttpUtility.UrlEncode(pointOfSaleCode)}/orders/eid/{HttpUtility.UrlEncode(externalOrderId)}/", Method.POST);
            req.AddBody(order);            
            var res = _restClient.Execute<Order>(req);
            AssertOk(res);
            return res.Data;
        }

        public OrderExtraField GetOrderExtraField(int orderId, string fieldName)
        {
            var req = BuildRequest($"orders/{orderId}/extra-fields/{HttpUtility.UrlEncode(fieldName)}/", Method.GET);
            var res = _restClient.Execute<OrderExtraField>(req);
            AssertOk(res);
            return res.Data;
        }

        public TierList GetCardSets()
        {
            var req = BuildRequest("tiers", Method.GET);

            var res = _restClient.Execute<TierList>(req);
            AssertOk(res);
            return res.Data;
        }

        public CardList FindCards(CardFilter filter)
        {
            var req = BuildRequest("cards", Method.GET, filter);

            if (!string.IsNullOrEmpty(filter.CardNo))
                req.AddQueryParameter("card_no", filter.CardNo);
            if (filter.IsActive != null)
                req.AddQueryParameter("is_active", filter.IsActive.Value.ToString().ToLowerInvariant());
            if (filter.CustomerId != null)
                req.AddQueryParameter("customer", filter.CustomerId.Value.ToString());

            var res = _restClient.Execute<CardList>(req);
            AssertOk(res);
            return res.Data;
        }

        public Card CreateUpdateCard(Card request)
        {
            var req = BuildRequest(request.Id == 0 ? "cards" : $"cards/{request.Id}/", request.Id == 0 ? Method.POST : Method.PUT);
            req.AddBody(request);
            var res = _restClient.Execute<Card>(req);
            AssertOk(res);
            return res.Data;
        }

        public Customer GetCustomer(int id)
        {
            var req = BuildRequest($"customers/{id}/", Method.GET);
            var res = _restClient.Execute<Customer>(req);
            AssertOk(res);
            res.Data.ViewUrl = _baseUrl + res.Data.ViewUrl;
            return res.Data;
        }
        
        public Customer CreateUpdateCustomer(Customer customer)
        {
            var req = BuildRequest($"customers-sync/", Method.POST);
            req.AddBody(customer);
            var res = _restClient.Execute<Customer>(req);
            AssertOk(res);
            res.Data.ViewUrl = _baseUrl + res.Data.ViewUrl;
            return res.Data;
        }

        public CustomerList FindCustomers(CustomerFilter filter)
        {
            var req = BuildRequest("customers", Method.GET, filter);

            if (!string.IsNullOrEmpty(filter.Email))
                req.AddQueryParameter("email", filter.Email);
            if (!string.IsNullOrEmpty(filter.Phone))
                req.AddQueryParameter("phone", filter.Phone);
            if (!string.IsNullOrEmpty(filter.ExternalId))
                req.AddQueryParameter("external_id", filter.ExternalId);

            var res = _restClient.Execute<CustomerList>(req);
            AssertOk(res);
            if (res.Data.Results != null)
                foreach (var customer in res.Data.Results)
                {
                    customer.ViewUrl = _baseUrl + customer.ViewUrl;
                }

            return res.Data;
        }

        #region Helpers

        private RestRequest BuildRequest(string url, Method method, FilterBase filter = null)
        {
            if (!url.EndsWith("/"))
                url += "/";
            var request = new RestRequest(url, method) {RequestFormat = DataFormat.Json};
            request.AddHeader("Authorization", "Token " + _token);
            if (_debugMode)
                request.AddHeader("X-Log", "1");
            
            request.JsonSerializer = new NewtonsoftJsonSerializer(JsonSerializer);

            if (filter != null)
            {
                if (filter.ModifiedSince != null)
                    request.AddQueryParameter("date_modified__gt", filter.ModifiedSince.Value.ToString("YYYY-DD-MMTHH:mm:ss"));
                if (filter.Page != null)
                    request.AddQueryParameter("page", filter.Page.Value.ToString());
            }

            return request;
        }

        private void AssertOk(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new LoyaltyException("Bad request: " + response.Content);
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new LoyaltyNotFoundException("Not found: " + response.ResponseUri);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw new LoyaltyException("Internal server error: " + response.Content);
            if (response.ErrorException != null)
                throw new LoyaltyException("Error processing loyalty request", response.ErrorException);
            if (response.StatusCode != HttpStatusCode.Created
                && response.StatusCode != HttpStatusCode.OK
                && response.StatusCode != HttpStatusCode.NoContent)
                throw new LoyaltyException("Error processing request, status is: " + response.StatusCode);
        }

        #endregion
    }
}