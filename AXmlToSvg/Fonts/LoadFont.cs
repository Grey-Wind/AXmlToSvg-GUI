using System.Windows.Media;

namespace AXmlToSvg.Fonts
{
    internal class LoadFont
    {
        /// <summary>
        /// 字体加载
        /// </summary>
        /// <returns>字体</returns>
        public static FontFamily LXGWWenKai()
        {
            string LXGWWenKai = "pack://application:,,,/AXmlToSvg;component/Fonts/LXGWWenKai-Regular.ttf";

            FontFamily customFont = new(new Uri(LXGWWenKai), "./#LXGWWenKai-Regular.ttf");

            return customFont;
        }

        public static FontFamily YouSheTitleBlack()
        {
            string YouSheTitleBlack = "pack://application:,,,/AXmlToSvg;component/Fonts/YouSheTitleBlack.ttf";

            FontFamily customFont = new(new Uri(YouSheTitleBlack), "./#YouSheTitleBlack.ttf");

            return customFont;
        }
    }
}
