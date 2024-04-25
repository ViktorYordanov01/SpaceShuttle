using SpaceShuttle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace SpaceLaunch
{
    class WriteCsvFile
    {
        StreamWriter writer;
        public string FilePath { get; set; } = "";
        public WriteCsvFile(List<List<string>> rawData, string filePath)
        {
            writer = new StreamWriter(filePath);
            FilePath = filePath;
            writer.WriteLine("Parameters,AverageValue,MinValue,MaxValue,MedianValue,BestLaunchDate");
            WriteSummarizedData(rawData);
        }

        private void WriteNumberData(List<string> data, int lowerBound, int upperBound, string name)
        {
            List<string> removeName = data.GetRange(1, data.Count - 1);
            List<int> convertedValues;
            try
            {
                convertedValues = removeName.Select(int.Parse).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Input data was not in the correct format");
                return;
            }
            SummaryNumField numberData = new SummaryNumField(convertedValues, name, lowerBound, upperBound);
            writer.WriteLine(name + "," + numberData.AverageValue + "," + numberData.MinimalValue + "," + numberData.MaximumValue + "," +
                             numberData.MedianValue + "," + numberData.BestLaunchDay);
        }
        private void WriteStringData(List<string> data, string name)
        {
            SummaryStrFields stringData = new SummaryStrFields(data.GetRange(1, data.Count - 1), name);
            writer.WriteLine(name + ",,,,," + stringData.BestLaunchDate);
        }
        private void WriteSummarizedData(List<List<string>> rawData)
        {
            foreach (List<string> l in rawData)
            {
                string name = l[0];
                switch (name)
                {
                    case "Temperature":
                        {
                            WriteNumberData(l, 2, 31, name);
                        }
                        break;
                    case "Wind":
                        {
                            WriteNumberData(l, 0, 11, name);
                        }
                        break;
                    case "Humidity":
                        {
                            WriteNumberData(l, 0, 60, name);
                        }
                        break;
                    case "Precipitation":
                        {
                            WriteNumberData(l, 0, 0, name);
                        }
                        break;
                    case "Lightning":
                        {
                            WriteStringData(l, name);
                        }
                        break;
                    case "Clouds":
                        {
                            WriteStringData(l, name);
                        }
                        break;
                    default:
                        break;
                }
            }

            writer.Close();
        }
    }
}
