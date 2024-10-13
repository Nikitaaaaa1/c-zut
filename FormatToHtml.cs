namespace laba1
{
    public class FormatToHtml
    {

        private string htmlT = "<html><body><div>HTML table</div><table>{0}</table></body></html>";
        private string finRes = "";
        static string regularFormat;

        const string htmlCellFormatRegular = "<td style='padding: 10px; text-align: center; border: 1px solid #ddd;'>{0}</td>";
        const string htmlCellFormatHeader = "<th style='padding: 10px; border: 1px solid #ddd;'>{0}</th>";

        public void initialTable()
        {
            this.finRes += "<table>";
        }
        public void commitTable()
        {
            this.finRes += "</table>";
        }
        public int FormatRegularColumn(string[] inputs)
        {
            string result = "<tr style=\"background-color: #f2f2f2;\">\n"; 
            foreach (var input in inputs)
            {
                result += String.Format(htmlCellFormatRegular, input) + "\n";
            }
            result += "</tr>\n"; 
            this.finRes += result;
            // return result;
            return 1;
        }

        public int FormatHeader(string[] inputs)
        {
            string result = "<tr style=\"background-color: #4CAF50; color: white;\">\n"; 
            foreach (var input in inputs)
            {
                result += String.Format(htmlCellFormatHeader, input) + "\n";
            }
            result += "</tr>\n"; 
            this.finRes += result;
            // return result;
            return 1;
        }

        public string GetHtml() => String.Format(htmlT, this.finRes);
    }
}