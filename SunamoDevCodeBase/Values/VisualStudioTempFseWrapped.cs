namespace SunamoDevCode.Values;

/// <summary>
/// Represents the visual studio temp fse wrapped type.
/// </summary>
public class VisualStudioTempFseWrapped
{
    #region 1) To delete
    /// <summary>
    /// The folders in solution to delete.
    /// </summary>
    public static List<string> FoldersInSolutionToDelete = null!;

    /// <summary>
    /// The folders in project to delete.
    /// </summary>
    public static List<string> FoldersInProjectToDelete = null!;

    /// <summary>
    /// The folders anywhere to delete.
    /// </summary>
    public static List<string> FoldersAnywhereToDelete = null!;
    #endregion

    #region 2) To keep
    /// <summary>
    /// The folders in solution to keep.
    /// </summary>
    public static List<string> FoldersInSolutionToKeep = null!;

    /// <summary>
    /// The folders in project to keep.
    /// </summary>
    public static List<string> FoldersInProjectToKeep = null!;

    /// <summary>
    /// The folders anywhere to keep.
    /// </summary>
    public static List<string> FoldersAnywhereToKeep = null!;
    #endregion

    #region 3) Downloaded
    /// <summary>
    /// The folders in solution downloaded.
    /// </summary>
    public static List<string> FoldersInSolutionDownloaded = null!;

    /// <summary>
    /// The folders in project downloaded.
    /// </summary>
    public static List<string> FoldersInProjectDownloaded = null!;

    /// <summary>
    /// The folders anywhere downloaded.
    /// </summary>
    public static List<string> FoldersAnywhereDownloaded = null!;
    #endregion

    /// <summary>
    /// The files web.
    /// </summary>
    public static List<string> FilesWeb = null!;

    /// <summary>
    /// The aggregate.
    /// </summary>
    public static List<string> Aggregate = null!;

    /// <summary>
    /// Is to indexed.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The is to indexed result.</returns>
    public static bool IsToIndexed(string path)
    {
        if (SH.ContainsAtLeastOne(path, Aggregate))
        {
            return false;
        }
        return true;
    }

    static VisualStudioTempFseWrapped()
    {
        #region 1) To delete
        FoldersInSolutionToDelete = CA.WrapWith(VisualStudioTempFse.FoldersInSolutionToDelete, "\"");
        FoldersInProjectToDelete = CA.WrapWith(VisualStudioTempFse.FoldersInProjectToDelete, "\"");
        FoldersAnywhereToDelete = CA.WrapWith(VisualStudioTempFse.FoldersAnywhereToDelete, "\"");
        #endregion

        #region 2) To keep
        FoldersInSolutionToKeep = CA.WrapWith(VisualStudioTempFse.FoldersInSolutionToKeep, "\"");
        FoldersInProjectToKeep = CA.WrapWith(VisualStudioTempFse.FoldersInProjectToKeep, "\"");
        FoldersAnywhereToKeep = CA.WrapWith(VisualStudioTempFse.FoldersAnywhereToKeep, "\"");
        #endregion

        #region 3) Downloaded
        FoldersInSolutionDownloaded = CA.WrapWith(VisualStudioTempFse.FoldersInSolutionDownloaded, "\"");
        FoldersInProjectDownloaded = CA.WrapWith(VisualStudioTempFse.FoldersInProjectDownloaded, "\"");
        FoldersAnywhereDownloaded = CA.WrapWith(VisualStudioTempFse.FoldersAnywhereDownloaded, "\"");
        #endregion

        FilesWeb = CA.WrapWith(VisualStudioTempFse.FilesWeb, "\"");
        Aggregate = CA.JoinIList(FoldersInSolutionToDelete,
FoldersInProjectToDelete,
FoldersInSolutionDownloaded,
FoldersAnywhereToDelete,
FoldersInSolutionToKeep,
FoldersInProjectToKeep,
FoldersInProjectDownloaded, FilesWeb);
    }
}
