using Picture.AXmlToSvg;
using System.Runtime.CompilerServices;

namespace ConvertPak
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

            try
            {
                // 读取整个文件内容到一个字符串中
                string fileContent = File.ReadAllText(filePath);

                // 输出文件内容
                Console.WriteLine(fileContent);

                return fileContent;
            }
            catch (Exception ex)
            {
                // 如果发生异常，输出异常信息
                Console.WriteLine("An error occurred: " + ex.Message);

                return ex.Message;
            }
        }
    }
}
