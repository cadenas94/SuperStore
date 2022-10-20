using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SuperstoreTool.Model;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using SuperStore_Tool.Model;
using System.Drawing;

namespace SuperstoreTool
{
    public static class Utils
    {
        //Method to move the data from datareader into a list
        public static IEnumerable<T> DataReader_DomEntry<T>(SqlDataReader dataReader) where T : class, new()
        {
            List<T> domObjList = new List<T>();
            PropertyInfo[] domEntryProperties = typeof(T).GetProperties();

            System.Data.DataTable table = new System.Data.DataTable();
            table.Load(dataReader);
            DataColumnCollection tableColumns = table.Columns;

            for (int r = 0; r < table.Rows.Count; r++)
            {
                T domObj = new T();
                DataRow dataRow = table.Rows[r];

                for (int p = 0; p < domEntryProperties.Length; p++)
                {
                    PropertyInfo domProp = domEntryProperties[p];

                    if (tableColumns.Contains(domProp.Name))
                    {
                        if (dataRow[domProp.Name] != DBNull.Value) domProp.SetValue(domObj, dataRow[domProp.Name], null);
                    }
                }

                domObjList.Add(domObj);
            }

            return domObjList;
        }

        //Increment the sales with the incremeneted percentage indicated by user
        public static List<YearSales> IncrementSales(List<YearSales> SalesList, double inc, string state)
        {
            if(state == "")
            {
                state = "All States";
            };
            if(inc == 0)
            {
                MessageBox.Show("Do not forget select an increment to simulate the increase of sales in the next year.",
                    "Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return SalesList;
            };
            foreach(YearSales s in SalesList)
            {
                if(state == "All States")
                {
                    s.Increment = inc;
                    s.IncreaseSales = ((inc / 100) * s.Sales) + s.Sales;
                }
               else if(state == s.State)
                {
                    s.Increment = inc;
                    s.IncreaseSales = ((inc / 100) * s.Sales) + s.Sales;
                }
            }
            return SalesList;
        }
        //Export data to a xlsx file - Point 3
        public static void ExportData(ListView listView1)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "State";
                    ws.Cells[1, 2] = "Percentage Increase";
                    ws.Cells[1, 3] = "Sales Value";
                    int i = 2;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[2].Text;
                        ws.Cells[i, 3] = item.SubItems[3].Text;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange,
                        XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();                    
                }
            }
        }
        public static void FillChart1(Chart chart1, string yearSelected, double inc, List<YearSales> SalesList)
        {
            List<AgSalesYear> agSalesYears = new List<AgSalesYear>();
            AgSalesYear AgSalesYearInc = new AgSalesYear();
            AgSalesYearInc.Year = Int16.Parse(yearSelected);
            Random random = new Random();
            double? agg = 0;

            foreach (YearSales c in SalesList)
            {
                AgSalesYear ob = new AgSalesYear();

                ob.Year = c.SaleYear;
                ob.Sales = c.Sales;

                agSalesYears.Add(ob);

                if (c.SaleYear == AgSalesYearInc.Year)
                {
                    agg = agg + (((inc / 100) * c.Sales) + c.Sales);
                }

            }
            AgSalesYearInc.Sales = agg;
            agSalesYears = SumGroups(agSalesYears).ToList();

            var objChart = chart1.ChartAreas[0];
            objChart.AxisX.IntervalType = DateTimeIntervalType.Number;
            objChart.AxisY.IntervalType = DateTimeIntervalType.Number;


            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Bonus 1");
            agSalesYears = agSalesYears.OrderBy(x => x.Year).ToList();
            foreach (AgSalesYear c in agSalesYears)
            {
                chart1.Series.Add(c.Year.ToString());
                chart1.Series[c.Year.ToString()].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                chart1.Series[c.Year.ToString()].ChartArea = "ChartArea1";
                chart1.Series[c.Year.ToString()].ChartType = SeriesChartType.Column;

                chart1.Series[c.Year.ToString()].Points.AddXY(c.Year, c.Sales);

            }
            string yearForecasted = AgSalesYearInc.Year.ToString() + "Forecasted";
            chart1.Series.Add(yearForecasted);
            chart1.Series[yearForecasted].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            chart1.Series[yearForecasted].ChartArea = "ChartArea1";

            chart1.Series[yearForecasted].Points.AddXY(AgSalesYearInc.Year, AgSalesYearInc.Sales);
        }

        public static void FillChart2(Chart chart2, string state, string yearSelected, double inc, List<YearSales> SalesList)
        {
            List<AgSalesState> SalesState = new List<AgSalesState>();
            List<AgSalesState> AggSalesState = new List<AgSalesState>();
            Random random = new Random();
            

            foreach (YearSales c in SalesList)
            {
                AgSalesState ob = new AgSalesState();
                AgSalesState obAgg = new AgSalesState();
                double? agg = 0;

                double res;              

                if (c.SaleYear.ToString() == yearSelected)
                {
                    ob.State = c.State;
                    ob.Sales = c.Sales;

                    SalesState.Add(ob);

                    agg = agg + (((inc / 100) * c.Sales) + c.Sales);

                    obAgg.State = c.State;
                    obAgg.Sales = agg;
                    AggSalesState.Add(obAgg);
                }

            }

            var objChart = chart2.ChartAreas[0];
            objChart.AxisY.IntervalType = DateTimeIntervalType.Number;

            chart2.Titles.Clear();
            chart2.Titles.Add("Bonus 2");            
            chart2.Series.Clear();
            chart2.ChartAreas["ChartArea2"].AxisX.Interval = 1;
            chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas["ChartArea2"].AxisY.MajorGrid.LineWidth = 0;

            SalesState = SalesState.OrderBy(x => x.State).ToList();
            AggSalesState = AggSalesState.OrderBy(x => x.State).ToList();

            chart2.Series.Add(yearSelected);
            chart2.Series[0].Color = Color.Blue;
            chart2.Series[0].ChartArea = "ChartArea2";
            chart2.Series[0].ChartType = SeriesChartType.Line;
            chart2.Series.Add(yearSelected + " Forecasted");
            chart2.Series[1].Color = Color.Red;
            chart2.Series[1].ChartArea = "ChartArea2";
            chart2.Series[1].ChartType = SeriesChartType.Line;
            foreach (AgSalesState c in SalesState)
            {
                chart2.Series[0].Points.AddXY(c.State, c.Sales);
            }
            foreach (AgSalesState c in AggSalesState)
            {
                chart2.Series[1].Points.AddXY(c.State, c.Sales);
            }

        }

        public static IEnumerable<AgSalesYear> SumGroups(IEnumerable<AgSalesYear> agSalesYears)
        {
            return agSalesYears.GroupBy(
                i => i.Year,
                (name, agSales) => new AgSalesYear()
                {
                    Year = name,
                    Sales = agSales.Sum(i => i.Sales)
                });
        }
    }
}
