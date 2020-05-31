using System;
using System.Collections.Generic;
using Checkpoint.Crm.Core.Models.Base;
using Checkpoint.Crm.Core.Models.Cards;
using Checkpoint.Crm.Core.Models.Customers;

namespace Checkpoint.Crm.Core.Models.Orders
{
    /// <summary>
    ///     Заказ гостя
    /// </summary>
    public class Order : ExternallyIdentifiedModel
    {
        /// <summary>
        ///     Клиент
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        ///     Идентификатор клиента
        /// </summary>
        public int? CustomerId { get; set; }
        
        /// <summary>
        /// Идентификатор гостя в момент создания заказа
        /// </summary>
        public Tier CustomerTier { get; set; }
        
        /// <summary>
        /// Идентификатор родительского заказа
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        ///     Идентификатор карты лояльности, применённой к заказу
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        ///     Опциональный промо-код заказа (может давать дополнительные скидки и возможности)
        /// </summary>
        public string PromoCode { get; set; }

        /// <summary>
        ///     Точка продаж, где осуществлён заказ. Альтернативой данному полю является использование кода точки продаж <see cref="PosCode"/>
        /// </summary>
        public int? PointOfSaleId { get; set; }
        
        /// <summary>
        ///     Код точки продажи. Может использоваться при операциях вставки/обновления для идентификации заказа по POS и <see cref="ExternalId"/>. Является альтернативой полю идентификатора точки <see cref="PointOfSaleId"/>
        /// </summary>
        public string PosCode { get; set; }
        

        #region Marketing data

        /// <summary>
        ///     Источник заказа
        /// </summary>
        public string MarketSource { get; set; }

        public string MarketSegment { get; set; }

        public string MarketTrackCode { get; set; }

        public string MarketGeoCode { get; set; }

        public string MarketOpenCode { get; set; }

        public string MarketExtra1 { get; set; }

        public string MarketExtra2 { get; set; }

        #endregion

        /// <summary>
        ///     Опциональное название заказа в свободной форме (например, "проживание", "посещение ресторана", "посещение СПА" и т.п.)
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///     Тип заказа
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Комментарии к заказу
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        ///     Дата начала заказа
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        ///     Опциональная дата завершения заказа
        /// </summary>
        public DateTime? DateEnd { get; set; }

        /// <summary>
        ///     Дополнительная произвольная информация по заказу
        /// </summary>
        public OrderExtraField[] ExtraFields { get; set; }

        /// <summary>
        ///     Перечень товаров и услуг, приобретённых в процессе визита
        /// </summary>
        public OrderItem[] Items { get; set; }

        /// <summary>
        ///     Список оплат, осуществлённых в процессе заказа
        /// </summary>
        public Payment[] Payments { get; set; }

        /// <summary>
        ///     Статус заказа (гость уехал, визит изменениям не подлежит).        
        /// </summary>
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        ADV = 0,
        PROG = 1,
        COMPL = 2,
        CANC = 3
    }
}