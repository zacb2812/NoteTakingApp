using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class Form1 : Form
    {
        DataTable dataTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Message", typeof(string));

            dataView.DataSource = dataTable;
            dataView.Columns["Message"].Visible = false;
            dataView.Columns["Title"].Width = 190;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textTitle.Clear();
            textMessage.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataTable.Rows.Add(textTitle.Text, textMessage.Text);
            textTitle.Clear();
            textMessage.Clear();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataView.CurrentCell.RowIndex;

                if (index > -1)
                {
                    textTitle.Text = dataTable.Rows[index].ItemArray[0].ToString();
                    textMessage.Text = dataTable.Rows[index].ItemArray[1].ToString();
                }
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dataView.CurrentCell.RowIndex;

            if (index > -1)
            {
                dataTable.Rows[index].Delete();
                textTitle.Clear();
                textMessage.Clear();
            }

        }

    }
}
