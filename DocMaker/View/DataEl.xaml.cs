using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DocMaker.View
{
    /// <summary>
    /// Логика взаимодействия для DataEl.xaml
    /// </summary>
    public partial class DataEl : UserControl
    {
        public DataEl()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(DataEl), new FrameworkPropertyMetadata(typeof(DataEl)));
            InitializeComponent();
        }

        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register(
        "Result",
        typeof(string),
        typeof(DataEl),
        new UIPropertyMetadata(null));

        public string Result
        {
            get { return (string)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ExamProperty = DependencyProperty.Register(
       "Exam",
       typeof(string),
       typeof(DataEl),
       new UIPropertyMetadata(null));

        public string Exam
        {
            get { return (string)GetValue(ExamProperty); }
            set { SetValue(ExamProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
       "Text",
       typeof(string),
       typeof(DataEl),
       new UIPropertyMetadata(null));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}
