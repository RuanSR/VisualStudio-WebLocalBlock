using System;
using System.Windows.Forms;
using WebLocalBlock.Entities.Class;
using WebLocalBlock.Forms;

namespace WebLocalBlock
{
    public partial class MainForm : Form
    {
        private string _Url;
        private DBManager _dbManager { get; }
        //CONSTRUTOR && LOAD\\
        public MainForm()
        {
            InitializeComponent();
            _dbManager = new DBManager();
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
                MessageBox.Show(ex.Message, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //BUTTONS\\
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _Url = txtUrl.Text.ToString();
            try{
                if (_Url != null && _Url.Contains("www.") && _Url.Contains(".com")){
                    _dbManager.InsertData(_Url);
                    LoadDataBase();
                    MessageBox.Show("Dados inseridos com sucesso!",Properties.Resources.MsgSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Preencha o campo corretamente!", Properties.Resources.MsgAtention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        //METODOS\\
        private void LoadDataBase()
        {
            try
            {
                grvURL.Rows.Clear();
                grvURL = _dbManager.ReadData(grvURL);

                foreach (DataGridViewRow row in grvURL.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells[2] as DataGridViewCheckBoxCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
