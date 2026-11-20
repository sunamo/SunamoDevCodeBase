namespace SunamoDevCode.Args;

/// <summary>
/// Represents the generate properties args type.
/// </summary>
public class GeneratePropertiesArgs
{
    /// <summary>
    /// Gets or sets the input.
    /// </summary>
    public List<string> Input { get; set; } = null!;

    /// <summary>
    /// Gets or sets the all strings.
    /// </summary>
    public bool AllStrings { get; set; } = false;
}
