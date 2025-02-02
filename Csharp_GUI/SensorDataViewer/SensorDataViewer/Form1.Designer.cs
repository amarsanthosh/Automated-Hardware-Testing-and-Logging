namespace SensorDataViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.btnStopTest = new System.Windows.Forms.Button();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(342, 86);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(600, 425);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(145, 168);
            this.btnStartTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(112, 38);
            this.btnStartTest.TabIndex = 1;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // btnStopTest
            // 
            this.btnStopTest.Location = new System.Drawing.Point(145, 344);
            this.btnStopTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStopTest.Name = "btnStopTest";
            this.btnStopTest.Size = new System.Drawing.Size(112, 38);
            this.btnStopTest.TabIndex = 2;
            this.btnStopTest.Text = "Stop Test";
            this.btnStopTest.UseVisualStyleBackColor = true;
            this.btnStopTest.Click += new System.EventHandler(this.btnStopTest_Click);
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(145, 256);
            this.btnExportReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(112, 38);
            this.btnExportReport.TabIndex = 3;
            this.btnExportReport.Text = "Export Report";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(329, 569);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(613, 319);
            this.cartesianChart1.TabIndex = 4;
            this.cartesianChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 938);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.btnExportReport);
            this.Controls.Add(this.btnStopTest);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Button btnStopTest;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        //private LiveCharts.Wpf.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        //private System.Windows.Forms.DataGridView dataGridView1;
    }
}

