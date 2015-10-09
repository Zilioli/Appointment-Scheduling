using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agenda
{
    public partial class frmPaciente : Form
    {
        private bool blnAlteracao = false;
        private string strCodigoPaciente = "";

        public frmPaciente()
        {
            InitializeComponent();
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
            this.Icon = Resource.system_switch_user;
            PreencherGrid();
        }

        #region PreencherGrid
        private void PreencherGrid()
        {
            clsConexaoBD objConexao = new clsConexaoBD();

            try
            {
                dtgPacientes.DataSource = objConexao.ExecutarComandoSqlDataSet("SELECT CDPACIENTE, CODPACIENTEUNIMED, UCASE(NMPACIENTE) AS NMPACIENTE," + 
                                " TELPACIENTE2, TELPACIENTE,  IIF( STATUSINATIVO = FALSE, 'ATIVO', 'INATIVO' ) AS STATUS FROM TBPACIENTES " + 
                                " WHERE UCASE(NMPACIENTE) LIKE '%" + txtNome.Text.Trim().ToUpper()+"%'" + 
                                "ORDER BY NMPACIENTE").Tables[0];
                dtgPacientes.Columns["CDPACIENTE"].Visible = false;
                dtgPacientes.Columns["NMPACIENTE"].HeaderText = "Nome do Paciente";
                dtgPacientes.Columns["TELPACIENTE"].HeaderText = "Celular";
                dtgPacientes.Columns["TELPACIENTE2"].HeaderText = "Telefone Residencial";
                dtgPacientes.Columns["CODPACIENTEUNIMED"].HeaderText = "Código Paciente";
                dtgPacientes.Columns["STATUS"].HeaderText = "Status";
                if (dtgPacientes.SelectedRows.Count > 0)
                    dtgPacientes.SelectedRows[0].Selected = false;

            }
            catch (Exception objErro)
            {
                MessageBox.Show(objErro.Message);
            }
            finally
            {
                objConexao = null;
            }

        }
        #endregion

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            StringBuilder strSQL = new StringBuilder();

            try
            {
                if (txtNome.Text == "")
                    MessageBox.Show("Preenche o campo Nome do Paciente!");
                else
                {
                    if (!blnAlteracao)
                    {
                        strSQL.Append("INSERT INTO TBPACIENTES(NMPACIENTE, TELPACIENTE, CODPACIENTEUNIMED, TELPACIENTE2, STATUSINATIVO) VALUES(");
                        strSQL.Append("'" + txtNome.Text + "', ");
                        if (txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim() != "")
                            strSQL.Append("'" + txtTelefone.Text + "', ");
                        else
                            strSQL.Append("NULL, ");

                        strSQL.Append("'" + txtCodigoPaciente.Text + "',");

                        if (txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim() != "")
                            strSQL.Append("'" + txtTelefone2.Text + "' ");
                        else
                            strSQL.Append("NULL ");

                        strSQL.Append(", FALSE )");

                        objConexao.ExecutarComandoSql(strSQL.ToString());

                        MessageBox.Show("Paciente Cadastrado!");

                        txtNome.Text = "";
                        txtTelefone.Text = "";
                        txtTelefone2.Text = "";
                        txtCodigoPaciente.Text = "";
                    }
                    else
                    {
                        strSQL.Append("UPDATE TBPACIENTES SET ");
                        strSQL.Append("NMPACIENTE = '" + txtNome.Text + "', ");

                        if (txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim() != "")
                            strSQL.Append("TELPACIENTE = '" + txtTelefone.Text + "', ");
                        else
                            strSQL.Append("TELPACIENTE =  NULL, ");

                        if (txtTelefone2.Text.Replace("(", "").Replace(")", "").Replace("-", "").Trim() != "")
                            strSQL.Append("TELPACIENTE2 = '" + txtTelefone2.Text + "', ");
                        else
                            strSQL.Append("TELPACIENTE2 =  NULL, ");

                        strSQL.Append("CODPACIENTEUNIMED = '" + txtCodigoPaciente.Text + "', ");

                        strSQL.Append("STATUSINATIVO = " + (chkStatus.Checked ? "TRUE" : "FALSE") + " ");

                        strSQL.Append("WHERE CDPACIENTE = " + strCodigoPaciente);

                        objConexao.ExecutarComandoSql(strSQL.ToString());

                        MessageBox.Show("Alteração Realizada!");

                        blnAlteracao = false;
                        txtNome.Text = "";
                        txtTelefone.Text = "";
                        txtTelefone2.Text = "";
                        txtCodigoPaciente.Text = "";
                        strCodigoPaciente = "";
                        chkStatus.Checked = false;
                        if (dtgPacientes.SelectedRows.Count > 0)
                            dtgPacientes.SelectedRows[0].Selected = false;
                    }

                    PreencherGrid();
                }
            }
            catch (Exception objErro)
            {
                MessageBox.Show(objErro.Message);
            }
            finally
            {
                objConexao = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgPacientes_Click(object sender, EventArgs e)
        {
            blnAlteracao = true;
            chkStatus.Enabled = true;
            txtNome.Text = ((DataGridView)sender).SelectedRows[0].Cells["NMPACIENTE"].Value.ToString();
            txtTelefone.Text = ((DataGridView)sender).SelectedRows[0].Cells["TELPACIENTE"].Value.ToString();
            txtTelefone2.Text = ((DataGridView)sender).SelectedRows[0].Cells["TELPACIENTE2"].Value.ToString();
            strCodigoPaciente = ((DataGridView)sender).SelectedRows[0].Cells["CDPACIENTE"].Value.ToString();
            txtCodigoPaciente.Text = ((DataGridView)sender).SelectedRows[0].Cells["CODPACIENTEUNIMED"].Value.ToString();
            chkStatus.Checked = ((DataGridView)sender).SelectedRows[0].Cells["STATUS"].Value.ToString() == "ATIVO" ? false : true;
        }

        private void btnNovoPaciente_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtTelefone2.Text = "";
            txtCodigoPaciente.Text = "";
            blnAlteracao = false;
            chkStatus.Enabled = false;
            strCodigoPaciente = "";
            if (dtgPacientes.SelectedRows.Count > 0)
                dtgPacientes.SelectedRows[0].Selected = false;
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            PreencherGrid();
        }
    }
}
