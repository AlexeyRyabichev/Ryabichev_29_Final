namespace TableAnalyser
{
    partial class GraphView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBarMinimum = new System.Windows.Forms.TrackBar();
            this.trackBarMaximum = new System.Windows.Forms.TrackBar();
            this.labelMinimumValue = new System.Windows.Forms.Label();
            this.labelMaximumValue = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMinimum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaximum)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea4.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart.Legends.Add(legend4);
            this.chart.Location = new System.Drawing.Point(12, 27);
            this.chart.Name = "chart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(660, 545);
            this.chart.TabIndex = 0;
            this.chart.Text = "Graph";
            this.chart.Click += new System.EventHandler(this.Chart_Click);
            this.chart.MouseHover += new System.EventHandler(this.Chart_MouseHover);
            // 
            // trackBarMinimum
            // 
            this.trackBarMinimum.Location = new System.Drawing.Point(9, 584);
            this.trackBarMinimum.Name = "trackBarMinimum";
            this.trackBarMinimum.Size = new System.Drawing.Size(576, 45);
            this.trackBarMinimum.TabIndex = 1;
            this.trackBarMinimum.Scroll += new System.EventHandler(this.TrackBarMinimum_Scroll);
            this.trackBarMinimum.MouseHover += new System.EventHandler(this.TrackBarMinimum_MouseHover);
            // 
            // trackBarMaximum
            // 
            this.trackBarMaximum.Location = new System.Drawing.Point(12, 635);
            this.trackBarMaximum.Name = "trackBarMaximum";
            this.trackBarMaximum.Size = new System.Drawing.Size(576, 45);
            this.trackBarMaximum.TabIndex = 2;
            this.trackBarMaximum.Value = 10;
            this.trackBarMaximum.Scroll += new System.EventHandler(this.TrackBarMaximum_Scroll);
            this.trackBarMaximum.MouseHover += new System.EventHandler(this.TrackBarMaximum_MouseHover);
            // 
            // labelMinimumValue
            // 
            this.labelMinimumValue.AutoSize = true;
            this.labelMinimumValue.Location = new System.Drawing.Point(591, 584);
            this.labelMinimumValue.Name = "labelMinimumValue";
            this.labelMinimumValue.Size = new System.Drawing.Size(78, 13);
            this.labelMinimumValue.TabIndex = 3;
            this.labelMinimumValue.Text = "Minimum Value";
            // 
            // labelMaximumValue
            // 
            this.labelMaximumValue.AutoSize = true;
            this.labelMaximumValue.Location = new System.Drawing.Point(591, 635);
            this.labelMaximumValue.Name = "labelMaximumValue";
            this.labelMaximumValue.Size = new System.Drawing.Size(81, 13);
            this.labelMaximumValue.TabIndex = 4;
            this.labelMaximumValue.Text = "Maximum Value";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.changeColorToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "Menu";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            this.exportToolStripMenuItem.MouseHover += new System.EventHandler(this.ExportToolStripMenuItem_MouseHover);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.changeColorToolStripMenuItem.Text = "Change color";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.ChangeColorToolStripMenuItem_Click);
            // 
            // GraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 692);
            this.Controls.Add(this.labelMaximumValue);
            this.Controls.Add(this.labelMinimumValue);
            this.Controls.Add(this.trackBarMaximum);
            this.Controls.Add(this.trackBarMinimum);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "GraphView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphView";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMinimum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaximum)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TrackBar trackBarMinimum;
        private System.Windows.Forms.TrackBar trackBarMaximum;
        private System.Windows.Forms.Label labelMinimumValue;
        private System.Windows.Forms.Label labelMaximumValue;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
    }
}