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

namespace Smart_Home_App.User_Controls
{
    /// <summary>
    /// Card.xaml 的交互逻辑
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(Card));

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(nameof(IsChecked), typeof(bool), typeof(Card));

        public bool IsHorizontal
        {
            get { return (bool)GetValue(IsHorizontalProperty); }
            set { SetValue(IsHorizontalProperty, value); }
        }
        public static readonly DependencyProperty IsHorizontalProperty = DependencyProperty.Register(nameof(IsHorizontal), typeof(bool), typeof(Card));

        public ImageSource ImageOn
        {
            get { return (ImageSource)GetValue(ImageOnProperty); }
            set { SetValue(ImageOnProperty, value); }
        }
        public static readonly DependencyProperty ImageOnProperty = DependencyProperty.Register(nameof(ImageOn), typeof(ImageSource), typeof(Card));

        public ImageSource ImageOff
        {
            get { return (ImageSource)GetValue(ImageOffProperty); }
            set { SetValue(ImageOffProperty, value); }
        }
        public static readonly DependencyProperty ImageOffProperty = DependencyProperty.Register(nameof(ImageOff), typeof(ImageSource), typeof(Card));
    }
}
