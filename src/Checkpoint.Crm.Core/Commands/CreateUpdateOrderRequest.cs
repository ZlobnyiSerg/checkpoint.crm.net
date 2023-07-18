using Checkpoint.Crm.Core.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint.Crm.Core.Commands;

/// <summary>
/// Запрос на создание/изменение заказа
/// </summary>
public class CreateUpdateOrderRequest
{
    /// <summary>
    /// Код точки продажи
    /// </summary>
    public string PointOfSaleCode { get; set; }

    /// <summary>
    /// Внешний идентификатор заказа
    /// </summary>
    public string ExternalOrderId { get; set; }

    /// <summary>
    /// Заказ
    /// </summary>
    public Order Order { get; set; }

    /// <summary>
    /// Инициатор запроса
    /// </summary>
    public string InitiatorUser { get; set; }
}
