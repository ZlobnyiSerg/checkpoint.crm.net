using System.Collections.Generic;
using Checkpoint.Crm.Core.Models;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Ответ на применение правил программы лояльности к услугам гостя
    /// </summary>
    public class ApplicablePromoOffersResponse
    {
        /// <summary>
        ///     Перечень доступных промо-предложений
        /// </summary>
        public PromoOffer[] Offers { get; set; }
        
        /// <summary>
        ///     Перечень доступных промо-предложений
        /// </summary>
        public PromoOffer[]? UnavailableOffers { get; set; }
    }
}