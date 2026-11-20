namespace SunamoDevCode._public;

/// <summary>
/// Represents the async loading base DC t progress bar type.
/// </summary>
public class AsyncLoadingBaseDC<T, ProgressBar>
{
    /// <summary>
    /// Gets or sets the progress bar instance.
    /// </summary>
    public ProgressBar ProgressBarInstance { get; set; } = default!;

    /// <summary>
    /// Gets or sets the processed count.
    /// </summary>
    public long ProcessedCount { get; set; } = 0;

    /// <summary>
    /// Gets or sets the status after load.
    /// </summary>
    public Action<T> StatusAfterLoad { get; set; } = null!;
}
