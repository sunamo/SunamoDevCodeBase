namespace SunamoDevCode._public;

/// <summary>
/// Represents the i progress bar DC type.
/// </summary>
public interface IProgressBarDC
{
    /// <summary>
    /// Gets or sets the is registered.
    /// </summary>
    bool IsRegistered { get; set; }
    /// <summary>
    /// Gets or sets the write only dividable by.
    /// </summary>
    int WriteOnlyDividableBy { get; set; }
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="percentCalculator">The percent calculator.</param>
    /// <returns>The init result.</returns>
    void Init(IPercentCalculatorDC percentCalculator);
    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="percentCalculator">The percent calculator.</param>
    /// <returns>The init result.</returns>
    void Init(IPercentCalculatorDC percentCalculator, bool isNotUt);
    /// <summary>
    /// Done one.
    /// </summary>
    /// <param name="percentCalculator">The percent calculator.</param>
    /// <returns>The done one result.</returns>
    void DoneOne(object asyncResult);
    /// <summary>
    /// Done one.
    /// </summary>
    /// <param name="percentCalculator">The percent calculator.</param>
    /// <returns>The done one result.</returns>
    void DoneOne();
    /// <summary>
    /// Done one.
    /// </summary>
    /// <param name="percentCalculator">The percent calculator.</param>
    /// <returns>The done one result.</returns>
    void DoneOne(int count);
    /// <summary>
    /// Start.
    /// </summary>
    /// <param name="percentCalculator">The percent calculator.</param>
    /// <returns>The start result.</returns>
    void Start(int totalCount);
    /// <summary>
    /// Done.
    /// </summary>
    /// <param name="percentCalculator">The percent calculator.</param>
    void Done();
}
