using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ErrorsLib;
using Cursor = System.Windows.Forms.Cursor;

namespace TableAnalyser
{
    public partial class GraphView : Form
    {
        private readonly DataTable _dataTable;
        private readonly string _firstColumn;
        private readonly string _secondColumn;
        private readonly Dictionary<int, int> _xY = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _yX = new Dictionary<int, int>();
        private bool _flag;

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
            Load += GraphView_Load;
        }

        /// <summary>
        ///     Loader for GraphView
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void GraphView_Load(object sender, EventArgs e)
        {
            ParseTable();
            Cursor.Current = Cursors.Default;
            BuildChart(_xY, _firstColumn, _secondColumn);
        }

        /// <summary>
        ///     Method for revert chart
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void chart_Click(object sender, EventArgs e)
        {
            _flag = !_flag;
            if (_flag)
                BuildChart(_xY, _firstColumn, _secondColumn);
            else
                BuildChart(_xY, _secondColumn, _firstColumn);
        }

        /// <summary>
        ///     Build chart
        /// </summary>
        /// <param name="xy">Dicitonary of coordinates</param>
        private void BuildChart(Dictionary<int, int> xy, string Ox, string Oy)
        {
            chart.Series[0].Points.Clear();
            chart.Series[0].Name = "Graph";
            chart.Series[0].LegendText = "Dependence " + Ox + " from " + Oy;
            chart.ChartAreas[0].AxisX.Title = Ox;
            chart.ChartAreas[0].AxisY.Title = Oy;
            var myList = xy.ToList();
            myList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
            foreach (KeyValuePair<int, int> pair in myList)
                chart.Series[0].Points.Add(pair.Key, pair.Value);
            chart.Series[0].ChartType = SeriesChartType.Spline;
        }

        /// <summary>
        ///     Parsing table of elements
        /// </summary>
        private void ParseTable()
        {
            //for (int i = 0; i < _dataTable.Rows.Count; i++)
            foreach (DataRow row in _dataTable.Rows)
                try
                {
                    if (_xY.ContainsKey(int.Parse(row[_firstColumn] as string ?? throw new BuildingGraphException())))
                        _xY[int.Parse(row[_firstColumn] as string)] =
                        (_xY[int.Parse(row[_firstColumn] as string)] + (row[_secondColumn] == null
                             ? 0
                             : int.Parse(row[_secondColumn] as string ?? throw new BuildingGraphException()))) / 2;
                    else
                        _xY.Add(
                            row[_firstColumn] == null
                                ? 0
                                : int.Parse(row[_firstColumn] as string ?? throw new BuildingGraphException()),
                            row[_secondColumn] == null
                                ? 0
                                : int.Parse(row[_secondColumn] as string ?? throw new BuildingGraphException()));
                if (_yX.ContainsKey(int.Parse(row[_secondColumn] as string ?? throw new BuildingGraphException())))
                    _yX[int.Parse(row[_secondColumn] as string)] =
                    (_yX[int.Parse(row[_secondColumn] as string)] + (row[_firstColumn] == null
                         ? 0
                         : int.Parse(row[_firstColumn] as string ?? throw new BuildingGraphException()))) / 2;
                else
                    _yX.Add(
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
    }
}