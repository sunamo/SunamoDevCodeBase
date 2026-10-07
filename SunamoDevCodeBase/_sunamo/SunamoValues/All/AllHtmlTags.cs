namespace SunamoDevCode._sunamo.SunamoValues.All;

internal class AllHtmlTags
{
    internal static List<string>? list = null;
    static List<string>? withLeftArrow;
    internal static List<string> WithLeftArrow
    {
        get
        {
            if (withLeftArrow == null)
            {
                Initialize();
                withLeftArrow = new(list!.Count);
                for (int index = 0; index < list!.Count; index++)
                {
                    withLeftArrow.Add("<" + list![index] + " ");
                }
            }
            return withLeftArrow;
        }
    }
    internal static void Initialize()
    {
        if (list == null)
        {
            list = new();
            foreach (var item in Enum.GetNames(typeof(HtmlTextWriterTag)))
            {
                list.Add(item.ToLower());
            }
            //list.Sort(new SunamoComparerICompare.StringLength.Desc(SunamoComparer.StringLength.Instance));
        }
    }
}