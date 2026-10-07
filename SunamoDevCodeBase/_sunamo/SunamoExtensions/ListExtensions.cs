namespace SunamoDevCode._sunamo.SunamoExtensions;

internal static class ListExtensions
{
    // Direct edit
    internal static List<string> LeadingRange(this List<string> list, IList<string> items)
    {
        for (var index = items.Count - 1; index >= 0; index--) list.Insert(0, items[index]);
        return list;
    }
}
