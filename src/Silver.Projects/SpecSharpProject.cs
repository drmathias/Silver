namespace Silver.Projects;

internal readonly record struct AssemblyFileReference(string Name, string HintPath, bool isprivate);

internal readonly record struct AssemblyProjectReference(string Name, SpecSharpProject Project, bool isprivate);

internal readonly record struct AssemblyGACReference(string Name, bool isprivate);

public abstract class SpecSharpProject : Runtime
{
    #region Constructors
    public SpecSharpProject(string filePath, string buildConfig, SpecSharpProject? parent = null) :base() 
    {
        ProjectFile = new FileInfo(FailIfFileNotFound(filePath));
        Parent = parent;
        Debug("Project directory is {0}.", ProjectFile.DirectoryName!);
        RequestedBuildConfig = buildConfig;
        TargetPlatform = "v4";
    }
    #endregion

    #region Properties
    public FileInfo ProjectFile { get; init; }

    protected SpecSharpProject? Parent { get; init; }

    public string RequestedBuildConfig { get; init; }

    public string AssemblyName { get; protected set; } = string.Empty;

    public string DefineConstants { get; protected set; } = string.Empty;

    public string OutputType { get; protected set; } = string.Empty;

    public bool DebugEnabled 
    {
        get => RequestedBuildConfig.StartsWith("Debug") || RequestedBuildConfig.EndsWith("Debug"); 
    } 

    public string RootNamespace { get; protected set; } = string.Empty;

    public List<string> SourceFiles { get; init; } = new();

    public string TargetPath { get; protected set; } = string.Empty;

    public string? TargetDir { get; protected set; }

    public string? TargetExt { get; init; }

    public string StartupObject { get; protected set; } = string.Empty;

    public string StandardLibraryLocation { get; protected set; } = string.Empty;

    public string TargetPlatform { get; protected set; } = string.Empty;

    public string TargetPlatformLocation { get; protected set; } = string.Empty;

    public string ShadowedAssembly { get; protected set; } = string.Empty;

    public bool AllowUnsafe { get; protected set; } = false;

    public List<string> References { get; protected set; } = new();

    internal List<AssemblyFileReference> FileReferences { get; } = new();

    internal List<AssemblyProjectReference> ProjectReferences { get; } = new();

    internal List<AssemblyGACReference> GACReferences { get; } = new();

    public bool NoStdLib { get; protected set; } = false;

    public string? BuildConfiguration { get; init; }

    public string CommandLine
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("/platform:v4 ");
            if (!string.IsNullOrEmpty(TargetPath))
            {
                sb.AppendFormat("/out:{0} ", TargetPath);
            }
            if (!string.IsNullOrEmpty(OutputType))
            {
                sb.AppendFormat("/target:{0} ", OutputType);
            }
            if (!string.IsNullOrEmpty(DefineConstants))
            {
                sb.AppendFormat("/define:{0} ", DefineConstants);
            }
            if (DebugEnabled)
            {
                sb.Append("/debug+ /debug:pdbonly ");
            }
            if (NoStdLib)
            {
                sb.Append("/nostdlib+ ");
            }
            if (!string.IsNullOrEmpty(ShadowedAssembly))
            {
                sb.AppendFormat("/shadow:{0} ", Path.Combine(ProjectFile.DirectoryName!, ShadowedAssembly));
            }
            if (AllowUnsafe)
            {
                sb.Append("/unsafe+ ");
            }
            sb.AppendFormat("/r:{0} ", References.JoinWith(";"));
            sb.Append(SourceFiles.JoinWithSpaces());
            return sb.ToString().TrimEnd();
        }
    }

    public IEnumerable<string> PublicReferences
    {
        get => References.Where(r => 
            !FileReferences.Any(fr => fr.HintPath == r && fr.isprivate) && 
            !ProjectReferences.Any(pr => pr.Project.TargetPath == r && pr.isprivate) &&
            !GACReferences.Any(gr => gr.Name == r && gr.isprivate)
        );
    }
    #endregion

    #region Methods
    public bool Compile()
    {
        FailIfNotInitialized();
        using (var op = Parent is null ?  
            Begin("Compiling Spec# project using configuration {0}", BuildConfiguration!) : Begin("Compiling Spec# reference for project {0} using configuration {1}", Parent.ProjectFile.Name, BuildConfiguration!))
        {
            var output = RunCmd(Path.Combine(AssemblyLocation, "ssc", "ssc.exe"), CommandLine, Path.Combine(AssemblyLocation, "ssc"),
                (sender, e) => 
                {
                    if (e.Data is not null && e.Data.Contains("error CS") && !e.Data.Trim().StartsWith("error"))
                    {
                        var errs = e.Data.Split(": error");
                        var errmsg = errs[1].Split(":");
                        Error("File: " + errs[0] + Environment.NewLine + "               Code:{0}" + Environment.NewLine + 
                            "               Msg: {1}", errmsg[0], errmsg[1]); 
                    }
                    else if (e.Data is not null && e.Data.Contains("error CS") && e.Data.Trim().StartsWith("error"))
                    {
                        var err = e.Data.Split("error ").Last().Split(":");
                        Error("Code:{0}" + Environment.NewLine + "               Msg:{1}", err[0], err.Skip(1).JoinWith(""));
                    }
                    else if (e.Data is not null && e.Data.Contains("error CS") && e.Data.Trim().StartsWith("fatal error"))
                    {
                        var err = e.Data.Split("fatal error ").Last().Split(":");
                        Error("Code:{0}" + Environment.NewLine + "               Msg:{1}", err[0], err.Skip(1).JoinWith(""));
                        //Error("goo");
                    }
                    else if (e.Data is not null && e.Data.Contains("error"))
                    {
                        var errs = e.Data.Split("error:");
                        Error(errs.Last());
                    }
                });
            if (output is null || output.Contains("error"))
            {
                Error("Compile failed.");
                op.Cancel(); 
                return false;
            }
            else
            {
                foreach (var r in PublicReferences)
                {
                    var cr = Path.Combine(Path.GetDirectoryName(TargetPath)!, Path.GetFileName(r));
                    if (File.Exists(r) && (!File.Exists(cr) || (File.GetLastWriteTime(r) > File.GetLastWriteTime(cr))))
                    {
                        if (File.Exists(cr)) File.Delete(cr);
                        File.Copy(r, cr);
                        var pr = Path.ChangeExtension(r, ".pdb");
                        if (File.Exists(pr))
                        {
                            var pcr = Path.Combine(Path.GetDirectoryName(TargetPath)!, Path.GetFileName(pr));
                            if (File.Exists(pcr)) File.Delete(pcr);
                            File.Copy(pr, pcr);
                        }
                        Info("Copied reference {0}.", Path.GetFileName(r));
                    }
                    else if (File.Exists(r))
                    {
                        Debug("Not copying reference {0} as it already exists.", r);
                    }
                }
                op.Complete();
                Info("Compile succeded. Assembly is at {0}.", TargetPath);
                return true;
            }
        }
    }

    public static SpecSharpProject? GetProject(string filePath, string buildConfig)
    {  
        var f = new FileInfo(FailIfFileNotFound(filePath));
        switch(f.Extension)
        {
            case ".csproj":
                return new MSBuildSpecSharpProject(f.FullName, buildConfig);
            case ".sscproj":
                return new XmlSpecSharpProject(f.FullName, buildConfig);
            default:
                Error("The file {0} has an unrecognized extension. Valid extensions for Spec# projects are {1} and {2}.", f.FullName, ".csproj", ".sscproj");
                return null;
        }
    }
    #endregion
}