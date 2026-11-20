namespace SunamoDevCode._public.SunamoCollectionWithoutDuplicates;

/// <summary>
/// Represents the collection without duplicates base DC t type.
/// </summary>
public abstract class CollectionWithoutDuplicatesBaseDC<T>
{
    /// <summary>
    /// Gets or sets the collection.
    /// </summary>
    public List<T> Collection { get; set; } = null!;

    /// <summary>
    /// Gets or sets the string representations.
    /// </summary>
    public List<string> StringRepresentations { get; set; } = null!;

    private bool? _allowNull = false;

    /// <summary>
    /// The allow null.
    /// </summary>
    public bool? AllowNull
    {
        get => _allowNull;
        set
        {
            _allowNull = value;
            if (value.HasValue && value.Value)
            {
                StringRepresentations = new List<string>(InitialCapacity);
            }
        }
    }

    /// <summary>
    /// Gets or sets the break on construction.
    /// </summary>
    public static bool BreakOnConstruction { get; set; } = false;

    private int InitialCapacity { get; set; } = 10000;

    /// <summary>
    /// Collection without duplicates base DC.
    /// </summary>
    /// <typeparam name="string">The type string.</typeparam>
    /// <param name="InitialCapacity">The initial capacity.</param>
    /// <returns>The collection without duplicates base DC result.</returns>
    public CollectionWithoutDuplicatesBaseDC()
    {
        if (BreakOnConstruction)
        {
            System.Diagnostics.Debugger.Break();
        }
        Collection = new List<T>();
    }

    /// <summary>
    /// Collection without duplicates base DC.
    /// </summary>
    /// <returns>The collection without duplicates base DC result.</returns>
    public CollectionWithoutDuplicatesBaseDC(int capacity)
    {
        this.InitialCapacity = capacity;
        Collection = new List<T>(capacity);
    }

    /// <summary>
    /// Collection without duplicates base DC.
    /// </summary>
    /// <returns>The collection without duplicates base DC result.</returns>
    public CollectionWithoutDuplicatesBaseDC(IList<T> initialList)
    {
        Collection = new List<T>(initialList.ToList());
    }

    /// <summary>
    /// Initializes a new instance of the add class.
    /// </summary>
    /// <param name="capacity">The capacity.</param>
    public bool Add(T value)
    {
        bool result = false;
        var containsResult = Contains(value);
        if (containsResult.HasValue)
        {
            if (!containsResult.Value)
            {
                Collection.Add(value);
                result = true;
            }
        }
        else
        {
            if (!AllowNull.HasValue)
            {
                Collection.Add(value);
                result = true;
            }
        }
        if (result)
        {
            if (IsComparingByString())
            {
                StringRepresentations.Add(ItemString);
            }
        }
        return result;
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns>The is comparing by string result.</returns>
    protected abstract bool IsComparingByString();

    /// <summary>
    /// Gets or sets the item string.
    /// </summary>
    protected string ItemString { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the contains class.
    /// </summary>
    /// <param name="IsComparingByString()">The is comparing by string.</param>
    public abstract bool? Contains(T value);

    /// <summary>
    /// Initializes a new instance of the add with index class.
    /// </summary>
    /// <param name="ItemString">The item string.</param>
    public abstract int AddWithIndex(T value);

    /// <summary>
    /// Index of.
    /// </summary>
    /// <returns>The index of result.</returns>
    public abstract int IndexOf(T value);

    private List<T> WasNotAdded { get; set; } = new List<T>();

    /// <summary>
    /// Add range.
    /// </summary>
    /// <returns>The add range result.</returns>
    public List<T> AddRange(IList<T> list)
    {
        WasNotAdded.Clear();
        foreach (var item in list)
        {
            if (!Add(item))
            {
                WasNotAdded.Add(item);
            }
        }
        return WasNotAdded;
    }

    /// <summary>
    /// Dump as string.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <returns>The dump as string result.</returns>
    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will stay there");
    }
}
