using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;

namespace Yellow_Pad_Framework
{
    partial class YellowPadWindow : Window
    {
        private void EditOnOpened(object sender, RoutedEventArgs e)
        {
            this.itemFormat.IsEnabled = this.inkcanv.GetSelectedStrokes().Count > 0;
        }

        private void CutOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.inkcanv.CopySelection();
        }

        private void CutCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.inkcanv.GetSelectedStrokes().Count > 0;
        }

        private void CopyOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.inkcanv.CopySelection();
        }

        private void PasteOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.inkcanv.Paste();
        }

        private void PasteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.inkcanv.CanPaste();
        }

        private void DeleteOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (Stroke strk in this.inkcanv.GetSelectedStrokes())
            {
                this.inkcanv.Strokes.Remove(strk);
            }
        }

        private void SelectAllOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.inkcanv.Select(this.inkcanv.Strokes);
        }


        private void FormatOnClick(object sender, RoutedEventArgs e)
        {
            StylusToolDialog dlg = new StylusToolDialog();
            dlg.Owner = this;
            dlg.Title = "Format Selection";

            StrokeCollection strokes = this.inkcanv.GetSelectedStrokes();

            if (strokes.Count > 0)
                dlg.DrawingAttributes = strokes[0].DrawingAttributes;   //获取选中的首个笔画特征
            else
                dlg.DrawingAttributes = this.inkcanv.DefaultDrawingAttributes;

            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                foreach (Stroke strk in strokes)
                {
                    strk.DrawingAttributes = dlg.DrawingAttributes;
                }
            }
        }

    }
}
