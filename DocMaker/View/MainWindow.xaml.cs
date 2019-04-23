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
using unvell.ReoGrid.CellTypes;

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
            DataGrid.Worksheets[0].RowCount = 2;
            DataGrid.Worksheets[1].ColumnCount = 62;
            DataGrid.Worksheets[1].RowCount = 20;
            DataGrid.Worksheets[2].ColumnCount = 3;
            DataGrid.Worksheets[2].RowCount = 10;
            DataGrid.Worksheets[3].ColumnCount = 12;
            DataGrid.Worksheets[3].RowCount = 6;
            DataGrid.SheetTabNewButtonVisible = false;

            #region List 1 Setup
            var namedrange = DataGrid.Worksheets[0].DefineNamedRange("Заголовок", "A1:V1");
            namedrange.Data = new object[]
                { "Вид", "Цель", "Категория проб", "Группа пробы", "Вид исследований", "Номер экспертизы / протокола", "Дата поступления",
                    "Наименование образца(пробы)","Кол - во проб", "Количество образцов(проб) масса" ,"ФИО Заказчика, адрес", "Код образцов(проб)",
                    "Цель исследования(испытаний) и измерений", "Направление образцов(проб)", "Ответственное лицо за испытания",
                    "Результат исследования(испытания) и измерений, дата выдачи протокола испытания", "Номер протокола и дата выдачи", "Подпись", "Примечание",
                    "ФЛ/ЮЛ", "ИНН", "Форма оплаты", "Статус оплаты"
                };

            DataGrid.Worksheets[0].RowHeaders[0].Height = 100;

            DataGrid.Worksheets[0].ColumnHeaders["G"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["H"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["J"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["F"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["K"].Width = 150;
            DataGrid.Worksheets[0].ColumnHeaders["M"].Width = 150;
            DataGrid.Worksheets[0].ColumnHeaders["P"].Width = 170;
            DataGrid.Worksheets[0].ColumnHeaders["N"].Width = 150;
            DataGrid.Worksheets[0].ColumnHeaders["O"].Width = 100;
            DataGrid.Worksheets[0].ColumnHeaders["Q"].Width = 150;
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

            DataGrid.Worksheets[1].MergeRange("A9:BJ9");
            DataGrid.Worksheets[1].Cells["A9"].Data = $"По общелабораторным исследованиям (результат исследования)";
            //DataGrid.Worksheets[1].Cells["A2"].Style.HAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[1].Cells["A9"].Style.FontSize = 14;
            DataGrid.Worksheets[1].Cells["A9"].Style.Indent = 20;
            DataGrid.Worksheets[1].Ranges["A9:BJ9"].Border.Outside = RangeBorderStyle.BlackSolid;

            DataGrid.Worksheets[1].Ranges["A1:BJ2"].Border.Outside = RangeBorderStyle.BlackSolid;

            DataGrid.Worksheets[1].Ranges["A3:BJ4"].Border.All = RangeBorderStyle.BlackSolid;

            #region Columns
            DataGrid.Worksheets[1].MergeRange("A3:A4");

            DataGrid.Worksheets[1].Cells["B6"].Formula = "SUM($B$5:$B5)";
            DataGrid.Worksheets[1].Cells["C6"].Formula = "SUM($C$5:$C5)";
            DataGrid.Worksheets[1].Cells["D6"].Formula = "SUM($D$5:$D5)";

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
            DataGrid.Worksheets[1].Cells["AF3"].Data = "Итого за июнь";
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

            DataGrid.Worksheets[1].Ranges["A3:BJ4"].Style.TextWrap = TextWrapMode.BreakAll;
            DataGrid.Worksheets[1].Ranges["B3:BJ4"].Style.HorizontalAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[1].Ranges["A3:BJ4"].Style.VerticalAlign = ReoGridVerAlign.Top;

            DataGrid.Worksheets[1].Cells["A6"].Data = "Всего ИЦ";
            DataGrid.Worksheets[1].Ranges["A6:BJ6"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A7"].Data = $"Всего ИЦ за {DateTime.Now.AddYears(-1).Year}";
            DataGrid.Worksheets[1].Ranges["A7:BJ7"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Blue;
            DataGrid.Worksheets[1].Ranges["A7:BJ7"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A8"].Data = "Динамика";
            DataGrid.Worksheets[1].Ranges["A8:BJ8"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Red;
            DataGrid.Worksheets[1].Ranges["A8:BJ8"].Style.Bold = true;
            //-----------------------
            DataGrid.Worksheets[1].Cells["A11"].Data = "Всего ВЛ";
            DataGrid.Worksheets[1].Ranges["A10:BJ10"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A12"].Data = $"Всего ВЛ за {DateTime.Now.AddYears(-1).Year}";
            DataGrid.Worksheets[1].Ranges["A11:BJ11"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Blue;
            DataGrid.Worksheets[1].Ranges["A11:BJ11"].Style.Bold = true;

            DataGrid.Worksheets[1].Cells["A13"].Data = "Динамика";
            DataGrid.Worksheets[1].Ranges["A12:BJ12"].Style.TextColor = unvell.ReoGrid.Graphics.SolidColor.Red;
            DataGrid.Worksheets[1].Ranges["A12:BJ12"].Style.Bold = true;

            DataGrid.Worksheets[1].Ranges["A14:BJ14"].Border.Outside = RangeBorderStyle.BlackSolid;
            DataGrid.Worksheets[1].MergeRange("A14:BJ14");
            DataGrid.Worksheets[1].Cells["A14"].Data = $"Общее";
            DataGrid.Worksheets[1].Cells["A14"].Style.Indent = 20;
            DataGrid.Worksheets[1].Cells["A14"].Style.FontSize = 14;
            #endregion

            #region List 3
            DataGrid.Worksheets["Печать"].MergeRange("A1:B4");
            DataGrid.Worksheets["Печать"].MergeRange("C1:J1");
            DataGrid.Worksheets["Печать"].MergeRange("C2:J2");
            DataGrid.Worksheets["Печать"].MergeRange("C3:J3");
            DataGrid.Worksheets["Печать"].MergeRange("C4:J4");
            DataGrid.Worksheets["Печать"].MergeRange("K1:L3");
            DataGrid.Worksheets["Печать"].MergeRange("K4:L4");
            DataGrid.Worksheets["Печать"].Ranges["A1:L5"].Border.All = unvell.ReoGrid.RangeBorderStyle.BlackSolid;
            DataGrid.Worksheets["Печать"].Ranges["A1:L4"].Style.HorizontalAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets["Печать"].Ranges["A1:L4"].Style.VerticalAlign = ReoGridVerAlign.Middle;
            DataGrid.Worksheets["Печать"].Ranges["A1:L4"].Style.TextWrap = TextWrapMode.WordBreak;
            DataGrid.Worksheets["Печать"].Ranges["A1:L5"].Style.Bold = true;
            DataGrid.Worksheets["Печать"].Cells["K4"].DataFormat = unvell.ReoGrid.DataFormat.CellDataFormatFlag.Text;
            DataGrid.Worksheets["Печать"].Cells["C1"].Data = "Бюджетное учреждение ветеринарии";
            DataGrid.Worksheets["Печать"].Cells["C2"].Data = "«Бурятская республиканская научно-производственная ветеринарная лаборатория»";
            DataGrid.Worksheets["Печать"].Cells["C3"].Data = "Испытательный центр";
            DataGrid.Worksheets["Печать"].Cells["C4"].Data = "Отдел приема проб и выдачи результатов";
            DataGrid.Worksheets["Печать"].Cells["K1"].Data = "Система менеджмента качества";
            DataGrid.Worksheets["Печать"].Cells["K4"].Data = @"03-08-03-01";
            DataGrid.Worksheets["Печать"].ColumnHeaders[0].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[1].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[2].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[3].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[4].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[5].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[6].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[7].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[8].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[9].Width = 170;
            DataGrid.Worksheets["Печать"].ColumnHeaders[10].Width = 150;
            DataGrid.Worksheets["Печать"].ColumnHeaders[11].Width = 150;


            DataGrid.Worksheets["Печать"].Cells["A5"].Data = "Вх. № п/п";
            DataGrid.Worksheets["Печать"].Cells["B5"].Data = "Дата поступления";
            DataGrid.Worksheets["Печать"].Cells["C5"].Data = "Наименование образца (пробы)";
            DataGrid.Worksheets["Печать"].Cells["D5"].Data = "Масса";
            DataGrid.Worksheets["Печать"].Cells["E5"].Data = "ФИО Заказчика, адрес";
            DataGrid.Worksheets["Печать"].Cells["F5"].Data = "Код образцов (проб)";
            DataGrid.Worksheets["Печать"].Cells["G5"].Data = "Цель исследования (испытаний) и измерений";
            DataGrid.Worksheets["Печать"].Cells["H5"].Data = "Направление образцов (проб)";
            DataGrid.Worksheets["Печать"].Cells["I5"].Data = "Ответсвенное лицо";
            DataGrid.Worksheets["Печать"].Cells["J5"].Data = "Результат исследования (испытания) и измерений, дата выдачи протокола испытаний";
            DataGrid.Worksheets["Печать"].Cells["K5"].Data = "Подпись";
            DataGrid.Worksheets["Печать"].Cells["L5"].Data = "Примечание";
            DataGrid.Worksheets["Печать"].Ranges["A5:L5"].Style.TextWrap = TextWrapMode.WordBreak;
            DataGrid.Worksheets["Печать"].Ranges["A5:L5"].Style.HorizontalAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets["Печать"].RowHeaders[4].Height = 100;
            DataGrid.Worksheets["Печать"].Ranges["A5:L5"].Style.VerticalAlign = ReoGridVerAlign.Middle;
            try
            {
                BitmapImage bimage = new BitmapImage();
                bimage.BeginInit();
                bimage.UriSource = new Uri("Source\\Лого.jpg", UriKind.Relative);
                bimage.EndInit();
                var imageObj = new unvell.ReoGrid.Drawing.ImageObject(bimage) { Location = new unvell.ReoGrid.Graphics.Point(2, 2), Size = new unvell.ReoGrid.Graphics.Size(75, 75), };
                DataGrid.Worksheets["Печать"].FloatingObjects.Add(imageObj);
            }
            catch
            {
                MessageBox.Show("Изображение \"Лого.png\" не найдено");
            }
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
        private static Settings _wndSettings;

        private void Btn_Click(object sender, RoutedEventArgs e)
        {

            int count = 0;
            DataGrid.Worksheets[0].IterateCells(new RangePosition(2, 5, DataGrid.Worksheets[0].MaxContentRow + 1, 1), (row, col, cell) =>
            {

                if (cell.Data != "" || cell.Data != null)
                    count++;
                return true;
            });

            if (_wndRecord == null)
            {

                _wndRecord = new NewRecordPage();
                _wndRecord.WindowClosed += _wndRecord_WindowClosed;
                _wndRecord.ShowInTaskbar = false;
                _wndRecord.Owner = this;
                _wndRecord.AddNewEntryEventHandler += _wndRecord_AddNewEntryEventHandler;
                _wndRecord.Show();
            }

            _wndRecord.EntryNum = count;


        }

        private void _wndRecord_AddNewEntryEventHandler(Data data)
        {
            #region List1
            int startLocR = DataGrid.Worksheets[0].MaxContentRow + 1;
            int endlocR = DataGrid.Worksheets[0].MaxContentRow + data.RowCount + 1;
            int endlocC = DataGrid.Worksheets[0].MaxContentCol + 1;
            DataGrid.Worksheets[0].InsertRows(startLocR, data.RowCount);

            for (int i = startLocR; i < endlocR; i++)
            {
                DataGrid.Worksheets[0].Ranges[i, 12, 1, 1].Data = data.exam[i - startLocR].Name;
                DataGrid.Worksheets[0].Ranges[i, 15, 1, 1].Data = data.exam[i - startLocR].Result;
            }

            for (int i = 0; i < 12; i++)
            {
                DataGrid.Worksheets[0].MergeRange(startLocR, i, endlocR - startLocR, 1);
            }

            for (int i = 13; i < 15; i++)
            {
                DataGrid.Worksheets[0].MergeRange(startLocR, i, endlocR - startLocR, 1);
            }

            for (int i = 16; i < endlocC; i++)
            {
                DataGrid.Worksheets[0].MergeRange(startLocR, i, endlocR - startLocR, 1);
            }

            DataGrid.Worksheets[0].Ranges[startLocR, 0, endlocR - startLocR, 1].Data = data.Type;
            DataGrid.Worksheets[0].Ranges[startLocR, 1, endlocR - startLocR, 1].Data = data.Target;
            DataGrid.Worksheets[0].Ranges[startLocR, 2, endlocR - startLocR, 1].Data = data.SCategory;
            DataGrid.Worksheets[0].Ranges[startLocR, 3, endlocR - startLocR, 1].Data = data.SGroup;
            DataGrid.Worksheets[0].Ranges[startLocR, 4, endlocR - startLocR, 1].Data = data.ExamType;
            DataGrid.Worksheets[0].Ranges[startLocR, 5, endlocR - startLocR, 1].Data = data.ExamNum;
            DataGrid.Worksheets[0].Ranges[startLocR, 6, endlocR - startLocR, 1].Data = data.Date;
            DataGrid.Worksheets[0].Ranges[startLocR, 7, endlocR - startLocR, 1].Data = data.Name;
            DataGrid.Worksheets[0].Ranges[startLocR, 8, endlocR - startLocR, 1].Data = data.Count;
            DataGrid.Worksheets[0].Ranges[startLocR, 9, endlocR - startLocR, 1].Data = data.Weight;
            DataGrid.Worksheets[0].Ranges[startLocR, 10, endlocR - startLocR, 1].Data = data.CustomerData;
            //DataGrid.Worksheets[0].Ranges[startLocR, 11, endlocR - startLocR, 1].Data = data.CustomerINN;
            DataGrid.Worksheets[0].Ranges[startLocR, 11, endlocR - startLocR, 1].Data = data.SampleCode;
            DataGrid.Worksheets[0].Ranges[startLocR, 13, endlocR - startLocR, 1].Data = data.SampleDestination;
            DataGrid.Worksheets[0].Ranges[startLocR, 14, endlocR - startLocR, 1].Data = data.RelatedFace;
            DataGrid.Worksheets[0].Ranges[startLocR, 16, endlocR - startLocR, 1].Data = data.ProtocolData;

            DataGrid.Worksheets[0].Ranges[startLocR, 19, endlocR - startLocR, 1].Data = data.FLUL;
            DataGrid.Worksheets[0].Ranges[startLocR, 20, endlocR - startLocR, 1].Data = data.CustomerINN;
            DataGrid.Worksheets[0].Ranges[startLocR, 21, endlocR - startLocR, 1].Data = data.PaymentForm;
            DataGrid.Worksheets[0].Ranges[startLocR, 22, endlocR - startLocR, 1].Data = data.PaymentState;

            DataGrid.Worksheets[0].Ranges[startLocR, 0, endlocR, endlocC].Style.HorizontalAlign = ReoGridHorAlign.Center;
            DataGrid.Worksheets[0].Ranges[startLocR, 0, endlocR, endlocC].Style.TextWrap = TextWrapMode.WordBreak;
            DataGrid.Worksheets[0].Ranges[startLocR, 0, endlocR, endlocC].Style.VerticalAlign = ReoGridVerAlign.Middle;
            DataGrid.Worksheets[0].SetRangeDataFormat(startLocR, 0, endlocR, endlocC, unvell.ReoGrid.DataFormat.CellDataFormatFlag.Text);

            int count = 0;
            DataGrid.Worksheets[0].IterateCells(new RangePosition(2, 5, DataGrid.Worksheets[0].MaxContentRow + 1, 1), (row, col, cell) =>
            {
                if (cell.Data != "" || cell.Data != null)
                    count++;
                return true;
            });

            if (_wndRecord != null)
                _wndRecord.EntryNum = count;
            #endregion

            #region PrintList
            if (data.Type.ToUpper() == "ИЦ")
            {
                startLocR = DataGrid.Worksheets[3].MaxContentRow + 1;
                endlocR = DataGrid.Worksheets[3].MaxContentRow + data.RowCount + 1;
                endlocC = DataGrid.Worksheets[3].MaxContentCol + 1;
                DataGrid.Worksheets[3].InsertRows(startLocR, data.RowCount);


                for (int i = startLocR; i < endlocR; i++)
                {
                    DataGrid.Worksheets[3].Ranges[i, 6, 1, 1].Data = data.exam[i - startLocR].Name;
                    DataGrid.Worksheets[3].Ranges[i, 9, 1, 1].Data = data.exam[i - startLocR].Result;
                }


                DataGrid.Worksheets[3].Ranges[startLocR, 0, endlocR - startLocR, 1].Data = data.ExamNum;
                DataGrid.Worksheets[3].Ranges[startLocR, 1, endlocR - startLocR, 1].Data = data.Date;
                DataGrid.Worksheets[3].Ranges[startLocR, 2, endlocR - startLocR, 1].Data = data.Name;
                DataGrid.Worksheets[3].Ranges[startLocR, 3, endlocR - startLocR, 1].Data = data.Count;
                DataGrid.Worksheets[3].Ranges[startLocR, 4, endlocR - startLocR, 1].Data = data.CustomerData;
                DataGrid.Worksheets[3].Ranges[startLocR, 5, endlocR - startLocR, 1].Data = data.SampleCode;
                DataGrid.Worksheets[3].Ranges[startLocR, 7, endlocR - startLocR, 1].Data = data.SampleDestination;
                DataGrid.Worksheets[3].Ranges[startLocR, 8, endlocR - startLocR, 1].Data = data.RelatedFace;

                for (int i = 0; i < 6; i++)
                {
                    DataGrid.Worksheets[3].MergeRange(startLocR, i, endlocR - startLocR, 1);
                }

                DataGrid.Worksheets[3].MergeRange(startLocR, 7, endlocR - startLocR, 1);
                DataGrid.Worksheets[3].MergeRange(startLocR, 8, endlocR - startLocR, 1);
                DataGrid.Worksheets[3].MergeRange(startLocR, 10, endlocR - startLocR, 1);
                DataGrid.Worksheets[3].MergeRange(startLocR, 11, endlocR - startLocR, 1);


                DataGrid.Worksheets[3].Ranges[startLocR, 0, endlocR, endlocC].Style.HorizontalAlign = ReoGridHorAlign.Center;
                DataGrid.Worksheets[3].Ranges[startLocR, 0, endlocR, endlocC].Style.TextWrap = TextWrapMode.WordBreak;
                DataGrid.Worksheets[3].Ranges[startLocR, 0, endlocR, endlocC].Style.VerticalAlign = ReoGridVerAlign.Middle;
                DataGrid.Worksheets[3].SetRangeDataFormat(startLocR, 0, endlocR, endlocC, unvell.ReoGrid.DataFormat.CellDataFormatFlag.Text);
            }
            #endregion
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

        private void _wndSettings_WindowClosed()
        {
            _wndSettings = null;
        }

        private void Btn_Click_1(object sender, RoutedEventArgs e)
        {
            if (_wndSettings == null)
            {
                _wndSettings = new Settings();
                _wndSettings.WindowClosed += _wndSettings_WindowClosed;
                _wndSettings.ShowInTaskbar = false;
                _wndSettings.Owner = this;
                _wndSettings.Show();
            }
        }
        #endregion

        #region Context Events

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {

            int dif = (int)DataGrid.CurrentWorksheet.SelectionRange.EndPos.Row - (int)DataGrid.CurrentWorksheet.SelectionRange.StartPos.Row;

            DataGrid.CurrentWorksheet.DeleteRows((int)DataGrid.CurrentWorksheet.SelectionRange.StartPos.Row, dif + 1);

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

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if ((string)DataGrid.CurrentWorksheet.Cells[DataGrid.CurrentWorksheet.SelectionRange.StartPos].Data != null)
                Clipboard.SetText((string)DataGrid.CurrentWorksheet.Cells[DataGrid.CurrentWorksheet.SelectionRange.StartPos].Data.ToString());
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.CurrentWorksheet.Ranges[DataGrid.CurrentWorksheet.SelectionRange].Data = Clipboard.GetText();
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
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, "Ошибка");
                    return;
                }

                foreach (Worksheet wk in DataGrid.Worksheets)
                {
                    wk.ColumnCount = wk.MaxContentCol;
                    wk.RowCount = wk.MaxContentRow;
                }

            }
        }

        #endregion

    }
}
