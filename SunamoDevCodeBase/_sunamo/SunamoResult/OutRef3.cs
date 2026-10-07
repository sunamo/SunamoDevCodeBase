namespace SunamoDevCode._sunamo.SunamoResult;

internal class OutRef3<T, U, V> : OutRef<T, U>
{
    internal OutRef3(T item1, U item2, V item3) : base(item1, item2)
    {
        Item3 = item3;
    }
    internal V Item3 { get; set; }
}