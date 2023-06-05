using System.Text;
using System.Text.RegularExpressions;
namespace Alternative_Language
{
    class CollectionOfCells
    {
        private Dictionary<string, Cell> cellPhones;
        public Dictionary<string, Cell> CellPhones
        {
            get {return cellPhones;}
        }

        public CollectionOfCells(List<string[]> listOfLines)
        {
            DataCleaner cleaner = new DataCleaner();
            this.cellPhones = new Dictionary<string, Cell>();
            foreach (string[] line in listOfLines)
            {
                string name = line[0] + " " + line[1];
                if (!cellPhones.ContainsKey(name)) {
                    cellPhones.Add(line[0] + " " + line[1], new Cell(cleaner.cleanData(line)));
                }
            }
        }

        public CollectionOfCells(List<Cell> listOfCells) {
            this.cellPhones = new Dictionary<string, Cell>();
            foreach (Cell phone in listOfCells)
            {
                this.cellPhones.Add(phone.Oem + " " + phone.Model, phone);
            }
        }

        //Gets a cell phone based on the oem and model. If not found, throws an ArgumentException
        public Cell getCellPhone(String phone) 
        {
            if (!this.cellPhones.ContainsKey(phone))
            {
                throw new ArgumentException();
            }
            return this.cellPhones[phone];
        }

        //Adds a cell phone to the collection
        public void addCellPhone(string oem, string model, int launchAnnounced, string launchStatus, 
                                string bodyDim, float bodyW, string bodyS, string displayType, 
                                float displayS, string displayR, string features, string os)
        {
            Cell newCell = new Cell(oem, model, launchAnnounced, launchStatus, bodyDim, bodyW, 
                                    bodyS, displayType, displayS, displayR, features, os);
            this.cellPhones.Add(oem + " " + model, newCell);
        }

        //Returns a list of all phones from the specified oem
        //Runs in O(n) time where n is the cellPhones dictionary
        public List<Cell> getAllPhonesFromOem(String oem)
        {
            List<Cell> listOfPhones = new List<Cell>();
            foreach (string phone in this.cellPhones.Keys)
            {
                Cell phoneObject = this.cellPhones[phone];
                if (phoneObject.Oem.Equals(oem))
                {
                    listOfPhones.Add(phoneObject);
                }
            }
            return listOfPhones;
        }

        //returns a list of all phone which had different announcment and release dates
        //Runs in O(n) time where n is the cellPhones dictionary
        public List<string> getPhoneAnnouncedAndReleasedDifferently() {
            List<string> phones = new List<string>();
            foreach (string phone in this.cellPhones.Keys)
            {
                Cell phoneObject = this.cellPhones[phone];
                if (phoneObject.LaunchStatus != "" && phoneObject.LaunchAnnounced != -1 && 
                    phoneObject.LaunchAnnounced != int.Parse(phoneObject.LaunchStatus))
                {
                    phones.Add(phone);
                }
            }
            return phones;
        }

        //returns a string representing the most common launch date
        //Runs in O(n + m) time where n is the cellPhones dictionary nad m is the dictionary represeting all launch dates
        public string mostCommonLaunchDate()
        {
            Dictionary<string, int> launchYears = new Dictionary<string, int>();
            Regex rx = new Regex(@"\d{4}");
            foreach (string phone in this.cellPhones.Keys)
            {
                string launchDate = this.cellPhones[phone].LaunchStatus;
                if (rx.IsMatch(launchDate))
                {
                    if (!launchYears.ContainsKey(launchDate))
                    {
                        launchYears.Add(launchDate, 0);
                    }
                    launchYears[launchDate] = launchYears[launchDate] + 1;
                }
            }
            int max = -1;
            string maxLaunchDate = "";
            foreach (string launchDate in launchYears.Keys)
            {
                if (launchYears[launchDate] > max)
                {
                    max = launchYears[launchDate];
                    maxLaunchDate = launchDate;
                }
            }
            return maxLaunchDate;
        }

        //Returns the average weight of the phones in the collection
        //Runs in O(n) time where n is the cellPhones dictionary
        public float AverageWeight()
        {
            float totalWeight = 0;
            int weightCount = 0;
            foreach (string cellPhone in this.cellPhones.Keys)
            {
                float weight = this.cellPhones[cellPhone].BodyWeight;
                if (weight != -1)
                {
                    totalWeight += weight;
                    weightCount++;
                }
            }
            return totalWeight / weightCount;
        }

        //Returns the average display size of the phones in the collection
        //Runs in O(n) time where n is the cellPhones dictionary
        public float AverageDisplaySize()
        {
            float totalSize = 0;
            int sizeCount = 0;
            foreach (string cellPhone in this.cellPhones.Keys)
            {
                float size = this.cellPhones[cellPhone].DisplaySize;
                if (size != -1)
                {
                    totalSize += size;
                    sizeCount++;
                }
            }
            return totalSize / sizeCount;
        }

        //returns a list of all oems in collection
        //Runs in O(n) time where n is the cellPhones dictionary
        public List<string> getListOfOems()
        {
            List<string> oems = new List<string>();
            foreach (string phone in this.cellPhones.Keys)
            {
                string oem = this.cellPhones[phone].Oem;
                if (!oems.Contains(oem))
                {
                    oems.Add(oem);
                }
            }
            return oems;
        }

        //returns a string representing all of the names of the phones in the collection
        //Runs in O(n) time where n is the cellPhones dictionary
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            foreach (string cellPhone in this.cellPhones.Keys)
            {
                outputString.Append(cellPhone + "\n");
            }
            return outputString.ToString();
        }
    }
}