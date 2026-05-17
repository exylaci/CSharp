using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

class setpointsfromlogs
{
    static void Main()
    {
        System.Console.WriteLine("Az idítás könyvtárában találhó minden log fájlokból subad-onként kigyűjti a val érték változásának időpontjait egy új result.txt fájlba..");
        string currentDirectory = Directory.GetCurrentDirectory();
        string outputFile = Path.Combine(currentDirectory, "result.txt");

        // Minden txt fájl a könyvtárban
        string[] files = Directory.GetFiles(currentDirectory, "*-*-*");

        // Saját output fájlt kihagyjuk
        files = Array.FindAll(files,
            f => Path.GetFileName(f).ToLower() != "result.txt");

        Regex regex = new Regex(
            @"^(?<time>\S+).*subad:\s*(?<subad>\d+).*val:\s*(?<val>-?\d+(\.\d+)?)",
            RegexOptions.Compiled);

        using StreamWriter writer = new StreamWriter(outputFile, false);

        foreach (string file in files)
        {
            writer.Write($"Fájl: {Path.GetFileName(file)}");
            Dictionary<int, double> lastValues = new Dictionary<int, double>();
            string? firstTimestamp = null;
            string? lastTimestamp = null;
            int subad=0;
            double value = 0;

            foreach (string line in File.ReadLines(file))
            {
                Match match = regex.Match(line);

                if (!match.Success) continue;
                string timestamp = match.Groups["time"].Value;
                lastTimestamp = timestamp;
                subad = int.Parse(match.Groups["subad"].Value);
                value = double.Parse(match.Groups["val"].Value, CultureInfo.InvariantCulture);

                // Első és utolsó időpont mentése
                if (firstTimestamp == null)
                {
                    firstTimestamp = timestamp;
                    writer.WriteLine($"Első adat időpontja : {firstTimestamp}");
                    writer.WriteLine($"{timestamp} | subad: 0 | kező: {value}");
                }

                // Első előfordulás
                if (!lastValues.ContainsKey(subad))
                {
                    lastValues[subad] = value;
                    continue;
                }
                double oldValue = lastValues[subad];

                // Változás detektálása
                if (oldValue != value)
                {
                    writer.WriteLine($"{timestamp} | subad: {subad} | új:   {value}");
                    lastValues[subad] = value;
                }
            }

            writer.WriteLine($"Utolsó adat időpontja: {lastTimestamp} | subad: {subad} | utolsó: {value}");
            writer.WriteLine();
        }

        Console.WriteLine($"Kész. Eredmény fájl: {outputFile}");
    }
}