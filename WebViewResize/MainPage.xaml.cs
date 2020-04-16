using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WebViewResize
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            WebViewSwitch.Toggled += (o, args) =>
            {
                var swt = o as ToggleSwitch;
                if (swt.IsOn)
                {
                    RedrawBrush();
                    BrushContainer.Visibility = Visibility.Visible;
                    WebViewContainer.Visibility = Visibility.Collapsed;
                    SizeSlider.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BrushContainer.Visibility = Visibility.Collapsed;
                    WebViewContainer.Visibility = Visibility.Visible;
                    SizeSlider.Visibility = Visibility.Visible;
                }
            };

            SizeSlider.ValueChanged += (o, args) =>
            {
                Slider slider = o as Slider;
                TheWebView.Height = slider.Value;
                BrushCanvas.Height = slider.Value;
                RedrawBrush();
            };

        }

        private void RedrawBrush()
        {
            var wb = new WebViewBrush 
            { 
                SourceName = "TheWebView",
                Stretch = Stretch.UniformToFill
            };
            wb.Redraw();
            BrushDisplay.Fill = wb;
        }
    }
}
