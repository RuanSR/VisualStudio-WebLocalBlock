using System;
using System.Windows.Forms;
using WebLocalBlock.Entities.Class;
using WebLocalBlock.Forms;

namespace WebLocalBlock {
    public partial class MainForm : Form {
        private int _SelectedID { get; set; }
        private string _Url { get; set; }
        private bool _IsChecked { get; set; }

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
                            _dbManager.InsertData(_Url, _IsChecked);
                            LoadDataBase();
                            txtUrl.Text = string.Empty;
                            MessageBox.Show("Dados inseridos com sucesso!", Properties.Resources.MsgSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            MessageBox.Show("Preencha o campo corretamente!", Properties.Resources.MsgAtention, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Update":
                        if (VerificaUrlText(_Url)) {
                            _dbManager.UpdateData(_SelectedID ,_Url,_IsChecked);
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

            _SelectedID = int.Parse(gridViewUrl.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            _Url = gridViewUrl.Rows[e.RowIndex].Cells["URL"].Value.ToString();
            _IsChecked = bool.Parse(gridViewUrl.Rows[e.RowIndex].Cells["Locked"].Value.ToString());

            switch (gridViewUrl.Columns[e.ColumnIndex].Name) {

                case "btnEdit":
                    btnAdd.Text = "Update";
                    txtUrl.Text = gridViewUrl.Rows[e.RowIndex].Cells["URL"].Value.ToString();
                    break;
                case "btnRemove":
                    if (MessageBox.Show("Deseja realmente remover este url?", Properties.Resources.MsgAtention, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        try {
                            _dbManager.DeleteData(_SelectedID);
                            LoadDataBase();
                            MessageBox.Show("URL removido com sucesso!", Properties.Resources.MsgSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
                case "Locked":
                    try
                    {
                        _dbManager.UpdateData(_SelectedID, _Url, !_IsChecked);
                        LoadDataBase();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,Properties.Resources.MsgError,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;
                default:
                    break;
            }
        }
        //METODOS\\
        private void LoadDataBaseOld() {
            try {
                gridViewUrl.Rows.Clear();
                //gridViewUrl = _dbManager.ReadData(gridViewUrl);

                foreach (DataGridViewRow row in gridViewUrl.Rows) {
                    DataGridViewCheckBoxCell cell = row.Cells[2] as DataGridViewCheckBoxCell;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataBase() {
            try {
                gridViewUrl.DataSource = _dbManager.ReadData();

                foreach (DataGridViewRow row in gridViewUrl.Rows) {
                    DataGridViewCheckBoxCell cell = row.Cells["Locked"] as DataGridViewCheckBoxCell;
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
