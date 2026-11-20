namespace SunamoDevCode._public;

/// <summary>
/// Represents the result with exception DC t type.
/// </summary>
public class ResultWithExceptionDC<T>
{
    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public T Data { get; set; } = default!;

    /// <summary>
    /// Gets or sets the exc.
    /// </summary>
    public string Exc { get; set; } = null!;

    /// <summary>
    /// Result with exception DC.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns>The result with exception DC result.</returns>
    public ResultWithExceptionDC(T data)
    {
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the result with exception DC class.
    /// </summary>
    /// <param name="data">The data.</param>
    public ResultWithExceptionDC(string exc)
    {
        this.Exc = exc;
    }

    /// <summary>
    /// Initializes a new instance of the result with exception DC class.
    /// </summary>
    /// <param name="exc">The exc.</param>
    public ResultWithExceptionDC(Exception exc)
    {
        this.Exc = Exceptions.TextOfExceptions(exc);
    }

    /// <summary>
    /// Initializes a new instance of the result with exception DC class.
    /// </summary>
    /// <param name="exc">The exc.</param>
    public ResultWithExceptionDC()
    {
    }
}
