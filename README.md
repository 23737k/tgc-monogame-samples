# TGC - MonoGame - Samples

[![.NET](https://github.com/tgc-utn/tgc-monogame-samples/actions/workflows/dotnet.yml/badge.svg)](https://github.com/tgc-utn/tgc-monogame-samples/actions/workflows/dotnet.yml)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/83dc66740f7d4b0893ad9e556a6496d6)](https://www.codacy.com/gh/tgc-utn/tgc-monogame-samples/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=tgc-utn/tgc-monogame-samples&amp;utm_campaign=Badge_Grade)
[![Join our Discord](https://img.shields.io/badge/chat%20on-discord-7289DA?logo=discord&logoColor=white)](https://discord.gg/FKZ4k39zAr)

![tgc-screenshot](https://user-images.githubusercontent.com/7131403/172287114-1bc554f0-3dcd-411f-b5be-a0d994990563.png)

[#BuiltWithMonoGame](http://www.monogame.net) and [.NET Core](https://dotnet.microsoft.com).


# Install on Windows

## Install Terminal and WinGet CLI on Windows 10

* [Windows Terminal](https://aka.ms/terminal).
* [WinGet CLI](https://aka.ms/winget-cli).

## Set up MonoGame

```bash
winget install Microsoft.VCRedist.2013.x64
winget install Microsoft.VCRedist.2015+.x64
winget install Microsoft.DotNet.SDK.6
```

```bash
dotnet new --install MonoGame.Templates.CSharp
dotnet tool install -g dotnet-mgfxc

# Create a basic project to test if MonoGame is working.
dotnet new mgdesktopgl -o MyGame
cd MyGame
dotnet restore
dotnet build
dotnet run
```

## Set up the IDE

You can use Visual Studio Code or Rider. The official documentation only explains it for Visual Studio but it is up to you which one you are more comfortable with.

### Visual Studio Code

```bash
winget install Microsoft.VisualStudioCode
```

Open other terminal ([Issue 222](https://github.com/microsoft/winget-cli/issues/222)) so you can use `code` and type:

```bash
# Visual Studio Code extensions
code --install-extension ms-dotnettools.csharp
code --install-extension timgjones.hlsltools
```

### JetBrains Rider

```bash
winget install JetBrains.Rider
```

### Visual Studio

```bash
winget install Microsoft.VisualStudio.2022.Community
```

## Set up tgc-monogame-samples

```bash
winget install Git.Git
```

Open other terminal ([Issue 222](https://github.com/microsoft/winget-cli/issues/222)) so you can use `git` and type:

```bash
git clone https://github.com/tgc-utn/tgc-monogame-samples.git
cd tgc-monogame-samples
# MonoGame Effects Compiler (MGFXC)
dotnet tool install -g dotnet-mgfxc
dotnet restore
dotnet build
dotnet run --project TGC.MonoGame.Samples
```
