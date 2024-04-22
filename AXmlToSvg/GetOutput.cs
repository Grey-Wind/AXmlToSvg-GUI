using System.IO;

namespace AXmlToSvg
{
    internal class GetOutput
    {
        /// <summary>
        /// 生成输出文件路径
        /// </summary>
        /// <param name="filePath">输入文件路径</param>
        /// <returns>输出文件路径</returns>
        public static string GetOutputFilePath(string filePath)
        {
            // 获取文件名
            string fileName = Path.GetFileName(filePath);

            // 获取文件所在目录
            string directory = Path.GetDirectoryName(filePath)!;

            // 获取文件的后缀名
            string extension = Path.GetExtension(filePath);

            // 修改后缀名
            string newExtension = ".output.svg";
            string newFilePath = Path.Combine(directory, Path.GetFileNameWithoutExtension(fileName) + newExtension);

            return newFilePath;
        }
    }
}
