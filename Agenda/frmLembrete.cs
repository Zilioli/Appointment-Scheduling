#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Agenda
{
    public partial class frmLembrete : Form
    {
        #region Variáveis

        private DateTime dtLembrete;
        private string strCodigoAgendamento = "";

        #endregion

        #region frmLembrete

        public frmLembrete()
        {
            InitializeComponent();
            dtpData.Visible = true;
            txtDataLembrete.Visible = false;
        }

        #endregion

        #region frmLembrete
        
        public frmLembrete(DateTime p_dtLembrete)
        {
            InitializeComponent();
            dtLembrete = p_dtLembrete;
            dtpData.Visible = false;
            txtDataLembrete.Visible = true;
        }

        #endregion

        #region frmLembrete_Load

        private void frmLembrete_Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
            this.Icon = Resource.mail_message_new_3;

            txtDataLembrete.Text = dtLembrete.ToString("dd/MM/yyyy");

            PreencherGridLembretes();
            txtLembrete.Focus();

            if (dtgLembrete.SelectedRows.Count > 0)
                dtgLembrete.SelectedRows[0].Selected = false;
        }

        #endregion

        #region btnConfirmarAgendamento_Click

        private void btnConfirmarAgendamento_Click(object sender, EventArgs e)
        {
            if (txtLembrete.Text == "")
                MessageBox.Show("Preencha o lembrete que deseja incluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                clsConexaoBD objConexao = new clsConexaoBD();
                StringBuilder strSQL = new StringBuilder();

                try
                {
                    if (strCodigoAgendamento == "")
                    {

                        if (dtpData.Visible)
                            dtLembrete = dtpData.Value;

                        strSQL.Append(" INSERT INTO TBLEMBRETES (DTLEMBRETE, DESCLEMBRETE, STNOTIFICACAO, STDESCARTAR) VALUES (");
                        strSQL.Append("'" + dtLembrete.Date.ToString("yyyy/MM/dd") + "', ");
                        strSQL.Append("'" + (txtLembrete.Visible == true ? txtLembrete.Text : dtpData.Value.ToString("dd/MM/yyyy")) + "', ");
                        strSQL.Append(chkNotificacao.Checked == true ? "true, " : "false, ");
                        strSQL.Append("false ) ");

                        objConexao.ExecutarComandoSql(strSQL.ToString());

                        txtLembrete.Text = "";
                        chkNotificacao.Checked = false;

                        MessageBox.Show("Lembrete cadastrado com sucesso", "AtençãCadastro de Lembrete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        if (dtpData.Visible)
                            dtLembrete = dtpData.Value;

                        strSQL.Append(" UPDATE TBLEMBRETES  SET ");
                        strSQL.Append("DESCLEMBRETE = '" + txtLembrete.Text +"' , " );
                        strSQL.Append("DTLEMBRETE = #" + dtLembrete.ToString("yyyy/MM/dd") + "# , ");
                        strSQL.Append("STNOTIFICACAO = " + (chkNotificacao.Checked == true ? "true" : "false"));
                        strSQL.Append(" WHERE ");
                        strSQL.Append(" CDLEMBRETE = " + strCodigoAgendamento);

                        objConexao.ExecutarComandoSql(strSQL.ToString());

                        btnExcluir.Enabled = false;
                        btnNovoLembrete.Enabled = false;
                        strCodigoAgendamento = "";
                        chkNotificacao.Checked = false;
                        txtLembrete.Text = "";

                        if (dtgLembrete.SelectedRows.Count > 0)
                            dtgLembrete.SelectedRows[0].Selected = false;

                        MessageBox.Show("Lembrete alterado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.PreencherGridLembretes();
                }
                catch (Exception objErro)
                {
                    MessageBox.Show("tela de Lembretes/Método ConfirmarAgendamento/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    objConexao = null;
                    strSQL = null;
                }
            }
        }

        #endregion

        #region PreencherGridLembretes
        
        private void PreencherGridLembretes()
        {
            StringBuilder strSQL = new StringBuilder();
            clsConexaoBD objConexao = new clsConexaoBD();

            if (dtpData.Visible)
                dtLembrete = dtpData.Value;

            strSQL.Append(" SELECT  CDLEMBRETE, DESCLEMBRETE, STNOTIFICACAO, STDESCARTAR FROM  TBLEMBRETES WHERE ");
            strSQL.Append(" YEAR(DTLEMBRETE) = " + dtLembrete.Year);
            strSQL.Append(" AND MONTH(DTLEMBRETE) = " + dtLembrete.Month);
            strSQL.Append(" AND DAY(DTLEMBRETE) = " + dtLembrete.Day);

            dtgLembrete.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgLembrete.DataSource = objConexao.ExecutarComandoSqlDataSet(strSQL.ToString()).Tables[0];
            dtgLembrete.Columns["CDLEMBRETE"].Visible = false;
            dtgLembrete.Columns["DESCLEMBRETE"].HeaderText = "Lembrete";
            dtgLembrete.Columns["STNOTIFICACAO"].Visible = false;
            dtgLembrete.Columns["STDESCARTAR"].Visible = false;
        }

        #endregion

        #region btnCancelar_Click
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region dtgLembrete_Click
        
        private void dtgLembrete_Click(object sender, EventArgs e)
        {
            txtLembrete.Text = ((DataGridView)sender).SelectedRows[0].Cells["DESCLEMBRETE"].Value.ToString();
            strCodigoAgendamento = ((DataGridView)sender).SelectedRows[0].Cells["CDLEMBRETE"].Value.ToString();
            chkNotificacao.Checked = (((DataGridView)sender).SelectedRows[0].Cells["STNOTIFICACAO"].Value.ToString().ToUpper()) == "TRUE" ? true : false;
            btnExcluir.Enabled = true;
            btnNovoLembrete.Enabled = true;
        }

        #endregion

        #region btnNovoLembrete_Click
        
        private void btnNovoLembrete_Click(object sender, EventArgs e)
        {
            btnExcluir.Enabled = false;
            btnNovoLembrete.Enabled = false;
            strCodigoAgendamento = "";
            chkNotificacao.Checked = false;
            txtLembrete.Text = "";

            if (dtgLembrete.SelectedRows.Count > 0)
                dtgLembrete.SelectedRows[0].Selected = false;
        }

        #endregion

        #region btnExcluir_Click

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (strCodigoAgendamento == "")
                MessageBox.Show("Selecione um lembrete para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                clsConexaoBD objConexao = new clsConexaoBD();

                try
                {
                    if (MessageBox.Show("Deseja realmente excluir o lembrete?", "Exclusão de Lembrete", MessageBoxButtons.YesNo) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        objConexao.ExecutarComandoSql(" DELETE FROM TBLEMBRETES WHERE CDLEMBRETE = " + strCodigoAgendamento);

                        btnExcluir.Enabled = false;
                        btnNovoLembrete.Enabled = false;
                        strCodigoAgendamento = "";
                        chkNotificacao.Checked = false;
                        txtLembrete.Text = "";

                        if (dtgLembrete.SelectedRows.Count > 0)
                            dtgLembrete.SelectedRows[0].Selected = false;

                        MessageBox.Show("Lembrete excluído.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        PreencherGridLembretes();
                    }

                }
                catch (Exception objErro)
                {
                    MessageBox.Show("tela de Lembrete/Método Excluir/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    objConexao = null;
                }
            }
        }

        #endregion

        #region dtpData_ValueChanged

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            btnExcluir.Enabled = false;
            btnNovoLembrete.Enabled = false;
            strCodigoAgendamento = "";
            chkNotificacao.Checked = false;
            txtLembrete.Text = "";

            if (dtgLembrete.SelectedRows.Count > 0)
                dtgLembrete.SelectedRows[0].Selected = false;

            PreencherGridLembretes();
        }

        #endregion
    }
}
