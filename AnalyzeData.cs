using System;
using System.Collections.Generic;

namespace SpaceLaunch
{
    class AnalyzeData
    {
        List<SingleDay> dayEntries;

        public AnalyzeData(List<List<string>> rawData)
        {
            dayEntries = new List<SingleDay>();
            foreach (List<string> item in rawData)
            {
                SingleDay tmpSingleDay = new SingleDay(item);
                if (tmpSingleDay.ValidData) { dayEntries.Add(tmpSingleDay); }
            }
        }

        public int CalculateBestLaunchDay()
        {
            SingleDay currentBestDay = dayEntries[0];
            foreach (SingleDay dayEntry in dayEntries)
            {
                if (CompareDays(currentBestDay, dayEntry))
                {
                    currentBestDay = dayEntry;
                }
            }

            if (currentBestDay.ValidLaunchDate) return currentBestDay.Date;
            return 0;
        }

        private bool CompareDays(SingleDay currentBest, SingleDay currentDay)
        {
            if (currentDay.ValidLaunchDate)
            {
                if (!currentBest.ValidData) 
                    return true;

                if (currentDay.WindSpeed < currentBest.WindSpeed) 
                    return true;
                else if (currentDay.WindSpeed == currentBest.WindSpeed && currentDay.Humidity < currentBest.Humidity) 
                    return true;

                return false;
            }
            return false;
        }
    }
}