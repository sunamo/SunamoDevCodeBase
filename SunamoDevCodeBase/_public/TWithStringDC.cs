namespace SunamoDevCode._public;

public class TWithStringDC<T>
{
    public string path = null!;
    public T t = default!;

    public TWithStringDC()
    {
    }

    public TWithStringDC(T item, string path)
    {
        this.t = item;
        this.path = path;
    }

    public override string ToString() => path;
}
