namespace SunamoDevCode.Values;

/// <summary>
/// Represents the visual studio temp fse type.
/// </summary>
public class VisualStudioTempFse
{
    /// <summary>
    /// The ignored for indexing.
    /// </summary>
    public static List<string>? IgnoredForIndexing = null;

    // "packages" cannot be here - after every cleaning, which is most time very often, must open sunamo sln and compile all
    // bin is e.g. in _Docker\DockerFromBeginWebForms,Analyzer1\Analyzer1 \Analyzer1 \Analyzer1.Test \Analyzer1.Vsix


    // Is in foldersInSolutionToKeep
    /// <summary>
    /// The git folder name constant.
    /// </summary>
    public const string GitFolderName = ".git";

    /// <summary>
    /// The gitignore file constant.
    /// </summary>
    public const string GitignoreFile = ".gitignore";

    #region 1) To delete
    /// <summary>
    /// The folders in solution to delete.
    /// </summary>
    public static List<string> FoldersInSolutionToDelete = new List<string>([".vs", "_UpgradeReport_Files", "obj", "Backup*", "bin", "obj", "TestResults", "MigrationBackup"]);
    /// <summary>
    /// The folders in project to delete.
    /// </summary>
    public static List<string> FoldersInProjectToDelete = new List<string>([".vs", "obj", "bin", "BundleArtifacts"]);
    /// <summary>
    /// The folders anywhere to delete.
    /// </summary>
    public static List<string> FoldersAnywhereToDelete = new List<string> { };

    /// <summary>
    /// The files in solution to delete.
    /// </summary>
    public static ExtensionSortedCollection FilesInSolutionToDelete = new ExtensionSortedCollection("UpgradeLog*.htm", "UpgradeLog*.htm", "*.suo");
    /// <summary>
    /// The files in project to delete.
    /// </summary>
    public static ExtensionSortedCollection FilesInProjectToDelete = new ExtensionSortedCollection("*.user");
    /// <summary>
    /// The files anywhere to delete.
    /// </summary>
    public static ExtensionSortedCollection FilesAnywhereToDelete = new ExtensionSortedCollection("Thumbs.db", "*.TMP", "*.tmp");
    #endregion

    #region 2) To keep
    /// <summary>
    /// The folders in solution to keep.
    /// </summary>
    public static List<string> FoldersInSolutionToKeep = new List<string> { GitFolderName };
    /// <summary>
    /// The folders in project to keep.
    /// </summary>
    public static List<string> FoldersInProjectToKeep = new List<string> { "AppPackages", "Assets", "BundleArtifacts", "Fonts", "MultilingualResources", "Properties", "Service References", "screenshots", "Import Schema Logs", "Stored Procedures", "XMLSchemaCollections", "User Defined Types" };
    /// <summary>
    /// The folders anywhere to keep.
    /// </summary>
    public static List<string> FoldersAnywhereToKeep = new List<string> { };

    /// <summary>
    /// The files in solution to keep.
    /// </summary>
    public static List<string> FilesInSolutionToKeep = new List<string> { };
    /// <summary>
    /// The files in project to keep.
    /// </summary>
    public static List<string> FilesInProjectToKeep = new List<string> { "*.suo" };
    /// <summary>
    /// The files anywhere to keep.
    /// </summary>
    public static List<string> FilesAnywhereToKeep = new List<string> { "*_TemporaryKey.pfx", "*.png", "*.jpg", "*.bmp", "*.ico", "*.dll", "README.md", "*.resx", "*.mdf", "*.ldf", "project.json", "project.lock.json", "*.nuget.targets" };
    #endregion

    #region 3) Downloaded
    /// <summary>
    /// The folders in solution downloaded.
    /// </summary>
    public static List<string> FoldersInSolutionDownloaded = new List<string> { "packages", GitFolderName, "node_modules", "x64", ".vs", ".vscode", "lib", ".idea", ".nuget", ".svn", ".*" };
    /// <summary>
    /// The folders in project downloaded.
    /// </summary>
    public static List<string> FoldersInProjectDownloaded = new List<string> { };
    /// <summary>
    /// The folders anywhere downloaded.
    /// </summary>
    public static List<string> FoldersAnywhereDownloaded = new List<string> { };

    // next all files starting with dot - ".gitignore", ".browserslistrc"
    // also all .json
    /// <summary>
    /// The files in solution downloaded.
    /// </summary>
    public static ExtensionSortedCollection FilesInSolutionDownloaded = new ExtensionSortedCollection(".gitattributes", GitignoreFile, "package-lock.json", "README.md");
    /// <summary>
    /// The files in project downloaded.
    /// </summary>
    public static List<string> FilesInProjectDownloaded = new List<string> { };
    /// <summary>
    /// The files anywhere downloaded.
    /// </summary>
    public static List<string> FilesAnywhereDownloaded = new List<string> { };
    #endregion

    /// <summary>
    /// The files web.
    /// </summary>
    public static List<string> FilesWeb = new List<string>() {  "img",
"ts",
"js",
"css",
"Scripts",
"bower_components"};

    static VisualStudioTempFse()
    {
        IgnoredForIndexing = CA.JoinIList<string>(FoldersInSolutionToDelete,
FoldersInProjectToDelete,
FoldersInSolutionDownloaded,
FoldersAnywhereToDelete,
FoldersInSolutionToKeep,
FoldersInProjectToKeep,
FoldersInProjectDownloaded);
    }
}
