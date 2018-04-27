using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bradesco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
		readonly System.Timers.Timer _timer = new System.Timers.Timer();

        public MainWindow()
        {
            InitializeComponent();
	        Loaded += Window_Loaded;
        }

	    //private int _endState = 0;
	    private void Window_Loaded(object sender, RoutedEventArgs e)
	    {
            //canvas.TouchDown += (s, e2) =>
            //{
            //    var x = e2.GetTouchPoint(canvas);
            //    if (x.Position.X < 100 && x.Position.Y > 1820)
            //    {
            //        _endState = 1;
            //    } else if (_endState == 1 && x.Position.X > 980 && x.Position.Y < 100)
            //    {
            //        Close();
            //    }
            //    else
            //    {
            //        _endState = 0;
            //    }
            //};

			InitializeScreensaver();
			ChangeContent(Controls.Home);
	    }

		#region Screensaver

		private void InitializeScreensaver()
	    {
			_timer.Interval = 90000;
			_timer.Elapsed += ((s1, e1) => {
				_timer.Stop();
				Dispatcher.BeginInvoke(new ThreadStart(() => {
					canvas.Visibility = Visibility.Hidden;
					screenSaver.Visibility = Visibility.Visible;
					screenSaver.Play();
				}));
			});
			_timer.AutoReset = true;
			_timer.Start();

			screenSaver.Source = new Uri(AppDomain.CurrentDomain.BaseDirectory + "Bradesco_InfoUteis\\Videos\\Display_Bradesco_timeout.mp4");
			screenSaver.MediaEnded += screenSaver_MediaEnded;
			screenSaver.TouchDown += screenSaver_TouchDown;
			screenSaver.MouseDown += screenSaver_MouseDown;
	    }

	    private void screenSaver_TouchDown(object sender, TouchEventArgs e) {
			screenSaver.Stop();
			screenSaver.Visibility = Visibility.Hidden;
			canvas.Visibility = Visibility.Visible;
			_timer.Start();
		}

		private void screenSaver_MouseDown(object sender, MouseButtonEventArgs e) {
			screenSaver.Stop();
			screenSaver.Visibility = Visibility.Hidden;
			canvas.Visibility = Visibility.Visible;
			_timer.Start();
		}

		private void screenSaver_MediaEnded(object sender, RoutedEventArgs e) {
			screenSaver.UnloadedBehavior = MediaState.Manual;
			screenSaver.Position = new TimeSpan(0, 0, 1);
			screenSaver.Play();
		}

		internal void ResetScreensaverTimer()
	    {
		    _timer.Reset();
	    }

		#endregion

		internal void ChangeContent(UIElement control)
	    {
			canvas.Children.Clear();
			canvas.Children.Add(control);   
	    }

	    ~MainWindow()
	    {
		    Dispose(false);
	    }

		public void Dispose() {
			Dispose(true);
		}

	    private void Dispose(bool disposing)
	    {
		    if (disposing)
		    {
			    _timer.Dispose();
		    }
	    }
    }
}
