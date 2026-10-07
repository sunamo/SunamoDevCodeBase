namespace SunamoDevCode._public.SunamoCollectionsNonGeneric;

public class ExtensionSortedCollection
{
    public Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    public ExtensionSortedCollection(params string[] extensions)
    {
        extensions.ToList().ForEach(fileName => AddOnlyFileName(fileName));
    }

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

    public void AddWholeFilePath(string filePath)
    {
        AddOnlyFileName(Path.GetFileName(filePath));
    }
}
