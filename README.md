# Welcome to DotNetBrowser QuickStart

This repository contains the examples for the [Quick Start](https://teamdev.com/dotnetbrowser/docs/quickstart/) guide.

## Prerequisites
Make sure your environment meets the
[software and hardware requirements](https://teamdev.com/dotnetbrowser/docs/guides/requirements.html). Additionally, .NET 6 SDK or higher must be installed.

Request a free 30-day evaluation license key via the [web form](https://teamdev.com/dotnetbrowser#evaluate).

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
 - `--ui` Optional. Can be either `console`, `wpf`, `winforms` or `avalonia`. The default value is `console`.

## Development container

This repository contains the development container (devcontainer) configuration that can be used to easily create a Linux-based development environment and work with DotNetBrowser there.

You can use [GitHub Codespaces](https://github.com/codespaces/new?hide_repo_select=true&ref=main&repo=489381301) or any of the [supported tools](https://containers.dev/supporting) to create a devcontainer and work with it. After the container is ready and the post-create command is executed, you can build and run the console example:

```
dotnet tool restore
dotnet cake --lang="csharp" --ui="console" --license-key="your_license_key"
```

*Note*: Development container is a headless Linux environment, and these environments do not support WPF or Windows Forms. Therefore, only the console example can be used.

## Contact us
Feel free to [submit request](https://dotnetbrowser.support.teamdev.com/support/tickets/new) to our support team if you own a commercial license with an active support subscription.
If you have any questions regarding using DotNetBrowser or the examples in this repository, [contact us via email](mailto:customer-care@teamdev.com?subject=[GitHub]%20Question%20on%20DotNetBrowser%20Quick%20Start).

---

The information in this repository is provided on the following terms: https://www.teamdev.com/terms-and-privacy
