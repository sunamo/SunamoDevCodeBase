namespace SunamoDevCode._sunamo.SunamoCollections;

internal class RemoveEmptyLinesService
{
    internal void RemoveEmptyLinesFromStartAndEnd(List<string> lines)
    {
        RemoveEmptyLinesToFirstNonEmpty(lines);
        RemoveEmptyLinesFromBack(lines);
    }

    internal void RemoveEmptyLinesToFirstNonEmpty(List<string> lines)
    {
        for (var index = 0; index < lines.Count; index++)
        {
            var line = lines[index];
            if (line.Trim() == string.Empty)
            {
                lines.RemoveAt(index);
                index--;
            }
            else
            {
                break;
            }
        }
    }

    internal void RemoveEmptyLinesFromBack(List<string> lines)
    {
        for (var index = lines.Count - 1; index >= 0; index--)
        {
            var line = lines[index];
            if (line.Trim() == string.Empty)
                lines.RemoveAt(index);
            else
                break;
        }
    }
}
