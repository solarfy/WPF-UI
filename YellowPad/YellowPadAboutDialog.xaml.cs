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
using System.Windows.Shapes;
using System.IO;
using System.Windows.Markup;
using System.Diagnostics;

namespace Yellow_Pad_Framework
{
    /// <summary>
    /// YellowPadAboutDialog.xaml 的交互逻辑
    /// </summary>
    public partial class YellowPadAboutDialog : Window
    {
        public YellowPadAboutDialog()
        {
            InitializeComponent();

            Uri uri = new Uri("pack://application:,,,/Images/Signature.xaml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            Drawing drawing = (Drawing)XamlReader.Load(stream);
            stream.Close();
            this.imgSignature.Source = new DrawingImage(drawing);

        }

        private void LinkOnRequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.OriginalString);
            e.Handled = true;
        }
    }
}
