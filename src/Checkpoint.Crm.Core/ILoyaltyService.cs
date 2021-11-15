using System.ServiceModel;
using Checkpoint.Crm.Core.Commands;
using Checkpoint.Crm.Core.Models.Cards;
using Checkpoint.Crm.Core.Models.Customers;
using Checkpoint.Crm.Core.Models.Orders;
using Checkpoint.Crm.Core.Models.Shared;

namespace Checkpoint.Crm.Core
{
    /// <summary>
    ///     Сервис программ лояльности
    /// </summary>
    [ServiceContract]
    public interface ILoyaltyService
    {        
        #region Promo-offers

        /// <summary>
        ///     Определяет набор промо-предложений с их описанием, которые применимы к указанным визитам гостя
        /// </summary>        
        ApplicablePromoOffersResponse GetApplicablePromoOffers(GetApplicablePromoOffersRequest request);

        /// <summary>
        ///     Применить промо-предложения к визиту/визитам гостя
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>        
        ApplyPromoOffersResponse ApplyPromoOffers(ApplyPromoOffersRequest request);
        
        /// <summary>
        ///     Осуществляет предварительный просчёт эффекта от промо-предложения, не сохраняя факт применения предложения и не затрагивая лимиты применения.
        ///     Также может использоваться для расчёта лимитов оплаты баллами - в каждой позиции заказа будет указан <see cref="OrderItem.BonusPaymentLimit"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ApplyPromoOffersResponse PreviewPromoOffers(ApplyPromoOffersRequest request);              

        #endregion

        #region Points

        /// <summary>
        ///     Списывает баллы со счёта гостя по идентификатору карты лояльности или по номеру счёта
        /// </summary>        
        /// <returns></returns>        
        AccountOperation ChargePoints(ChargePointsRequest request);

        /// <summary>
        /// Найти операции с бонусным счётом по фильтру
        /// </summary>
        AccountOperationList FindAccountOperations(AccountOperationFilter filter);

        /// <summary>
        /// Удаляет операцию списания баллов
        /// </summary>
        /// <param name="accountOperationId"></param>
        void ChargedPointsDelete(int accountOperationId);

        #endregion

        #region Shared

        /// <summary>
        ///     Возвращает список точек продаж по фильтру
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        PointOfSaleList FindPointOfSales(PointOfSaleFilter filter);

        /// <summary>
        ///     Создаёт или обновляет точку продаж
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        PointOfSale CreateOrUpdatePos(PointOfSale pos);

        /// <summary>
        /// Возвращает точку продаж по идентификатору
        /// </summary>
        /// <param name="pointOfSaleId"></param>
        /// <returns></returns>
        PointOfSale GetPointOfSale(long pointOfSaleId);

        #endregion

        #region Orders

        /// <summary>
        ///     Возвращает заказ по внешнему идентификатору
        /// </summary>
        /// <param name="pointOfSaleCode"></param>
        /// <param name="externalOrderId"></param>
        /// <returns></returns>
        Order GetOrder(string pointOfSaleCode, string externalOrderId);

        /// <summary>
        /// Возвращает заказ по внутреннему идентификатору
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Order GetOrder(int orderId);

        /// <summary>
        ///     Осуществляет поиск по визитам гостей
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>        
        OrderList FindOrders(OrderFilter filter);

        /// <summary>
        ///     Регистрирует факт визита гостя вместе со всей детализацией по услугам, оплатам и предпочтениям. Если заказ с указанным externalId уже есть, обновляет его. Если такого нет - создаёт новый. 
        /// </summary>
        /// <param name="pointOfSaleCode">Код точки продаж</param>
        /// <param name="externalOrderId">Внешний идентификатор заказа</param>
        /// <param name="order"></param>
        /// <returns>Идентификтор визита</returns>        
        Order CreateUpdateOrder(string pointOfSaleCode, string externalOrderId, Order order);

        /// <summary>
        /// Возвращает
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        OrderExtraField GetOrderExtraField(int orderId, string fieldName);

        /// <summary>
        /// Удаляет заказ
        /// </summary>        
        void DeleteOrder(int orderId);

        #endregion

        #region Loyalty Cards

        /// <summary>
        ///     Возвращает список наборов карт лояльности
        /// </summary>
        /// <returns></returns>
        TierList GetTiers();

        /// <summary>
        ///     Возвращает список карт согласно параметрам фильтрации
        /// </summary>
        /// <param name="filter"></param>
        CardList FindCards(CardFilter filter);

        /// <summary>
        ///     Выпускает новую карту лояльности и привязывает к гостю
        /// </summary>
        Card IssueCard(IssueCardRequest request);

        #endregion

        #region Customers

        /// <summary>
        /// Возвращает клиента по идентификатору, либо null
        /// </summary>        
        /// <returns></returns>
        Customer GetCustomer(int id);        

        /// <summary>
        /// Создаёт или обновляет профиль клиента. Если указан идентификатор (<see cref="Id"/>) то будет обновлен профиль по идентификатору, в противном случае
        /// будет осуществляться поиск по уникальным полям, настраиваемым со стороны системы лояльности.
        /// По умолчанию эти поля фамилия+телефон+дата рождения. Если клиент с такой комбинацией полей уже есть, он обновляется.
        /// Если его нет - создаётся новая запись. Если полей недостаточно - возвращается ошибка.
        /// </summary>
        Customer CreateUpdateCustomer(Customer customer);

        /// <summary>
        /// Осуществляет поиск клиентов по заданным критериям
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        CustomerList FindCustomers(CustomerFilter filter);

        #endregion
    }
}