
using System.IO;
using System.Text;

namespace Alternative_Language
{
    class Cell
    {
        private string oem;
        private string model;
        private int launchAnnounced;
        private string launchStatus;
        private string bodyDimensions;
        private float bodyWeight;
        private string bodySim;
        private string displayType;
        private float displaySize;
        private string displayResolution;
        private string featuresSensors;
        private string platformOS;

        public Cell(CleanData cleanData) 
        {
            string[] stringData = cleanData.getStringData();
            float[] floatData = cleanData.getFloatData();
            this.oem = stringData[0];
            this.model = stringData[1];
            this.launchAnnounced = cleanData.getIntData();
            this.launchStatus = stringData[2];
            this.bodyDimensions = stringData[3];
            this.bodyWeight = floatData[0];
            this.bodySim = stringData[4];
            this.displayType = stringData[5];
            this.displaySize = floatData[1];
            this.displayResolution = stringData[6];
            this.featuresSensors = stringData[7];
            this.platformOS = stringData[8];
        }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Name: " + this.oem + " " + this.model + "\n");
            outputString.Append("Announcment Date: " + this.launchAnnounced + "\n");
            outputString.Append("Launch Status " + this.launchStatus + "\n");
            outputString.Append("Dimensions " + this.bodyDimensions + "\n");
            outputString.Append("Weight " + this.bodyWeight + "\n");
            outputString.Append("Sim Card: " + this.bodySim + "\n");
            outputString.Append("Display Type: " + this.displayType + "\n");
            outputString.Append("Display Size: " + this.displaySize + "\n");
            outputString.Append("Display Resolution: " + this.displayResolution + "\n");
            outputString.Append("Sensor Features: " + this.featuresSensors + "\n");
            outputString.Append("Operating System: " + this.platformOS);
            return outputString.ToString();
        }

    }
}