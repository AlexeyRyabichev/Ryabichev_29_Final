﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ErrorsLib;

namespace TableAnalyser
{
    public partial class ChooseColumns : Form
    {
        private readonly DataTable _dataTable;
        private string[] _tableHeaders;

        /// <summary>
        ///     Create form of ChooseColumn
        /// </summary>
        /// <param name="dataTable"></param>
        public ChooseColumns(DataTable dataTable)
        {
            InitializeComponent();
            Size = new Size(400, 400);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            _dataTable = dataTable;
            Load += ChooseColumns_Load;
        }

        public string FirstColumn { get; private set; }
        public string SecondColumn { get; private set; }


        /// <summary>
        ///     Loader for ChooseColumn
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void ChooseColumns_Load(object sender, EventArgs e)
        {
            _tableHeaders = new string[_dataTable.Columns.Count];
            for (int i = 0; i < _tableHeaders.Length; i++)
            {
                _tableHeaders[i] = _dataTable.Columns[i].ColumnName;
                checkedListBox.Items.Add(_tableHeaders[i]);
            }
        }

        /// <summary>
        ///     Clicker for button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (checkedListBox.CheckedIndices.Count != 2)
                throw new ChooseException("Choose only two columns");
            FirstColumn = _tableHeaders[checkedListBox.CheckedIndices[0]];
            SecondColumn = _tableHeaders[checkedListBox.CheckedIndices[1]];
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///     Listener for mouse hover of listbox
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void CheckedListBox_MouseHover(object sender, EventArgs e) => toolTip.SetToolTip(checkedListBox, "List of column names");

        /// <summary>
        ///     Listener for mouse hover of button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event arguments</param>
        private void Button_MouseHover(object sender, EventArgs e) => toolTip.SetToolTip(button, "OK button");
    }
}