using System.Collections;
using System.Text.RegularExpressions;

namespace Alternative_Language 
{
    class DataCleaner
    {
        public DataCleaner(){}
        public CleanData cleanData(String[] data)
        {
            if (data.Length < 12)
            {
                string[] newData = new string[12];
                Array.Copy(data, newData, 12);
                data = newData;
            }
            string[] stringData = new string[9];
            float[] floatData = new float[2];
            int launchInteger = -1;
            int stringIndex = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 2)
                {
                    launchInteger = convertToYear(data[i]);
                } 
                else if (i == 5) 
                {
                    floatData[0] = convertToWeight(data[i]);
                } 
                else if (i == 8)
                {
                    floatData[1] = convertToSize(data[i]);
                } else
                {
                    stringData[stringIndex] = data[i];
                    stringIndex++;
                }
            }
            return new CleanData(stringData, floatData, launchInteger);
        }

        public int convertToYear(String text)
        {
            Regex rx = new Regex(@"\d{4}");
            if (rx.IsMatch(text))
            {
                return int.Parse(rx.Match(text).ToString()); 
            } else {
                return -1;
            }
        }

        public float convertToWeight(String text)
        {
            Regex rx = new Regex(@"\d+\s*[g]{1}");
            Regex rx2 = new Regex(@"\d+");
            if (rx.IsMatch(text))
            {
                string matchedString = rx.Match(text).ToString();
                return float.Parse(rx2.Match(matchedString).ToString());
            } else {
                return -1;
            }
        }
        public float convertToSize(String text)
        {
            Regex rx = new Regex(@"\d+\.?\d*\s*(inches)");
            Regex rx2 = new Regex(@"\d+\.?\d*");
            if (rx.IsMatch(text))
            {
                string matchedString = rx.Match(text).ToString();
                return float.Parse(rx2.Match(matchedString).ToString()); 
            } else {
                return -1;
            }
        }
    }
    
}