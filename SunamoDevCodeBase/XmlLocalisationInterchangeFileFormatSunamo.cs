namespace SunamoDevCode;

public class XmlLocalisationInterchangeFileFormatSunamo
{
    public const string Cs = "const string ";
    private const string eqBs = " = \"";

    // Translate.FromKey(
    public const string RLDataEn = SunamoNotTranslateAble.RLDataEn;

    public const string RLDataCs = SunamoNotTranslateAble.RLDataCs;
    public const string RLDataEn2 = SunamoNotTranslateAble.RLDataEn2;
    public const string SessI18n = SunamoNotTranslateAble.SessI18n;
    public const string XlfKeysDot = SunamoNotTranslateAble.XlfKeysDot;
    public const string SessI18nShort = SunamoNotTranslateAble.SessI18nShort;

    public static string PathXlfKeys = BasePathsHelper.Vs + @"sunamo\sunamo\Constants\XlfKeys.cs";
    private static Type type = typeof(XmlLocalisationInterchangeFileFormatSunamo);
    public static string SunamoStringsDot = "SunamoStrings.";

    public static
        async Task
        ReplaceHtmlEntitiesWithEmpty(string xlfPath)
    {

        var content =
            await
                FileAsync.ReadAllTextAsync(xlfPath);

        #region

        var consts = new List<string>();
        AllLists.InitHtmlEntitiesFullNames();

        var values = AllLists.htmlEntitiesFullNames.Values.ToList();
        int index;
        for (index = 0; index < values.Count; index++) values[index] = "_" + values[index];


        foreach (var item in values) content = content.Replace(item, string.Empty);


        await
            FileAsync.WriteAllTextAsync(xlfPath, content);

        #endregion
    }

    public static
        async Task
        ReplaceInXlfManuallyEnteredPairsWithPrependXlfKeys(string xlfPath)
    {
        int index;

        #region MyRegion

        string? replacePairs = null;

        #endregion

        var splitResult = SHSplit.SplitFromReplaceManyFormatList(replacePairs!);
        var toItems = splitResult.Item1;
        var from = splitResult.Item2;

        for (index = 0; index < from.Count; index++)
        {
            from[index] = from[index].Replace("XlfKeys.", string.Empty);
            toItems[index] = toItems[index].Replace("XlfKeys.", string.Empty);
        }

        from.Reverse();
        toItems.Reverse();


        var content =
            await
                FileAsync.ReadAllTextAsync(xlfPath);

        for (index = from.Count - 1; index >= 0; index--)
            //Debug.WriteLine(i);
            content = content.Replace(from[index], toItems[index]);


        await
            FileAsync.WriteAllTextAsync(xlfPath, content);
    }

    public static void ConstsFromClipboard(string input)
    {
        var lines = input.Split(new[] { input.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        //StringBuilder stringBuilder = new StringBuilder();
        //foreach (var item in lines)
        //{
        //    stringBuilder.AppendLine(string.Format(template, item));
        //}

        //ClipboardHelper.SetText(stringBuilder.ToString());
    }


    // Compare to whole line
    public static
        async Task
        RemoveDuplicatedXlfKeysConsts()
    {
        int index;

        var lines = SHGetLines.GetLines(
            await
                FileAsync.ReadAllTextAsync(PathXlfKeys)).ToList();

        for (index = 0; index < lines.Count; index++) lines[index] = lines[index].Trim();

        // only consts
        var consts = new List<string>();
        // all lines
        var constsAllLines = new List<string>();

        var count = "const ";


        index = 0;


        foreach (var item in lines)
        {
            index++;
            if (item.Contains(count))
            {
                // Get consts names
                var text = GetConstsFromLine(item);
                consts.Add(text);
                constsAllLines.Add(text);
            }
            else
            {
                constsAllLines.Add(string.Empty);
            }
        }

        List<string> foundedDuplicities;
        CAG.RemoveDuplicitiesList(constsAllLines, out foundedDuplicities);

        foundedDuplicities.Reverse();

        foreach (var item in foundedDuplicities)
            if (item != string.Empty)
            {
                var duplicateIndex = constsAllLines.IndexOf(item);
                lines.RemoveAt(duplicateIndex);
            }

        await FileAsync.WriteAllLinesAsync(PathXlfKeys, lines);
    }

    public static
        async Task
        RemoveDuplicatedXlfKeysConsts2()
    {
        int sourceIndex, index;
        //AllLists.InitHtmlEntitiesDict();
        var path = PathXlfKeys;
        var sourceList = SHGetLines.GetLines(
            await
                FileAsync.ReadAllTextAsync(path)).ToList();
        //var sourceList = SHGetLines.GetLines(text);
        int first;
        var consts = CSharpParser.ParseConsts(sourceList, out first);
        List<string> ls3;
        var ls2 = CAG.GetDuplicities(consts, out ls3);

        //string t = CSharpHelper.GetConsts(sourceList, false);
        //var tl = SHGetLines.GetLines(t);
        for (index = ls2.Count - 1; index >= 0; index--)
            for (sourceIndex = 0; sourceIndex < sourceList.Count; sourceIndex++)
                if (sourceList[sourceIndex].Contains(" " + ls2[index] + " "))
                {
                    ls2.RemoveAt(index);
                    sourceList.RemoveAt(sourceIndex);
                    index = ls2.Count - 1;
                    break;
                }

        await FileAsync.WriteAllLinesAsync(path, sourceList);
    }

    public static string GetConstsFromLine(string line)
    {
        return SH.GetTextBetweenSimple(line, Cs, eqBs, false);
    }

#pragma warning disable
    public static LangsDC GetLangFromFilename(string text)
    {
        return LangsDC.cs;
        //return XmlLocalisationInterchangeFileFormatXlf.GetLangFromFilename(text);
    }
#pragma warning restore


    public static string? TextFromRLData(string pathOrExt, string key2)
    {
        var ext = Path.GetExtension(pathOrExt);
        // Inlined from SH.PrefixIfNotStartedWith - přidává prefix pokud řetězec nezačíná daným prefixem
        if (!ext.StartsWith("."))
        {
            ext = "." + ext;
        }
        if (ext == AllExtensions.CsExtension)
            return SessI18n + XlfKeysDot + key2 + ")";
        if (ext == AllExtensions.TsExtension) return "su.en(\"" + key2 + "\")";
        ThrowEx.NotImplementedCase(ext);
        return null;
    }

    #region Mám už tady metodu GetKeysInCsWithRLDataEn, proto je toto zbytečné

    //public static List<string> UsedXlfKeysInCs(string count)
    //{
    //    List<string> usedKeys = new List<string>();

    //    var occ = SH.ReturnOccurencesOfString(count, SessI18n);
    //    var ending = new List<int>(occ.Count);

    //    foreach (var item in occ)
    //    {
    //        ending.Add(count.IndexOf(')', item));
    //    }

    //    var lines = SessI18n.Length;
    //    var l2 = XlfKeysDot.Length;

    //    for (int i = occ.Count - 1; i >= 0; i--)
    //    {
    //        var k = SHSubstring.Substring(count, occ[i] + lines + l2, ending[i], new SubstringArgs { returnInputIfIndexFromIsLessThanIndexTo = true } );
    //        if (k != count)
    //        {
    //            usedKeys.Add(k);
    //        }
    //    }

    //    return usedKeys;
    //}

    #endregion
}
