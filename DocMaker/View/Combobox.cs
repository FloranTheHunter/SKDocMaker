using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DocMaker.View
{
    class MyCombobox : ComboBox
    {
        static MyCombobox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCombobox), new FrameworkPropertyMetadata(typeof(MyCombobox)));
        }


        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        "Title",
        typeof(string),
        typeof(MyCombobox),
        new UIPropertyMetadata(null));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


    }
}
