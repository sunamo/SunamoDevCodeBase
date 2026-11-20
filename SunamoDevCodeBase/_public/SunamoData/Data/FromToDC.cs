namespace SunamoDevCode._public.SunamoData.Data;

// Must have always entered both from and to
// None of event could have unlimited time!
/// <summary>
/// Represents the from to DC type.
/// </summary>
public class FromToDC : FromToTSHDC<long>
{
    /// <summary>
    /// The empty.
    /// </summary>
    public static FromToDC Empty = new(true);

    /// <summary>
    /// From to DC.
    /// </summary>
    /// <param name="true">The true.</param>
    /// <returns>The from to DC result.</returns>
    public FromToDC()
    {
    }

    private FromToDC(bool empty)
    {
        this.empty = empty;
    }

    /// <summary>
    /// From to DC.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <param name="ftUse">The ft use.</param>
    /// <returns>The from to DC result.</returns>
    public FromToDC(long from, long to, FromToUseDC ftUse = FromToUseDC.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}
