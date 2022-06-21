using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Yellow_Pad_Framework
{
    partial class YellowPadWindow : Window
    {
        private void AboutOnClick(object sender, RoutedEventArgs e)
        {
            YellowPadHelp win = new YellowPadHelp();
            win.Owner = this;
            win.Show();
        }

        private void HelpOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            YellowPadAboutDialog dlg = new YellowPadAboutDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
        }
    }
}
