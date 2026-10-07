namespace SunamoDevCode._sunamo.SunamoCollections;

internal partial class CA
{
    internal static void RemoveWhichContainsList(List<string> files, List<string> list, bool isWildcard, Func<string, string, bool>? wildcardIsMatch = null)
    {
        foreach (var item in list)
        {
            RemoveWhichContains(files, item, isWildcard, wildcardIsMatch);
        }
    }

    internal static List<string> TrimEnd(List<string> list, params char[] toTrim)
    {
        for (int index = 0; index < list.Count; index++)
        {
            list[index] = list[index].TrimEnd(toTrim);
        }

        return list;
    }

    internal static List<T> JoinIList<T>(params IList<T>[] lists)
    {
        var result = new List<T>();
        foreach (var list in lists)
        {
            foreach (var element in list)
            {
                result.Add((T)element);
            }
        }

        return result;
    }

    internal static void RemoveEmptyLinesToFirstNonEmpty(List<string> lines)
    {
        for (int index = 0; index < lines.Count; index++)
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

    internal static void RemoveLines(List<string> lines, List<int> lineIndexesToRemove)
    {
        lineIndexesToRemove.Sort();
        for (int index = lineIndexesToRemove.Count - 1; index >= 0; index--)
        {
            var lineIndex = lineIndexesToRemove[index];
            lines.RemoveAt(lineIndex);
        }
    }

    internal static List<string> RemoveStringsEmpty2(List<string> list)
    {
        for (int index = list.Count - 1; index >= 0; index--)
        {
            if (list[index].Trim() == string.Empty)
            {
                list.RemoveAt(index);
            }
        }

        return list;
    }

    internal static List<string> WrapWith(List<string> list, string wrapText)
        => WrapWith(list, wrapText, wrapText);

    internal static List<string> WrapWith(List<string> list, string prefixText, string suffixText)
    {
        for (int index = 0; index < list.Count; index++)
        {
            list[index] = prefixText + list[index] + suffixText;
        }

        return list;
    }

    internal static List<string> EnsureBackslash(List<string> paths)
    {
        for (int index = 0; index < paths.Count; index++)
        {
            string path = paths[index];
            if (path[path.Length - 1] != '\\')
            {
                paths[index] = path + "\\";
            }
        }

        return paths;
    }

    internal static bool ContainsElement<T>(IList<T> list, T element)
    {
        if (list.Count == 0)
        {
            return false;
        }

        foreach (T item in list)
        {
            if (Comparer<T>.Equals(item, element))
            {
                return true;
            }
        }

        return false;
    }

    internal static void RemoveWildcard(List<string> list, string mask)
    {
        //https://stackoverflow.com/a/15275806
        for (int index = list.Count - 1; index >= 0; index--)
        {
            if (SH.MatchWildcard(list[index], mask))
            {
                list.RemoveAt(index);
            }
        }
    }

    internal static bool HasPostfix(string key, params string[] suffixes)
    {
        foreach (var item in suffixes)
        {
            if (key.EndsWith(item))
            {
                return true;
            }
        }

        return false;
    }

    internal static List<string> Prepend(string prefix, List<string> list)
    {
        for (int index = 0; index < list.Count; index++)
        {
            if (!list[index].StartsWith(prefix))
            {
                list[index] = prefix + list[index];
            }
        }

        return list;
    }

    internal static List<string> ToListString(params string[] values)
        => values.ToList();
}
