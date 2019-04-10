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
using System.Windows.Shapes;

namespace DocMaker.View
{
    /// <summary>
    /// Логика взаимодействия для NewRecordPage.xaml
    /// </summary>
    public partial class NewRecordPage : Window
    {
        public NewRecordPage()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            WindowClosed?.Invoke();
        }

        public delegate void WindowClosedEventHandler();
        public event WindowClosedEventHandler WindowClosed;

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (ExamTypeSelection.SelectedIndex == -1)
                return;

            var exam = ExamTypeSelection.Text;
            var result = ExamResultBox.Text;
            ExamsData.Children.Add(new ExamData() { ExamPoint = exam, Result = result });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
