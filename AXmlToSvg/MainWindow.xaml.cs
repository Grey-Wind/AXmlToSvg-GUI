using AXmlToSvg.Pages;
using System.Windows;

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