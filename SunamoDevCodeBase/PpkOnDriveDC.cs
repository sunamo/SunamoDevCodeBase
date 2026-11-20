namespace SunamoDevCode;

// Checking whether string is already contained.
public class PpkOnDriveDC : PpkOnDriveDevCodeBase<string>
{
    public bool RemoveDuplicates { get; set; } = false;

    public PpkOnDriveDC(PpkOnDriveDevCodeArgs args) : base(args)
    {
    }

    public PpkOnDriveDC(string filePath, bool isLoading = true) : base(new PpkOnDriveDevCodeArgs { File = filePath, Load = isLoading })
    {
    }

    public PpkOnDriveDC(string filePath, bool isLoading, bool isSaving) : base(new PpkOnDriveDevCodeArgs
    { File = filePath, Load = isLoading, Save = isSaving })
    {
    }

    //public static PpkOnDrive WroteOnDrive
    public async Task Load(string filePath)
    {
        args.File = filePath;
        await Load();
    }

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
