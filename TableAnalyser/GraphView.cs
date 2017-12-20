using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ErrorsLib;
using TableAnalyser.Properties;
using Cursor = System.Windows.Forms.Cursor;

namespace TableAnalyser
{
    public partial class GraphView : Form
    {
        private readonly DataTable _dataTable;
        private readonly string _firstColumn;
        private readonly string _secondColumn;
        private readonly Dictionary<int, int> _xYDictionary = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _yXDictionary = new Dictionary<int, int>();
        private bool _flag;
        private List<KeyValuePair<int, int>> _xY = new List<KeyValuePair<int, int>>();
        private List<KeyValuePair<int, int>> _yX = new List<KeyValuePair<int, int>>();

        /// <summary>
        ///     Creates GraphView Form
        /// </summary>
        /// <param name="dataTable">Table of elements</param>
        /// <param name="firstColumn">Name of first column</param>
        /// <param name="secondColumn">Name of second column</param>
        public GraphView(DataTable dataTable, string firstColumn, string secondColumn)
        {
            InitializeComponent();
            _dataTable = dataTable;
            _firstColumn = firstColumn;
            _secondColumn = secondColumn;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _flag = false;
            ParseTable();
            SortDictionaries();
            Cursor.Current = Cursors.Default;
            BuildChart(_xY, _firstColumn, _secondColumn);
            MessageBox.Show(Resources.GraphViewChartClickHint);
        }

        /// <summary>
        ///     Method for revert chart
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void Chart_Click(object sender, EventArgs e)
        {
            _flag = !_flag;
            if (_flag)
                BuildChart(_xY, _firstColumn, _secondColumn);
            else
                BuildChart(_yX, _secondColumn, _firstColumn);
        }

        /// <summary>
        ///     Build chart
        /// </summary>
        /// <param name="xy">Dicitonary of coordinates</param>
        /// <param name="ox">Name for Ox</param>
        /// <param name="oy">Name for Oy</param>
        private void BuildChart(List<KeyValuePair<int, int>> xy, string ox, string oy)
        {
            chart.Series[0].Points.Clear();
            chart.Series[0].Name = "Graph";
            chart.Series[0].LegendText = "Dependence " + ox + " from " + oy;
            chart.ChartAreas[0].AxisX.Title = ox;
            chart.ChartAreas[0].AxisY.Title = oy;
            chart.Series[0].ChartType = SeriesChartType.Spline;

            foreach (KeyValuePair<int, int> pair in xy)
                chart.Series[0].Points.Add(pair.Key, pair.Value);

            trackBarMinimum.Minimum = (int) chart.ChartAreas[0].AxisX.Minimum;
            trackBarMinimum.Maximum = (int) chart.ChartAreas[0].AxisX.Maximum;
            trackBarMaximum.Minimum = (int) chart.ChartAreas[0].AxisX.Minimum;
            trackBarMaximum.Maximum = (int) chart.ChartAreas[0].AxisX.Maximum;
            trackBarMaximum.TickFrequency = 5;
            trackBarMinimum.TickFrequency = 5;
            trackBarMaximum.Value = (int) chart.ChartAreas[0].AxisX.Maximum;
            trackBarMinimum.Value = (int) chart.ChartAreas[0].AxisX.Minimum;
        }

        private void SetTrackbarsMinMax()
        {
            trackBarMaximum.Minimum = trackBarMinimum.Value;
            trackBarMinimum.Maximum = trackBarMaximum.Value;
        }

        /// <summary>
        ///     Parsing table of elements
        /// </summary>
        private void ParseTable()
        {
            foreach (DataRow row in _dataTable.Rows)
                try
                {
                    if (_xYDictionary.ContainsKey(
                        int.Parse(row[_firstColumn] as string ?? throw new BuildingGraphException())))
                        _xYDictionary[int.Parse(row[_firstColumn] as string)] =
                        (_xYDictionary[int.Parse(row[_firstColumn] as string)] + (row[_secondColumn] == null
                             ? 0
                             : int.Parse(row[_secondColumn] as string ?? throw new BuildingGraphException()))) / 2;
                    else
                        _xYDictionary.Add(
                            row[_firstColumn] == null
                                ? 0
                                : int.Parse(row[_firstColumn] as string ?? throw new BuildingGraphException()),
                            row[_secondColumn] == null
                                ? 0
                                : int.Parse(row[_secondColumn] as string ?? throw new BuildingGraphException()));
                    if (_yXDictionary.ContainsKey(
                        int.Parse(row[_secondColumn] as string ?? throw new BuildingGraphException())))
                        _yXDictionary[int.Parse(row[_secondColumn] as string)] =
                        (_yXDictionary[int.Parse(row[_secondColumn] as string)] + (row[_firstColumn] == null
                             ? 0
                             : int.Parse(row[_firstColumn] as string ?? throw new BuildingGraphException()))) / 2;
                    else
                        _yXDictionary.Add(
                            row[_secondColumn] == null
                                ? 0
                                : int.Parse(row[_secondColumn] as string ?? throw new BuildingGraphException()),
                            row[_firstColumn] == null
                                ? 0
                                : int.Parse(row[_firstColumn] as string ?? throw new BuildingGraphException()));
                }
                catch (Exception exception)
                {
                    throw new GraphException(exception);
                }
        }

        /// <summary>
        ///     Listener for maximum trackbar scrolling
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void TrackBarMaximum_Scroll(object sender, EventArgs e)
        {
            SetTrackbarsMinMax();
            chart.ChartAreas[0].AxisX.Maximum = trackBarMaximum.Value;
        }

        /// <summary>
        ///     Listener for minimum trackbar scrolling
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void TrackBarMinimum_Scroll(object sender, EventArgs e)
        {
            SetTrackbarsMinMax();
            chart.ChartAreas[0].AxisX.Minimum = trackBarMinimum.Value;
        }

        /// <summary>
        ///     Cast dicitonaries to lists and sort them
        /// </summary>
        private void SortDictionaries()
        {
            _xY = _xYDictionary.ToList();
            _xY.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));

            _yX = _yXDictionary.ToList();
            _yX.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
        }

        /// <summary>
        ///     Change color of chart
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        public void ChangeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                chart.Series[0].Color = colorDialog.Color;
        }

        /// <summary>
        ///     Export chart as png
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            if (_flag)
                chart.SaveImage(
                    folderBrowserDialog.SelectedPath + @"\" + "Dependence" + _firstColumn + "from" + _secondColumn +
                    ".png", ChartImageFormat.Png);
            else
                chart.SaveImage(
                    folderBrowserDialog.SelectedPath + @"\" + "Dependence" + _secondColumn + "from" + _firstColumn +
                    ".png", ChartImageFormat.Png);
            MessageBox.Show(Resources.FileSave + folderBrowserDialog.SelectedPath);
        }

        /// <summary>
        ///     Listener for mouse hover of chart
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void Chart_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(chart, "Chart");
        }

        /// <summary>
        ///     Listener for mouse hover of menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void ExportToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(menuStrip, "Menu");
        }

        /// <summary>
        ///     Listener for mouse hover of maximum trackbar
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void TrackBarMaximum_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(trackBarMaximum, "Maximum trackbar");
        }

        /// <summary>
        ///     Listener for mouse hover of minimum tracbar
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void TrackBarMinimum_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(trackBarMinimum, "Minimum trackbar");
        }
    }
}