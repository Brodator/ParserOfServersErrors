using System;
using System.Windows.Forms;

namespace ParseR
{
    public partial class Form2 : Form
    {
        DataGridViewCellEventArgs ee;
        public Form2(DataGridViewCellEventArgs ee)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            this.ee = ee;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
          //  richTextBox1.Text = Form1.parsedData[ee.RowIndex];
            
            richTextBox1.Text = Form1.completeErrors[ee.RowIndex].allError;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
