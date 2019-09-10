using System;
using System.Windows.Forms;
using WebLocalBlock.Entities.Class;
using WebLocalBlock.Forms;

namespace WebLocalBlock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Init.Initializing();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
    }
}
