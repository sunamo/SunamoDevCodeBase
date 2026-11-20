namespace SunamoDevCode._public;

/// <summary>
/// Represents the t with string DC t type.
/// </summary>
public class TWithStringDC<T>
{
    /// <summary>
    /// The path.
    /// </summary>
    public string path = null!;
    /// <summary>
    /// The t.
    /// </summary>
    public T t = default!;

    /// <summary>
    /// T with string DC.
    /// </summary>
    /// <returns>The t with string DC result.</returns>
    public TWithStringDC()
    {
    }

    /// <summary>
    /// T with string DC.
    /// </summary>
    /// <returns>The t with string DC result.</returns>
    public TWithStringDC(T item, string path)
    {
        this.t = item;
        this.path = path;
    }

    /// <summary>
    /// Initializes a new instance of the to string class.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="path">The path.</param>
    public override string ToString() => path;
}
