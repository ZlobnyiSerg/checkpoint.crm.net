using System;
using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    /// <summary>
    /// Операция над счётом
    /// </summary>
    public class AccountOperation : Model
    {
        /// <summary>
        /// Точка продаж, начислившая или списавшая баллы
        /// </summary>
        public string? PointOfSaleId { get; set; }
        
        /// <summary>
        /// Целевой счёт
        /// </summary>
        public string AccountId { get; set; }
        
        /// <summary>
        /// Название операции (информационное поле)
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Заметки к операции списания
        /// </summary>
        public string Notes { get; set; }
        
        /// <summary>
        /// Сумма, если это начисление баллов
        /// </summary>
        public decimal Debit { get; set; }
        
        /// <summary>
        /// Сумма, если это списание баллов
        /// </summary>
        public decimal Credit { get; set; }
        
        /// <summary>
        /// Дата истечения срока действия баллов (если это начисление)
        /// </summary>
        public DateTime? ExpirationDate  { get; set; }
        
        /// <summary>
        /// Номер заказа, благодаря которому баллы начисляются или в котором списываются в качестве оплаты
        /// </summary>
        public string? OrderId { get; set; }
        
        /// <summary>
        /// Номер правила вознаграждения, на основании которого баллы начислены
        /// </summary>
        public string? RuleId { get; set; }
        
        /// <summary>
        /// Тип бонусных баллов
        /// </summary>
        public string? BonusTypeId { get; set; }
        
        /// <summary>
        /// Пользователь-инициатор
        /// </summary>
        public string InitiatorUser { get; set; }
        
        /// <summary>
        /// Тип бонусных баллов (уровневые или платёжные)
        /// </summary>
        public BonusClass BonusClass { get; set; }
    }

    public enum BonusClass
    {
        /// <summary>
        /// Уровневые баллы
        /// </summary>
        LVL,
        
        /// <summary>
        /// Баллы для оплаты
        /// </summary>
        PAYM
    }
}