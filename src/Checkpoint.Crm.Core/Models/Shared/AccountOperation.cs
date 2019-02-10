using System;
using Checkpoint.Crm.Core.Models.Base;

namespace Checkpoint.Crm.Core.Models.Shared
{
    /// <summary>
    /// Операция над счётом
    /// </summary>
    public class AccountOperation : Model
    {
        public string Name { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime? ExpirationDate  { get; set; }
        public bool Expireable { get; set; }
        public int AccountId { get; set; }
        public int? OrderId { get; set; }
        public int? RuleId { get; set; }
        public int? BonusTypeId { get; set; }
        public string InitiatorUser { get; set; }
    }
}