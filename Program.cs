

using SpaceLaunch;

namespace SpaceShuttle
{ 
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Welcome to the Space Shuttle Programme!");
            Console.WriteLine("Made by Viktor Yordanov");
            Console.WriteLine("Please input the full path of a .csv file that contains the weather report for the monty of July:");
            string inputPath = Console.ReadLine();

            if(!File.Exists(inputPath) || Path.GetExtension(inputPath) != ".csv")
            {
                Console.WriteLine("This is not a valid path!");
                return;
            }

            Console.WriteLine();

            ReadCsvFile read = new ReadCsvFile(inputPath);
            if(!read.ValidateFieldNames())
            {
                Console.WriteLine("Invalid fields are added in .csv file!");
                return;
            }

            string outputPath = Path.GetDirectoryName(inputPath) + "\\test1.csv";
            WriteCsvFile write = new WriteCsvFile(read.GetRawDataRows, outputPath);

        }
    }
}

