namespace SunamoDevCode._public.SunamoTextOutputGenerator;

/// <summary>
/// Represents the text builder DC type.
/// </summary>
public class TextBuilderDC
{
    private static Type type = typeof(TextBuilderDC);
    private bool _canUndo = false;
    private int _lastIndex = -1;
    private string _lastText = "";
    /// <summary>
    /// The string builder.
    /// </summary>
    public StringBuilder stringBuilder = null!;
    /// <summary>
    /// Gets or sets the prepend every no white.
    /// </summary>
    public string prependEveryNoWhite { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list.
    /// </summary>
    public List<string> list { get; set; } = null!;
    private bool _useList = false;

    /// <summary>
    /// Clear.
    /// </summary>
    /// <returns>The clear result.</returns>
    public void Clear()
    {
        if (_useList)
        {
            list.Clear();
        }
        else
        {
            stringBuilder.Clear();
        }
    }

    /// <summary>
    /// Create.
    /// </summary>
    /// <returns>The create result.</returns>
    public static TextBuilderDC Create(bool useList = false)
    {
        return new TextBuilderDC(useList);
    }

    /// <summary>
    /// Initializes a new instance of the text builder DC class.
    /// </summary>
    public TextBuilderDC(bool useList = false)
    {
        _useList = useList;
        if (useList)
        {
            list = new List<string>();
        }
        else
        {
            stringBuilder = new StringBuilder();
        }
    }

    /// <summary>
    /// The can undo.
    /// </summary>
    public bool CanUndo
    {
        get
        {
            if (_useList)
            {
                return false;
            }
            return _canUndo;
        }
        set
        {
            _canUndo = value;
            if (!value)
            {
                _lastIndex = -1;
                _lastText = "";
            }
        }
    }

    private void UndoIsNotAllowed(string what)
    {
        ThrowEx.IsNotAllowed(what);
    }

    /// <summary>
    /// Undo.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <returns>The undo result.</returns>
    public void Undo()
    {
        if (_useList)
        {
            UndoIsNotAllowed("Undo");
        }
        if (_lastIndex != -1)
        {
            stringBuilder.Remove(_lastIndex, _lastText.Length);
        }
    }

    /// <summary>
    /// Append.
    /// </summary>
    public void Append(string text)
    {
        if (_useList)
        {
            if (list.Count > 0)
            {
                list[list.Count - 1] += text;
            }
            else
            {
                list.Add(text);
            }
        }
        else
        {
            SetUndo(text);
            stringBuilder.Append(prependEveryNoWhite);
            stringBuilder.Append(text);
        }
    }

    private void SetUndo(string text)
    {
        if (_useList)
        {
            UndoIsNotAllowed("SetUndo");
        }
        if (CanUndo)
        {
            _lastIndex = stringBuilder.Length;
            _lastText = text;
        }
    }

    /// <summary>
    /// Append.
    /// </summary>
    /// <param name="_useList">The use list.</param>
    /// <returns>The append result.</returns>
    public void Append(object text)
    {
        string textString = text.ToString()!;
        SetUndo(textString);
        Append(textString);
    }

    /// <summary>
    /// Append line.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The append line result.</returns>
    public void AppendLine()
    {
        Append(Environment.NewLine);
    }

    /// <summary>
    /// Append line.
    /// </summary>
    /// <param name="text">The text.</param>
    public void AppendLine(string text)
    {
        if (_useList)
        {
            list.Add(prependEveryNoWhite + text);
        }
        else
        {
            SetUndo(text);
            stringBuilder.Append(prependEveryNoWhite + text + Environment.NewLine);
        }
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <param name="_useList">The use list.</param>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        if (_useList)
        {
            return string.Join(Environment.NewLine, list);
        }
        else
        {
            return stringBuilder.ToString();
        }
    }
}
