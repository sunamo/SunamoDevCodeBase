namespace SunamoDevCode.Args;

/// <summary>
/// Represents the remove from xlf which have empty target or source args type.
/// </summary>
public class RemoveFromXlfWhichHaveEmptyTargetOrSourceArgs
{
    /// <summary>
    /// Gets or sets the default.
    /// </summary>
    public static RemoveFromXlfWhichHaveEmptyTargetOrSourceArgs Default { get; set; } = new RemoveFromXlfWhichHaveEmptyTargetOrSourceArgs();

    /// <summary>
    /// Gets or sets the remove whole trans unit.
    /// </summary>
    public bool RemoveWholeTransUnit { get; set; } = true;

    /// <summary>
    /// Gets or sets the save.
    /// </summary>
    public bool Save { get; set; } = true;
}
