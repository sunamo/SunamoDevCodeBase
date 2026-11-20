namespace SunamoDevCode._public.SunamoCollectionsNonGeneric;

/// <summary>
/// Represents the extension sorted collection type.
/// </summary>
public class ExtensionSortedCollection
{
    /// <summary>
    /// The dictionary.
    /// </summary>
    public Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    /// <summary>
    /// Extension sorted collection.
    /// </summary>
    /// <returns>The extension sorted collection result.</returns>
    public ExtensionSortedCollection(params string[] extensions)
    {
        extensions.ToList().ForEach(fileName => AddOnlyFileName(fileName));
    }

    /// <summary>
    /// Initializes a new instance of the add only file name class.
    /// </summary>
    public void AddOnlyFileName(string fileName)
    {
        string key = Path.GetExtension(fileName).ToLower();
        string value = Path.GetFileNameWithoutExtension(fileName).ToLower();
        if (dictionary.ContainsKey(key))
        {
            if (!dictionary[key].Contains(value))
            {
                dictionary[key].Add(value);
            }
        }
        else
        {
            var values = new List<string>();
            values.Add(value);
            dictionary.Add(key, values);
        }
    }

    /// <summary>
    /// Add whole file path.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The add whole file path result.</returns>
    public void AddWholeFilePath(string filePath)
    {
        AddOnlyFileName(Path.GetFileName(filePath));
    }
}
