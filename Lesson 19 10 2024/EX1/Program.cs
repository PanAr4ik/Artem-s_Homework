using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ListFilesAndDirs(directory: @"E:\Projekts\С#\AsiCodeL_Shcool", fileExtension: ".txt", showFiles: true, showDirs: false, modifiedWithinDays: 30);
    }

    static void ListFilesAndDirs(string directory, string fileExtension = null, bool showFiles = true, bool showDirs = true, int? modifiedWithinDays = null)
    {
        DateTime now = DateTime.Now;
        DateTime? timeThreshold = null;

        if (modifiedWithinDays.HasValue)
        {
            timeThreshold = now.AddDays(-modifiedWithinDays.Value);
        }

        if (!Directory.Exists(directory))
        {
            Console.WriteLine($"Directory '{directory}' does not exist.");
            return;
        }

        foreach (var dir in Directory.GetDirectories(directory, "*", SearchOption.AllDirectories))
        {
            if (showDirs)
            {
                Console.WriteLine($"Directory: {dir}");
            }

            if (showFiles)
            {
                var files = Directory.GetFiles(dir)
                    .Where(f => string.IsNullOrEmpty(fileExtension) || f.EndsWith(fileExtension, StringComparison.OrdinalIgnoreCase));

                foreach (var file in files)
                {
                    DateTime lastModified = File.GetLastWriteTime(file);
                    if (timeThreshold.HasValue && lastModified < timeThreshold.Value)
                    {
                        continue; 
                    }

                    Console.WriteLine($"File: {file}");
                }
            }
        }
    }

    
}
