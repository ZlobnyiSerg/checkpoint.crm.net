using System.ComponentModel.DataAnnotations;
using Checkpoint.Crm.Core.Models;
using Checkpoint.Crm.Core.Models.Cards;
using Checkpoint.Crm.Core.Models.Orders;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Запрос на применение промо-предложений к визиту гостя
    /// </summary>
    public class ApplyPromoOffersRequest
    {
        /// <summary>
        ///     Информация о визите
        /// </summary>
        [Required]
        public Order Order { get; set; }

        /// <summary>
        ///     Перечень идентификаторов промо-предложений, которые следует применить к визиту гостя
        /// </summary>
        public string[] OfferIds { get; set; }
    }
    
    /// <summary>
    ///     Ответ на запрос применения промо-предложений
    /// </summary>
    public class ApplyPromoOffersResponse
    {
        /// <summary>
        ///     Обновленная информация о визите
        /// </summary>
        public OrderResultModel Order { get; set; }
        
        /// <summary>
        /// Перечень применённых промо-предложений
        /// </summary>
        public PromoOffer[] Offers { get;set; }

        /// <summary>
        /// Результат применения промо-предложения
        /// </summary>
        public class OrderResultModel
        {
            /// <summary>
            /// Перечень позиций заказа, к которым применёно промо-предложение. Позиции могут включать новую стоимость (после скидки)
            /// </summary>
            public OrderItemResultModel[]? Items { get; set; }
    
            /// <summary>
            /// Перечень применённых промо-предложений
            /// </summary>
            public PromoOfferResultModel[]? AppliedOffers { get; set; }

            /// <summary>
            /// Информация о карте, задействованной при применении промо-предложения. В зависимости от заказа, это может быть как предъявленная гостем карта,
            /// так и карта, привязанная к его профилю
            /// </summary>
            public CardSlimModel? CardInfo { get; set; }
            
            public class OrderItemResultModel
            {
                /// <summary>
                /// Внешний идентификатор позиции
                /// </summary>
                public string ExternalId { get; set; }
        
                /// <summary>
                /// Код
                /// </summary>
                public string Code { get; set; }
        
                /// <summary>
                /// Сумма
                /// </summary>
                public decimal Amount { get; set; }
        
        
                /// <summary>
                /// Сумма до скидки
                /// </summary>
                public decimal AmountBeforeDiscount { get; set; }
        
                /// <summary>
                /// Лимит оплаты баллами
                /// </summary>
                public decimal BonusPaymentLimit { get; set; }
            }
            
            /// <summary>
            /// Промо-предложение, применённое к заказу
            /// </summary>
            public class PromoOfferResultModel
            {
                public string Id { get; set; }

                /// <summary>
                /// Код промо-предложения
                /// </summary>
                public string? Code { get; set; }

                /// <summary>
                /// Наименование
                /// </summary>
                public string? Name { get; set; }

                /// <summary>
                /// Описание
                /// </summary>
                public string? Description { get; set; }

                /// <summary>
                ///     Признак того, что промо-предложение можно применить к визиту/визитам гостя. Если оно недоступно, см. <see cref="UnavailabilityReason"/>
                /// </summary>
                public bool IsAvailable { get; set; }

                /// <summary>
                ///     Причина недоступности применения промо-предложения, например: предложение уже было применено максимально доступное количество раз
                /// </summary>
                public string? UnavailabilityReason { get; set; }

                /// <summary>
                ///     Признак, указывающий на то, что данное промо-предложение должно применяться автоматически
                /// </summary>
                public bool AutoApply { get; set; }

                /// <summary>
                ///     Признак, что применение промо-предложения может отслеживаться в системе лояльности.
                ///     Не все предложения позволяют это делать, например предложения, ограничивающие лимит оплаты баллами. 
                /// </summary>
                public bool CanBeTracked { get; set; }

                /// <summary>
                ///     Действия промо-предложения
                /// </summary>
                public PromoOfferActionResultModel[] Actions { get; set; }
                
                public class PromoOfferActionResultModel
                {
                    public string Id { get; set; }
        
                    public string Notes { get; set; }
        
                    public string FilterTransactionCodes { get; set; }
        
                    public decimal? DiscountPercent { get; set; }
        
                    public decimal? BonusPaymentLimit { get; set; }
                }
            }
        }
    }
}