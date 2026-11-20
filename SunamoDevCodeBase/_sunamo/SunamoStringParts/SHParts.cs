namespace SunamoDevCode._sunamo.SunamoStringParts;

internal class SHParts
{
    internal static string RemoveAfterFirst(string text, string searchString)
    {
        int index = text.IndexOf(searchString);
        if (index == -1 || index == text.Length - 1)
        {
            return text;
        }

        string result = text.Remove(index);
        return result;
    }
    // The KeepAfterFirst method was removed - inlined in TypeScriptHelper.cs:79

    // The RemoveAfterLast method was removed - inlined in SolutionFolderSerialize.cs:57

    internal static string RemoveAfterFirst(string text, char searchChar)
    {
        int index = text.IndexOf(searchChar);
        return index == -1 || index == text.Length - 1 ? text : text.Substring(0, index);
    }

}
