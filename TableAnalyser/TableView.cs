using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ErrorsLib;
using TableAnalyser.Properties;

namespace TableAnalyser
{
    public sealed partial class TableView : Form
    {
        private readonly OpenFileDialog _openFileDialog = new OpenFileDialog
        {
            Filter = Resources._openFileDialog_Filter,
            Title = Resources._openFileDialog_Title
        };

        private DataTable _dataTable;
        private bool _fileReady;

        /// <summary>
        ///     Create form of TableView
        /// </summary>
        public TableView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Font = new Font("Bandera", 8);
            Load += TableView_Load;
        }

        /// <summary>
        ///     Loader for TableView
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void TableView_Load(object sender, EventArgs e)
        {
            Show();
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
                    DialogResult dialogResult = _openFileDialog.ShowDialog();
                    if (dialogResult != DialogResult.OK && !_fileReady)
                        throw new Exception("Please, choose file firstly");
                    
                    Cursor.Current = Cursors.WaitCursor;
                    FillTable();
                    Cursor.Current = Cursors.Default;
                    Show();
                    ShowTable();

                    flag = true;
                    _fileReady = true;
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
                    _dataTable.Rows.Add(_dataTable.NewRow().ItemArray = SmartSplit(tmp[i]));
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
            _dataGridView.Anchor = AnchorStyles.Top;
        }

        /// <summary>
        ///     Clicker for open file menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        ///     Clicker for build graph menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void BuildGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseColumns chooseColumns = new ChooseColumns(_dataTable);
            try
            {
                DialogResult dialogResult = chooseColumns.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    GraphView graphView =
                        new GraphView(_dataTable, chooseColumns.FirstColumn, chooseColumns.SecondColumn);
                    graphView.Show();
                }
                else if (dialogResult != DialogResult.Abort && dialogResult != DialogResult.Cancel)
                {
                    throw new ChooseException();
                }
            }
            catch (ChooseException exception)
            {
                MessageBox.Show(Resources.ChooseExceptionMessage + exception.Message);
                BuildGraphToolStripMenuItem_Click(sender, e);
            }
            catch (GraphException exception)
            {
                if (exception.InnerException != null) MessageBox.Show(exception.InnerException.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        ///     Split string by coma
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>object[]</returns>
        private object[] SmartSplit(string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            object[] objects = new object[_dataTable.Columns.Count];
            for (int j = 0; j < s.Split(',').Length; j++)
                objects[j] = string.IsNullOrEmpty(s.Split(',')[j]) ? "0" : s.Split(',')[j];
            return objects;
        }

        /// <summary>
        /// Listener for mouse hover of table
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void _dataGridView_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(_dataGridView, "Table of elements from file");
        }

        /// <summary>
        /// Listener for mouse hover of menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void OpenFileToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(menuStrip, "Menu");
        }
    }
}