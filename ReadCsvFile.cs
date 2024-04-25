using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceLaunch
{
    class ReadCsvFile
    {
        private string filePath;
        private TextFieldParser parser;
        private List<List<string>> extractedRawDataColumns;
        public List<List<string>> GetRawDataColumns => extractedRawDataColumns;
        private List<List<string>> extractedRawDataRows;
        public List<List<string>> GetRawDataRows => extractedRawDataRows;
        public ReadCsvFile(string filePath)
        {
            this.filePath = filePath; 

            ExtractData(filePath);

        }

        private void ExtractData(string filePath)
        {
            this.parser = new TextFieldParser(filePath);
            this.parser.TextFieldType = FieldType.Delimited;
            this.parser.SetDelimiters(",");
            extractedRawDataColumns = new List<List<string>>();
            extractedRawDataRows = new List<List<string>>();

            string[] days = parser.ReadFields();
            int numberOfColumns = days.Length;
            extractedRawDataRows.Add(days.ToList());

            for (int i = 0; i < numberOfColumns; i++)
            {
                extractedRawDataColumns.Add(new List<string>());
            }
            for (int i = 0; i < numberOfColumns; i++)
            {
                extractedRawDataColumns[i].Add(days[i]);
            }

            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                extractedRawDataRows.Add(row.ToList());
                for (int i = 0; i < numberOfColumns; i++)
                {
                    extractedRawDataColumns[i].Add(row[i]);
                }
            }

            parser.Close();
        }
        public void printData()
        {
            for (int i = 0; i < extractedRawDataRows.Count; i++)
            {
                for (int j = 0; j < extractedRawDataRows[i].Count; j++)
                {
                    Console.Write(extractedRawDataRows[i][j] + ",");
                }
                Console.WriteLine();
            }
        }


        public bool ValidateFieldNames()
        {
            if (extractedRawDataColumns[0].Count != 8) return false;
            if (extractedRawDataColumns[0][0] != "Station") return false;
            if (extractedRawDataColumns[0][1] != "Day") return false;
            if (extractedRawDataColumns[0][2] != "Temperature") return false;
            if (extractedRawDataColumns[0][3] != "Wind") return false;
            if (extractedRawDataColumns[0][4] != "Humidity") return false;
            if (extractedRawDataColumns[0][5] != "Precipitation") return false;
            if (extractedRawDataColumns[0][6] != "Lightning") return false;
            if (extractedRawDataColumns[0][7] != "Clouds") return false;

            return true;
        }

    }
}
