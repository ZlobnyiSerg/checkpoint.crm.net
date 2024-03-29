﻿using System.Collections.Generic;
using Checkpoint.Crm.Core.Models.Shared;

namespace Checkpoint.Crm.Core.Models.Base
{
    /// <summary>
    ///     Базовый класс для фильтрованных списков сущностей
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListBase<T>
    {
        /// <summary>
        ///     Указывает общее число записей, удовлетворяющих условиям фильтра
        /// </summary>
        public int Count { get; set;  }

        /// <summary>
        ///     Список сущностей
        /// </summary>
        public T[] Results { get; set; }
    }
}