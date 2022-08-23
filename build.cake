var target = Argument("target", "Run");
var lang = Argument("lang", "csharp");
var ui = Argument("ui", "console");
var licenseKey = Argument("license-key", "");

//////////////////////////////////////////////////////////////////////
// SETUP
//////////////////////////////////////////////////////////////////////

Setup(setupContext =>
{
    if (lang != "csharp" && lang != "vbnet")
    {
        throw new Exception("The --lang argument should be set to either \"csharp\" or \"vbnet\".");
    }
    if (ui != "wpf" && ui != "winforms" && ui != "console")
    {
        throw new Exception("The --ui argument should be set to either \"console\", \"wpf\", or \"winforms\".");
    }
    if (string.IsNullOrWhiteSpace(licenseKey))
    {
        throw new Exception("The license key is not specified.");
    }
    if(!IsRunningOnWindows() && ui != "console")
    {
        throw new Exception("WPF and Windows Forms are not supported on non-Windows environments.");
    }

});

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetRestore(new DotNetRestoreSettings(){
        DisableParallel = true, 
        IgnoreFailedSources = true,
        WorkingDirectory = $"./{lang}"
    });
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
        DotNetBuild($"./{lang}/DotNetBrowser.QuickStart.sln", new DotNetBuildSettings
        {
            Configuration = "Release",
        });
    }
    else
    {
        Information("Skipping solution build in non-Windows environment");
    }
});

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
{
    var project = ui == "console" ? "example.console" : $"embedding.{ui}" ;
    var path = $"./{lang}/{project}";
    var settings = new DotNetRunSettings
    {
        Configuration = "Release"
    };
    settings.EnvironmentVariables= new Dictionary<string, string>(){{"DOTNETBROWSER_LICENSE", licenseKey}};
    Information($"Launching {path}");
    
    DotNetRun(path, settings);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);