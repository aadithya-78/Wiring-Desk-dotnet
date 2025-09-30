using System;
using System.Collections.Generic;
using System.IO;

public static class ProcessReader
{
    public static List<List<string>> Process_CSV { get; private set; } = new List<List<string>>();

    public static void LoadProcess(string fileNameWithoutExtension)
    {
        Process_CSV.Clear();

        try
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "process");
            string fullPath = Path.Combine(folderPath, fileNameWithoutExtension + ".csv");

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"CSV file not found: {fullPath}");
            }

            string[] lines = File.ReadAllLines(fullPath);

            foreach (var line in lines)
            {
                // Split CSV line by comma and store as list
                var values = new List<string>(line.Split(','));
                Process_CSV.Add(values);
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Error loading CSV: " + ex.Message);
        }
    }
}
