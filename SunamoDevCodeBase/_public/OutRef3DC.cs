namespace SunamoDevCode._public;

/// <summary>
/// Represents the out ref 3 DC t u v type.
/// </summary>
public class OutRef3DC<T, U, V> : OutRefDC<T, U>
{
    /// <summary>
    /// Initializes a new instance of the out ref 3 DC class.
    /// </summary>
    /// <param name="firstValue">The first value.</param>
    /// <param name="secondValue">The second value.</param>
    /// <param name="thirdValue">The third value.</param>
    public OutRef3DC(T firstValue, U secondValue, V thirdValue) : base(firstValue, secondValue)
    {
        Item3 = thirdValue;
    }
    /// <summary>
    /// Gets or sets the item 3.
    /// </summary>
    public V Item3 { get; set; }
}
