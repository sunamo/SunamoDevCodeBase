namespace SunamoDevCode._public.SunamoCollectionWithoutDuplicates;

/// <summary>
/// Represents the collection without duplicates DC t type.
/// </summary>
public class CollectionWithoutDuplicatesDC<T> : CollectionWithoutDuplicatesBaseDC<T>
{
    /// <summary>
    /// Initializes a new instance of the collection without duplicates DC class.
    /// </summary>
    public CollectionWithoutDuplicatesDC() : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates DC class.
    /// </summary>
    /// <param name="count">The count.</param>
    public CollectionWithoutDuplicatesDC(int count) : base(count)
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates DC class.
    /// </summary>
    /// <param name="list">The list.</param>
    public CollectionWithoutDuplicatesDC(IList<T> list) : base(list)
    {
    }

    /// <summary>
    /// Add with index.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The add with index result.</returns>
    public override int AddWithIndex(T value)
    {
        if (IsComparingByString())
        {
            if (Contains(value).GetValueOrDefault())
            {

            }
            else
            {
                Add(value);
                return Collection.Count - 1;
            }
        }
        int index = Collection.IndexOf(value);
        if (index == -1)
        {
            Add(value);
            return Collection.Count - 1;
        }
        return index;
    }

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The contains result.</returns>
    public override bool? Contains(T value)
    {
        if (IsComparingByString())
        {
            ItemString = value!.ToString()!;
            return StringRepresentations.Contains(ItemString);
        }
        else
        {
            if (!Collection.Contains(value))
            {
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    return null;
                }
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Index of.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The index of result.</returns>
    public override int IndexOf(T value)
    {
        if (IsComparingByString())
        {
            return StringRepresentations.IndexOf(value!.ToString()!);
        }
        int index = Collection.IndexOf(value);
        if (index == -1)
        {
            Collection.Add(value);
            return Collection.Count - 1;
        }
        return index;
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    /// <returns>The is comparing by string result.</returns>
    protected override bool IsComparingByString() => AllowNull.HasValue && AllowNull.Value;
}
