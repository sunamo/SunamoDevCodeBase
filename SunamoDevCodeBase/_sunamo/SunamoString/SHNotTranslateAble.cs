namespace SunamoDevCode._sunamo.SunamoString;

internal class SHNotTranslateAble
{
    internal static string DecodeSlashEncodedString(string value)
    {
        // keep as was writte
        value = SHReplace.ReplaceAll(value, "\\", "\\\\");
        value = SHReplace.ReplaceAll(value, "\"", "\\\"");
        value = SHReplace.ReplaceAll(value, "\'", "\\\'");
        return value;
    }
}