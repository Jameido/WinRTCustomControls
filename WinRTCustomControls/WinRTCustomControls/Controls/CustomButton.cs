using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace WinRTCustomControls.Controls
{
    public class CustomButton : Control
    {
        public CustomButton()
        {
            DefaultStyleKey = typeof(CustomButton);
        }
        
        public SolidColorBrush PressedBackground
        {
            get { return base.GetValue(PressedBackgroundProperty) as SolidColorBrush; }
            set { base.SetValue(PressedBackgroundProperty, value); }
        }
        public static readonly DependencyProperty PressedBackgroundProperty =
          DependencyProperty.Register("PressedBackground", typeof(SolidColorBrush), typeof(CustomButton),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public SolidColorBrush DisabledBackground
        {
            get { return base.GetValue(DisabledBackgroundProperty) as SolidColorBrush; }
            set { base.SetValue(DisabledBackgroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledBackgroundProperty =
          DependencyProperty.Register("DisabledBackground", typeof(SolidColorBrush), typeof(CustomButton),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));
        
        public SolidColorBrush PressedBorderBrush
        {
            get { return base.GetValue(PressedBorderBrushProperty) as SolidColorBrush; }
            set { base.SetValue(PressedBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PressedBorderBrushProperty =
          DependencyProperty.Register("PressedBorderBrush", typeof(SolidColorBrush), typeof(CustomButton),
              new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public SolidColorBrush DisabledBorderBrush
        {
            get { return base.GetValue(DisabledBorderBrushProperty) as SolidColorBrush; }
            set { base.SetValue(DisabledBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty DisabledBorderBrushProperty =
          DependencyProperty.Register("DisabledBorderBrush", typeof(SolidColorBrush), typeof(CustomButton),
              new PropertyMetadata(new SolidColorBrush(Colors.Gray)));
        
        public SolidColorBrush PressedForeground
        {
            get { return base.GetValue(PressedForegroundProperty) as SolidColorBrush; }
            set { base.SetValue(PressedForegroundProperty, value); }
        }
        public static readonly DependencyProperty PressedForegroundProperty =
          DependencyProperty.Register("PressedForeground", typeof(SolidColorBrush), typeof(CustomButton),
              new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public SolidColorBrush DisabledForeground
        {
            get { return base.GetValue(DisabledForegroundProperty) as SolidColorBrush; }
            set { base.SetValue(DisabledForegroundProperty, value); }
        }
        public static readonly DependencyProperty DisabledForegroundProperty =
          DependencyProperty.Register("DisabledForeground", typeof(SolidColorBrush), typeof(CustomButton),
              new PropertyMetadata(new SolidColorBrush(Colors.Gray)));
    }
}
