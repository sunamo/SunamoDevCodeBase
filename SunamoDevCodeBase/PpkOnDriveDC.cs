namespace SunamoDevCode;

// Checking whether string is already contained.
/// <summary>
/// Represents the ppk on drive DC type.
/// </summary>
public class PpkOnDriveDC : PpkOnDriveDevCodeBase<string>
{
    /// <summary>
    /// Gets or sets the remove duplicates.
    /// </summary>
    public bool RemoveDuplicates { get; set; } = false;

    /// <summary>
    /// Ppk on drive DC.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns>The ppk on drive DC result.</returns>
    public PpkOnDriveDC(PpkOnDriveDevCodeArgs args) : base(args)
    {
    }

    /// <summary>
    /// Ppk on drive DC.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="isLoading">The is loading.</param>
    /// <returns>The ppk on drive DC result.</returns>
    public PpkOnDriveDC(string filePath, bool isLoading = true) : base(new PpkOnDriveDevCodeArgs { File = filePath, Load = isLoading })
    {
    }

    /// <summary>
    /// Ppk on drive DC.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="isLoading">The is loading.</param>
    /// <param name="isSaving">The is saving.</param>
    /// <returns>The ppk on drive DC result.</returns>
    public PpkOnDriveDC(string filePath, bool isLoading, bool isSaving) : base(new PpkOnDriveDevCodeArgs
    { File = filePath, Load = isLoading, Save = isSaving })
    {
    }

    //public static PpkOnDrive WroteOnDrive
    /// <summary>
    /// Load.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>The load result.</returns>
    public async Task Load(string filePath)
    {
        args.File = filePath;
        await Load();
    }

    /// <summary>
    /// Load.
    /// </summary>
    public override
        async Task
        Load()
    {
        if (File.Exists(args.File))
        {
            AddRange(SHGetLines.GetLines(
                await
                    FileAsync.ReadAllTextAsync(args.File)));
            if (RemoveDuplicates)
            {
                var data = this.ToList();
                await Clear();
                data = data.Distinct().ToList();
                AddRange(data);
            }
        }
    }
}
