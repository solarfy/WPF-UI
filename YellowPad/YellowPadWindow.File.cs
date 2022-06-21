using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Yellow_Pad_Framework
{
    partial class YellowPadWindow : Window
    {
        /* [Strokes 笔画]
         * 计算机图形学术语中，stroke本质上就是polyline，也就是一组短而互相连接线段的集合；
         * 所以，Stroke对象具有一个名为StylusPoints类型为StylusPointCollection的属性，也就是
         * StylusPoint对象的集合，StylusPoint结构包含了X、Y及PressureFactor（触控笔对屏幕所施加的压力，默认的压力越大，线条越宽）。
         *
         * 每个Stroke都有自己的颜色，此颜色是DrawingAttributes对象的一部分，DrawingAttributes也包含了Width与Height属性。
         *
         * StrokeCollection定义了一个Save方法，将Stroke集合以Ink Serialized Format（墨水串行化格式，ISF）保存；
         * 同时StokeCollection也具有一个构造函数，可以加载ISF格式的文件。
         *
         */ 

        private void NewOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.inkcanv.Strokes.Clear();
        }

        private void OpenOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "Ink Serialized Format(*.isf)|*.isf|All files(*.*)|*.*";

            if ((bool)dlg.ShowDialog(this))
            {
                try
                {
                    FileStream file = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                    this.inkcanv.Strokes = new StrokeCollection(file);
                    file.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Title);
                }
            }

        }

        private void SaveOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|XAML Drawing File (*.xaml)|*.xaml|All files (*.*)|*.*";
            
            if ((bool)dlg.ShowDialog(this))
            {
                try
                {               
                    FileStream file = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);

                    if (dlg.FilterIndex == 1 || dlg.FilterIndex == 3)
                        this.inkcanv.Strokes.Save(file);
                    else
                    {
                        DrawingGroup drawgrp = new DrawingGroup();

                        foreach(Stroke strk in this.inkcanv.Strokes)
                        {
                            Color clr = strk.DrawingAttributes.Color;

                            if (strk.DrawingAttributes.IsHighlighter)
                                clr = Color.FromArgb(128, clr.A, clr.G, clr.B);

                            drawgrp.Children.Add(new GeometryDrawing(new SolidColorBrush(clr), null, strk.GetGeometry()));
                        }

                        XamlWriter.Save(drawgrp, file);
                    }
                    file.Close();
                }
                catch (Exception exc) 
                {
                    MessageBox.Show(exc.Message, this.Title);                    
                }
            }
        }

        private void CloseOnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
