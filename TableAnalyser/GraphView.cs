using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TableAnalyser
{
    public partial class GraphView : Form
    {
        private readonly DataTable _dataTable;
        private readonly Dictionary<int, int> _xY = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _yX = new Dictionary<int, int>();
        private bool _flag;
        private readonly string _firstColumn;
        private readonly string _secondColumn;

        /// <summary>
        /// Creates GraphView Form
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
            _flag = false;
        }

        /// <summary>
        /// Loader for GraphView
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void GraphView_Load(object sender, EventArgs e)
        {
            ParseTable();
            BuildChart(_xY);
        }

        /// <summary>
        /// Method for revert chart
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void chart_Click(object sender, EventArgs e)
        {
            _flag = !_flag;
            BuildChart(_flag ? _xY : _yX);
        }

        /// <summary>
        /// Method which build chart
        /// </summary>
        /// <param name="xy">Dicitonary of coordinates</param>
        private void BuildChart(Dictionary<int, int> xy)
        {
            chart.Series[0].Points.Clear();
            var myList = xy.ToList();
            myList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key));
            foreach (KeyValuePair<int, int> pair in myList)
                chart.Series[0].Points.Add(pair.Key, pair.Value);
            chart.Series[0].ChartType = SeriesChartType.Spline;
        }

        /// <summary>
        /// Method, which parsing table of elements
        /// </summary>
        private void ParseTable()
        {
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                try
                {
                    _xY.Add(_dataTable.Rows[i][_firstColumn] == null ? 0 : int.Parse(_dataTable.Rows[i][_firstColumn] as string),
                        _dataTable.Rows[i][_secondColumn] == null ? 0 : int.Parse(_dataTable.Rows[i][_secondColumn] as string));
                    _yX.Add(_dataTable.Rows[i][_secondColumn] == null ? 0 : int.Parse(_dataTable.Rows[i][_secondColumn] as string),
                        _dataTable.Rows[i][_firstColumn] == null ? 0 : int.Parse(_dataTable.Rows[i][_firstColumn] as string));
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                }
            }
            
        }
    }
}
