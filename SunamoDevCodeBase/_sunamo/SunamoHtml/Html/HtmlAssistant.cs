namespace SunamoDevCode._sunamo.SunamoHtml.Html;

internal class HtmlAssistant
{
    internal static string TrimInnerHtml(string value)
    {
        throw new Exception("Code without CreateHtmlDocument");
    }
    internal static string HtmlDecode(string encodedText)
    {
        return WebUtility.HtmlDecode(encodedText);
    }
}