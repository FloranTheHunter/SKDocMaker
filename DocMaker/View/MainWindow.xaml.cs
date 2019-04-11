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
using DocMaker.View;
using Microsoft.Win32;
using unvell.ReoGrid;
using unvell.ReoGrid.Actions;

namespace DocMaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataGrid.ControlStyle = new ControlAppearanceStyle(unvell.ReoGrid.Graphics.SolidColor.Gray, unvell.ReoGrid.Graphics.SolidColor.LimeGreen, false);
            InitializeDataGrid();
        }


        private void InitializeDataGrid()
        {
            #region ControlStyle
            var rgcs = new ControlAppearanceStyle();
            rgcs[ControlAppearanceColors.LeadHeadNormal] = Color.FromArgb(255, 182, 182, 182);
            rgcs[ControlAppearanceColors.LeadHeadSelected] = Color.FromArgb(255, 105, 105, 105);
            rgcs[ControlAppearanceColors.LeadHeadIndicatorStart] = Color.FromArgb(180, 51, 255, 51);
            rgcs[ControlAppearanceColors.LeadHeadIndicatorEnd] = Color.FromArgb(180, 0, 255, 0);
            rgcs[ControlAppearanceColors.ColHeadSplitter] = Color.FromArgb(255, 131, 131, 131);
            rgcs[ControlAppearanceColors.ColHeadNormalStart] = Color.FromArgb(255, 182, 182, 182);
            rgcs[ControlAppearanceColors.ColHeadNormalEnd] = Color.FromArgb(255, 182, 182, 182);
            rgcs[ControlAppearanceColors.ColHeadHoverStart] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.ColHeadHoverEnd] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.ColHeadSelectedStart] = Color.FromArgb(180, 51, 255, 51);
            rgcs[ControlAppearanceColors.ColHeadSelectedEnd] = Color.FromArgb(180, 0, 153, 0);
            rgcs[ControlAppearanceColors.ColHeadFullSelectedStart] = Color.FromArgb(180, 51, 255, 51);
            rgcs[ControlAppearanceColors.ColHeadFullSelectedEnd] = Color.FromArgb(180, 0, 255, 0);
            rgcs[ControlAppearanceColors.ColHeadInvalidStart] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.ColHeadInvalidEnd] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.ColHeadText] = Color.FromArgb(255, 80, 80, 80);
            rgcs[ControlAppearanceColors.RowHeadSplitter] = Color.FromArgb(255, 131, 131, 131);
            rgcs[ControlAppearanceColors.RowHeadNormal] = Color.FromArgb(255, 150, 150, 150);
            rgcs[ControlAppearanceColors.RowHeadHover] = Color.FromArgb(255, 105, 105, 105);
            rgcs[ControlAppearanceColors.RowHeadSelected] = Color.FromArgb(180, 0, 204, 0);
            rgcs[ControlAppearanceColors.RowHeadFullSelected] = Color.FromArgb(180, 0, 255, 0);
            rgcs[ControlAppearanceColors.RowHeadInvalid] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.RowHeadText] = Color.FromArgb(255, 80, 80, 80);
            rgcs[ControlAppearanceColors.SelectionBorder] = Color.FromArgb(180, 0, 204, 0);
            rgcs[ControlAppearanceColors.SelectionFill] = Color.FromArgb(30, 0, 102, 0);
            rgcs[ControlAppearanceColors.GridBackground] = Color.FromArgb(255, 255, 255, 255);
            rgcs[ControlAppearanceColors.GridText] = Color.FromArgb(255, 0, 0, 0);
            rgcs[ControlAppearanceColors.GridLine] = Color.FromArgb(255, 233, 233, 233);
            rgcs[ControlAppearanceColors.OutlinePanelBorder] = Color.FromArgb(255, 131, 131, 131);
            rgcs[ControlAppearanceColors.OutlinePanelBackground] = Color.FromArgb(255, 182, 182, 182);
            rgcs[ControlAppearanceColors.OutlineButtonBorder] = Color.FromArgb(255, 131, 131, 131);
            rgcs[ControlAppearanceColors.OutlineButtonText] = Color.FromArgb(180, 0, 102, 0);
            rgcs[ControlAppearanceColors.SheetTabBorder] = Color.FromArgb(255, 131, 131, 131);
            rgcs[ControlAppearanceColors.SheetTabBackground] = Color.FromArgb(255, 182, 182, 182);
            rgcs[ControlAppearanceColors.SheetTabSelected] = Color.FromArgb(255, 255, 255, 255);
            DataGrid.ControlStyle = rgcs;
            #endregion



            DataGrid.Worksheets[0].Name = "Записи";
            DataGrid.Worksheets.Add(DataGrid.CreateWorksheet("Поступления"));
            DataGrid.Worksheets.Add(DataGrid.CreateWorksheet("Исследования"));
            DataGrid.Worksheets.Add(DataGrid.CreateWorksheet("Печать"));

            #region WorksheetEvents
            DataGrid.Worksheets[0].SelectionRangeChanging += MainWindow_SelectionRangeChanged;
            DataGrid.Worksheets[1].SelectionRangeChanging += MainWindow_SelectionRangeChanged;
            DataGrid.Worksheets[2].SelectionRangeChanging += MainWindow_SelectionRangeChanged;
            DataGrid.Worksheets[3].SelectionRangeChanging += MainWindow_SelectionRangeChanged;

            DataGrid.Worksheets[0].SelectionRangeChanged += MainWindow_SelectionRangeChanged;
            DataGrid.Worksheets[1].SelectionRangeChanged += MainWindow_SelectionRangeChanged;
            DataGrid.Worksheets[2].SelectionRangeChanged += MainWindow_SelectionRangeChanged;
            DataGrid.Worksheets[3].SelectionRangeChanged += MainWindow_SelectionRangeChanged;
            #endregion

            DataGrid.Worksheets[0].ColumnCount = 22;
            DataGrid.Worksheets[0].RowCount = 20000;
            DataGrid.Worksheets[1].ColumnCount = 62;
            DataGrid.Worksheets[1].RowCount = 1000;
            DataGrid.Worksheets[2].ColumnCount = 15;
            DataGrid.Worksheets[2].RowCount = 20000;
            DataGrid.Worksheets[3].ColumnCount = 15;
            DataGrid.Worksheets[3].RowCount = 20000;

            DataGrid.SheetTabNewButtonVisible = false;

            #region List 1 Setup
            var namedrange = DataGrid.Worksheets[0].DefineNamedRange("Заголовок", "A1:V1");
            namedrange.Data = new object[]
                { "Вид", "Цель", "Категория проб", "Группа пробы", "Вид исследований", "Номер экспертизы / протокола", "Дата поступления", "Наименование образца(пробы)",
              "Кол - во проб", "Количество образцов(проб) масса" ,"ФИО Заказчика, адрес", "Код образцов(проб)", "Цель исследования(испытаний) и измерений", "Направление образцов(проб)",
              "Ответственное лицо за испытания", "Результат исследования(испытания) и измерений, дата выдачи протокола испытания", "Номер протокола и дата выдачи", "Подпись", "Примечание", "Форма оплаты", "ФЛ/ЮЛ", "Состояние оплаты"};

            DataGrid.Worksheets[0].RowHeaders[0].Height = 100;
            DataGrid.Worksheets[0].ColumnHeaders["G"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["H"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["F"].Width = 150;
            DataGrid.Worksheets[0].ColumnHeaders["M"].Width = 150;
            DataGrid.Worksheets[0].ColumnHeaders["P"].Width = 150;
            DataGrid.Worksheets[0].ColumnHeaders["N"].Width = 150;
            DataGrid.Worksheets[0].ColumnHeaders["O"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["S"].Width = 150;
            DataGrid.Worksheets[0].Ranges["A1:V1"].Style.HorizontalAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[0].Ranges["A1:V1"].Style.VerticalAlign = ReoGridVerAlign.Middle;
            DataGrid.Worksheets[0].Ranges["A1:V1"].Style.TextWrap = TextWrapMode.WordBreak;
            DataGrid.Worksheets[0].Ranges["A1:V1"].Style.Bold = true;
            DataGrid.Worksheets[0].Ranges["A1:V1"].Border.Outside = RangeBorderStyle.BlackSolid;
            #endregion

            #region List 2 Setup
            DataGrid.Worksheets[1].MergeRange("A1:BJ1");
            DataGrid.Worksheets[1].Cells["A1"].Data = $"Поступление проб в БУ ветеринарии \"БРНПВЛ\" в  {DateTime.Now.Year} году";
            //DataGrid.Worksheets[1].Cells["A1"].Style.HAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[1].Cells["A1"].Style.Bold = true;
            DataGrid.Worksheets[1].Cells["A1"].Style.FontSize = 16;
            DataGrid.Worksheets[1].Cells["A1"].Style.Indent = 20;
            DataGrid.Worksheets[1].MergeRange("A2:BJ2");
            DataGrid.Worksheets[1].Cells["A2"].Data = $"Испытательный центр";
            //DataGrid.Worksheets[1].Cells["A2"].Style.HAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[1].Cells["A2"].Style.FontSize = 14;
            DataGrid.Worksheets[1].Cells["A2"].Style.Indent = 20;

            DataGrid.Worksheets[1].MergeRange("A5:BJ5");
            DataGrid.Worksheets[1].Cells["A9"].Data = $"По общелабораторным исследованиям (результат исследования)";
            //DataGrid.Worksheets[1].Cells["A2"].Style.HAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[1].Cells["A9"].Style.FontSize = 14;
            DataGrid.Worksheets[1].Cells["A9"].Style.Indent = 20;
            DataGrid.Worksheets[1].Ranges["A9:BJ9"].Border.Outside = RangeBorderStyle.BlackSolid;

            DataGrid.Worksheets[1].Ranges["A1:BJ2"].Border.Outside = RangeBorderStyle.BlackSolid;

            DataGrid.Worksheets[1].Ranges["A3:BJ4"].Border.All = RangeBorderStyle.BlackSolid;

            DataGrid.Worksheets[1].Ranges["A3:BJ4"].Style.TextWrap = TextWrapMode.BreakAll;
            DataGrid.Worksheets[1].Ranges["B3:BJ4"].Style.HorizontalAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[1].Ranges["A3:BJ4"].Style.VerticalAlign = ReoGridVerAlign.Top;
            #region Columns
            DataGrid.Worksheets[1].MergeRange("A3:A4");
            DataGrid.Worksheets[1].MergeRange("B3:D3");
            DataGrid.Worksheets[1].ColumnHeaders["A"].Width = 120;
            DataGrid.Worksheets[1].Cells["A3"].Data = "Наименование продукции";
            DataGrid.Worksheets[1].Cells["B3"].Data = "Январь";

            DataGrid.Worksheets[1].MergeRange("E3:E4");
            DataGrid.Worksheets[1].MergeRange("F3:I3");
            DataGrid.Worksheets[1].Cells["E3"].Data = "Итого за январь";
            DataGrid.Worksheets[1].Cells["F3"].Data = "Февраль";

            DataGrid.Worksheets[1].MergeRange("J3:J4");
            DataGrid.Worksheets[1].MergeRange("K3:O3");
            DataGrid.Worksheets[1].Cells["J3"].Data = "Итого за февраль";
            DataGrid.Worksheets[1].Cells["K3"].Data = "Март";
            
            DataGrid.Worksheets[1].MergeRange("P3:P4");
            DataGrid.Worksheets[1].MergeRange("Q3:T3");
            DataGrid.Worksheets[1].Cells["P3"].Data = "Итого за март";
            DataGrid.Worksheets[1].Cells["Q3"].Data = "Апрель";

            DataGrid.Worksheets[1].MergeRange("U3:U4");
            DataGrid.Worksheets[1].MergeRange("V3:Y3");
            DataGrid.Worksheets[1].Cells["U3"].Data = "Итого за апрель";
            DataGrid.Worksheets[1].Cells["V3"].Data = "Май";
            
            DataGrid.Worksheets[1].MergeRange("Z3:Z4");
            DataGrid.Worksheets[1].MergeRange("AA3:AE3");
            DataGrid.Worksheets[1].Cells["Z3"].Data = "Итого за май";
            DataGrid.Worksheets[1].Cells["AA3"].Data = "Июнь";

            DataGrid.Worksheets[1].MergeRange("AF3:AF4");
            DataGrid.Worksheets[1].MergeRange("AG3:AJ3");
            DataGrid.Worksheets[1].Cells["F3"].Data = "Итого за июнь";
            DataGrid.Worksheets[1].Cells["AG3"].Data = "Июль";            
            
            DataGrid.Worksheets[1].MergeRange("AK3:AK4");
            DataGrid.Worksheets[1].MergeRange("AL3:AO3");
            DataGrid.Worksheets[1].Cells["AK3"].Data = "Итого за июль";
            DataGrid.Worksheets[1].Cells["AL3"].Data = "Август";
            
            DataGrid.Worksheets[1].MergeRange("AP3:AP4");
            DataGrid.Worksheets[1].MergeRange("AQ3:AT3");
            DataGrid.Worksheets[1].Cells["AP3"].Data = "Итого за август";
            DataGrid.Worksheets[1].Cells["AQ3"].Data = "Сентябрь";
            
            DataGrid.Worksheets[1].MergeRange("AU3:AU4");
            DataGrid.Worksheets[1].MergeRange("AV3:AY3");
            DataGrid.Worksheets[1].Cells["AU3"].Data = "Итого за сентябрь";
            DataGrid.Worksheets[1].Cells["AV3"].Data = "Октябрь";
            
            DataGrid.Worksheets[1].MergeRange("AZ3:AZ4");
            DataGrid.Worksheets[1].MergeRange("BA3:BD3");
            DataGrid.Worksheets[1].Cells["AZ3"].Data = "Итого за октябрь";
            DataGrid.Worksheets[1].Cells["BA3"].Data = "Ноябрь";
            
            DataGrid.Worksheets[1].MergeRange("BE3:BE4");
            DataGrid.Worksheets[1].MergeRange("BF3:BI3");
            DataGrid.Worksheets[1].Cells["BE3"].Data = "Итого за ноябрь";
            DataGrid.Worksheets[1].Cells["BF3"].Data = "Декабрь";

            DataGrid.Worksheets[1].MergeRange("BJ3:BJ4");
            DataGrid.Worksheets[1].Cells["BJ3"].Data = "Итого за Декабрь";            

            #endregion

            DataGrid.Worksheets[1].Cells["A6"].Data = "Всего ИЦ";
            DataGrid.Worksheets[1].Ranges["A6:BJ6"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A7"].Data = $"Всего ИЦ за {DateTime.Now.AddYears(-1).Year}";
            DataGrid.Worksheets[1].Ranges["A7:BJ7"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Blue;
            DataGrid.Worksheets[1].Ranges["A7:BJ7"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A8"].Data = "Динамика";
            DataGrid.Worksheets[1].Ranges["A8:BJ8"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Red;
            DataGrid.Worksheets[1].Ranges["A8:BJ8"].Style.Bold = true;
            //-----------------------
            DataGrid.Worksheets[1].Cells["A10"].Data = "Всего ВЛ";
            DataGrid.Worksheets[1].Ranges["A10:BJ10"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A11"].Data = $"Всего ВЛ за {DateTime.Now.AddYears(-1).Year}";
            DataGrid.Worksheets[1].Ranges["A11:BJ11"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Blue;
            DataGrid.Worksheets[1].Ranges["A11:BJ11"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A12"].Data = "Динамика";
            DataGrid.Worksheets[1].Ranges["A12:BJ12"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Red;
            DataGrid.Worksheets[1].Ranges["A12:BJ12"].Style.Bold = true;

            DataGrid.Worksheets[1].Ranges["A13:BJ13"].Border.Outside = RangeBorderStyle.BlackSolid;
            DataGrid.Worksheets[1].MergeRange("A13:BJ13");
            DataGrid.Worksheets[1].Cells["A13"].Data = $"Общее";
            DataGrid.Worksheets[1].Cells["A13"].Style.Indent = 20;
            DataGrid.Worksheets[1].Cells["A13"].Style.FontSize = 14;            
            #endregion
        }

        private void MainWindow_SelectionRangeChanged(object sender, unvell.ReoGrid.Events.RangeEventArgs e)
        {


            var dt = ((Worksheet)sender).GetCell(e.Range.StartPos.ToAddress());
            if (dt == null)
                SelectionDataBox.Text = "";
            else
            if (dt.HasFormula == true)
                SelectionDataBox.Text = dt.Formula;
            else
                SelectionDataBox.Text = dt.Data != null ? dt.Data.ToString() : "";
            SelectionRangeBox.Text = e.Range.ToAddress();
        }

        #region Pages
        private static NewRecordPage _wndRecord;
        private static NewExaminePage _wndExamine;

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (_wndRecord == null)
            {
                _wndRecord = new NewRecordPage();
                _wndRecord.WindowClosed += _wndRecord_WindowClosed;
                _wndRecord.ShowInTaskbar = false;
                _wndRecord.Owner = this;
                _wndRecord.Show();
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            if (_wndExamine == null)
            {
                _wndExamine = new NewExaminePage();
                _wndExamine.WindowClosed += _wndExamine_WindowClosed;
                _wndExamine.ShowInTaskbar = false;
                _wndExamine.Owner = this;
                _wndExamine.Show();
            }
        }

        private void _wndRecord_WindowClosed()
        {
            _wndRecord = null;
        }

        private void _wndExamine_WindowClosed()
        {
            _wndExamine = null;
        }
        #endregion

        #region Context Events

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {

            int dif = (int)DataGrid.CurrentWorksheet.SelectionRange.EndPos.Row - (int)DataGrid.CurrentWorksheet.SelectionRange.StartPos.Row;


            DataGrid.DoAction(new RemoveRowsAction((int)DataGrid.CurrentWorksheet.SelectionRange.StartPos.Row, dif + 1));
        }

        private void InsertTopItem_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.DoAction(new InsertRowsAction((int)DataGrid.CurrentWorksheet.SelectionRange.StartPos.Row, 1));
        }

        private void InsertBottomItem_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.DoAction(new InsertRowsAction((int)DataGrid.CurrentWorksheet.SelectionRange.StartPos.Row + 1, 1));
        }

        private void DeleteCell_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.DoAction(new RemoveRangeDataAction(DataGrid.CurrentWorksheet.SelectionRange));
        }

        private void MergeItem_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.DoAction(new MergeRangeAction(DataGrid.CurrentWorksheet.SelectionRange));
        }

        private void UnMergeItem_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.DoAction(new UnmergeRangeAction(DataGrid.CurrentWorksheet.SelectionRange));

        }

        private void SetBorderItem_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.DoAction(new SetRangeBorderAction(DataGrid.CurrentWorksheet.SelectionRange, BorderPositions.Outside, RangeBorderStyle.BlackBoldSolid));
        }

        private void UnSetBorderItem_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.DoAction(new SetRangeBorderAction(DataGrid.CurrentWorksheet.SelectionRange, BorderPositions.Outside, RangeBorderStyle.Empty));
        }
        #endregion

        #region File Managment Buttons

        private void CreateNew(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show(this, "Сохранить текущий документ?", "Создать документ", MessageBoxButton.YesNoCancel))
            {
                case
                    MessageBoxResult.Yes:
                    Save(this, new RoutedEventArgs());
                    DataGrid.Reset();
                    InitializeDataGrid();
                    break;
                case
                    MessageBoxResult.No:
                    DataGrid.Reset();
                    InitializeDataGrid();
                    break;
                default:
                    break;
            }

        }

        private void Save(object sender, RoutedEventArgs e)

        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Filter = "Excel Files|*.xlsx";
            saveFile.Title = "Сохранить как";
            saveFile.FileName = "Новый документ";
            saveFile.AddExtension = true;
            if (saveFile.ShowDialog(this) == true)
            {
                DataGrid.Save(saveFile.FileName);
            }

        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show(this, "Сохранить текущий документ?", "Открыть", MessageBoxButton.YesNoCancel))
            {
                case
                    MessageBoxResult.Yes:
                    DataGrid.Reset();
                    break;
                case
                    MessageBoxResult.No:
                    DataGrid.Reset();
                    break;
                default:
                    return;
                    //   break;
            }

            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Excel Files|*.xlsx";
            openFile.Title = "Открыть";
            openFile.FileName = "Новый документ";
            openFile.Multiselect = false;
            openFile.AddExtension = true;
            if (openFile.ShowDialog(this) == true)
            {
                try
                {
                    DataGrid.Reset();
                    DataGrid.Load(openFile.FileName, unvell.ReoGrid.IO.FileFormat.Excel2007);
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Не удается открыть файл: файл открыт в другой программе", "Ошибка доступа");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.StackTrace, "Ошибка");
                }
            }
        }

        #endregion
    }
}
