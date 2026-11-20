namespace SunamoDevCode._public.SunamoData.Data;

/// <summary>
/// Represents the from to TSHDC t type.
/// </summary>
public class FromToTSHDC<T>
{
    /// <summary>
    /// The empty.
    /// </summary>
    public bool empty;
    /// <summary>
    /// The from l.
    /// </summary>
    protected long fromL;
    /// <summary>
    /// The ft use.
    /// </summary>
    public FromToUseDC ftUse = FromToUseDC.DateTime;
    /// <summary>
    /// The to l.
    /// </summary>
    protected long toL;

    /// <summary>
    /// Initializes a new instance of the from to TSHDC class.
    /// </summary>
    public FromToTSHDC()
    {
        var type = typeof(T);
        if (type == typeof(int)) ftUse = FromToUseDC.None;
    }

    // Use Empty constant outside of class
    private FromToTSHDC(bool empty) : this()
    {
        this.empty = empty;
    }

    /// <summary>
    /// Initializes a new instance of the from to TSHDC class.
    /// </summary>
    public FromToTSHDC(T from, T to, FromToUseDC ftUse = FromToUseDC.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }

    /// <summary>
    /// The from.
    /// </summary>
    public T from
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value!;
    }

    /// <summary>
    /// The to.
    /// </summary>
    public T to
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets the from l.
    /// </summary>
    public long FromL => fromL;
    /// <summary>
    /// Gets the to l.
    /// </summary>
    public long ToL => toL;
}
