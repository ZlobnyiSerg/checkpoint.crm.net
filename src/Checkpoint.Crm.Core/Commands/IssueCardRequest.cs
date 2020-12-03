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
        public int CustomerId { get; set; }
        
        /// <summary>
        /// Tier of issued card
        /// </summary>
        public int TierId { get; set; }
    }
}