using Picture.AXmlToSvg;
using ReadContent;

namespace ConvertPak
{
    public class AsyncConvert
    {
        static readonly string tempPath = Path.Combine(Path.GetTempPath(), "axml2svg");

        public static async Task Convert(string inputFilePath, string outputFilePath)
        {
            await StartConvert.StartAsync(inputFilePath, outputFilePath);
        }

        public static async Task<string> View(string inputFilePath, string outputFilePath)
        {
            string fileName = Path.GetFileName(outputFilePath);
            string filePath = Path.Combine(tempPath, fileName);

            await StartConvert.StartAsync(inputFilePath, filePath);

            string output = await Read.ReadContentAsync(filePath);

            return output;
        }
    }
}
