using SuperstoreTool.Model;
using SuperstoreTool.SQLConnection;
using SuperstoreTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStore_Tool
{
    public partial class Form1 : Form
    {
        List<YearSales> SalesList;
        List<YearSales> yearList;
        List<String> StateList = new List<string>();
        public Form1()
        {
            //Access to DB to get the data filtered
            SalesList = DataAccess.DOM_Connection().GetSalesPerState().ToList();
            
            InitializeComponent();
            InitializelistBox1();
            InitializeSelectYear();
        }

        //Button which execute Point 1, 2 and Bonus 1 and Bonus 2 
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();          
            String yearSelected = SelectYear.Value.Year.ToString();
            //Get the year from user 
            yearList = SalesList.Where(x => x.SaleYear.ToString() == yearSelected).ToList();



            string state = listBox1.GetItemText(listBox1.SelectedItem);
            double inc = Convert.ToDouble(Increment.Text);

            yearList = Utils.IncrementSales(yearList, inc, state);

            //Fill the list view object with the results from point 1 and 2
            foreach (YearSales c in yearList)
            {
                listView1.Items.Add(new ListViewItem(new string[]{c.State.ToString(), c.Sales.ToString(), c.Increment.ToString() + "%",
                c.IncreaseSales.ToString()}));
            }
            InitializeList();
            //We fill the both charts for Bonus1 and Bonus2
            Utils.FillChart1(chart1, yearSelected, inc, SalesList);
            Utils.FillChart2(chart2, state, yearSelected, inc, SalesList);

        }

        private void InitializeList()
        {
            listView1.OwnerDraw = true;

            listView1.Columns.Add("STATE");
            listView1.Columns.Add("SALES");
            listView1.Columns.Add("INCREMENT");
            listView1.Columns.Add("INCREASED SALES");
            listView1.GridLines = true;
            listView1.AllowColumnReorder = true;
            listView1.LabelEdit = true;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.Details;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void InitializeSelectYear()
        {
            SelectYear.Format = DateTimePickerFormat.Custom;
            SelectYear.CustomFormat = "yyyy";
            SelectYear.ShowUpDown = true;
            SelectYear.MinDate = new DateTime(2018, 1, 1);
            SelectYear.MaxDate = new DateTime(2021, 1, 31);
        }


        private void InitializelistBox1()
        {
            foreach (YearSales c in SalesList)
            {
                if (StateList.Contains(c.State.ToString())) continue;
                StateList.Add(c.State.ToString());
            };

            foreach (string c in StateList)
            {
                listBox1.Items.Add(c);
            }
            listBox1.Sorted = true;
            listBox1.Sorted = false;
            listBox1.Items.Insert(0, "All States");

        }
        private void SelectYear_ValueChanged(object sender, EventArgs e)
        {
            String yearSelected = SelectYear.Value.Year.ToString();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Increment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            e.DrawText();
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Export the data to an excel - Point 3
            Utils.ExportData(listView1);
            MessageBox.Show("Data has been successfully exported.",
                    "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
