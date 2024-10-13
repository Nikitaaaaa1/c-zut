// namespace DefaultNamespace;

namespace Reader
{
    using System;
    public class CsvFileReadAndParseIntoStringArray
    {
        private string filename = "";
        public CsvFileReadAndParseIntoStringArray(string name)
        {
            filename = name;
        }

        public bool CheckFileInDir()
        {
            return File.Exists(filename);
        }

        public string[] ReadCsvFile()
        {
            string[] lines = {};

            try
            {
                lines = File.ReadAllLines(filename);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            int lineIndex = 1;
            foreach (var line in lines)
            {
                Console.WriteLine("{0} line: {1}", lineIndex, line);
                lineIndex++;
            }

            return lines;
        }
        public void ReadCsvFileUsingStream(Func<string, bool, int> callback)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                bool isFirst = true;
                while ((line = sr.ReadLine()) != null)
                {
                    callback(line, isFirst);
                    isFirst = false;
                }
            }
        }
    }


}

