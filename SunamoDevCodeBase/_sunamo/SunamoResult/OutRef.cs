namespace SunamoDevCode._sunamo.SunamoResult;

internal class OutRef<T, U>(T item1, U item2)
{
    internal T Item1 { get; set; } = item1;
    internal U Item2 { get; set; } = item2;
}