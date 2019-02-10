using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Customers
{
    /// <summary>
    ///     Список гостей (как результат выполнения поиска с фильтрацией). Содержит дополнительные данные об ожидаемом размере
    ///     списка.
    /// </summary>
    public class CustomerList : ListBase<Customer>
    {
    }
}