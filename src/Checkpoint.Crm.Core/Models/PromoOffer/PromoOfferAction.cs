namespace Checkpoint.Crm.Core.Models
{
    /// <summary>
    /// Действие промо-предложения
    /// </summary>
    public class PromoOfferAction
    {
        public long Id { get; set; }
        
        /// <summary>
        /// Заметки
        /// </summary>
        public string Notes { get; set; }
        
        /// <summary>
        /// Регулярное выражение для фильтрации кодов транзакций
        /// </summary>
        public string FilterTransactionCodes { get; set; }
        
        /// <summary>
        /// Размер скидки на транзакции
        /// </summary>
        public decimal? DiscountPercent { get; set; }
        
        /// <summary>
        /// Лимит оплаты бонусными баллами
        /// </summary>
        public decimal? BonusPaymentLimit { get; set; }
    }
}