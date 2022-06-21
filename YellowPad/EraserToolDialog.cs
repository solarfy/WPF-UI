using System.Windows;
using System.Windows.Ink;

namespace Yellow_Pad_Framework
{
    class EraserToolDialog : StylusToolDialog
    {
        public EraserToolDialog()
        {
            this.Title = "Eraser Tool";
            this.chkboxPressure.Visibility = Visibility.Collapsed;
            this.chkboxHighlighter.Visibility = Visibility.Collapsed;
            this.lstboxColor.Visibility = Visibility.Collapsed;
        }

        public StylusShape EraserShape
        {
            set
            {
                this.txtboxHeight.Text = (0.75 * value.Height).ToString("F1");
                this.txtboxWidth.Text = (0.75 * value.Width).ToString("F1");
                this.txtboxAngle.Text = value.Rotation.ToString();

                if (value is EllipseStylusShape)
                    this.radioEllipse.IsChecked = true;
                else
                    this.radioRect.IsChecked = true;
            }

            get
            {
                StylusShape eraser;
                double width = double.Parse(this.txtboxWidth.Text) / 0.75;
                double height = double.Parse(this.txtboxHeight.Text) / 0.75;
                double angle = double.Parse(this.txtboxAngle.Text);

                if ((bool)this.radioEllipse.IsChecked)
                    eraser = new EllipseStylusShape(width, height, angle);
                else
                    eraser = new RectangleStylusShape(width, height, angle);

                return eraser;
            }
        }

    }


}
