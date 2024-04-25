

using SpaceLaunch;

namespace SpaceShuttle
{ 
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Welcome to the Space Shuttle Programme!");
            Console.WriteLine("Made by Viktor Yordanov");
            Console.WriteLine("Please input the full path of a .csv file that contains the weather report for the month of July:");
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

            string outputPath = Path.GetDirectoryName(inputPath) + "Locations/Tanegashima.csv";
            WriteCsvFile write = new WriteCsvFile(read.GetRawDataRows, outputPath);

            Console.WriteLine("Please provide email address and password of the sender:");
            Console.Write("Email:");
            string senderAddress = Console.ReadLine();
            Console.Write("Password:");
            string senderPassword = Console.ReadLine();
            Console.WriteLine("Please provide the email of the receiver:");
            string receiverAddress = Console.ReadLine();
    
            EmailSender emailSender = new EmailSender(senderAddress, senderPassword, receiverAddress, outputPath);
            try
            {
                emailSender.Send();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}

