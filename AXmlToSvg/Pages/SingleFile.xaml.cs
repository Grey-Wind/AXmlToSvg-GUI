using AXmlToSvg.Fonts;
using ConvertPak;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace AXmlToSvg
{
    /// <summary>
    /// SingleFile.xaml 的交互逻辑
    /// </summary>
    public partial class SingleFile : Page
    {
        readonly string getInputError = "选择输入文件失败";
        readonly string getOutputError = "无输入文件，生成输出文件失败";

        public SingleFile()
        {
            InitializeComponent();

            // 初始化字体
            SgPg.FontFamily = LoadFont.LXGWWenKai();
        }

        /// <summary>
        /// 选择输入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInputFileBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Xml文件 (*.xml)|*.xml" // 选择器，筛选
            };

            bool? result = openFileDialog.ShowDialog(); // 显示文件选择对话框

            if (result == true)
            {
                string filePath = openFileDialog.FileName; // 获取选定的文件路径
                InputFileTextBox.Text = filePath; // 返回文件路径和文件名的元组
                OutputFileTextBox.Text = GetOutput.GetOutputFilePath(filePath);
            }
            else
            {
                InputFileTextBox.Text = getInputError;
                OutputFileTextBox.Text = getOutputError;
            }
        }
        
        /// <summary>
        /// 清空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            InputFileTextBox.Clear();
            OutputFileTextBox.Clear();
            OutputTextBox.Clear();
        }

        /// <summary>
        /// 导出SVG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UseAsyncCheckBox.IsChecked == true)
            {
                await AsyncConvert.Convert(InputFileTextBox.Text, OutputFileTextBox.Text);
                OutputTextBox.Text = await AsyncConvert.View(InputFileTextBox.Text, OutputFileTextBox.Text);
            }
            else
            {
                SyncConvert.Convert(InputFileTextBox.Text, OutputFileTextBox.Text);
                OutputTextBox.Text = SyncConvert.View(InputFileTextBox.Text, OutputFileTextBox.Text);
            }
        }

        /// <summary>
        /// 查看SVG文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UseAsyncCheckBox.IsChecked == true)
            {
                OutputTextBox.Text = await AsyncConvert.View(InputFileTextBox.Text, OutputFileTextBox.Text);
            }
            else
            {
                OutputTextBox.Text = SyncConvert.View(InputFileTextBox.Text, OutputFileTextBox.Text);
            }
        }
    }
}
