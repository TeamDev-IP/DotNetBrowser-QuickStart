# Welcome to DotNetBrowser QuickStart

This repository contains the examples for the [Quick Start](https://dotnetbrowser-support.teamdev.com/docs/quickstart/) guide.

## Prerequisites
Make sure your environment meets the
[software and hardware requirements](https://dotnetbrowser-support.teamdev.com/docs/guides/requirements.html). Additionally, .NET Core SDK 3.1 or higher must be installed.

Request a free 30-day evaluation license key via the [web form](https://www.teamdev.com/dotnetbrowser#evaluate).

Clone this repository using the following command:
 ```bash
 git clone https://github.com/TeamDev-IP/DotNetBrowser-QuickStart
 ```

## Build and run

Open the command line and run the following commands:
```
dotnet tool restore
dotnet cake --lang="csharp" --ui="wpf" --license-key="your_license_key"
```

### Arguments

 - `--license-key` Required. The license key used for launching the application.
 - `--lang` Optional. Can be either `csharp` or `vbnet`. The default value is `csharp`.
 - `--ui` Optional. Can be either `console`, `wpf`, or `winforms`. The default value is `console`.
