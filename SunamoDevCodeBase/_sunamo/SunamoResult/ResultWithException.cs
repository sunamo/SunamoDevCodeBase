namespace SunamoDevCode._sunamo.SunamoResult;

public class ResultWithException<T>
{
    public T Data { get; set; } = default!;
    public string? Exc { get; set; }

    public ResultWithException(T data)
    {
        Data = data;
    }

    public ResultWithException(string exc)
    {
        this.Exc = exc;
    }

    public ResultWithException(Exception exc)
    {
        this.Exc = exc.Message;
    }

    public ResultWithException()
    {
    }
}
