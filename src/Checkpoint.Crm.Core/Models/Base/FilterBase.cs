using System;

namespace Checkpoint.Crm.Core.Models.Base
{
    /// <summary>
    ///     Базовый класс для фильтров списков сущностей
    /// </summary>
    public class FilterBase
    {
        /// <summary>
        ///     Дата последней модификации
        /// </summary>
        public DateTime? ModifiedSince { get; set; }

        /// <summary>
        ///     Номер страницы
        /// </summary>
        public int? Page { get; set; }
    }
}