namespace SunamoDevCode;

// Dictionary as cache is good in database but not in ordinal c# app!
/// <summary>
/// Represents the replacer xlf type.
/// </summary>
public class ReplacerXlf
{
    private static ReplacerXlf? instance;
    private readonly List<string> values;
    /// <summary>
    /// Gets or sets the with without underscore.
    /// </summary>
    public Dictionary<string, string> WithWithoutUnderscore { get; set; } = new();

    private ReplacerXlf()
    {
        AllLists.InitHtmlEntitiesFullNames();

        values = AllLists.htmlEntitiesFullNames.Values.ToList();

        CA.Prepend("_", values);
    }

    /// <summary>
    /// The instance.
    /// </summary>
    public static ReplacerXlf Instance
    {
        get
        {
            if (instance is null) instance = new ReplacerXlf();

            return instance;
        }
    }

    /// <summary>
    /// Initializes a new instance of the without underscore class.
    /// </summary>
    /// <param name="null">The null.</param>
    public string WithoutUnderscore(string text)
    {
        foreach (var item in values) text = text.Replace(item, string.Empty);
        return text;
    }



}
