namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Описание действия на транзакцию (услугу) визита гостя
    /// </summary>
    public class LoyalityTransactionRuleDto
    {
        /// <summary>
        ///     Идентификтор транзакции во внешней системе
        /// </summary>
        public string TransactionConsumerId { get; set; }

        /// <summary>
        ///     Новая стоимость услуги, которую следует применить. 0, если это подарок. Null, если исходную стоимость изменять не
        ///     нужно
        /// </summary>
        public decimal? NewAmount { get; set; }

        /// <summary>
        ///     Размер скидки в процентах, если была предоставлена не абсолютная, а относительная скидка
        /// </summary>
        public decimal? NewAmountDiscount { get; set; }

        /// <summary>
        ///     Стоимость услуги, которая может быть оплачена бонусами
        /// </summary>
        public decimal? AmountPayWithPoints { get; set; }
    }
}