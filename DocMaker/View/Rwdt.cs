using DocMaker.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public class Rwdt : Control
    {

        static Rwdt()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Rwdt), new FrameworkPropertyMetadata(typeof(Rwdt)));            
        }

        public Rwdt()
        {
            contextMenu = new ContextMenu();        
            MenuItem EditRow = new MenuItem() { Header = "Изменить"};
            EditRow.Click += Edit_Click;
            SetValue(ExamPropertyKey, new ObservableCollection<String>());

            MenuItem DeleteRow = new MenuItem() { Header = "Удалить" };
            EditRow.Click += Delete_Click;
            SetValue(ExamPropertyKey, new ObservableCollection<String>());

            contextMenu.Items.Add(EditRow);
            contextMenu.Items.Add(DeleteRow);

            this.ContextMenu = contextMenu;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NewRecordPage newRecord = new NewRecordPage();
            newRecord.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {           
            

        }

        ContextMenu contextMenu;

        #region Properties

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register(
       "Type",
       typeof(string),
       typeof(Rwdt),
       new UIPropertyMetadata(null));

        public string Type
        {
            get
            {
                if (TypeProperty == null)
                    SetValue(TypeProperty, "");
                return (string)GetValue(TypeProperty);
            }
            set
            {
                SetValue(TypeProperty, value);
            }
        }



        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
     "Target",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string Target
        {
            get
            {
                if (TargetProperty == null)
                    SetValue(TargetProperty, "");
                return (string)GetValue(TargetProperty);
            }
            set
            {
                SetValue(TargetProperty, value);
            }
        }



        public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register(
     "Category",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string Category
        {
            get
            {
                if (CategoryProperty == null)
                    SetValue(CategoryProperty, "");
                return (string)GetValue(CategoryProperty);
            }
            set
            {
                SetValue(CategoryProperty, value);
            }
        }



        public static readonly DependencyProperty GroupProperty = DependencyProperty.Register(
     "Group",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string Group
        {
            get
            {
                if (GroupProperty == null)
                    SetValue(GroupProperty, "");
                return (string)GetValue(GroupProperty);
            }
            set
            {
                SetValue(GroupProperty, value);
            }

        }



        public static readonly DependencyProperty ExamTypeProperty = DependencyProperty.Register(
     "ExamType",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string ExamType
        {
            get
            {
                if (ExamTypeProperty == null)
                    SetValue(ExamTypeProperty, "");
                return (string)GetValue(ExamTypeProperty);
            }
            set
            {
                SetValue(ExamTypeProperty, value);
            }
        }



        public static readonly DependencyProperty ExamNumProperty = DependencyProperty.Register(
     "ExamNum",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string ExamNum
        {
            get
            {
                if (ExamNumProperty == null)
                    SetValue(ExamNumProperty, "0");
                return (string)GetValue(ExamNumProperty);
            }
            set
            {
                SetValue(ExamNumProperty, value);
            }
        }

        private string _examBeginNum;
        private string ExamBeginNum
        {
            get
            {
                return _examBeginNum;
            }
            set
            {
                _examBeginNum = value;
                DateChanged();
            }
        }

        private string _examEndNum;
        private string ExamEndNum
        {
            get
            {
                return _examEndNum;
            }
            set
            {
                _examEndNum = value;
                DateChanged();
            }
        }

        void DateChanged()
        {
            if (_examBeginNum == _examEndNum)
                SetValue(ExamNumProperty, _examBeginNum);
            else
                SetValue(ExamNumProperty, _examBeginNum + " + " + _examEndNum);
        }

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(
    "Date",
    typeof(string),
    typeof(Rwdt),
    new UIPropertyMetadata(null));

        public string Date
        {
            get
            {
                if (DateProperty == null)
                    SetValue(DateProperty, "");
                return (string)GetValue(DateProperty);
            }
            set
            {
                SetValue(DateProperty, value);
            }
        }



        public static readonly DependencyProperty SampleNameProperty = DependencyProperty.Register(
     "SampleName",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string SampleName
        {
            get
            {
                if (SampleNameProperty == null)
                    SetValue(SampleNameProperty, "");
                return (string)GetValue(SampleNameProperty);
            }
            set
            {
                SetValue(SampleNameProperty, value);
            }
        }



        public static readonly DependencyProperty SampleCountProperty = DependencyProperty.Register(
     "SampleCount",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string SampleCount
        {
            get
            {
                if (SampleCountProperty == null)
                    SetValue(SampleCountProperty, "");
                return (string)GetValue(SampleCountProperty);
            }
            set
            {
                SetValue(SampleCountProperty, value);
            }
        }



        public static readonly DependencyProperty SampleWeightProperty = DependencyProperty.Register(
     "SampleWeight",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string SampleWeight
        {
            get
            {
                if (SampleWeightProperty == null)
                    SetValue(SampleWeightProperty, "");
                return (string)GetValue(SampleWeightProperty);
            }
            set
            {
                SetValue(SampleWeightProperty, value);
            }
        }



        public static readonly DependencyProperty CustomerDataProperty = DependencyProperty.Register(
     "CustomerData",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string CustomerData
        {
            get
            {
                if (CustomerDataProperty == null)
                    SetValue(CustomerDataProperty, "");
                return (string)GetValue(CustomerDataProperty);
            }
            set
            {
                SetValue(CustomerDataProperty, value);
            }
        }


        public static readonly DependencyProperty SampleDirectoryProperty = DependencyProperty.Register(
     "SampleDirectory",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string SampleDirectory
        {
            get
            {
                if (SampleDirectoryProperty == null)
                    SetValue(SampleDirectoryProperty, "");
                return (string)GetValue(SampleDirectoryProperty);
            }
            set
            {
                SetValue(SampleDirectoryProperty, value);
            }
        }



        public static readonly DependencyProperty ResponsiblePersonProperty = DependencyProperty.Register(
     "ResponsiblePerson",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string ResponsiblePerson
        {
            get
            {
                if (ResponsiblePersonProperty == null)
                    SetValue(ResponsiblePersonProperty, "-");
                return (string)GetValue(ResponsiblePersonProperty);
            }
            set
            {
                SetValue(ResponsiblePersonProperty, value);
            }
        }



        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register(
     "Comment",
     typeof(string),
     typeof(Rwdt),
     new UIPropertyMetadata(null));

        public string Comment
        {
            get
            {
                if (CommentProperty == null)
                    SetValue(CommentProperty, "");
                return (string)GetValue(CommentProperty);
            }
            set
            {
                SetValue(CommentProperty, value);
            }
        }



        private static readonly DependencyPropertyKey ExamPropertyKey = DependencyProperty.RegisterReadOnly(
     "Exam",
     typeof(ObservableCollection<String>),
     typeof(Rwdt),
      new FrameworkPropertyMetadata(new ObservableCollection<String>()));

        public static readonly DependencyProperty ExamProperty = ExamPropertyKey.DependencyProperty;

        public ObservableCollection<String> Exam
        {
            get
            {
                if (ExamProperty == null)
                    SetValue(ExamProperty, "");
                return (ObservableCollection<String>)GetValue(ExamProperty);
            }
            set
            {
                SetValue(ExamProperty, value);
            }
        }

        #endregion
    }
}
