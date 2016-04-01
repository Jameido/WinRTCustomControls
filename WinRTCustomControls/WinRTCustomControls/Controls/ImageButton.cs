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
    public class ImageButton : CustomButton
    {
        public ImageButton()
        {
            DefaultStyleKey = typeof(ImageButton);
        }

        public ImageSource ImageSource
        {
            get { return base.GetValue(ImageSourceProperty) as ImageSource; }
            set { base.SetValue(ImageSourceProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceProperty =
          DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ImageButton), null);
        
        public ImageSource PressedImageSource
        {
            get { return base.GetValue(PressedImageSourceProperty) as ImageSource; }
            set { base.SetValue(PressedImageSourceProperty, value); }
        }
        public static readonly DependencyProperty PressedImageSourceProperty =
          DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(ImageButton), null);

        public ImageSource DisabledImageSource
        {
            get { return base.GetValue(DisabledImageSourceProperty) as ImageSource; }
            set { base.SetValue(DisabledImageSourceProperty, value); }
        }
        public static readonly DependencyProperty DisabledImageSourceProperty =
          DependencyProperty.Register("DisabledImageSource", typeof(ImageSource), typeof(ImageButton), null);

        private static void OnDisabledImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = d as ImageButton;
        }
    }
}
