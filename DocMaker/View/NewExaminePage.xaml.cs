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
using System.Windows.Shapes;

namespace DocMaker.View
{
    /// <summary>
    /// Логика взаимодействия для NewExaminePage.xaml
    /// </summary>
    public partial class NewExaminePage : Window
    {
        public NewExaminePage()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (WindowClosed != null)
                WindowClosed();
        }

        public delegate void WindowClosedEventHandler();
        public event WindowClosedEventHandler WindowClosed;
    }
}
