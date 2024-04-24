using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShuttle
{
    class SummaryStrFields
    {
        public string FieldName { get; private set; } = "";
        public int BestLaunchDate { get; private set; } = 0;
        private List<string> values;

        public SummaryStrFields(List<string> values, string name)
        {
            this.values = values;
            this.FieldName = name;
            CalculateBestLaunchDate();
        }

        private void CalculateBestLaunchDate()
        {
            switch (FieldName)
            {
                case "Lightning":
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (values[i] == "No") { BestLaunchDate = i + 1; break; }
                        }
                    }
                    break;
                case "Clouds":
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            if (values[i] != "Cumulus" && values[i] != "Nimbus") { BestLaunchDate = i + 1; break; }
                        }
                    }
                    break;
                default: break;
            }
        }
    }
}
