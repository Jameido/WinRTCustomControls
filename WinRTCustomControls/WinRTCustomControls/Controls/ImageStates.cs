using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace WinRTCustomControls.Controls
{
    public class ImageStates : Control
    {
        public ImageStates()
        {
            DefaultStyleKey = typeof(ImageStates);
        }

        public ImageSource Source
        {
            get { return base.GetValue(SourceProperty) as ImageSource; }
            set { base.SetValue(SourceProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty =
          DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageStates),
              new PropertyMetadata(null, new PropertyChangedCallback(OnImageChanged)));

        private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as ImageStates;
        }

        public ImageSource PressedSource
        {
            get { return base.GetValue(PressedSourceProperty) as ImageSource; }
            set { base.SetValue(PressedSourceProperty, value); }
        }
        public static readonly DependencyProperty PressedSourceProperty =
          DependencyProperty.Register("PressedSource", typeof(ImageSource), typeof(ImageStates),
              new PropertyMetadata(null, new PropertyChangedCallback(OnPressedImageChanged)));

        private static void OnPressedImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as ImageStates;
        }

        public ImageSource DisabledSource
        {
            get { return base.GetValue(DisabledSourceProperty) as ImageSource; }
            set { base.SetValue(DisabledSourceProperty, value); }
        }
        public static readonly DependencyProperty DisabledSourceProperty =
          DependencyProperty.Register("DisabledSource", typeof(ImageSource), typeof(ImageStates),
              new PropertyMetadata(null, new PropertyChangedCallback(OnDisabledImageChanged)));

        private static void OnDisabledImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as ImageStates;
        }
    }
}
