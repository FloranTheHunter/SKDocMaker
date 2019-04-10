using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DocMaker.View
{
    public class Btn : Button
    {
        //Unless you override the style it will never be rendered
        static Btn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Btn), new FrameworkPropertyMetadata(typeof(Btn)));
        }
       

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        "Text",
        typeof(string),
        typeof(Btn),
        new UIPropertyMetadata(null));

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(
            "Image",
            typeof(ImageSource),
            typeof(Btn),
            new UIPropertyMetadata(null));

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
        "Orientation",
        typeof(bool),
        typeof(Btn),
        new UIPropertyMetadata(null));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public bool Orientation
        {
            get { return (bool)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
    }
}
