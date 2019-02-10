namespace Checkpoint.Crm.Core.Commands
{
    public class ChargePointsRequest
    {        
        /// <summary>
        /// Номер карты лояльности
        /// </summary>
        public string CardNo { get; set; }
        
        /// <summary>
        /// Идентификатор аккаунта (взаимозаменим с номером карты лояльности)
        /// </summary>
        public int? AccountId { get; set; }
        
        /// <summary>
        /// Описание/наименование операции списания баллов
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Код точки продаж (где был оформлен заказ)
        /// </summary>
        public string PosCode { get; set; }
        
        /// <summary>
        /// Внешний идентификатор заказа, на котором происходит оплата (для информации)
        /// </summary>
        public string OrderExternalId { get; set; }               

        /// <summary>
        /// Сумма списания (должна быть >0)
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Заметки (комментарий)
        /// </summary>
        public decimal Notes { get; set; }
        
        /// <summary>
        /// Пользователь, инициировавший списание баллов
        /// </summary>
        public string InitiatorUser { get; set; }               

        public ChargePointsRequest(string name, string posCode, string orderExternalId, int? accountId, decimal amount, string initiatorUser)
        {
            Name = name;
            PosCode = posCode;
            OrderExternalId = orderExternalId;            
            AccountId = accountId;
            Amount = amount;
            InitiatorUser = initiatorUser;
        }
        
        public ChargePointsRequest(string name, string posCode, string orderExternalId, string cardNo, decimal amount, string initiatorUser)
        {
            Name = name;
            PosCode = posCode;
            OrderExternalId = orderExternalId;
            CardNo = cardNo;            
            Amount = amount;
            InitiatorUser = initiatorUser;
        }
    }
}