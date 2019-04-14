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

public struct Data
{
    public int RowCount;
    public string Target,
           SCategory,
           SGroup,
           ExamType,
           ExamNum,
           Date,
           Name,
           Count,
           Weight,
           CustomerData,
           SampleCode,
           SampleDestination,
           RelatedFace,
           ProtocolData,
           PaymentForm,
           FLUL,
           PaymentState;
}

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
            ExamNum.Text = EntryNum.ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            WindowClosed?.Invoke();
        }

        int entryNum = 0;
        public int EntryNum
        {
            get
            {
                return entryNum;
            }
            set
            {
                ExamNum.Text = value.ToString();
                entryNum = value;
            }
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
            Data data = new Data();

            if (ExamsData.Children.Count >= 1)
                data.RowCount = ExamsData.Children.Count;
            else
                data.RowCount = 1;

            data.Target = Target.Text;
            data.SCategory = SCategory.Text;
            data.SGroup = SGroup.Text;
            data.ExamType = ExamType.Text;
            data.ExamNum = ExamNum.Text;
            data.Date = Date.DisplayDate.ToString();
            data.Name = ExamType.Name;
            data.Count = Weight.Text;
            data.CustomerData = CustomerData.Text;
            data.SampleCode = ExamType.Text;
            data.SampleDestination = SampleDestination.Text;
            data.RelatedFace = RelatedFace.Text;
            data.ProtocolData = ProtocolData.Text;
            data.PaymentForm = PaymentForm.Text;
            data.FLUL = FLUL.Text;
            data.PaymentState = PaymentState.Text;

            AddNewEntryEventHandler(data);
        }

        public delegate void AddNewEntryEvent(Data data);
        public event AddNewEntryEvent AddNewEntryEventHandler;
    }
}
