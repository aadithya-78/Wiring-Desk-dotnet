using System;
using System.Collections.Generic;
using System.IO;

namespace Wiring_Desk
{
    public static class ConfigReader
    {
        public static List<List<string>> ConfigCSV { get; private set; } = new List<List<string>>();
        public static void LoadConfig(string filePath = "./config/config.csv")
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("CSV file not found: " + filePath);

            ConfigCSV.Clear();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                ConfigCSV.Add(new List<string>(values));
            }
        }
        public static string Get(int row, int col)
        {
            if (row < 0 || row >= ConfigCSV.Count)
                throw new IndexOutOfRangeException("Row index out of range");
            if (col < 0 || col >= ConfigCSV[row].Count)
                throw new IndexOutOfRangeException("Column index out of range");
            return ConfigCSV[row][col];
        }
    }
}
