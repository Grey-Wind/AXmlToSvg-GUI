using AXmlToSvg.Pages;
using System.Windows;
using AXmlToSvg.Fonts;

namespace AXmlToSvg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 初始化字体
            Mw.FontFamily = LoadFont.LXGWWenKai();

            // 初始化窗口
            PageFrame.Content = LoadSingleFilePage();
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
    }
}