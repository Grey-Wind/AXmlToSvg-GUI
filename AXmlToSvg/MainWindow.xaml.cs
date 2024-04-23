using AXmlToSvg.Pages;
using System.Windows;
using AXmlToSvg.Fonts;
using System.IO;
using System.ComponentModel;
using Ver;

namespace AXmlToSvg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string tempPath = Path.Combine(Path.GetTempPath(), "axml2svg");

        public MainWindow()
        {
            InitializeComponent();

            this.Closing += new CancelEventHandler(ClosingWindow!);

            // 初始化字体
            Mw.FontFamily = LoadFont.LXGWWenKai();

            // 初始化版本
            Mw.Title += GetVersion.GetVer();

            // 初始化窗口
            PageFrame.Content = LoadSingleFilePage();

            // 初始化Temp文件夹
            CreateTempFolder();
        }

        private static void ClosingWindow(object sender, CancelEventArgs e)
        {
            try
            {
                if (Directory.Exists(tempPath))
                {
                    Directory.Delete(tempPath, true);
                    Console.WriteLine("临时文件夹已删除：" + tempPath);
                }
                else
                {
                    Console.WriteLine("临时文件夹不存在：" + tempPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除临时文件夹时出错：" + ex.Message);
            }
        }

        private void SingleFileModeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PageFrame.Content is not SingleFile)
            {
                PageFrame.Content = null;
                PageFrame.Content = LoadSingleFilePage();
            }
        }

        private void MultiFileModeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PageFrame.Content is not MultiFile)
            {
                PageFrame.Content = null;
                PageFrame.Content = LoadMultiFilePage();
            }
        }

        private static SingleFile LoadSingleFilePage()
        {
            SingleFile singleFile = new();
            return singleFile;
        }

        private static MultiFile LoadMultiFilePage()
        {
            MultiFile multiFile = new();
            return multiFile;
        }

        private static void CreateTempFolder()
        {
            try
            {
                // 如果文件夹不存在，则创建
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                    Console.WriteLine("文件夹已创建：" + tempPath);
                }
                else
                {
                    Console.WriteLine("文件夹已存在：" + tempPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建文件夹时出错：" + ex.Message);
            }
        }
    }
}