using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

public struct ExamInfo
{
    public string Name;         // Цель исследования
    public string Result;       // Результат исследования
}

public struct Data
{
    public int RowCount;
    public string
           Type,               // Вид
           Target,             // Цель
           SCategory,          // Категория проб
           SGroup,             // Группа пробы
           ExamType,           // Вид исследований 
           ExamNum,            // Номер экспертизы
           Date,               // Дата поступления
           Name,               // Наименование образца
           Count,              // Кол-во проб
           Weight,             // Масса образцов
           CustomerData,       // ФИО и адрес заказчика
           SampleCode,         // Код образцов
           SampleDestination,  // Направление образцов
           RelatedFace,        // Ответственное лицо за испытания
           ProtocolData,       // Номер протокола и дата выдачи
                               // Подпись
                               // Примечание
           CustomerINN,        // ИНН
           FLUL,               // ФЛ/ЮЛ
           PaymentForm,        // Способ оплаты
           PaymentState;       // Состояние оплаты

    public ExamInfo[] exam;    // Экзамены
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

            // Type,               // Вид !
            //Target,             // Цель !
            //SCategory,          // Категория проб !
            //SGroup,             // Группа пробы !
            //ExamType,           // Вид исследований !
            //ExamNum,            // Номер экспертизы !
            //Date,               // Дата поступления !
            //Name,               // Наименование образца !
            //Count,              // Кол-во проб !
            //Weight,             // Масса образцов !
            //CustomerData,       // ФИО и адрес заказчика !
            //SampleCode,         // Код образцов !
            //SampleDestination,  // Направление образцов !
            //RelatedFace,        // Ответственное лицо за испытания !
            //ProtocolData,       // Номер протокола и дата выдачи !
            //// Подпись
            //// Примечание
            //CustomerINN,        // ИНН !
            //FLUL,               // ФЛ/ЮЛ !
            //PaymentForm,        // Способ оплаты !
            //PaymentState;       // Состояние оплаты !

            Data data = new Data();


            data.Type = Type.Text;
            data.Target = Target.Text;
            data.SCategory = SCategory.Text;
            data.SGroup = SGroup.Text;
            data.ExamType = ExamType.Text;
            data.ExamNum = ExamNum.Text;
            data.Date = Date.Text.ToString();
            data.Name = Name.Text;
            data.Count = Count.Text;
            data.Weight = Weight.Text;
            data.CustomerData = CustomerData.Text;
            data.SampleCode = SampleCode.Text;
            data.SampleDestination = SampleDestination.Text;
            data.RelatedFace = RelatedFace.Text;
            data.ProtocolData = ProtocolData.Text;
            data.CustomerINN = CustomerINN.Text;
            data.FLUL = FLUL.Text;
            data.PaymentForm = PaymentForm.Text;
            data.PaymentState = PaymentState.Text;

            if (ExamsData.Children.Count == 0)
            {
                data.exam[0].Name = "-";
                data.exam[0].Result = "-";
                data.RowCount = 1;
            }
            else
            {
                data.RowCount = ExamsData.Children.Count;
                data.exam = new ExamInfo[data.RowCount];

                for (int i = 0; i < ExamsData.Children.Count; i++)
                {
                    data.exam[i].Name = ((ExamData)ExamsData.Children[i]).ExamPoint;
                    data.exam[i].Result = ((ExamData)ExamsData.Children[i]).Result;
                }
            }
            AddNewEntryEventHandler(data);
        }

        public delegate void AddNewEntryEvent(Data data);
        public event AddNewEntryEvent AddNewEntryEventHandler;


        private static readonly Regex _regex = new Regex("[^0-9]+");

        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);

        }

        private void CustomerINN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }


        private void CustomerINN_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
