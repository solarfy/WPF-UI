using System.Windows;

namespace Yellow_Pad_Framework
{
    partial class YellowPadWindow : Window
    {

        private void StylusToolOnClick(object sender, RoutedEventArgs e)
        {
            StylusToolDialog dlg = new StylusToolDialog();
            dlg.Owner = this;
            dlg.DrawingAttributes = this.inkcanv.DefaultDrawingAttributes;

            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                this.inkcanv.DefaultDrawingAttributes = dlg.DrawingAttributes;
            }
        }

        private void EraserToolOnClick(object sender, RoutedEventArgs e)
        {
            EraserToolDialog dlg = new EraserToolDialog();
            dlg.Owner = this;
            dlg.EraserShape = this.inkcanv.EraserShape;

            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                this.inkcanv.EraserShape = dlg.EraserShape;
            }
        }
    }
}