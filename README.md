# CommandLineParser(WinObjControl) Guide

This document describes how to install and use the `CommandLineParser` library in C# applications. This library simplifies the parsing of command line arguments, making it easier to manage user inputs in console applications.

## Installation Guide

### Verifying NuGet Package Source

1. Open **Visual Studio** and navigate to **Tools** > **Options**.
2. Go to **NuGet Package Manager** > **Package Sources**.
3. Ensure that **nuget.org** is listed and enabled.
   - If it's missing, add a new source by clicking "Add". Set the name to "nuget.org" and the source URL to `https://api.nuget.org/v3/index.json`.

### Installing via Visual Studio

1. Right-click your project in the Solution Explorer and select **Manage NuGet Packages...**.
2. In the "Browse" tab, search for `"CommandLineParser"`.
3. Find the `CommandLineParser` package in the search results and click "Install".
4. Accept any license agreements that appear during the installation process.

### Installing via Package Manager Console

1. Navigate to **Tools** > **NuGet Package Manager** > **Package Manager Console**.
2. Type the following command and press Enter:



## Code Implementation Description

### Setting up the Parser in Your Project

Include the library in your C# file with:

```csharp
using CommandLine;
```

### public class Options

```csharp
{
    [Option('f', "file", Required = true, HelpText = "Path to the file to open with Notepad.")]
    public string FilePath { get; set; }
}
```

### Parsing Command Line Arguments

Implement parsing in your Main method:

```csharp
static void Main(string[] args)
{
    Parser.Default.ParseArguments<Options>(args)
           .WithParsed<Options>(opts => StartNotepad(opts.FilePath))
           .WithNotParsed<Options>(errs => Console.WriteLine("Invalid options provided."));
}

private static void StartNotepad(string filePath)
{
    Process.Start("notepad.exe", filePath);
    Console.WriteLine($"Notepad launched successfully with file: {filePath}");
}
```

## How to Use CommandLineParser

Build this project. and move the executable file to the desired location.

> WinObjControl.exe --file "C:\Users\Name\Desktop\test.txt"

## Troubleshooting

If CommandLineParser does not appear in search results:

Make sure that your NuGet package sources are correctly configured.
If you encounter errors while running the program:

Ensure that all paths and command line arguments are correctly formatted.
Check for exceptions and handle them appropriately in your application code.