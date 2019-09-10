using System;
using System.Windows.Forms;
using WebLocalBlock.Entities.Class;
using WebLocalBlock.Forms;

namespace WebLocalBlock
{
    public partial class MainForm : Form
    {
        private DBManager _dbManager { get; } = new DBManager();
        //CONSTRUTOR && LOAD\\
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Init.Initializing();
                LoadDataBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //BUTTONS\\
        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        //METODOS\\
        private void LoadDataBase()
        {
            try
            {
                grvURL = _dbManager.ReadTable(grvURL);

                foreach (DataGridViewRow row in grvURL.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[2] as DataGridViewCheckBoxCell;
                    //if (cell.Value == cell.TrueValue)
                    //{
                    //    MessageBox.Show("");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
