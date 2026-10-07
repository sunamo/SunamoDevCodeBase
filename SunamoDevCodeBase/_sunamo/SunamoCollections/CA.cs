namespace SunamoDevCode._sunamo.SunamoCollections;

internal partial class CA
{
    internal enum SearchStrategyCA
    {
        FixedSpace,
        AnySpaces,
        ExactlyName
    }

    internal static List<int> ReturnWhichContainsIndexes(IList<string> list, string term)
    {
        var result = new List<int>();
        var index = 0;
        if (list != null)
            foreach (var item in list)
            {
                if (item.Contains(term))
                    result.Add(index);
                index++;
            }

        return result;
    }

    internal static List<int> ReturnWhichContainsIndexes(string text, IList<string> terms)
    {
        var result = new List<int>();
        var index = 0;
        foreach (var term in terms)
        {
            if (text.Contains(term))
                result.Add(index);
            index++;
        }

        return result;
    }

    internal static IList<int> ReturnWhichContainsIndexes(IList<string> parts, IList<string> mustContains)
    {
        var result = new List<int>();
        foreach (var term in mustContains)
            result.AddRange(ReturnWhichContainsIndexes(parts, term));
        result = result.Distinct().ToList();
        return result;
    }

    internal static List<string> StartingWith(string prefix, List<string> list)
    {
        for (var index = list.Count - 1; index >= 0; index--)
            if (!list[index].StartsWith(prefix))
                list.RemoveAt(index);
        return list;
    }

    internal static List<string> PostfixIfNotEnding(string prefix, List<string> list)
    {
        for (var index = 0; index < list.Count; index++)
            list[index] = prefix + list[index];
        return list;
    }

    internal static List<List<string>> Split(List<string> list, string delimiter)
    {
        var result = new List<List<string>>();
        var currentGroup = new List<string>();
        foreach (var item in list)
            if (item == delimiter)
            {
                result.Add(currentGroup);
                currentGroup.Clear();
            }

        return result;
    }

    internal static List<string> RemoveStringsEmptyTrimBefore(List<string> list)
    {
        for (var index = list.Count - 1; index >= 0; index--)
            if (list[index].Trim() == string.Empty)
                list.RemoveAt(index);
        return list;
    }

    internal static bool ContainsAnyFromElementBool(string text, IList<string> list)
    {
        if (list.Count == 1 && list.First() == "*")
            return true;
        foreach (var item in list)
            if (text.Contains(item))
                return true;
        return false;
    }

    internal static void RemoveNullEmptyWs(List<string> list)
    {
        for (int index = list.Count - 1; index >= 0; index--)
        {
            if (string.IsNullOrWhiteSpace(list[index]))
            {
                list.RemoveAt(index);
            }
        }
    }

    internal static List<string> Trim(List<string> list)
    {
        for (var index = 0; index < list.Count; index++)
            list[index] = list[index].Trim();
        return list;
    }

    internal static void DoubleOrMoreMultiLinesToSingle(ref string text)
    {
        text = Regex.Replace(text, @"(\r?\n\s*){2,}", Environment.NewLine + Environment.NewLine);
        text = text.Trim();
    }

    internal static void TrimWhereIsOnlyWhitespace(List<string> list)
    {
        for (int index = list.Count - 1; index >= 0; index--)
        {
            var item = list[index];
            if (string.IsNullOrWhiteSpace(item))
            {
                list[index] = list[index].Trim();
            }
        }
    }

    private static string Replace(string text, string what, string replacement)
        => text.Replace(what, replacement);

    internal static void Replace(List<string> list, string what, string replacement)
    {
        for (int index = 0; index < list.Count; index++)
        {
            list[index] = Replace(list[index], what, replacement);
        }
    }

    internal static (bool, string) IsNegationTuple(string text)
    {
        if (text[0] == '!')
        {
            text = text.Substring(1);
            return (true, text);
        }

        return (false, text);
    }

    internal static void RemoveStartingWith(string prefix, List<string> list, RemoveStartingWithArgs? args = null)
    {
        args ??= new RemoveStartingWithArgs();

        var(isNegated, actualPrefix) = IsNegationTuple(prefix);
        prefix = actualPrefix;
        for (int index = list.Count - 1; index >= 0; index--)
        {
            var value = list[index];
            if (args.TrimBeforeFinding)
            {
                value = value.Trim();
            }

            if (isNegated)
            {
                if (!StartingWith(value, prefix, args.CaseSensitive))
                {
                    list.RemoveAt(index);
                }
            }
            else
            {
                if (StartingWith(value, prefix, args.CaseSensitive))
                {
                    list.RemoveAt(index);
                }
            }
        }
    }

    internal static bool StartingWith(string text, string prefix, bool isCaseSensitive)
    {
        if (isCaseSensitive)
        {
            return text.StartsWith(prefix);
        }
        else
        {
            return text.ToLower().StartsWith(prefix.ToLower());
        }
    }

    internal static string? StartWith(List<string> prefixes, string text, out string? matchedPrefix)
    {
        matchedPrefix = null;
        if (prefixes != null)
        {
            foreach (var prefix in prefixes)
            {
                if (text.StartsWith(prefix))
                {
                    matchedPrefix = prefix;
                    return text;
                }
            }
        }

        return null;
    }

    internal static void RemoveWhichContains(List<string> list, string pattern, bool isWildcard, Func<string, string, bool>? wildcardIsMatch)
    {
        if (isWildcard)
        {
            if (wildcardIsMatch is null)
            {
                throw new ArgumentNullException(nameof(wildcardIsMatch), "Wildcard match function is required when isWildcard is true");
            }

            for (int index = list.Count - 1; index >= 0; index--)
            {
                if (wildcardIsMatch(list[index], pattern))
                {
                    list.RemoveAt(index);
                }
            }
        }
        else
        {
            for (int itemIndex = list.Count - 1; itemIndex >= 0; itemIndex--)
            {
                if (list[itemIndex].Contains(pattern))
                {
                    list.RemoveAt(itemIndex);
                }
            }
        }
    }
}
