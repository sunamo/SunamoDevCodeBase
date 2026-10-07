namespace SunamoDevCode._public;

public interface IProgressBarDC
{
    bool IsRegistered { get; set; }
    int WriteOnlyDividableBy { get; set; }
    void Init(IPercentCalculatorDC percentCalculator);
    void Init(IPercentCalculatorDC percentCalculator, bool isNotUt);
    void DoneOne(object asyncResult);
    void DoneOne();
    void DoneOne(int count);
    void Start(int totalCount);
    void Done();
}
