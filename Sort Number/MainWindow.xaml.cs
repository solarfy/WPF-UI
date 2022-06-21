using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Sort_Number
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int NumberRows = 4;
        const int NumberCols = 4;

        UniformGrid ungrid;
        int xEmpty, yEmpty, iCounter;
        Key[] keys = { Key.Left, Key.Right, Key.Up, Key.Down };
        Random rand;
        UIElement elEmptySpare = new Empty();

        TextBlock textTimerLength;
        DateTime startTime;
        System.Windows.Threading.DispatcherTimer timerLength = null;

        public MainWindow()
        {
            InitializeComponent();

            PlaySortNumber();
        }

        private void PlaySortNumber()
        {
            this.Title = "数字移动";
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.ResizeMode = ResizeMode.CanMinimize;
            this.Background = SystemColors.ControlBrush;

            //建立一个StackPanel，作为窗口的内容
            StackPanel stack = new StackPanel();
            this.Content = stack;

            StackPanel sp = new StackPanel();
            stack.Children.Add(sp);

            //在窗口上面建立一个Button
            Button btn = new Button();
            btn.Content = "开始";
            btn.Margin = new Thickness(10);
            btn.Padding = new Thickness(8,2,8,2);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.Click += ScrambleOnClick;
            sp.Children.Add(btn);

            //时长
            textTimerLength = new TextBlock() { Text = "00:00:00" };
            textTimerLength.Foreground = SystemColors.WindowTextBrush;
            textTimerLength.HorizontalAlignment = HorizontalAlignment.Center;
            textTimerLength.Margin = new Thickness(10);
            sp.Children.Add(textTimerLength);

            //创建一个border
            Border bord = new Border();
            bord.BorderBrush = SystemColors.ControlDarkDarkBrush;
            bord.BorderThickness = new Thickness(1);
            stack.Children.Add(bord);

            //创建UniformGrid
            ungrid = new UniformGrid();
            ungrid.Rows = NumberRows;
            ungrid.Columns = NumberCols;
            bord.Child = ungrid;

            //创建Tile对象，填满所有的格子（空一个不填）
            for (int i = 0; i < NumberCols * NumberRows - 1; i++)
            {
                Tile tile = new Tile();
                tile.Text = (i + 1).ToString();
                tile.MouseLeftButtonDown += TileOnMouseLeftButtonDown;
                ungrid.Children.Add(tile);
            }

            //建立一个Empty对象，填入最后一个位置
            ungrid.Children.Add(new Empty());
            xEmpty = NumberRows - 1;    //记录“空”方块所在的位置
            yEmpty = NumberCols - 1;

        }

        private void TileOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tile tile = sender as Tile;

            int iMove = ungrid.Children.IndexOf(tile);  //根据所点击的Tile在面板中的索引，计算出该Tile的x，y坐标
            int xMove = iMove % NumberCols;
            int yMove = iMove / NumberCols;

            if (xMove == xEmpty)    //x坐标与Empty的x坐标相同则进行上下方向移动
            {
                //可移动多个Tile，所以用While处理
                while (yMove != yEmpty)
                {
                    MoveTile(xMove, yEmpty + (yMove - yEmpty) / Math.Abs(yMove - yEmpty));      //yEmpty在MoveTile中变换
                }
            }

            if (yMove == yEmpty)    //y坐标与Empty的y坐标相同则进行左右方向移动
            {
                while (xMove != xEmpty)
                {
                    MoveTile(xEmpty + (xMove - xEmpty) / Math.Abs(xMove - xEmpty), yMove);      //xEmpty在MoveTile中变换
                }
            }

            if (IsCompleted() && timerLength != null)
            {
                timerLength.Stop();
                MessageBox.Show("Perfect");
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            //上下左右移动Empty，但为了使看上去不是移动的Empty而是移动同方向上与Empty相邻的Tile，所以此处的处理与Empty的移动方向相反
            switch (e.Key)
            {
                case Key.Right: MoveTile(xEmpty - 1, yEmpty); break;
                case Key.Left: MoveTile(xEmpty + 1, yEmpty); break;
                case Key.Up: MoveTile(xEmpty, yEmpty + 1); break;
                case Key.Down: MoveTile(xEmpty, yEmpty - 1); break;
            }

            if (IsCompleted() && timerLength != null)
            {
                timerLength.Stop();
                MessageBox.Show("Perfect");
            }
        }

        private void ScrambleOnClick(object sender, RoutedEventArgs e)
        {
            rand = new Random();
            iCounter = 16 * NumberCols * NumberRows;

            System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer();
            tmr.Interval = TimeSpan.FromMilliseconds(3);
            tmr.Tick += new EventHandler((arg1, arg2) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    //移动Empty的位置，打乱整个数组面板
                    MoveTile(xEmpty, yEmpty + rand.Next(3) - 1);
                    MoveTile(xEmpty + rand.Next(3) - 1, yEmpty);

                    //MoveTile(xEmpty + rand.Next(3) - 1, yEmpty + rand.Next(3) - 1);
                }

                if (0 == iCounter--)
                {
                    (arg1 as System.Windows.Threading.DispatcherTimer).Stop();

                    //启动计时
                    timerLength = new System.Windows.Threading.DispatcherTimer();
                    timerLength.Interval = TimeSpan.FromSeconds(1);
                    timerLength.Tick += new EventHandler((a1, a2) =>
                    {
                        TimeSpan ts = DateTime.Now - startTime;
                        textTimerLength.Text = ts.ToString(@"hh\:mm\:ss");
                    });

                    startTime = DateTime.Now;
                    timerLength.Start();
                }
            });
            tmr.Start();
        }

        /// <summary>
        /// 移动方块
        /// </summary>
        /// <param name="xTile">方块当前所在的x位置</param>
        /// <param name="yTile">方块当前所在的y位置</param>
        private void MoveTile(int xTile, int yTile)
        {
            /*
             * 将相邻的Tile移动到Empty上
             * 
             */

            if ((xTile == xEmpty && yTile == yEmpty) ||
                xTile < 0 || xTile >= NumberCols ||
                yTile < 0 || yTile >= NumberRows)
            {
                return;
            }

            int iTile = NumberCols * yTile + xTile;     //根据Tile方块坐标，计算出该方块所在Panel面板中的索引  （y * 列数 + x）UnnformGrid是从左到右，从上到下的排列
            int iEmpty = NumberCols * yEmpty + xEmpty;  //根据Empty方块坐标，计算出该方块所在Panel面板中的索引

            UIElement elTile = ungrid.Children[iTile];      //根据索引获取该位置上的Tile
            UIElement elEmpty = ungrid.Children[iEmpty];    //获取Empty

            //交换Tile与Empty的位置
            ungrid.Children.RemoveAt(iTile);
            ungrid.Children.Insert(iTile, elEmptySpare);
            ungrid.Children.RemoveAt(iEmpty);
            ungrid.Children.Insert(iEmpty, elTile);

            //重新记录Empty的位置
            xEmpty = xTile;
            yEmpty = yTile;
            elEmptySpare = elEmpty;
        }

        private bool IsCompleted()
        {
            for (int i = 0; i < NumberCols * NumberRows - 1; i++)
            {
                if (ungrid.Children[i] is Tile tile)
                {
                    if (tile.Text == (i + 1).ToString())
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Tile : Canvas
    {
        const int SIZE = 64;
        const int BORD = 6;
        TextBlock txtblk;

        public Tile()
        {
            this.Width = SIZE;
            this.Height = SIZE;

            //左上的影子边界
            Polygon poly = new Polygon();
            poly.Points = new PointCollection(new Point[]
            {
                new Point(0, 0), new Point(SIZE, 0), new Point(SIZE-BORD, BORD), new Point(BORD, BORD), new Point(BORD, SIZE-BORD), new Point(0, SIZE)
            });
            poly.Fill = SystemColors.ControlLightBrush;
            this.Children.Add(poly);

            //右下的影子边界
            poly = new Polygon();
            poly.Points = new PointCollection(new Point[]
            {
                new Point(SIZE, SIZE), new Point(SIZE, 0), new Point(SIZE-BORD, BORD), new Point(SIZE-BORD, SIZE-BORD), new Point(BORD, SIZE-BORD), new Point(0, SIZE)
            });
            poly.Fill = SystemColors.ControlDarkBrush;
            this.Children.Add(poly);

            //放置中央文字
            Border bord = new Border();
            bord.Width = SIZE - 2 * BORD;
            bord.Height = SIZE - 2 * BORD;
            bord.Background = SystemColors.ControlBrush;
            this.Children.Add(bord);
            Canvas.SetLeft(bord, BORD);
            Canvas.SetTop(bord, BORD);

            //显示文字
            txtblk = new TextBlock();
            txtblk.FontSize = 32;
            txtblk.Foreground = SystemColors.ControlTextBrush;
            txtblk.HorizontalAlignment = HorizontalAlignment.Center;
            txtblk.VerticalAlignment = VerticalAlignment.Center;
            bord.Child = txtblk;
        }

        //设置文字的property
        public string Text
        {
            get => txtblk.Text;
            set => txtblk.Text = value;
        }

    }

    /// <summary>
    /// 空白格子
    /// </summary>
    public class Empty : System.Windows.FrameworkElement { }
}
