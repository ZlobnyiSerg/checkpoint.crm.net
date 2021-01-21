using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    /// <summary>
    /// Балльный счёт гостя
    /// </summary>
    public class Account : Model
    {
        /// <summary>
        /// Баланс платёжных баллов
        /// </summary>
        public decimal Balance { get; set; }            
        
        /// <summary>
        /// Дебет баланса (поступления платёжных баллов)
        /// </summary>
        public decimal BalanceDebit { get; set; }
        
        /// <summary>
        /// Кредит баланса (расходы платёжных баллов)
        /// </summary>
        public decimal BalanceCredit { get; set; }
        
        /// <summary>
        /// Сумма платёжных баллов с ограниченным сроком действия
        /// </summary>
        public decimal BalanceExpirable { get; set; }  
        
        /// <summary>
        /// Сумма уровневых баллов
        /// </summary>
        public decimal BalanceLevel { get; set; }            
    }
}