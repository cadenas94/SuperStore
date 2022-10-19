using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SuperStore_Tool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.TotalSales = new System.Windows.Forms.Button();
            this.SelectYear = new System.Windows.Forms.DateTimePicker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label_state = new System.Windows.Forms.Label();
            this.label_increment = new System.Windows.Forms.Label();
            this.Increment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // TotalSales
            // 
            this.TotalSales.BackColor = System.Drawing.Color.IndianRed;
            this.TotalSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.TotalSales.Location = new System.Drawing.Point(22, 504);
            this.TotalSales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TotalSales.Name = "TotalSales";
            this.TotalSales.Size = new System.Drawing.Size(244, 70);
            this.TotalSales.TabIndex = 0;
            this.TotalSales.Text = "Total Sales";
            this.TotalSales.UseVisualStyleBackColor = false;
            this.TotalSales.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectYear
            // 
            this.SelectYear.Location = new System.Drawing.Point(22, 63);
            this.SelectYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectYear.Name = "SelectYear";
            this.SelectYear.Size = new System.Drawing.Size(130, 22);
            this.SelectYear.TabIndex = 2;
            this.SelectYear.ValueChanged += new System.EventHandler(this.SelectYear_ValueChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(22, 138);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(130, 356);
            this.listBox1.TabIndex = 5;
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.BackColor = System.Drawing.Color.Bisque;
            this.label_state.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label_state.Location = new System.Drawing.Point(22, 112);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(69, 23);
            this.label_state.TabIndex = 6;
            this.label_state.Text = "STATES";
            // 
            // label_increment
            // 
            this.label_increment.AutoSize = true;
            this.label_increment.BackColor = System.Drawing.Color.Bisque;
            this.label_increment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label_increment.Location = new System.Drawing.Point(166, 112);
            this.label_increment.Name = "label_increment";
            this.label_increment.Size = new System.Drawing.Size(107, 23);
            this.label_increment.TabIndex = 7;
            this.label_increment.Text = "INCREMENT";
            // 
            // Increment
            // 
            this.Increment.Location = new System.Drawing.Point(170, 138);
            this.Increment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Increment.Name = "Increment";
            this.Increment.Size = new System.Drawing.Size(53, 22);
            this.Increment.TabIndex = 8;
            this.Increment.Text = "0";
            this.Increment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Increment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Increment_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(223, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "%";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(293, 2);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(533, 842);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(22, 615);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 55);
            this.button1.TabIndex = 11;
            this.button1.Text = "Export Forecasted Data";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(845, 2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(957, 321);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea2";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(845, 329);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(957, 515);
            this.chart2.TabIndex = 14;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1803, 845);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Increment);
            this.Controls.Add(this.label_increment);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.TotalSales);
            this.Controls.Add(this.SelectYear);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Super Store Manager";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button TotalSales;
        private DateTimePicker SelectYear;
        private ListBox listBox1;
        private Label label_state;
        private Label label_increment;
        private TextBox Increment;
        private Label label1;
        private ListView listView1;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private Chart chart1;
        private Chart chart2;
    }
}

