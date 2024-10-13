
using System.Web;
using laba1;
using Reader;

namespace DefaultNamespace;


public class Program
{
    
    
    static void Main(string[] args)
    {
        Console.WriteLine(args.Length);
        
        
        if (args.Length == 0)
        {
            throw new ArgumentNullException("No provided path to csv file");
        }
        string csvPath = args[0];
        CsvFileReadAndParseIntoStringArray reader = new Reader.CsvFileReadAndParseIntoStringArray
        (
            csvPath
        );
          
        if (!reader.CheckFileInDir()) { throw new FileNotFoundException(); }
            
   
         
        string path = @"/Users/macbook/Documents/university/c#/laba1/output.html";
        // var values = reader.ReadCsvFile();

        
        // using (FileWriter fw = new FileWriter(path))
        // {
        //     if (values.Length == 0)
        //     {
        //         throw new ArgumentNullException("CSV file is empty");
        //     }
        //     FormatToHtml format = new FormatToHtml();
        //     foreach (var (value, i) in values.Select((value, i) => (value, i)))
        //     {
        //         string[] splitResult = value.Split(',');
        //         string formattedRow = i == 0 
        //             ? format.FormatHeader(splitResult)
        //             : format.FormatRegularColumn(splitResult);
        //
        //         Console.WriteLine(formattedRow);
        //     }
        //     fw.AddText(format.GetHtml()); 
        // }


        using (FileWriter fw = new FileWriter(path))
        {
            FormatToHtml format = new FormatToHtml();
            reader.ReadCsvFileUsingStream((string line, bool isFirst) => isFirst 
                ? format.FormatHeader(line.Split(',')) 
                : format.FormatRegularColumn(line.Split(',')));
            
            fw.AddText(format.GetHtml());
        }
    }
}