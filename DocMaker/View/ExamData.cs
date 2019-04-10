using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ExamData : TextBox   
    {
        static ExamData()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExamData), new FrameworkPropertyMetadata(typeof(ExamData)));            
        }

        public ExamData()
        {            
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Items.Add(new MenuItem() { Header = "Удалить"});
            ((MenuItem)this.ContextMenu.Items[0]).Click += ExamData_Click;
        }

        private void ExamData_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this);
            ((StackPanel)parent).Children.Remove(this);
         //   throw new NotImplementedException();
        }

        public static readonly DependencyProperty ExamPointProperty = DependencyProperty.Register(
     "ExamPoint",
     typeof(string),
     typeof(ExamData),
     new UIPropertyMetadata(null));

        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register(
        "Result",
        typeof(string),
        typeof(ExamData),
        new UIPropertyMetadata(null));


        public string ExamPoint
        {
            get
            {
                if (ExamPointProperty == null)
                    SetValue(ExamPointProperty, "");
                return (string)GetValue(ExamPointProperty);
            }
            set
            {
                SetValue(ExamPointProperty, value);
            }
        }

        public string Result
        {
            get
            {
                if (ResultProperty == null)
                    SetValue(ResultProperty, "");
                return (string)GetValue(ResultProperty);
            }
            set
            {
                SetValue(ResultProperty, value);
            }
        }
    }
}
