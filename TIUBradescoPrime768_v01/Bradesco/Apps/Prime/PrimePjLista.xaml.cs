﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Bradesco.Apps.Prime
{
	/// <summary>
	/// Interaction logic for PrimePjLista.xaml
	/// </summary>
	public partial class PrimePjLista : UserControl
	{
		protected TouchPoint TouchStart;
		protected bool AlreadySwiped;
		private readonly Stopwatch _doubleTapStopwatch = new Stopwatch();
		private Point _lastTapLocation;
		private double scrollToValue;

		private double MINZOOMFACTOR = 1.0;
		private double MAXZOOMFACTOR = 1.2;

		public PrimePjLista()
		{
			InitializeComponent();
			this.TouchDown += new EventHandler<TouchEventArgs>(BasePage_TouchDown);
			this.TouchMove += new EventHandler<TouchEventArgs>(BasePage_TouchMove);
		}

		public void ScrollTo(int index)
		{

			var i = ImageLista as Image;

			if (i == null) return;

			var matrix = ((MatrixTransform)i.RenderTransform).Matrix;
			matrix.Translate(0, matrix.OffsetY * -1);
			matrix.Translate(0, -1 * index);

			scrollToValue = Convert.ToDouble(index);

			matrix.M11 = 1;
			matrix.M22 = 1;
			matrix.OffsetX = 0;
			matrix.OffsetY = scrollToValue * -1;

			i.RenderTransform = new MatrixTransform(matrix);

			var storyboard = FindResource("showItemsStoryboard") as Storyboard;
			if (storyboard != null) storyboard.Begin((FrameworkElement)i);

			storyboard = FindResource("showItemsMenuStoryboard") as Storyboard;
			if (storyboard != null) storyboard.Begin((FrameworkElement)i);
		}

		private bool IsDoubleTap(TouchEventArgs e)
		{
			Point currentTapPosition = e.GetTouchPoint(this).Position;
			bool tapsAreCloseInDistance = Point.Subtract(currentTapPosition, _lastTapLocation).Length < 30;
			_lastTapLocation = currentTapPosition;

			TimeSpan elapsed = _doubleTapStopwatch.Elapsed;
			_doubleTapStopwatch.Restart();
			bool tapsAreCloseInTime = (elapsed != TimeSpan.Zero && elapsed < TimeSpan.FromSeconds(0.7));

			return tapsAreCloseInDistance && tapsAreCloseInTime;
		}


		void BasePage_TouchDown(object sender, TouchEventArgs e)
		{

			if (IsDoubleTap(e))
			{
				Mouse_DoubleTouch(sender, e);
			}
			else
			{
				TouchStart = e.GetTouchPoint(this);
			}

		}

		void Mouse_DoubleTouch(object sender, TouchEventArgs e)
		{

			var element = e.OriginalSource as Image;
			if (element == null) return;

			var Touch = e.GetTouchPoint(this);
			var matrix = ((MatrixTransform)element.RenderTransform).Matrix;

			Rect elementBounds = new Rect(matrix.OffsetX, matrix.OffsetY, (element.RenderSize.Width * matrix.M11), (element.RenderSize.Height * matrix.M11));

			double zoomFactor = 1 - (matrix.M11 - 1);
			matrix.ScaleAt(zoomFactor, zoomFactor, (elementBounds.Width / 2), Touch.Position.Y);

			//----------------------------------------
			if (matrix.M11 < MINZOOMFACTOR)
			{
				matrix.M11 = matrix.M22 = MINZOOMFACTOR;
			}
			else if (matrix.M11 > MAXZOOMFACTOR)
			{
				matrix.M11 = matrix.M22 = MAXZOOMFACTOR;
			}
			//----------------------------------------
			matrix.OffsetX = 0;
			//----------------------------------------
			elementBounds = new Rect(matrix.OffsetX, matrix.OffsetY, (element.RenderSize.Width * matrix.M11), (element.RenderSize.Height * matrix.M11));
			//----------------------------------------
			if (matrix.OffsetY < (scroll.ActualHeight - elementBounds.Height))
			{
				matrix.OffsetY = (scroll.ActualHeight - elementBounds.Height);
			}
			//----------------------------------------
			if (matrix.OffsetY > 0)
			{
				matrix.OffsetY = 0;
			}
			//----------------------------------------

			element.RenderTransform = new MatrixTransform(matrix);
			e.Handled = true;

		}

		void BasePage_TouchMove(object sender, TouchEventArgs e)
		{
			var i = e.OriginalSource as Image;

			if (i == null) return;

			var matrix = ((MatrixTransform)i.RenderTransform).Matrix;

			if (!AlreadySwiped && matrix.Determinant == 1 && TouchesOver.Count() == 1)
			{
				var tt = new TranslateTransform();

				var Touch = e.GetTouchPoint(this);
				//Swipe Left
				if (TouchStart != null && Touch.Position.X > (TouchStart.Position.X + 200))
				{
					AlreadySwiped = true;

					TarifasPF w = new TarifasPF();

					DependencyObject ucParent = this.Parent;

					while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
					{
						ucParent = LogicalTreeHelper.GetParent(ucParent);
					}

					Principal tela = (Principal)ucParent;

					tela.labelTitulo.Content = "Tarifas PF";
					if (tela.gridPrincipal.Children.Count > 0)
					{
						tela.gridPrincipal.Children.RemoveAt(0);
					}                                        
					
					tela.gridPrincipal.Children.Add(w);
					w.RenderTransform = tt;

				}
				//Swipe Right

				if (TouchStart != null && Touch.Position.X < (TouchStart.Position.X - 200))
				{
					AlreadySwiped = true;
					PrimeSCR w = new PrimeSCR();

					DependencyObject ucParent = this.Parent;

					while (!(ucParent is UserControl) || ucParent.ToString() != "Bradesco.Apps.Principal")
					{
						ucParent = LogicalTreeHelper.GetParent(ucParent);
					}

					Principal tela = (Principal)ucParent;

					tela.labelTitulo.Content = "Prime SCR";

					if (tela.gridPrincipal.Children.Count > 0)
					{
						tela.gridPrincipal.Children.RemoveAt(0);
					}                    

					tela.gridPrincipal.Children.Add(w);

					tt.X = 300;

					w.RenderTransform = tt;
				}

			}

			e.Handled = true;

		}

		private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs args)
		{
			UIElement element = args.Source as UIElement;
			MatrixTransform xform = element.RenderTransform as MatrixTransform;
			Matrix matrix = xform.Matrix;
			ManipulationDelta delta = args.DeltaManipulation;
			Point center = args.ManipulationOrigin;

			Rect elementBounds = new Rect(matrix.OffsetX, matrix.OffsetY, (element.RenderSize.Width * matrix.M11), (element.RenderSize.Height * matrix.M11));

			FrameworkElement parent = args.ManipulationContainer as FrameworkElement;

			//------------------------------------------
			//--- S C A L E
			//------------------------------------------
			if (!(matrix.M11 <= MINZOOMFACTOR && delta.Scale.X < 1) && !(matrix.M11 >= MAXZOOMFACTOR && delta.Scale.X > 1))
			{
				matrix.ScaleAt(delta.Scale.X, delta.Scale.Y, center.X, center.Y);
			}
			//----------------------------------------
			if (matrix.M11 < MINZOOMFACTOR)
			{
				matrix.M11 = matrix.M22 = MINZOOMFACTOR;
			}
			else if (matrix.M11 > MAXZOOMFACTOR)
			{
				matrix.M11 = matrix.M22 = MAXZOOMFACTOR;
			}

			//------------------------------------------
			//--- O F F S E T
			//------------------------------------------

			Vector offset = new Vector(0, 0);

			//----------------------------------------
			if ((elementBounds.Left + delta.Translation.X) <= 0)
			{
				if ((elementBounds.Right + delta.Translation.X) >= scroll.ActualWidth)
				{
					offset.X = delta.Translation.X;
				}
				else
				{
					offset.X = 0;
				}
			}
			else
			{
				offset.X = scroll.ActualWidth;
			}
			//----------------------------------------

			if ((elementBounds.Top + delta.Translation.Y) <= 0)
			{
				if ((elementBounds.Bottom + delta.Translation.Y) >= scroll.ActualHeight)
				{
					offset.Y = delta.Translation.Y;
				}
				else
				{
					offset.Y = 0;
				}
			}
			else
			{
				offset.Y = scroll.ActualHeight;
			}
			//----------------------------------------
			matrix.Translate(offset.X, offset.Y);
			//----------------------------------------
			if (matrix.OffsetX < (scroll.ActualWidth - elementBounds.Width))
			{
				matrix.OffsetX = (scroll.ActualWidth - elementBounds.Width);
			}
			if (matrix.OffsetY < (scroll.ActualHeight - elementBounds.Height))
			{
				matrix.OffsetY = (scroll.ActualHeight - elementBounds.Height);
			}
			//----------------------------------------
			if (matrix.OffsetX > 0)
			{
				matrix.OffsetX = 0;
			}
			if (matrix.OffsetY > 0)
			{
				matrix.OffsetY = 0;
			}
			//----------------------------------------

			xform.Matrix = matrix;

			args.Handled = true;
			base.OnManipulationDelta(args);

		}


		private void OnManipulationStarting(object sender, ManipulationStartingEventArgs args)
		{
			args.ManipulationContainer = this;
			args.Handled = true;
			base.OnManipulationStarting(args);
		}

		private void OnInertiaStarting(object sender, ManipulationInertiaStartingEventArgs args)
		{
			args.TranslationBehavior.DesiredDeceleration = 0.0009;
			args.Handled = true;
		}

	}
}
