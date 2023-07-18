using System;
using System.ComponentModel.DataAnnotations;
using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Orders
{
    /// <summary>
    ///     Факт оказания услуги
    /// </summary>
    public class OrderItem : ExternallyIdentifiedModel
    {
        /// <summary>
        ///     Дата и время услуги
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Вид дохода от услуги/товара
        /// </summary>
        public string RevenueType { get; set; }

        /// <summary>
        ///     Тип транзакции от услуги/товара
        /// </summary>
        public string TransactionType { get; set; }

        /// <summary>
        ///     Код оказанной услуги
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Код тарифной группы (тарифа)
        /// </summary>
        public string RateGroup { get; set; }

        /// <summary>
        ///     Наименование транзакции (услуги и т.п.)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Комментарии к транзакции
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        ///     Количество оказанных услуг
        /// </summary>
        [Range(0, 1e18)]
        public decimal Quantity { get; set; }

        /// <summary>
        ///     Стоимость услуги
        /// </summary>
        [Range(0, 1e18)]
        public decimal Amount { get; set; }

        /// <summary>
        ///     Размер включенного налога
        /// </summary>
        [Range(0, 1e18)]
        public decimal IncludedTaxAmount { get; set; }

        /// <summary>
        ///     Стоимость услуги до применения скидок
        /// </summary>
        [Range(0, 1e18)]
        public decimal AmountBeforeDiscount { get; set; }

        /// <summary>
        ///     Признак, что транзакция ещё не проведена, а лишь запланирована
        /// </summary>
        public bool IsScheduled { get; set; }

        /// <summary>
        ///     Группа (для объединения с оплатами)
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        ///     Лимит оплаты бонусными баллами.
        /// </summary>
        public decimal? BonusPaymentLimit { get; set; }
    }
}