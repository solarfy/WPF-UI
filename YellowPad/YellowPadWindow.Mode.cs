using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Yellow_Pad_Framework
{
    partial class YellowPadWindow : Window
    {
        private void StylusModeOnOpened(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;

            foreach (MenuItem child in item.Items)
                child.IsChecked = this.inkcanv.EditingMode == (InkCanvasEditingMode)child.Tag;
        }

        private void StylusModeOnClick(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            this.inkcanv.EditingMode = (InkCanvasEditingMode)item.Tag;
        }

        private void EraseModeOnOpened(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;

            foreach (MenuItem child in item.Items)
                child.IsChecked = this.inkcanv.EditingModeInverted == (InkCanvasEditingMode)child.Tag;
        }

        private void EraserModeOnClick(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            this.inkcanv.EditingModeInverted = (InkCanvasEditingMode)item.Tag;
        }
    }
}
