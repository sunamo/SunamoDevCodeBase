namespace SunamoDevCode._public.SunamoData.Data;

/// <summary>
/// Represents the from to list type.
/// </summary>
public class FromToList
{
    /// <summary>
    /// Gets or sets the ranges.
    /// </summary>
    public List<FromToDC> Ranges { get; set; } = new();

    /// <summary>
    /// Is in range.
    /// </summary>
    /// <returns>The is in range result.</returns>
    public bool IsInRange(int value)
    {
        foreach (var item in Ranges)
            if (value < item.to && value > item.from)
                return true;
        return false;
    }
}
