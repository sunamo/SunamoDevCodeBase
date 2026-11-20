namespace SunamoDevCode._public.SunamoData.Data;

/// <summary>
/// Represents the file info lite DC type.
/// </summary>
public class FileInfoLiteDC
{
    /// <summary>
    /// Gets or sets the path.
    /// </summary>
    public string? Path { get; set; } = null;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string? Name { get; set; } = null;

    /// <summary>
    /// Gets the file name.
    /// </summary>
    public string FileName => Name!;

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    public long Size { get; set; } = 0;

    /// <summary>
    /// Gets the length.
    /// </summary>
    public long Length => Size;

    /// <summary>
    /// Gets or sets the directory.
    /// </summary>
    public string? Directory { get; set; } = null;

    /// <summary>
    /// Initializes a new instance of the file info lite DC class.
    /// </summary>
    public FileInfoLiteDC()
    {
    }

    /// <summary>
    /// Initializes a new instance of the file info lite DC class.
    /// </summary>
    /// <param name="directory">The directory.</param>
    /// <param name="fileName">The file name.</param>
    /// <param name="length">The length.</param>
    public FileInfoLiteDC(string directory, string fileName, long length)
    {
        this.Directory = directory;
        Name = fileName;
        Size = length;
    }

    /// <summary>
    /// Get FIL.
    /// </summary>
    /// <returns>The get FIL result.</returns>
    public static FileInfoLiteDC GetFIL(FileInfo fileInfo)
    {
        var fileInfoLite = new FileInfoLiteDC
        {
            Name = fileInfo.Name,
            Path = fileInfo.FullName,
            Directory = fileInfo.DirectoryName!,
            Size = fileInfo.Length
        };
        return fileInfoLite;
    }

    /// <summary>
    /// Get FIL.
    /// </summary>
    /// <param name="fileInfo">The file info.</param>
    /// <returns>The get FIL result.</returns>
    public static FileInfoLiteDC GetFIL(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        return GetFIL(fileInfo);
    }
}
