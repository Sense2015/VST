//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------
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
using System.Threading;
using System.Media;

using EyeXFramework;
using Tobii.EyeX.Framework;

namespace VoiceSymbol
{

    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<Point> pointList = new List<Point>();
        //Thread dot, dot2 , SoundPlay;
        //double eyex, eyey;
        //Ellipse ellipse;
        //System.Windows.Threading.DispatcherTimer m_timer;
        //string[] content=new string[9];
        //int count = 0;
        //storage sto = new storage();
        //string[] content = new string[9];
        public MainWindow()
        {
            InitializeComponent();
        }
        public void viewclose()
        {
            Global.count++;
            if (Global.count >= Global.DataNum) Global.count = 0;
        }
        //我要吃
        private void m00_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            Global.content[Global.count] = "img11";
            Console.WriteLine("" + Global.content[Global.count]);
            w1.Show();
            w1.win = this;
            canvasdraw();
            viewclose();
        }
        //我要喝
        private void m01_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            Global.content[Global.count] = "img12";
            Console.WriteLine("" + Global.content[Global.count]);
            w2.Show();
            w2.win = this;
            canvasdraw();
            viewclose();
        }
        //我要做
        private void m10_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3();
            Global.content[Global.count] = "img13";
            Console.WriteLine("" + Global.content[Global.count]);
            w3.Show();
            w3.win = this;
            canvasdraw();
            viewclose();
        }
        //我要運動
        private void m11_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4();
            Global.content[Global.count] = "img14";
            Console.WriteLine("" + Global.content[Global.count]);
            w4.Show();
            w4.win = this;
            canvasdraw();
            viewclose();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SV.HorizontalScrollBarVisibility =ScrollBarVisibility.Hidden;
            EyeCanvas EC = new EyeCanvas();
            EC.Show();
        }
        
        //念整句
        private void c20_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Global.DataNum; i++)
            {
                Console.Write(Global.content[i] + ",");
            }
            Console.WriteLine("");
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
            
            //Thread t1 = new Thread(new ThreadStart(this.Sound1)); 
            //t1.Start(); 
            //int i = 0;
            //while (Global.content[i] != null && i < 9)
            //{
            MediaPlayer player = new MediaPlayer();
            Global.path = @"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + Global.content[0] + ".mp3";
            Global.index = 1;
            MediaPlayerThree.play(Global.path);
            //player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + Global.content[i] + ".mp3", UriKind.Relative));
            //player.Play();

            //player.MediaEnded += new EventHandler(player_MediaEnded);
            //i++;
            //if (i == 9) break;
            //}
        }
        //void Sound1() 
        //{ 
        //    SoundPlayer sp = new SoundPlayer(); 
        //    sp.SoundLocation = @"C:\tobiitest\VoiceSymbolTry\EXDN\source\WpfSamples\GazeAwareElements\Sounds\img26.mp3"; 
        //    sp.Play(); 
        //    Console.WriteLine("sp1"); 
        //    Console.ReadLine(); 
        //} 
        
        //倒退
        private void c00_Click(object sender, RoutedEventArgs e)
        {
            if (Global.count > 0)
            {
                Global.content[Global.count - 1] = null;
                Global.count--;
            }
            canvasdraw();
        }
        //清除
        private void c10_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Global.DataNum; i++)
            {
                Global.content[i] = null;
            }
            Global.count = 0;
            canvasdraw();
        }
        //發單音
        private void c30_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Global.content[Global.count - 1]);
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + Global.content[Global.count - 1] + ".mp3", UriKind.Relative));
            player.Play();
        }

        private void l00_Click(object sender, RoutedEventArgs e)
        {
            Global.language = 0;
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\airplane.mp3", UriKind.Relative));
            player.Play();
            Console.WriteLine("test");
        }

        private void l01_Click(object sender, RoutedEventArgs e)
        {
            Global.language = 1;
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(@"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\img01.mp3", UriKind.Relative));
            player.Play();
            Console.WriteLine("test");
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
                this.canvas1.Width = this.canvas1.ActualWidth + width;
                Canvas.SetTop(ig, 0 * height + 5);
                Canvas.SetLeft(ig, i * width + 5);

                ig.Source = ((Image)TryFindResource(Global.content[i])).Source;
                i++;
                if (i == Global.DataNum) break;
            }
        }
        
    }
}

