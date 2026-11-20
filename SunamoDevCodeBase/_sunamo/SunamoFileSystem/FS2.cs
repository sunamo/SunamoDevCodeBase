namespace SunamoDevCode._sunamo.SunamoFileSystem;

// Variable names have been checked and replaced with self-descriptive names
internal partial class FS
{
    internal static string Slash(string path, bool slash)
    {
        string? result = null;
        if (slash)
        {
            result = path.Replace("\"", "/"); //SHReplace.ReplaceAll2(path, "/", "\"");
        }
        else
        {
            result = path.Replace("/", "\""); //SHReplace.ReplaceAll2(path, "\"", "/");
        }

        SH.FirstCharUpper(ref result);
        return result;
    }

    internal static Dictionary<string, List<string>> GetDictionaryByFileNameWithExtension(List<string> files)
    {
        var result = new Dictionary<string, List<string>>();
        foreach (var item in files)
        {
            string filename = Path.GetFileName(item);
            DictionaryHelper.AddOrCreateIfDontExists<string, string>(result, filename, item);
        }

        return result;
    }

    internal static string AddExtensionIfDontHave(string file, string ext)
    {
        // For *.* and git paths {dir}/*
        if (file[file.Length - 1] == '*')
        {
            return file;
        }

        if (Path.GetExtension(file) == string.Empty)
        {
            return file + ext;
        }

        return file;
    }

    internal static bool TryDeleteDirectory(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            return true;
        }

        try
        {
            Directory.Delete(directoryPath, true);
            return true;
        }
        catch (Exception)
        {
        // It's try so don't know what this is doing here
        }

        var files = GetFiles(directoryPath, "*", SearchOption.AllDirectories);
        foreach (var filePath in files)
        {
            File.SetAttributes(filePath, FileAttributes.Normal);
        }

        try
        {
            Directory.Delete(directoryPath, true);
            return true;
        }
        catch (Exception)
        {
        }

        return false;
    }

    internal static string WithEndSlash(string path)
    {
        return WithEndSlash(ref path);
    }

    internal static string WithEndSlash(ref string path)
    {
        if (path != string.Empty)
        {
            path = path.TrimEnd('\\') + '\\';
        }

        SH.FirstCharUpper(ref path);
        return path;
    }

    internal static string InsertBetweenFileNameAndExtension(string originalPath, string textToInsert)
    {
        // The path would be useful here because of FS.CiStorageFile
        // however I do not know whether StorageFolder is used, so it will work even without it
        var originalPathString = originalPath.ToString();
        string fileName = Path.GetFileNameWithoutExtension(originalPathString);
        string extension = Path.GetExtension(originalPathString);
        if (originalPathString.Contains('/') || originalPathString.Contains('\\'))
        {
            string directory = Path.GetDirectoryName(originalPathString)!;
            return Path.Combine(directory, fileName + textToInsert + extension);
        }

        return fileName + textToInsert + extension;
    }

    internal static List<string> OnlyNamesNoDirectEdit(String[] filePaths)
    {
        var list = filePaths.ToList();
        return OnlyNamesNoDirectEdit(list);
    }

    // No direct edit
    // Returns with extension
    // WARNING: Unlike the same method in sunamo, this method returns a completely new array and does not modify A1
    internal static List<string> OnlyNamesNoDirectEdit(List<string> filePaths)
    {
        var fileNames = new List<string>(filePaths.Count);
        for (int index = 0; index < filePaths.Count; index++)
        {
            fileNames.Add(Path.GetFileName(filePaths[index]));
        }

        return fileNames;
    }

    internal static List<string> GetFiles(string folder, string mask, SearchOption searchOption /*, GetFilesArgsDC getFilesArgs = null*/)
    {
        return Directory.GetFiles(folder, mask, searchOption).ToList();
    }

    internal static string GetDirectoryName(string filePath)
    {
        var data = Path.GetDirectoryName(filePath)!;
        return FS.WithEndSlash(data);
    }

    internal static string GetFileName(string fullPathFolder)
    {
        return FS.GetFileName(fullPathFolder);
    }

    internal static bool ExistsFile(string filePath)
    {
        return File.Exists(filePath);
    }

    internal static bool ExistsDirectory(string directoryPath)
    {
        return Directory.Exists(directoryPath);
    }
}