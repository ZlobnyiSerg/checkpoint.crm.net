using System.ComponentModel.DataAnnotations;
using Checkpoint.Crm.Core.Models.Orders;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Запрос на применение промо-предложений к визиту гостя
    /// </summary>
    public class ApplyPromoOffersRequest
    {
        /// <summary>
        ///     Информация о визите
        /// </summary>
        [Required]
        public Order Order { get; set; }

        /// <summary>
        ///     Перечень идентификаторов промо-предложений, которые следует применить к визиту гостя
        /// </summary>
        public int[] OfferIds { get; set; }
    }
    
    /// <summary>
    ///     Ответ на запрос применения промо-предложений
    /// </summary>
    public class ApplyPromoOffersResponse
    {
        /// <summary>
        ///     Обновленная информация о визите
        /// </summary>
        public Order Order { get; set; }
    }
}