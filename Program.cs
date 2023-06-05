using Microsoft.VisualBasic.FileIO;
namespace Alternative_Language 
{
    class Program {
        public static void Main(String[] args)
        {
            List<string[]> listOfLines = readInData("cells.csv");
            CollectionOfCells cells = new CollectionOfCells(listOfLines);
            List<string> oems = cells.getListOfOems();
            Console.WriteLine(cells.mostCommonLaunchDate());
        }

        static List<String[]> readInData(string file) {
            using (TextFieldParser parser = new TextFieldParser("cells.csv"))
            {
                parser.SetDelimiters(new string[] { "," });
                parser.HasFieldsEnclosedInQuotes = true;
                List<string[]> dataLines = new List<string[]>();
                while (!parser.EndOfData)
                {
                    dataLines.Add(parser.ReadFields());
                }
                return dataLines;
            }
        }

        static string findLargestWeight(CollectionOfCells cells)
        {
            List<string> oems = cells.getListOfOems();
            float maxWeight = -1;
            string maxOem = "";
            foreach (string oem in oems)
            {
                CollectionOfCells phones = new CollectionOfCells(cells.getAllPhonesFromOem(oem));
                float currWeight = phones.AverageWeight();
                if (currWeight > maxWeight)
                {
                    maxWeight = currWeight;
                    maxOem = oem;
                }
            }
            return maxOem;
        }

        static void printOneSensor(CollectionOfCells cells)
        {
            int count = 0;
            foreach (string phone in cells.CellPhones.Keys)
            {
                Cell phoneObject = cells.CellPhones[phone];
                if (!phoneObject.FeaturesSensors.Contains(','))
                {
                    Console.Write(phone);
                    count++;
                }        
            }
        }
    }
}
