namespace SunamoDevCode;

// Helper class for System.Windows controls shortcuts and names
/// <summary>
/// Represents the system windows controls type.
/// </summary>
public static class SystemWindowsControls
{
    private static readonly Type type = typeof(SystemWindowsControls);
    private static bool s_initialized;
    private static readonly Dictionary<string, List<string>> s_controls = new();
    private static EmbeddedResourcesH? s_embeddedResourcesH;

    private static Dictionary<string, string>? controlsShortLong;

    /// <summary>
    /// Init controls short long.
    /// </summary>
    public static void InitControlsShortLong()
    {
        Init();

        if (controlsShortLong is null)
        {
            controlsShortLong = new Dictionary<string, string>();

            foreach (var item in s_controls)
            foreach (var shortcut in item.Value)
                controlsShortLong.Add(shortcut, item.Key);
        }
    }

    /// <summary>
    /// Init.
    /// </summary>
    public static void Init()
    {
        if (!s_initialized)
        {
            s_initialized = true;

            s_embeddedResourcesH = new EmbeddedResourcesH(type.Assembly, "SunamoDevCode");
        }
    }

    /// <summary>
    /// Starting with shortcut of control.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The starting with shortcut of control result.</returns>
    public static bool StartingWithShortcutOfControl(string text)
    {
        foreach (var item in s_controls)
        foreach (var shortcut in item.Value)
            if (shortcut.Length > 2)
                if (text.StartsWith(shortcut))
                    return true;

        return false;
    }

    /// <summary>
    /// Is shortcut of control.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is shortcut of control result.</returns>
    public static bool IsShortcutOfControl(string text)
    {
        foreach (var item in s_controls)
        foreach (var shortcut in item.Value)
            if (shortcut == text)
                return true;

        return false;
    }

    /// <summary>
    /// Is name of control.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is name of control result.</returns>
    public static bool IsNameOfControl(string text) => s_controls.ContainsKey(text);
}
