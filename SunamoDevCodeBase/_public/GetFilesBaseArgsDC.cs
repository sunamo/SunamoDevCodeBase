namespace SunamoDevCode._public;

// Base arguments class for getting files
/// <summary>
/// Represents the get files base args DC type.
/// </summary>
public class GetFilesBaseArgsDC /*: GetFoldersEveryFolderArgs - do not inherit - read comment above*/
{
    internal bool FollowJunctions { get; set; } = false;
    internal Func<string, bool>? IsJunctionPoint { get; set; } = null;
    internal bool TrimA1AndLeadingBs { get; set; } = false;
}
