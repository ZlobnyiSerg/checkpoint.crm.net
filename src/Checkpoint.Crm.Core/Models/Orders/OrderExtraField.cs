using Checkpoint.Crm.Core.Models.Shared;

namespace Checkpoint.Crm.Core.Models.Orders
{
    public class OrderExtraField : ExtraField
    {
        /// <summary>
        ///     Идентификатор заказа
        /// </summary>
        public string OrderId { get; set; }
        
        /// <summary>
        ///     Двоичные данные
        /// </summary>
        public byte[] BinaryData { get; set; }

        public OrderExtraField()
        {
        }

        public OrderExtraField(string name, string value) : base(name, value)
        {
        }
    }
}