using Picture.AXmlToSvg;
using ReadContent;

namespace ConvertPak.SingleFile
{
    public class SyncConvert
    {
        static readonly string tempPath = Path.Combine(Path.GetTempPath(), "axml2svg");

        public static void Convert(string inputFilePath, string outputFilePath)
        {
            StartConvert.Start(inputFilePath, outputFilePath);
        }

        public static string View(string inputFilePath, string outputFilePath)
        {
            string fileName = Path.GetFileName(outputFilePath);

            string filePath = Path.Combine(tempPath, fileName);

            StartConvert.Start(inputFilePath, filePath);

            return Read.ReadContent(filePath);
        }
    }
}
