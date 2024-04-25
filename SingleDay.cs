using System;
using System.Collections.Generic;

namespace SpaceLaunch
{
    class SingleDay
    {
        public int Date { get; private set; } = 1;

        public int Temperature { get; private set; } = 0;

        public int WindSpeed { get; private set; } = 0;

        public int Humidity { get; private set; } = 0;

        public int Precipitation { get; private set; } = 0;

        public bool Lightning { get; private set; } = false;

        public string CloudType { get; private set; } = "";
        public string Station { get; private set; } = "";

        public bool ValidLaunchDate { get; private set; } = false;
        public bool ValidData { get; private set; } = true;

        public SingleDay(List<string> rawData)
        {
            try
            {
                ParseRawData(rawData);
                ValidateLaunchDate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ValidData = false;
            }
        }

        private void ParseRawData(List<string> rawData)
        {
            this.Station = rawData[0];
            this.Date = int.Parse(rawData[1]);
            if (Date < 1 || Date > 31) 
                throw new ArgumentException("An inavlid date was found in the data!");
            this.Temperature = int.Parse(rawData[2]);
            this.WindSpeed = int.Parse(rawData[3]);
            if (WindSpeed < 0)
                throw new ArgumentException("Wind speed less than 0m/s found in the data!");
            this.Humidity = int.Parse(rawData[4]);
            if (Humidity < 0 || Humidity > 100) 
                throw new ArgumentException("Humidity without percentage found in the data!");
            this.Precipitation = int.Parse(rawData[5]);
            if (Precipitation < 0 || Precipitation > 100) 
                throw new ArgumentException("Precipitation without percentage found in the data!");
            if (rawData[5] != "Yes" && rawData[6] != "No") 
                throw new ArgumentException("Lightning field that is not yes/no found in the data!");
            if (rawData[5] == "Yes") this.Lightning = true;
            this.CloudType = rawData[7];
        }
        private void ValidateLaunchDate()
        {
            if (Temperature < 1 || Temperature > 31) return;
            if (WindSpeed > 11 || Humidity >= 55) return;
            if (Precipitation != 0 || Lightning) return;
            if (CloudType == "Cumulus" || CloudType == "Nimbus") return;
            ValidLaunchDate = true;
        }
    }
}