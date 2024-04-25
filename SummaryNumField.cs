using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttle
{
    class SummaryNumField
    {
        public string FieldName { get; private set; } = "";
        public int MinimalValue { get; private set; } = int.MinValue;
        public int MaximumValue { get; private set; } = int.MaxValue;
        public double AverageValue { get; private set; } = 0;
        public double MedianValue { get; private set; } = 0;
        public int BestLaunchDay { get; private set; } = 0;
        private List<int> values;
        public List<int> Values => values;
        public SummaryNumField(List<int> values, string name, int lowerBound, int upperBound)
        {
            this.values = values;
            this.FieldName = name;
            CalculateBestLaunchDay(lowerBound, upperBound);
        }
        private void CalculateBestLaunchDay(int lowerBound, int upperBound)
        {
            if (FieldName == "Wind" || FieldName == "Humidity")
            {
                int currentLowest = int.MaxValue;
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i] > lowerBound && values[i] < upperBound && values[i] < currentLowest)
                    {
                        currentLowest = values[i];
                        BestLaunchDay = i + 1;
                    }
                }
            }

            if (FieldName == "Temperature" || FieldName == "Precipitation")
            {
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i] >= lowerBound && values[i] <= upperBound)
                    {
                        BestLaunchDay = i + 1;
                        break;
                    }
                }
            }
        }
    }
}
