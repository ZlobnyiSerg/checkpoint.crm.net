using System;
using Checkpoint.Crm.Core.Models.Customers;
using Checkpoint.Crm.Core.Models.Shared;

namespace Checkpoint.Crm.Core.Models.Cards
{
    /// <summary>
    ///     Карта лояльности
    /// </summary>
    public class Card
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Строковый идентификатор карты
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        ///     Уровень карты (Id)
        /// </summary>
        public int? CurrentTierId { get; set; }
        
        /// <summary>
        ///     Уровень карты
        /// </summary>
        public Tier CurrentTier { get; set; }
        
        /// <summary>
        ///     Рассчётный уровень карты (Id)
        /// </summary>
        public int? ExpectedTierId { get; set; }
        
        /// <summary>
        ///     Рассчётный уровень карты
        /// </summary>
        public Tier ExpectedTier { get; set; }

        /// <summary>
        ///     Дата выпуска (привязки) карты
        /// </summary>
        public DateTime? IssueDate { get; set; }

        /// <summary>
        ///     Признак активности карты
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        ///     Гость владелец карты
        /// </summary>
        public int? CustomerId { get; set; }        
        
        /// <summary>
        ///     Счёт, к которому привязана карта
        /// </summary>
        public Account Account { get; set; }
        
        /// <summary>
        ///     Выпустивший карту пользователь
        /// </summary>
        public string Issuer { get; set; }
    }
}
