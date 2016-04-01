using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace WinRTCustomControls.Controls
{
    public class Rating : Control
    {
        private StackPanel starContainer;
        private double size;

        public Rating()
        {
            this.DefaultStyleKey = typeof(Rating);
            ManipulationMode = ManipulationModes.TranslateX;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            starContainer = GetTemplateChild("starContainer") as StackPanel;
            if (starContainer != null)
                starContainer.SizeChanged += StarContainer_SizeChanged;
            AddStars();
            SetIndicatorHandlers();
        }

        private void StarContainer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            size = starContainer.ActualWidth;
        }

        private void Rating_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (starContainer != null && size > 0)
            {
                Value = Math.Round((e.Position.X / size) * TotalStars * 2, MidpointRounding.AwayFromZero) / 2;
            }
        }

        private void Rating_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (starContainer != null && size > 0)
            {
                Value = Math.Round((e.Position.X / size) * TotalStars * 2, MidpointRounding.AwayFromZero) / 2;

                if (ValueChanged != null)
                {
                    ValueChanged(this, Value);
                }
            }
        }

        private void SetupStars()
        {
            if (starContainer != null)
            {
                for (int i = 0; i < starContainer.Children.Count; i++)
                {
                    var img = starContainer.Children[i];
                    if (img.GetType() == typeof(Image))
                        SetSource(img as Image, i);
                }
            }
        }

        private void AddStars()
        {
            if (starContainer != null)
            {
                starContainer.Children.Clear();
                for (int i = 0; i < TotalStars; i++)
                {
                    var star = new Image();
                    if (!IsIndicator)
                        star.Tapped += Star_Tapped;
                    starContainer.Children.Add(star);
                }
                SetupStars();
            }
        }

        private void Star_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (starContainer != null)
            {
                var index = starContainer.Children.IndexOf(sender as Image);
                Value = index + 1;
            }
            if (ValueChanged != null)
            {
                ValueChanged(this, Value);
            }
        }

        private void SetIndicatorHandlers()
        {
            if (IsIndicator)
            {
                ManipulationDelta -= Rating_ManipulationDelta;
                ManipulationCompleted -= Rating_ManipulationCompleted;
                if (starContainer != null)
                    foreach (var i in starContainer.Children)
                        if (i.GetType() == typeof(Image))
                            i.Tapped -= Star_Tapped;
            }
            else
            {
                ManipulationDelta += Rating_ManipulationDelta;
                ManipulationCompleted += Rating_ManipulationCompleted;
                if (starContainer != null)
                    foreach (var i in starContainer.Children)
                        if (i.GetType() == typeof(Image))
                            i.Tapped += Star_Tapped;
            }
        }

        private void SetSource(Image star, int index)
        {
            var starValue = Value - (double)index;

            if (starValue > 0.7)
                star.Source = FullStarSource;
            else if (starValue < 0.4)
                star.Source = EmptyStarSource;
            else
                star.Source = HalfStarSource;
        }

        #region DependencyProperties
        public ImageSource FullStarSource
        {
            get { return base.GetValue(FullStarSourceProperty) as ImageSource; }
            set { base.SetValue(FullStarSourceProperty, value); }
        }
        public static readonly DependencyProperty FullStarSourceProperty =
          DependencyProperty.Register("FullStarSource", typeof(ImageSource), typeof(Rating),
              new PropertyMetadata(new BitmapImage(new Uri("ms-appx:///WinRTCustomControls/Assets/ic_star_on_48dp.png")), new PropertyChangedCallback(OnFullStarChanged)));

        private static void OnFullStarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as Rating;
            instance.SetupStars();
        }

        public ImageSource HalfStarSource
        {
            get { return base.GetValue(HalfStarSourceProperty) as ImageSource; }
            set { base.SetValue(HalfStarSourceProperty, value); }
        }
        public static readonly DependencyProperty HalfStarSourceProperty =
          DependencyProperty.Register("HalfStarSource", typeof(ImageSource), typeof(Rating),
              new PropertyMetadata(new BitmapImage(new Uri("ms-appx:///WinRTCustomControls/Assets/ic_star_mid_48dp.png")), new PropertyChangedCallback(OnHalfStarChanged)));

        private static void OnHalfStarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as Rating;
            instance.SetupStars();
        }

        public ImageSource EmptyStarSource
        {
            get { return base.GetValue(EmptyStarSourceProperty) as ImageSource; }
            set { base.SetValue(EmptyStarSourceProperty, value); }
        }
        public static readonly DependencyProperty EmptyStarSourceProperty =
          DependencyProperty.Register("EmptyStarSource", typeof(ImageSource), typeof(Rating),
              new PropertyMetadata(new BitmapImage(new Uri("ms-appx:///WinRTCustomControls/Assets/ic_star_off_48dp.png")), new PropertyChangedCallback(OnEmptyStarChanged)));

        private static void OnEmptyStarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as Rating;
            instance.SetupStars();
        }

        public bool IsIndicator
        {
            get { return Convert.ToBoolean(base.GetValue(IsIndicatorProperty)); }
            set { base.SetValue(IsIndicatorProperty, value); }
        }
        public static readonly DependencyProperty IsIndicatorProperty =
          DependencyProperty.Register("IsIndicator", typeof(bool), typeof(Rating), new PropertyMetadata(false, new PropertyChangedCallback(OnIsIndicatorChanged)));

        public static void OnIsIndicatorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as Rating;
            instance.SetIndicatorHandlers();
        }

        public double Value
        {
            get { return Convert.ToDouble(base.GetValue(ValueProperty)); }
            set { base.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
          DependencyProperty.Register("Value", typeof(double), typeof(Rating),
              new PropertyMetadata(0, new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as Rating;
            instance.SetupStars();
        }

        public int TotalStars
        {
            get { return Convert.ToInt32(base.GetValue(TotalStarsProperty)); }
            set { base.SetValue(TotalStarsProperty, TotalStars); }
        }
        public static readonly DependencyProperty TotalStarsProperty =
          DependencyProperty.Register("TotalStars", typeof(int), typeof(Rating), new PropertyMetadata(5, new PropertyChangedCallback(OnTotalStarsChanged)));

        private static void OnTotalStarsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as Rating;
            instance.AddStars();
        }
        #endregion

        #region Delegates
        public delegate void ValueChangedEventHandler(object sender, double value);

        public event ValueChangedEventHandler ValueChanged;
        #endregion
    }
}
