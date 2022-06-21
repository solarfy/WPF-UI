using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Yellow_Pad_Framework
{
    /// <summary>
    /// YellowPadHelp.xaml 的交互逻辑
    /// </summary>
    public partial class YellowPadHelp : NavigationWindow
    {
        public YellowPadHelp()
        {
            InitializeComponent();

            (this.tree.Items[0] as TreeViewItem).IsSelected = true;
            this.tree.Focus();
        }

        private void HelpOnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = e.NewValue as TreeViewItem;

            if (item.Tag == null)
                return;

            //Uri uri = new Uri(item.Tag as string, UriKind.Relative);
            Uri uri = new Uri("Help/EraserToolDialog.xaml", UriKind.Relative);  //其他文件与此文件类似
            this.frame.Navigate(uri);
        }
    }
}
