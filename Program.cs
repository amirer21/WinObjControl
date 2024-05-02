using System;
using CommandLine;
using System.Diagnostics;

namespace NotepadLauncher
{
    // 커맨드라인 옵션을 정의하는 클래스
    public class Options
    {
        [Option('f', "file", Required = true, HelpText = "Path to the file to open with Notepad.")]
        public string FilePath { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(opts => StartNotepad(opts.FilePath))
                   .WithNotParsed<Options>((errs) => Console.WriteLine("Invalid options provided."));
        }

        private static void StartNotepad(string filePath)
        {
            try
            {
                Process.Start("notepad.exe", filePath);
                Console.WriteLine($"Notepad launched successfully with file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start Notepad with file: {ex.Message}");
            }
        }
    }
}
