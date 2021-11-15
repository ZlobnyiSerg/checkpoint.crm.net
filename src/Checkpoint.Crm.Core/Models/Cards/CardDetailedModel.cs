using Checkpoint.Crm.Core.Models.Shared;

namespace Checkpoint.Crm.Core.Models.Cards;

public class CardDetailedModel : CardSlimModel
{                
    /// <summary>
    /// Current loyalty tier of card
    /// </summary>
    public Tier CurrentTier { get; set; }
        
    /// <summary>
    /// Expected loyalty tier of card
    /// </summary>
    public Tier ExpectedTier { get; set; }
        
    /// <summary>
    /// Loyalty program of card
    /// </summary>
    public ProgramModel Program { get; set; }
}