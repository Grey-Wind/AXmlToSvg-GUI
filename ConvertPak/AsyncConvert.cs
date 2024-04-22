using Picture.AXmlToSvg;

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
            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, fileName);

            await StartConvert.StartAsync(inputFilePath, filePath);

            try
            {
                // 异步读取整个文件内容到一个字符串中
                string fileContent = await Task.Run(() => File.ReadAllText(filePath));

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
