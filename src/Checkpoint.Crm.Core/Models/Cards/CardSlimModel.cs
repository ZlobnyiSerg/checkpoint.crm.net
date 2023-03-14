using System;
using Checkpoint.Crm.Core.Models.Shared;

namespace Checkpoint.Crm.Core.Models.Cards;

/// <summary>
/// Loyalty card model.
/// </summary>
public class CardSlimModel
{
    /// <summary>
    /// ID
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Card number
    /// </summary>
    public string CardNo { get; set; }

    /// <summary>
    /// Issuer
    /// </summary>
    public string? Issuer { get; set; }

    /// <summary>
    /// Issue date
    /// </summary>
    public DateTime? IssueDate { get; set; }

    /// <summary>
    /// Created date
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// Modified date
    /// </summary>
    public DateTime DateModified { get; set; }

    /// <summary>
    /// External created date
    /// </summary>
    public DateTime? ExtDateCreated { get; set; }

    /// <summary>
    /// External modified date
    /// </summary>
    public DateTime? ExtDateModified { get; set; }

    /// <summary>
    /// Is active
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Account this card is bound to
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    public string? CustomerId { get; set; }

    /// <summary>
    /// Current tier Id
    /// </summary>
    public string? CurrentTierId { get; set; }

    /// <summary>
    /// Code of current card tier
    /// </summary>
    public string? CurrentTierCode { get; set; }

    /// <summary>
    /// Name of current tier
    /// </summary>
    public string? CurrentTierName { get; set; }

    /// <summary>
    /// Expected tier id
    /// </summary>
    public string? ExpectedTierId { get; set; }

    /// <summary>
    /// Loyalty program Id
    /// </summary>
    public string ProgramId { get; set; }
}