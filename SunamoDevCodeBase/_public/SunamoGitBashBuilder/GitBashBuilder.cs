namespace SunamoDevCode._public.SunamoGitBashBuilder;

/// <summary>
/// Represents the git bash builder type.
/// </summary>
public partial class GitBashBuilder : IGitBashBuilder
{
    /// <summary>
    /// Pull.
    /// </summary>
    public void Pull()
    {
        Git("pull");
        AppendLine();
    }

    // 11-9 the repoUrl attribute has been removed because it is fully replaceable with args
    /// <summary>
    /// Clone.
    /// </summary>
    /// <param name="args">The args.</param>
    public void Clone(string args)
    {
        Git("clone " + args);
        AppendLine();
    }

    /// <summary>
    /// Commit.
    /// </summary>
    /// <param name="addAllUntrackedFiles">The add all untracked files.</param>
    /// <param name="commitMessage">The commit message.</param>
    public void Commit(bool addAllUntrackedFiles, string commitMessage)
    {
        ThrowEx.IsNullOrWhitespace("commitMessage", commitMessage);
        Git("commit ");
        if (addAllUntrackedFiles)
        {
            Append("-a");
        }

        if (!string.IsNullOrWhiteSpace(commitMessage))
        {
            Append("-m " + SH.WrapWithQm(commitMessage));
        }

        AppendLine();
    }

    /// <summary>
    /// Push.
    /// </summary>
    /// <param name="force">The force.</param>
    public void Push(bool force)
    {
        Git("push");
        if (force)
        {
            Append("-f");
        }

        AppendLine();
    }

    /// <summary>
    /// Push.
    /// </summary>
    /// <param name="arg">The arg.</param>
    public void Push(string arg)
    {
        Git("push");
        Append(arg);
        AppendLine();
    }

    /// <summary>
    /// Init.
    /// </summary>
    public void Init()
    {
        Git("init");
        AppendLine();
    }

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    public void Add(string filePath)
    {
        Git("add");
        Append(filePath);
        AppendLine();
    }

    /// <summary>
    /// Config.
    /// </summary>
    /// <param name="configOption">The config option.</param>
    public void Config(string configOption)
    {
        Git("config");
        Append(configOption);
        AppendLine();
    }

    /// <summary>
    /// Clean.
    /// </summary>
    /// <param name="cleanOptions">The clean options.</param>
    public void Clean(string cleanOptions)
    {
        Git("clean");
        Arg(cleanOptions);
        AppendLine();
    }

    /// <summary>
    /// Git static.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="remainCommand">The remain command.</param>
    /// <returns>The git static result.</returns>
    public static string GitStatic(StringBuilder stringBuilder, string remainCommand)
    {
        stringBuilder.Append("git " + remainCommand);
        return stringBuilder.ToString();
    }

    private void Git(string remainingCommand)
    {
        if (remainingCommand[remainingCommand.Length - 1] != ' ')
        {
            remainingCommand += " ";
        }

        StringBuilder.Append((GitForDebug ? "GitForDebug " : "git ") + remainingCommand);
    }

    private void Arg(string argument)
    {
        Append("-" + argument);
    }

    /// <summary>
    /// Comment.
    /// </summary>
    /// <param name="commentText">The comment text.</param>
    public void Comment(string commentText)
    {
        AppendLine("#" + commentText);
    }

    /// <summary>
    /// Multiline comment.
    /// </summary>
    /// <param name="lines">The lines.</param>
    public void MultilineComment(List<string> lines)
    {
        AppendLine("<#");
        foreach (var item in lines)
        {
            AppendLine(item);
        }

        AppendLine("#>");
    }

    /// <summary>
    /// Remote.
    /// </summary>
    /// <param name="arg">The arg.</param>
    public void Remote(string arg)
    {
        Git("remote");
        Append(arg);
        AppendLine();
    }

    /// <summary>
    /// Status.
    /// </summary>
    public void Status()
    {
        Git("status");
        AppendLine();
    }

    /// <summary>
    /// Fetch.
    /// </summary>
    /// <param name="remoteName">The remote name.</param>
    public void Fetch(string remoteName = "")
    {
        Git("fetch " + remoteName);
        AppendLine();
    }

    /// <summary>
    /// Merge.
    /// </summary>
    /// <param name="branchName">The branch name.</param>
    public void Merge(string branchName)
    {
        Git("merge " + branchName);
        AppendLine();
    }

    /// <summary>
    /// Add new remote.
    /// </summary>
    /// <param name="remoteUrl">The remote url.</param>
    public void AddNewRemote(string remoteUrl)
    {
        Remote("add origin " + remoteUrl);
        Fetch("origin");
        Checkout("-b master --track origin/master");
        AppendLine("vsGitIgnoreGitHub");
        AppendLine("gaacipuu");
    }

    /// <summary>
    /// Checkout.
    /// </summary>
    /// <param name="arg">The arg.</param>
    public void Checkout(string arg)
    {
        Git("checkout");
        AppendLine(arg);
    }

    private static Type type = typeof(GitBashBuilder);
    /// <summary>
    /// Gets or sets the string builder.
    /// </summary>
    public TextBuilderDC StringBuilder { get; set; } = null!;
    /// <summary>
    /// Git bash builder.
    /// </summary>
    /// <param name="stringBuilder">The string builder.</param>
    /// <returns>The git bash builder result.</returns>
    public GitBashBuilder(TextBuilderDC stringBuilder)
    {
        this.StringBuilder = stringBuilder;
    }

    /// <summary>
    /// Gets or sets the git for debug.
    /// </summary>
    public bool GitForDebug { get; set; } = false;
    /// <summary>
    /// Gets the commands.
    /// </summary>
    public List<string> Commands { get => SHGetLines.GetLines(ToString()); }

    /// <summary>
    /// Create git add for files.
    /// </summary>
    /// <param name="ToString()">The to string.</param>
    /// <returns>The create git add for files result.</returns>
    public static string CreateGitAddForFiles(StringBuilder stringBuilder, List<string> linesFiles)
    {
        return CreateGitCommandForFiles("add", stringBuilder, linesFiles);
    }

    /// <summary>
    /// Generate command for git.
    /// </summary>
    /// <param name="ToString()">The to string.</param>
    /// <returns>The generate command for git result.</returns>
    public static string GenerateCommandForGit( /*object tlb,*/string solution, List<string> linesFiles, out bool anyError, string searchOnlyWithExtension, string command, string basePathIfA2SolutionsWontExistsOnFilesystem)
    {
        var filesToCommit = GitBashBuilder.PrepareFilesToSimpleGitFormat( /*tlb,*/solution, linesFiles, out anyError, searchOnlyWithExtension, basePathIfA2SolutionsWontExistsOnFilesystem);
        if (filesToCommit == null || filesToCommit.Count == 0)
        {
            return "";
        }

        string result = GitBashBuilder.CreateGitCommandForFiles(command, new StringBuilder(), filesToCommit);
        return result;
    }

    /// <summary>
    /// Initializes a new instance of the checkout with extension class.
    /// </summary>
    /// <param name="filesToCommit">The files to commit.</param>
    public static string CheckoutWithExtension(string folder, string typedExt, List<string> files, string basePathIfA2SolutionsWontExistsOnFilesystem, TextBuilderDC textBuilder)
    {
        ThrowEx.IsNull("typedExt", typedExt);
        GitBashBuilder bashBuilder = new GitBashBuilder(textBuilder);
        bool anyError = false;
        var filesToCommit = GitBashBuilder.PrepareFilesToSimpleGitFormat( /*null,*/folder, files, out anyError, typedExt, basePathIfA2SolutionsWontExistsOnFilesystem);
        if (filesToCommit == null)
        {
        }

        string result = GitBashBuilder.GenerateCommandForGit( /*null,*/folder, files, out anyError, typedExt, "checkout", basePathIfA2SolutionsWontExistsOnFilesystem);
        return result;
    }
}
