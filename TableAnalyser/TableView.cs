using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TableAnalyser.Properties;

namespace TableAnalyser
{
    public partial class TableView : Form
    {
        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog
        {
            Filter = Resources._openFileDialog_Filter,
            Title = Resources._openFileDialog_Title
        };

        private DataTable _dataTable;

        /// <summary>
        ///     Create form of TableView
        /// </summary>
        public TableView()
        {
            InitializeComponent();
            Size = new Size(700, 700);
            StartPosition = FormStartPosition.CenterScreen;
            Load += TableView_Load;
        }

        /// <summary>
        ///     Loader for TableView
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void TableView_Load(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        ///     Open file
        /// </summary>
        private void OpenFile()
        {
            bool flag = false;
            while (!flag)
                try
                {
                    if (_openFileDialog.ShowDialog() != DialogResult.OK)
                        throw new Exception("Please, choose file first");

                    FillTable();
                    ShowTable();

                    flag = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
        }

        /// <summary>
        ///     Fill table of elements
        /// </summary>
        private void FillTable()
        {
            _dataTable = new DataTable();
            string[] tmp = File.ReadAllLines(_openFileDialog.FileName);
            for (int i = 0; i < tmp.Length; i++)
                if (i == 0)
                    foreach (string s in tmp[i].Split(','))
                        _dataTable.Columns.Add(s);
                else
                    _dataTable.Rows.Add(_dataTable.NewRow().ItemArray = tmp[i].Split(','));
        }

        /// <summary>
        ///     Show table of elements
        /// </summary>
        private void ShowTable()
        {
            _dataGridView.DataSource = _dataTable;
            _dataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _dataGridView.ScrollBars = ScrollBars.Both;
            _dataGridView.Height = Height - 25;
            _dataGridView.Width = Height - 25;
            _dataGridView.Padding = new Padding(0, 25, 0, 0);
            _dataGridView.Anchor = AnchorStyles.Top;
        }

        /// <summary>
        ///     Clicker for open file menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        ///     Clicker for build graph menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void buildGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseColumns chooseColumns = new ChooseColumns(_dataTable);
            chooseColumns.ShowDialog();
            GraphView graphView = new GraphView(_dataTable, chooseColumns.FirstColumn, chooseColumns.SecondColumn);
            graphView.Show();
        }
    }
}