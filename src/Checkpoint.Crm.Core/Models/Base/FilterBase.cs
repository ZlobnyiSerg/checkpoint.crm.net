using System;

namespace Checkpoint.Crm.Core.Models.Base
{
    /// <summary>
    ///     Базовый класс для фильтров списков сущностей
    /// </summary>
    public class FilterBase
    {
        /// <summary>
        ///     Размер ограничений записей
        /// </summary>
        public long? Limit { get; set; }
        
        public long? Offset { get; set; }
    }
}