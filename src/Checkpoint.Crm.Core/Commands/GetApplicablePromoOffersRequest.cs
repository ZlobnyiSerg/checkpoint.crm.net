using Checkpoint.Crm.Core.Models.Orders;

namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    ///     Запрос на получение списка промо-предложений для визита (или нескольких визитов) гостей
    /// </summary>
    public class GetApplicablePromoOffersRequest
    {
        /// <summary>
        ///     Визит гостя (новый или уже свершившийся), для которого следует определить промо-предложения.
        ///     Если визит ещё не зарегистрирован в системе, то он будет создан и в ответе возвращён с новым идентификтором.
        ///     Существующий визит будет обновлен.
        /// </summary>
        public Order Order { get; set; }        
    }
}