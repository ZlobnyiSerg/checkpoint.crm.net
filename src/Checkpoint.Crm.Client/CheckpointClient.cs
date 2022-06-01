using System;
using System.Net;
using System.Threading;
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
using RestSharp;
using RestRequest = RestSharp.RestRequest;

namespace Checkpoint.Crm.Client
{
    /// <inheritdoc />
    public class CheckpointClient : ILoyaltyService
    {
        private readonly string _baseUrl;
        private readonly string _token;
        private readonly RestClient _restClient;
        private readonly bool _debugMode;
        private readonly NewtonsoftJsonSerializer _serializer;

        /// <summary>
        /// Creates client service
        /// </summary>
        /// <param name="url">URL to loyalty server</param>
        /// <param name="token">Auth token to login</param>
        /// <param name="debugMode">If set, requests may be logged on server side (can be slower, avoid production usage)</param>
        /// <param name="useSnakeCase">Force usage of legacy snake case format for properties</param>
        public CheckpointClient(string url, string token, bool debugMode = false, bool useSnakeCase = false)
        {
            _debugMode = debugMode;
            if (!url.EndsWith("/"))
                url += "/";
            _baseUrl = new Uri(url).GetLeftPart(UriPartial.Authority);
            _token = token;
            _restClient = new RestClient(url)
            {
                ThrowOnDeserializationError = false,
                ThrowOnAnyError = true
            };
            _serializer = new NewtonsoftJsonSerializer();
            _restClient.AddHandler("application/json", () => _serializer);
            _restClient.AddHandler("text/json", () => _serializer);
        }

        /// <inheritdoc />
        public ApplicablePromoOffersResponse GetApplicablePromoOffers(GetApplicablePromoOffersRequest request)
        {
            var req = BuildRequest("offers", Method.POST);
            req.AddJsonBody(request);
            var response = ExecuteRequestInternal<ApplicablePromoOffersResponse>(req);
            AssertOk(response);
            return response.Data;
        }

        /// <inheritdoc />
        public ApplyPromoOffersResponse ApplyPromoOffers(ApplyPromoOffersRequest request)
        {
            var req = BuildRequest("apply-offers", Method.POST);
            req.AddJsonBody(request);
            var response = ExecuteRequestInternal<ApplyPromoOffersResponse>(req);
            AssertOk(response);
            return response.Data;
        }

        /// <inheritdoc />
        public ApplyPromoOffersResponse PreviewPromoOffers(ApplyPromoOffersRequest request)
        {
            var req = BuildRequest("apply-offers/preview/", Method.POST);
            req.AddJsonBody(request);
            var response = ExecuteRequestInternal<ApplyPromoOffersResponse>(req);
            AssertOk(response);
            return response.Data;
        }

        /// <inheritdoc />
        public AccountOperation ChargePoints(ChargePointsRequest request)
        {
            var req = BuildRequest("accounts/charge/", Method.POST);
            req.AddJsonBody(request);
            var response = ExecuteRequestInternal<AccountOperation>(req);
            AssertOk(response);
            return response.Data;
        }

        /// <inheritdoc />
        public AccountOperationList FindAccountOperations(AccountOperationFilter filter)
        {
            var req = BuildRequest($"account-operations/{filter.AccountId}/", Method.GET);
            var res = ExecuteRequestInternal<AccountOperationList>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public void ChargedPointsDelete(DeleteAccountOperationRequest request)
        {
            var req = BuildRequest($"account-operations/{request.AccountOperationId}/", Method.DELETE);
            req.AddJsonBody(request);
            AssertOk(ExecuteRequestInternal(req));
        }

        /// <inheritdoc />
        public PointOfSaleList FindPointOfSales(PointOfSaleFilter filter)
        {
            var req = BuildRequest("point-of-sales", Method.GET, filter);

            if (!string.IsNullOrEmpty(filter.Code))
                req.AddQueryParameter("code", filter.Code);

            if (!string.IsNullOrEmpty(filter.Name))
                req.AddQueryParameter("name", filter.Name);

            var res = ExecuteRequestInternal<PointOfSaleList>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public PointOfSale CreateOrUpdatePos(PointOfSale request)
        {
            var req = BuildRequest(request.Id == 0 ? "point-of-sales" : $"point-of-sales/{request.Id}/", request.Id == 0 ? Method.POST : Method.PUT);
            req.AddJsonBody(request);
            var res = ExecuteRequestInternal<PointOfSale>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public PointOfSale GetPointOfSale(long pointOfSaleId)
        {
            var req = BuildRequest($"point-of-sales/{pointOfSaleId}/", Method.GET);            
            var res = ExecuteRequestInternal<PointOfSale>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public Order GetOrder(int orderId)
        {
            var req = BuildRequest($"orders/{orderId}/", Method.GET);
            var res = ExecuteRequestInternal<Order>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public Order GetOrder(string pointOfSaleCode, string externalOrderId)
        {
            var req = BuildRequest($"point-of-sales/{HttpUtility.UrlEncode(pointOfSaleCode)}/orders/eid/{HttpUtility.UrlEncode(externalOrderId)}/", Method.GET);
            var res = ExecuteRequestInternal<Order>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public OrderList FindOrders(OrderFilter filter)
        {
            var req = BuildRequest("orders", Method.GET, filter);

            if (filter.CustomerId != null)
                req.AddQueryParameter("customer", filter.CustomerId.ToString());
            
            if (filter.ParentId != null)
                req.AddQueryParameter("parent_id", filter.ParentId.ToString());
            
            var res = ExecuteRequestInternal<OrderList>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public Order CreateUpdateOrder(string pointOfSaleCode, string externalOrderId, Order order)
        {
            var req = BuildRequest($"point-of-sales/{HttpUtility.UrlEncode(pointOfSaleCode)}/orders/eid/{HttpUtility.UrlEncode(externalOrderId)}/", Method.POST);
            order.PosCode ??= pointOfSaleCode;
            order.ExternalId ??= externalOrderId;
            req.AddJsonBody(order);            
            var res = ExecuteRequestInternal<Order>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public OrderExtraField? GetOrderExtraField(int orderId, string fieldName)
        {
            var req = BuildRequest($"orders/{orderId}/extra-fields/{HttpUtility.UrlEncode(fieldName)}/", Method.GET);
            var res = ExecuteRequestInternal<OrderExtraField>(req);
            if (res.StatusCode == HttpStatusCode.NotFound)
                return null;
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public void DeleteOrder(int orderId)
        {
            var req = BuildRequest($"orders/{orderId}/", Method.DELETE);                        
            var res = ExecuteRequestInternal<Order>(req);
            AssertOk(res);            
        }

        /// <inheritdoc />
        public TierList GetTiers()
        {
            var req = BuildRequest("tiers", Method.GET);

            var res = ExecuteRequestInternal<TierList>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public CardList FindCards(CardFilter filter)
        {
            var req = BuildRequest("cards", Method.GET, filter);

            if (!string.IsNullOrEmpty(filter.CardNo))
                req.AddQueryParameter("card_no", filter.CardNo);
            if (filter.IsActive != null)
                req.AddQueryParameter("is_active", filter.IsActive.Value.ToString().ToLowerInvariant());
            if (filter.CustomerId != null)
                req.AddQueryParameter("customer", filter.CustomerId.Value.ToString());

            var res = ExecuteRequestInternal<CardList>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public Card IssueCard(IssueCardRequest request)
        {
            var req = BuildRequest("cards", Method.POST);
            req.AddJsonBody(request);
            var res = ExecuteRequestInternal<Card>(req);
            AssertOk(res);
            return res.Data;
        }

        /// <inheritdoc />
        public Customer GetCustomer(int id)
        {
            var req = BuildRequest($"customers/{id}/", Method.GET);
            var res = ExecuteRequestInternal<Customer>(req);
            AssertOk(res);
            res.Data.ViewUrl = _baseUrl + res.Data.ViewUrl;
            return res.Data;
        }

        /// <inheritdoc />
        public Customer GetCustomerByExternalId(string externalId)
        {
            var req = BuildRequest($"customers/eid/{externalId}/", Method.GET);
            var res = ExecuteRequestInternal<Customer>(req);
            AssertOk(res);
            res.Data.ViewUrl = _baseUrl + res.Data.ViewUrl;
            return res.Data;
        }

        /// <inheritdoc />
        public Customer CreateUpdateCustomer(Customer customer)
        {
            if (customer.Id != 0)
            {
                var req = BuildRequest($"customers/{customer.Id}/", Method.PUT);
                req.AddJsonBody(customer);
                var res = ExecuteRequestInternal<Customer>(req);
                AssertOk(res);
                res.Data.ViewUrl = _baseUrl + res.Data.ViewUrl;
                return res.Data;
            }
            else
            {
                var req = BuildRequest("customers-sync/", Method.POST);
                req.AddJsonBody(customer);
                var res = ExecuteRequestInternal<Customer>(req);
                AssertOk(res);
                res.Data.ViewUrl = _baseUrl + res.Data.ViewUrl;
                return res.Data;
            }
        }

        /// <inheritdoc />
        public CustomerList FindCustomers(CustomerFilter filter)
        {
            var req = BuildRequest("customers", Method.GET, filter);

            if (!string.IsNullOrEmpty(filter.Email))
                req.AddQueryParameter("email", filter.Email);
            
            if (!string.IsNullOrEmpty(filter.Phone))
                req.AddQueryParameter("phone", filter.Phone);

            if (!string.IsNullOrEmpty(filter.LastName))
                req.AddQueryParameter("last_name", filter.LastName);

            if (filter.BirthDate != null)
                req.AddQueryParameter("birth_date", filter.BirthDate.Value.ToString("yyyy-MM-dd"));
            
            if (!string.IsNullOrEmpty(filter.ExternalId))
                req.AddQueryParameter("external_id", filter.ExternalId);
            
            if (!string.IsNullOrEmpty(filter.Query))
                req.AddQueryParameter("query", filter.Query);
            
            if (filter.IsClosed != null)
                req.AddQueryParameter("is_closed", filter.IsClosed.ToString().ToLowerInvariant());
            
            var res = ExecuteRequestInternal<CustomerList>(req);
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
            request.AddHeader("Accept-Language", Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            if (_debugMode)
                request.AddHeader("X-Log", "1");
            request.JsonSerializer = _serializer;

            if (filter != null)
            {
                if (filter.Limit != null)
                    request.AddQueryParameter("limit", filter.Limit.Value.ToString());
                if (filter.Offset != null)
                    request.AddQueryParameter("offset", filter.Offset.Value.ToString());
            }

            return request;
        }

        private void AssertOk(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
                throw new LoyaltyValidationException("Bad request: " + response.Content);
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new LoyaltyNotFoundException("Not found: " + response.ResponseUri);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw new LoyaltyException("Internal server error: " + response.Content);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new LoyaltyUnauthorizedException("Unauthorized. Check access token");
            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new LoyaltyForbiddenException("Forbidden. User has no access to resource");
            if (response.ErrorException != null)
                throw new LoyaltyException(response.ErrorException.Message, response.ErrorException);
        }
        
        protected virtual IRestResponse ExecuteRequestInternal(IRestRequest request)
        {
            return _restClient.Execute(request);
        }

        protected virtual IRestResponse<T> ExecuteRequestInternal<T>(IRestRequest request) where T : new()
        {
            return _restClient.Execute<T>(request);
        }

        #endregion        
    }
}