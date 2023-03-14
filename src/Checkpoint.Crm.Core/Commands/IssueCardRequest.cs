namespace Checkpoint.Crm.Core.Commands
{
    /// <summary>
    /// Request to issue new card for customer
    /// </summary>
    public class IssueCardRequest
    {
        /// <summary>
        /// Card number
        /// </summary>
        public string CardNo { get; set; }
        
        /// <summary>
        /// Customer identifier
        /// </summary>
        public string CustomerId { get; set; }
        
        /// <summary>
        /// Tier of issued card
        /// </summary>
        public string TierId { get; set; }
        
        /// <summary>
        /// Card issuer 
        /// </summary>
        public string Issuer { get; set; }
        
        /// <summary>
        /// If this flag is set, other customer's cards will be deactivated
        /// </summary>
        public bool DeactivateOtherCards { get; set; }
    }
}