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
using System.Threading;

using EyeXFramework;
using Tobii.EyeX.Framework;

namespace VoiceSymbol
{
    
    public partial class EyeCanvas : Window
    {
        Thread dot;
        Ellipse ellipse;
        double eyex, eyey;
        System.Windows.Threading.DispatcherTimer m_timer;
        public EyeCanvas()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dot = new Thread(Eyetracking);
            ellipse = new Ellipse();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(100, 255, 255, 0);
            ellipse.Fill = mySolidColorBrush;
            //邊框
            //ellipse.StrokeThickness = 2;
            //ellipse.Stroke = Brushes.Red;
            ellipse.Width = 10;
            ellipse.Height = 10;
            //this.Show();
            this.EyeEllipseCanvas.Children.Add(ellipse);
            dot.Start();
            m_timer = new System.Windows.Threading.DispatcherTimer();
            m_timer.Tick += new EventHandler(testFunction);
            m_timer.Interval = new TimeSpan(0, 0, 0 ,0,1);  //0.001seconds
            m_timer.IsEnabled = true;
        }
        public void testFunction(object sender, EventArgs e)
        {
            Canvas.SetLeft(ellipse, eyex - 0);
            Canvas.SetTop(ellipse, eyey - 0);
            //Console.WriteLine("x:" + eyex.ToString() + "- y:" + eyey.ToString());
        }
        public void Eyetracking()
        {
            using (var eyeXHost = new EyeXHost())
            {
                // Create a data stream: lightly filtered gaze point data.
                // Other choices of data streams include EyePositionDataStream and FixationDataStream.
                using (var lightlyFilteredGazeDataStream = eyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered))
                {
                    // Start the EyeX host.
                    eyeXHost.Start();

                    // Write the data to the console.
                    lightlyFilteredGazeDataStream.Next += (s, e) =>
                    {
                        //Console.WriteLine("Gaze point at ({0:0.0}, {1:0.0}) @{2:0}", e.X, e.Y, e.Timestamp);
                        eyex = e.X;
                        eyey = e.Y;
                    };// Let it run until a key is pressed.
                    Console.WriteLine("Listening for gaze data, press any key to exit...");
                    Console.In.Read();
                }
            }
        }
    }
}
