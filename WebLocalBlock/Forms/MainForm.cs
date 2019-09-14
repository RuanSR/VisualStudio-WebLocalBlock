using System;
using System.Windows.Forms;
using WebLocalBlock.Entities.Class;
using WebLocalBlock.Forms;

namespace WebLocalBlock {
    public partial class MainForm : Form {
        private int _SelectedID;
        private string _Url;
        private DBManager _dbManager { get; }
        //CONSTRUTOR && LOAD\\
        public MainForm() {
            InitializeComponent();
            _dbManager = new DBManager();
        }
        private void MainForm_Load(object sender, EventArgs e) {
            try {
                Init.Initializing();
                LoadDataBase();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //BUTTONS\\
        private void btnAdd_Click(object sender, EventArgs e) {
            _Url = txtUrl.Text.ToString();
            try {
                switch (btnAdd.Text) {
                    case "Add":
                        if (VerificaUrlText(_Url)) {
                            _dbManager.InsertData(_Url);
                            LoadDataBase();
                            txtUrl.Text = string.Empty;
                            MessageBox.Show("Dados inseridos com sucesso!", Properties.Resources.MsgSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            MessageBox.Show("Preencha o campo corretamente!", Properties.Resources.MsgAtention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Update":
                        if (VerificaUrlText(_Url)) {
                            _dbManager.UpdateData(_SelectedID ,_Url,false);
                            LoadDataBase();
                            btnAdd.Text = "Add";
                            txtUrl.Text = string.Empty;
                            MessageBox.Show("Dados atualizados com sucesso!", Properties.Resources.MsgSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            MessageBox.Show("Preencha o campo corretamente!", Properties.Resources.MsgAtention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAbout_Click(object sender, EventArgs e) {
            new AboutBox().ShowDialog();
        }
        private void gridViewUrl_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (dtgUrl.Columns[e.ColumnIndex].Name == "btnEdit") {
                btnAdd.Text = "Update";
                txtUrl.Text = dtgUrl.Rows[e.RowIndex].Cells["URL"].Value.ToString();
                _SelectedID = int.Parse(dtgUrl.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
        }
        //METODOS\\
        private void LoadDataBase() {
            try {
                dtgUrl.Rows.Clear();
                dtgUrl = _dbManager.ReadData(dtgUrl);

                foreach (DataGridViewRow row in dtgUrl.Rows) {
                    DataGridViewCheckBoxCell cell = row.Cells[2] as DataGridViewCheckBoxCell;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool VerificaUrlText(string url) {
            if (url != null && url.Contains("www.") && url.Contains(".com")) {
                return true;
            } else {
                return false;
            }
        }
    }
}
