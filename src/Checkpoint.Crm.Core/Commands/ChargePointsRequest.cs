namespace Checkpoint.Crm.Core.Commands
{
    public class ChargePointsRequest
    {
        /// <summary>
        /// Описание/наименование операции списания баллов
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер счёта для списания
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Номер заказа, в котором будет осуществляться списание
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// Сумма списания
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Пользователь, инициировавший списание баллов
        /// </summary>
        public string InitiatorUser { get; set; }
    }
}