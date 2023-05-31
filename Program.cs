using Microsoft.VisualBasic.FileIO;
namespace Alternative_Language 
{
    class Program{
        public static void Main(String[] args)
        {
            Dictionary<string, Cell> cellPhones = new Dictionary<string, Cell>();
            DataCleaner cleaner = new DataCleaner();
            List<string[]> listOfLines = readInData("cells.csv");
            foreach (string[] line in listOfLines)
            {
                string name = line[0] + " " + line[1];
                if (!cellPhones.ContainsKey(name)) {
                    cellPhones.Add(line[0] + " " + line[1], new Cell(cleaner.cleanData(line)));
                }
            }
            Console.WriteLine(cellPhones["Google Pixel 4"].ToString());
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
    }
}
