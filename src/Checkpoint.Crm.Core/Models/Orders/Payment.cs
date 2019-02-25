using System;
using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Orders
{
    /// <summary>
    ///     Оплата
    /// </summary>
    public class Payment : ExternallyIdentifiedModel
    {
        /// <summary>
        ///     Дата и время оплаты
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Способ оплаты (наличные, кредитки и т.п.)
        /// </summary>
        public PaymentType Type { get; set; }

        /// <summary>
        ///     Наименование оплаты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Комментарии к оплате
        /// </summary>
        public string Notes { get; set; }


        /// <summary>
        ///     Размер оплаты в валюте POS
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Тип банковской карты (если оплата была карты)
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        ///     Эмитент банковской карты
        /// </summary>
        public string CardIssuer { get; set; }
        
        /// <summary>
        ///     Группа (для объединения с оплатами)
        /// </summary>
        public string GroupId { get; set; }
    }

    public enum PaymentType
    {
        /// <summary>
        /// Наличные
        /// </summary>
        CASH = 1,

        /// <summary>
        /// Кредитные карты
        /// </summary>
        CC = 2,

        /// <summary>
        /// Безналично
        /// </summary>
        BANK = 3,

        /// <summary>
        /// Баллами лояльности
        /// </summary>
        LOYALTY = 4,

        /// <summary>
        /// Иной спобос
        /// </summary>
        OTHER = 5
    }
}