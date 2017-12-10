using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalExamElliott
{
    public partial class Form1 : Form
    {
        TriLink trilink = new TriLink();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdd.Text))
            {
                MessageBox.Show("Field must contain a value.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int value = 0;
            if (int.TryParse(txtAdd.Text, out value))
            {
                trilink.insert(value);
                txtOutput.Text = trilink.print();
                lblStats.Text = trilink.countNode();
                txtAdd.Text = "";
                txtAdd.Focus();
                txtAdd.SelectAll();
            }
            else
            {
                MessageBox.Show("Field must contain an integer value.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdd.Text))
            {
                MessageBox.Show("Field must contain a value.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int value = 0;
            if (int.TryParse(txtAdd.Text, out value))
            {
                if (trilink.search(value))
                {
                    MessageBox.Show("Value was found in the trilink tree.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Value was NOT found in the trilink tree.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Field must contain an integer value.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdd.Text))
            {
                MessageBox.Show("Field must contain a value.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int value = 0;
            if (int.TryParse(txtAdd.Text, out value))
            {
                trilink.delete(value);
                txtOutput.Text = trilink.print();
                lblStats.Text = trilink.countNode();
                txtAdd.Text = "";
                txtAdd.Focus();
                txtAdd.SelectAll();
            }
            else
            {
                MessageBox.Show("Field must contain an integer value.", "Trilink tree", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
