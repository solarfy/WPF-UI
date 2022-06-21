using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;

namespace Yellow_Pad_Framework
{
    /// <summary>
    /// StylusToolDialog.xaml 的交互逻辑
    /// </summary>
    public partial class StylusToolDialog : Window
    {
        public StylusToolDialog()
        {
            InitializeComponent();

            this.txtboxWidth.TextChanged += TextBoxOnTextChanged;
            this.txtboxHeight.TextChanged += TextBoxOnTextChanged;
            this.txtboxAngle.TextChanged += TextBoxOnTextChanged;

            this.txtboxWidth.Focus();
        }

        public DrawingAttributes DrawingAttributes
        {
            set 
            {
                this.txtboxHeight.Text = (0.75 * value.Height).ToString("F1");
                this.txtboxWidth.Text = (0.75 * value.Width).ToString("F1");
                this.txtboxAngle.Text = (180 * Math.Acos(value.StylusTipTransform.M11) / Math.PI).ToString("F1");
                this.chkboxPressure.IsChecked = value.IgnorePressure;
                this.chkboxHighlighter.IsChecked = value.IsHighlighter;

                if (value.StylusTip == StylusTip.Ellipse)
                    this.radioEllipse.IsChecked = true;
                else
                    this.radioRect.IsChecked = true;

                this.lstboxColor.SelectedColor = value.Color;
                this.lstboxColor.ScrollIntoView(this.lstboxColor.SelectedColor);
            }

            get
            {
                DrawingAttributes drawattr = new DrawingAttributes();

                drawattr.Height = double.Parse(this.txtboxHeight.Text) / 0.75;
                drawattr.Width = double.Parse(this.txtboxWidth.Text) / 0.75;
                drawattr.StylusTipTransform = new RotateTransform(double.Parse(this.txtboxAngle.Text)).Value;
                drawattr.IgnorePressure = (bool)this.chkboxPressure.IsChecked;
                drawattr.IsHighlighter = (bool)this.chkboxHighlighter.IsChecked;
                drawattr.StylusTip = (bool)this.radioEllipse.IsChecked ? StylusTip.Ellipse : StylusTip.Rectangle;
                drawattr.Color = this.lstboxColor.SelectedColor;
                return drawattr;
            }
        }

        private void TextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            double width, height, angle;

            this.btnOk.IsEnabled = double.TryParse(this.txtboxWidth.Text, out width)
                                   && width / 0.75 >= DrawingAttributes.MinWidth
                                   && width / 0.75 <= DrawingAttributes.MaxWidth
                                   && double.TryParse(this.txtboxHeight.Text, out height)
                                   && height / 0.75 >= DrawingAttributes.MinHeight
                                   && height / 0.75 <= DrawingAttributes.MaxHeight
                                   && double.TryParse(this.txtboxAngle.Text, out angle);
        }

        private void OkOnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
