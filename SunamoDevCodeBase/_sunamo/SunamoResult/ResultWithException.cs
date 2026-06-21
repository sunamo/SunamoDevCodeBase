namespace SunamoDevCode._sunamo.SunamoResult;

/// <summary>
/// Wraps a result of type T with an optional exception message string.
/// </summary>
/// <typeparam name="T">Type of the result data.</typeparam>
public class ResultWithException<T>
{
    /// <summary>
    /// The result data.
    /// </summary>
    public T Data { get; set; } = default!;
    /// <summary>
    /// Exception message string. Only string because Message property is not editable after instantiate.
    /// </summary>
    public string? Exc { get; set; }
    /// <summary>
    /// Creates a result with the given data.
    /// </summary>
    /// <param name="data">Result data.</param>
    public ResultWithException(T data)
    {
        Data = data;
    }
    /// <summary>
    /// Creates a result with the given exception message.
    /// </summary>
    /// <param name="exc">Exception message.</param>
    public ResultWithException(string exc)
    {
        this.Exc = exc;
    }
    /// <summary>
    /// Creates a result with the message from the given exception.
    /// </summary>
    /// <param name="exc">Exception to extract message from.</param>
    public ResultWithException(Exception exc)
    {
        this.Exc = exc.Message;
    }
    /// <summary>
    /// Default constructor for cases where data type is string (same as exception type).
    /// </summary>
    public ResultWithException()
    {
    }
}