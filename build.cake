var target = Argument("target", "Run");
var lang = Argument("lang", "csharp");
var ui = Argument("ui", "wpf");
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
    if (ui != "wpf" && ui != "winforms")
    {
        throw new Exception("The --ui argument should be set to either \"wpf\" or \"winforms\".");
    }
    if (string.IsNullOrWhiteSpace(licenseKey))
    {
        throw new Exception("The license key is not specified.");
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
    DotNetBuild($"./{lang}/DotNetBrowser.QuickStart.sln", new DotNetBuildSettings
    {
        Configuration = "Release",
    });
});

Task("Run")
    .IsDependentOn("Build")
    .Does(() =>
{
    var path = new FilePath($"./{lang}/embedding.{ui}/bin/Release/netcoreapp3.1/embedding.{ui}.exe").MakeAbsolute(Context.Environment);

    var settings = new ProcessSettings {
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        WorkingDirectory = path.GetDirectory()
    };
    settings.EnvironmentVariables= new Dictionary<string, string>(){{"DOTNETBROWSER_LICENSE", licenseKey}};
    Information($"Launching {path}");
    StartProcess(path, settings);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);