namespace SunamoDevCode._public;

/// <summary>
/// Represents the out ref DC t u type.
/// </summary>
public class OutRefDC<T, U>
{
    /// <summary>
    /// Initializes a new instance of the out ref DC class.
    /// </summary>
    /// <param name="firstValue">The first value.</param>
    /// <param name="secondValue">The second value.</param>
    public OutRefDC(T firstValue, U secondValue)
    {
        Item1 = firstValue;
        Item2 = secondValue;
    }
    /// <summary>
    /// Gets or sets the item 1.
    /// </summary>
    public T Item1 { get; set; }
    /// <summary>
    /// Gets or sets the item 2.
    /// </summary>
    public U Item2 { get; set; }
}
