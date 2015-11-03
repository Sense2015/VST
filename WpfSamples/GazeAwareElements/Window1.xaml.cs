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
using System.Windows.Shapes;

namespace VoiceSymbol
{   
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        public MainWindow win;
        public Window1()
        {
            InitializeComponent();
        }
        public void viewclose()
        {
            win.canvasdraw();
            Global.count++;
            if (Global.count >= Global.DataNum) Global.count = 0;
            this.Close();
        }
        private void x00_Click(object sender, RoutedEventArgs e)
        {
            Global.content[Global.count] = "img17";
            viewclose();
        }
        private void x01_Click(object sender, RoutedEventArgs e)
        {
            Global.content[Global.count] = "img18";
            viewclose();
        }
        private void x02_Click(object sender, RoutedEventArgs e)
        {
            Global.content[Global.count] = "img19";
            viewclose();
        }
        private void x03_Click(object sender, RoutedEventArgs e)
        {
            Global.content[Global.count] = "img20";
            viewclose();
        }
        private void x23_Click(object sender, RoutedEventArgs e)
        {
            viewclose();
        }
        //回首頁
        private void _home_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //倒退
        private void _back_Click(object sender, RoutedEventArgs e)
        {
            if (Global.count > 0)
            {
                Global.content[Global.count - 1] = null;
                Global.count--;
            }
            canvasdraw();
        }
        //清除
        private void _delete_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Global.DataNum; i++)
            {
                Global.content[i] = null;
            }
            Global.count = 0;
            canvasdraw();
        }
        //念整句
        private void _say_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Global.DataNum; i++)
            {
                Console.Write(Global.content[i] + ",");
            }
            Console.WriteLine("");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvasdraw();
        }
        public void canvasdraw()
        {
            canvas1.Children.Clear();
            int i = 0;

            while (Global.content[i] != null && i < Global.DataNum)
            {
                double width = (this.canvas1.ActualWidth - (Global.DataNum + 1) * 5) / Global.DataNum;
                double height = (this.canvas1.ActualHeight - (1 + 1) * 5) / 1;
                Image ig = new Image()
                {
                    Width = width,
                    Height = height,
                };
                canvas1.Children.Add(ig);
                Canvas.SetTop(ig, 0 * height + 5);
                Canvas.SetLeft(ig, i * width + 5);

                ig.Source = ((Image)TryFindResource(Global.content[i])).Source;
                i++;
                if (i == Global.DataNum) break;
            }
        }
    }
}
