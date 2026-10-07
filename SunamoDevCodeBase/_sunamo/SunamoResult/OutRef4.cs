namespace SunamoDevCode._sunamo.SunamoResult;

internal class OutRef4<T, U, V, W> : OutRef3<T, U, V>
{
    internal OutRef4(T item1, U item2, V item3, W item4) : base(item1, item2, item3)
    {
        Item4 = item4;
    }

    internal W Item4 { get; set; }
}