using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yellow_Pad_Framework
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class YellowPadWindow : Window
    {
        public static readonly double WidthCanvas = 5 * 96;
        public static readonly double HeightCanvas = 7 * 96;
            
        public YellowPadWindow()
        {
            InitializeComponent();

            double y = 96;
            while ( y < HeightCanvas)
            {
                Line line = new Line();
                line.X1 = 0;
                line.Y1 = y;
                line.X2 = WidthCanvas;
                line.Y2 = y;
                line.Stroke = Brushes.LightBlue;
                this.inkcanv.Children.Add(line);
                y += 24;
            }

            //如果没有平板电脑，就隐藏擦除模式菜单
            if (Tablet.TabletDevices.Count == 0)
                this.menuEraserMode.Visibility = Visibility.Collapsed;
        }
    }
}
