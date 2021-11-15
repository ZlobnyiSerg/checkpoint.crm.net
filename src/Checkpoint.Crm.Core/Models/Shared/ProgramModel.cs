using System;

namespace Checkpoint.Crm.Core.Models.Shared;

/// <summary>
/// Loyalty program
/// </summary>
public class ProgramModel
{
    public int Id { get; set; }

    /// <summary>
    /// Name of program
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Date of start
    /// </summary>
    public DateTime? StartDate { get; set; }
    
    /// <summary>
    /// Date of end
    /// </summary>
    public DateTime? EndDate { get; set; }
    
    /// <summary>
    /// Draft - means it is on the way and not finished yet
    /// </summary>
    public bool IsDraft { get; set; }
}