namespace SunamoDevCode;

/// <summary>
/// Represents the ppk on drive dev code base t type.
/// </summary>
public abstract class PpkOnDriveDevCodeBase<T> : List<T>
{
    #region DPP

    /// <summary>
    /// The args.
    /// </summary>
    protected PpkOnDriveDevCodeArgs args;

    #endregion

    private bool isSaving;

    // Must use FileSystemWatcher, not FileSystemWatcher because its in sunamo, not desktop
    private readonly FileSystemWatcher w = null!;

    /// <summary>
    /// Remove all.
    /// </summary>
    public
        async Task
        RemoveAll()
    {
        await Clear();
        await
            FileAsync.WriteAllTextAsync(args.File, string.Empty);
    }

    /// <summary>
    /// Initializes a new instance of the remove class.
    /// </summary>
    /// <param name="args.File">The args file.</param>
    /// <param name="string.Empty">The string empty.</param>
    public new async Task Remove(T value)
    {
        base.Remove(value);
        await Save();
    }

    /// <summary>
    /// Clear.
    /// </summary>
    /// <returns>The clear result.</returns>
    public new async Task Clear()
    {
        base.Clear();
        await Save();
    }

    /// <summary>
    /// Load.
    /// </summary>
    public abstract
        Task
        Load();

    /// <summary>
    /// Add without save.
    /// </summary>
    public void AddWithoutSave(T value)
    {
        if (!Contains(value)) base.Add(value);
    }

    /// <summary>
    /// Initializes a new instance of the add class.
    /// </summary>
    /// <param name="!Contains(value)">The contains value.</param>
    public async Task Add(IList<T> items)
    {
        foreach (var item in items) await Add(item);
    }

    /// <summary>
    /// Initializes a new instance of the add class.
    /// </summary>
    /// <param name="items">The items.</param>
    public new async Task<bool> Add(T value)
    {
        var wasAdded = false;
        if (!Contains(value))
        {
            if (value!.ToString()!.Trim() != string.Empty)
            {
                base.Add(value);
                wasAdded = true;
            }
            // keep on false
        }

        // keep on false
        await Save();
        return wasAdded;
    }

    private void Load(bool loadImmediately)
    {
        if (loadImmediately) Load();
    }

    /// <summary>
    /// Initializes a new instance of the save class.
    /// </summary>
    /// <param name="loadImmediately">The load immediately.</param>
    public async Task Save()
    {
        if (args.Save)
        {
            isSaving = true;
            var removedOrNotExists = false;
            if (removedOrNotExists)
            {
                string content;
                content = ReturnContent();
                await FileAsync.WriteAllTextAsync(args.File, content);
            }

            isSaving = false;
        }
    }

    private string ReturnContent()
    {
        var stringBuilder = new StringBuilder();
        foreach (var item in this) stringBuilder.AppendLine(item!.ToString());
        return stringBuilder.ToString();
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return ReturnContent();
    }

    #region base

    /// <summary>
    /// Ppk on drive dev code base.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns>The ppk on drive dev code base result.</returns>
    public PpkOnDriveDevCodeBase(PpkOnDriveDevCodeArgs args)
    {
        this.args = args;
        File.AppendAllText(args.File, "");
        Load(args.Load);
        if (args.LoadChangesFromDrive)
        {
            w = new FileSystemWatcher(Path.GetDirectoryName(args.File)!);
            w.Filter = args.File;
            w.Changed += W_Changed;
        }
    }

    private void W_Changed(object sender, FileSystemEventArgs eventArgs)
    {
        if (!isSaving) Load();
    }

    #endregion
}
