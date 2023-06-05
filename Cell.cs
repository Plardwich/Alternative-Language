
using System.IO;
using System.Text;

namespace Alternative_Language
{
    class Cell
    {
        private string oem;
        public string Oem
        {
            get {return oem;}
            set {oem = value;}
        }
        private string model;
        public string Model
        {
            get {return model;}
            set {model = value;}
        }
        private int launchAnnounced;
        public int LaunchAnnounced
        {
            get {return launchAnnounced;}
            set {launchAnnounced = value;}
        }
        private string launchStatus;
        public string LaunchStatus
        {
            get {return launchStatus;}
            set {launchStatus = value;}
        }
        private string bodyDimensions;
        public string BodyDimensions
        {
            get {return bodyDimensions;}
            set {bodyDimensions = value;}
        }
        private float bodyWeight;
        public float BodyWeight
        {
            get {return bodyWeight;}
            set {bodyWeight = value;}
        }
        private string bodySim;
        public string BodySim
        {
            get {return bodySim;}
            set {bodySim = value;}
        }
        private string displayType;
        public string DisplayType
        {
            get {return displayType;}
            set {displayType = value;}
        }
        private float displaySize;
        public float DisplaySize
        {
            get {return displaySize;}
            set {displaySize = value;}
        }
        private string displayResolution;
        public string DisplayResolution
        {
            get {return displayResolution;}
            set {displayResolution = value;}
        }
        private string featuresSensors;
        public string FeaturesSensors
        {
            get {return featuresSensors;}
            set {featuresSensors = value;}
        }
        private string platformOS;
        public string PlatformOS
        {
            get {return platformOS;}
            set {platformOS = value;}
        }

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

        public Cell(string oem, string model, int launchAnnounced, string launchStatus, string bodyDim, 
                    float bodyW, string bodyS, string displayType, float displayS, string displayR, 
                    string features, string os)
        {
            this.oem = oem;
            this.model = model;
            this.launchAnnounced = launchAnnounced;
            this.launchStatus = launchStatus;
            this.bodyDimensions = bodyDim;
            this.bodyWeight = bodyW;
            this.bodySim = bodyS;
            this.displayType = displayType;
            this.displaySize = displayS;
            this.displayResolution = displayR;
            this.featuresSensors = features;
            this.platformOS = os;
        }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Name: " + this.oem + " " + this.model + "\n");
            outputString.Append("Announcment Date: " + this.launchAnnounced + "\n");
            outputString.Append("Launch Status: " + this.launchStatus + "\n");
            outputString.Append("Dimensions: " + this.bodyDimensions + "\n");
            outputString.Append("Weight: " + this.bodyWeight + "\n");
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