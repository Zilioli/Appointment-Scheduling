#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Reflection;

#endregion

namespace Agenda
{
    public partial class frmAgenda : Form
    {

        #region Variáveis

        private string strNomePacienteFiltro = "";
        private string strHorarioFiltro = "";
        private string strHorario;
        private string[] strCor;
        private Color clrLinhas = Color.LightGray;
        #endregion

        #region frmAgenda

        public frmAgenda()
        {
            InitializeComponent();
        }

        #endregion

        #region frmAgenda_Load

        private void frmAgenda_Load(object sender, EventArgs e)
        {

            dynamic p = typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            p.SetValue(this.dtgAgenda, true, null);

            this.WindowState = FormWindowState.Maximized;
            this.ShowIcon = true;
            this.Icon = Resource.address_book_new_31;
            VerificarNotificacoes();
            CarregaGrid();
            PreencherComboFisioterapeutas();
            PreencherComboStatus();
        }

        #endregion

        #region "CarregaGrid"

        private void CarregaGrid()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            DataSet objResultado;
            StringBuilder strSQL = new StringBuilder();

            try
            {

                strSQL.Append("SELECT ");
                strSQL.Append("FORMAT(A.DTAGENDAMENTO, 'HH:mm') AS HORARIO, ");
                strSQL.Append("A.CDAGENDAMENTO,  ");
                strSQL.Append("A.DTAGENDAMENTO, ");
                strSQL.Append("P.CDPACIENTE, ");
                strSQL.Append("P.NMPACIENTE, ");
                strSQL.Append("P.TELPACIENTE, ");
                strSQL.Append("P.TELPACIENTE2, ");
                strSQL.Append("F.CDFUNCIONARIO, ");
                strSQL.Append("F.NMFUNCIONARIO, ");
                strSQL.Append("S.CDSTATUS, ");
                strSQL.Append("S.DESSTATUS, ");
                strSQL.Append("A.DTAUTORIZACAOGUIA,  ");
                strSQL.Append("A.DTVENCIMENTOGUIA, ");
                strSQL.Append("( ");
                strSQL.Append("SELECT FIRST(CORPROCEDIMENTO) FROM TBPROCEDIMENTOSAGENDAMENTO PA INNER JOIN TBPROCEDIMENTOS PRO ON PRO.CDPROCEDIMENTO = PA.CDPROCEDIMENTO  ");
                strSQL.Append("WHERE PA.CDAGENDAMENTO = A.CDAGENDAMENTO AND  CORPROCEDIMENTO <> '' GROUP BY PA.CDAGENDAMENTO   ");
                strSQL.Append(") AS COR ");
                strSQL.Append("FROM  ");
                strSQL.Append("(((TBAGENDAMENTO A INNER JOIN TBPACIENTES P ON A.CDPACIENTE = P.CDPACIENTE) ");
                strSQL.Append("LEFT JOIN TBFUNCIONARIOS F ON A.CDFUNCIONARIO = F.CDFUNCIONARIO)  ");
                strSQL.Append("INNER JOIN TBSTATUS S ON S.CDSTATUS = A.CDSTATUS)");
                strSQL.Append("WHERE  ");
                strSQL.Append("FORMAT(DTAGENDAMENTO, 'dd/MM/yyyy') = #" + dtAgenda.Value.ToString("yyyy/MM/dd") + "#  ");

                if (txtPaciente.Text.Trim() != "")
                    strSQL.Append(" AND P.NMPACIENTE LIKE '%" + txtPaciente.Text + "%' ");

                if (cboFisioterapeutas.Text != "")
                    strSQL.Append(" AND F.CDFUNCIONARIO = " + cboFisioterapeutas.SelectedValue.ToString());

                if (cboStatus.Text != "")
                    strSQL.Append(" AND S.CDSTATUS = " + cboStatus.SelectedValue.ToString());

                if (txtHorario.Text.Replace(":", "").Trim() != "")
                    strSQL.Append(" AND  FORMAT(DTAGENDAMENTO, 'HH:mm') >=  #" + DateTime.Parse(txtHorario.Text).AddMinutes(-30).ToString("HH:mm") + "# ");

                strSQL.Append(" ORDER BY  ");
                strSQL.Append("A.DTAGENDAMENTO, ");
                strSQL.Append("P.NMPACIENTE ");

                objResultado =
                    objConexao.ExecutarComandoSqlDataSet(strSQL.ToString());

                dtgAgenda.DataSource = PreencherListaAgendamento(objResultado.Tables[0]);

                //FormtarGrid();
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Agenda/Método CarregarGid/ERRO:" + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                objResultado = null;
                strSQL = null;
            }
        }

        #endregion

        #region dtAgenda_ValueChanged

        private void dtAgenda_ValueChanged(object sender, EventArgs e)
        {
            this.CarregaGrid();
            VerificarNotificacoes();
        }

        #endregion

        #region PreencherListaAgendamento

        private List<VWAgenda> PreencherListaAgendamento(DataTable p_pacientesAgendados)
        {

            string strHorarioInicio = ConfigurationManager.AppSettings["inicioAtendimento"].ToString();
            string strHorarioFim = ConfigurationManager.AppSettings["terminoAtendimento"].ToString();
            string strTempoAtendimento = ConfigurationManager.AppSettings["tempoConsuta"].ToString();
            string strMediaPacientesAtendidosHora = ConfigurationManager.AppSettings["mediaPacientesHora"].ToString();
            VWAgenda objAgenda;
            List<VWAgenda> lstAgenda = new List<VWAgenda>();


            try
            {
                foreach (DataRow objLinha in p_pacientesAgendados.Rows)
                {
                    objAgenda = new VWAgenda();

                    objAgenda.cdAgendamento = objLinha["CDAGENDAMENTO"].ToString();
                    objAgenda.cdFuncionario = objLinha["CDFUNCIONARIO"].ToString();
                    objAgenda.cdPaciente = objLinha["CDPACIENTE"].ToString();
                    objAgenda.cdStatus = objLinha["CDSTATUS"].ToString();
                    objAgenda.desStatus = objLinha["DESSTATUS"].ToString();
                    objAgenda.dtAgendamento = DateTime.Parse(objLinha["DTAGENDAMENTO"].ToString());
                    objAgenda.horaAgendamento = objLinha["HORARIO"].ToString();
                    objAgenda.nmFuncionario = objLinha["NMFUNCIONARIO"].ToString();
                    objAgenda.nmPaciente = objLinha["NMPACIENTE"].ToString();
                    objAgenda.telPaciente = objLinha["TELPACIENTE"].ToString();
                    objAgenda.telPaciente2 = objLinha["TELPACIENTE2"].ToString();
                    objAgenda.dtAutorizacaoGuia = objLinha["DTAUTORIZACAOGUIA"].ToString();
                    objAgenda.dtVencimentoGuia = objLinha["DTVENCIMENTOGUIA"].ToString();
                    objAgenda.cor =  objLinha["COR"].ToString();

                    lstAgenda.Add(objAgenda);
                    objAgenda = null;
                }

                if (txtPaciente.Text.Trim() == "" && cboStatus.Text == "" && cboFisioterapeutas.Text == ""
                    && txtHorario.Text.Replace(":", "").Trim() == "")
                {
                    int ContHorario = int.Parse(strHorarioInicio);
                    int contPacienteHorario = 0;
                    string strMinutos = "00";

                    while (ContHorario <= int.Parse(strHorarioFim))
                    {
                        contPacienteHorario = lstAgenda.Count(e => e.horaAgendamento == ContHorario.ToString().PadLeft(2, '0') + ":" + strMinutos);

                        while (contPacienteHorario < int.Parse(strMediaPacientesAtendidosHora))
                        {
                            objAgenda = new VWAgenda();
                            objAgenda.horaAgendamento = ContHorario.ToString().PadLeft(2, '0') + ":" + strMinutos;
                            lstAgenda.Add(objAgenda);
                            objAgenda = null;
                            contPacienteHorario++;
                        }

                        contPacienteHorario = 0;

                        if (strMinutos == "00")
                            strMinutos = "30";
                        else
                        {
                            ContHorario++;
                            strMinutos = "00";
                        }
                    }
                }

                return lstAgenda.OrderBy(e => e.horaAgendamento).ToList();
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Agendamento/Método PreencherListaAgendamento/ERRO: " +
                    objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                objAgenda = null;
                lstAgenda = null;
            }

        }

        #endregion

        #region FormtarGrid

        private void FormtarGrid()
        {

            try
            {

                strHorario = ConfigurationManager.AppSettings["inicioAtendimento"].ToString().PadLeft(2, '0') + ":" + "00";
                dtgAgenda.Columns["horaAgendamento"].HeaderText = "Horário";
                dtgAgenda.Columns["cdAgendamento"].Visible = false;
                dtgAgenda.Columns["cdFuncionario"].Visible = false;
                dtgAgenda.Columns["cdPaciente"].Visible = false;
                dtgAgenda.Columns["cdStatus"].Visible = false;
                dtgAgenda.Columns["dtAgendamento"].Visible = false;
                dtgAgenda.Columns["nmFuncionario"].HeaderText = "Fisioterapeuta";
                dtgAgenda.Columns["nmPaciente"].HeaderText = "Paciente";
                dtgAgenda.Columns["telPaciente"].HeaderText = "Celular";
                dtgAgenda.Columns["telPaciente2"].HeaderText = "Telefone Residencial";
                dtgAgenda.Columns["desStatus"].HeaderText = "Status";
                dtgAgenda.Columns["dtAutorizacaoGuia"].Visible = false;
                dtgAgenda.Columns["dtVencimentoGuia"].Visible = false;
                dtgAgenda.Columns["COR"].Visible = false;

                Color clrLinhas = Color.LightGray;

                foreach (DataGridViewRow rowGrid in dtgAgenda.Rows)
                {
                    if (strHorario != rowGrid.Cells["horaAgendamento"].Value.ToString())
                    {
                        strHorario = rowGrid.Cells["horaAgendamento"].Value.ToString();

                        if (clrLinhas == Color.White)
                            clrLinhas = Color.LightGray;
                        else
                            clrLinhas = Color.White;

                    }

                    rowGrid.DefaultCellStyle.BackColor = clrLinhas;

                    if (rowGrid.Cells["COR"].Value != null && rowGrid.Cells["COR"].Value.ToString() != "")
                    {

                        strCor = rowGrid.Cells["COR"].Value.ToString().Split('/');
                        rowGrid.DefaultCellStyle.BackColor = 
                                Color.FromArgb(int.Parse(strCor[0]), int.Parse(strCor[1]), int.Parse(strCor[2]), int.Parse(strCor[3]));
                    }
                        
                }

            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Agendamento/Método FormatarGrid/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        #endregion
        
        #region dtgAgenda_DoubleClick

        private void dtgAgenda_DoubleClick(object sender, EventArgs e)
        {
            VWAgenda objItemAgendado = new VWAgenda();
            try
            {
                objItemAgendado = (VWAgenda)(((DataGridView)sender).SelectedRows[0].DataBoundItem);

                if (objItemAgendado.cdAgendamento == "")
                    objItemAgendado.dtAgendamento = dtAgenda.Value;

                frmIncluirAgendamento_ objFormIncluirAgendamento = new frmIncluirAgendamento_(objItemAgendado);
                objFormIncluirAgendamento.ShowDialog();
                CarregaGrid();
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Agendamento/Método GridDoubleClick/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objItemAgendado = null;
            }
        }

        #endregion

        #region btnNovoHorario_Click

        private void btnNovoHorario_Click(object sender, EventArgs e)
        {
            VWAgenda objAgenda = new VWAgenda();
            objAgenda.dtAgendamento = dtAgenda.Value;
            objAgenda.horaAgendamento = "00:00";
            frmIncluirAgendamento_ objFormIncluirAgendamento = new frmIncluirAgendamento_(objAgenda);
            objFormIncluirAgendamento.ShowDialog();
            CarregaGrid();
        }

        #endregion

        #region txtPaciente_TextChanged

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {
            if (txtPaciente.Text.Length > 3)
            {
                strNomePacienteFiltro = txtPaciente.Text;
                CarregaGrid();
            }
            else if (strNomePacienteFiltro != "" && txtPaciente.Text.Trim() == "")
            {
                strNomePacienteFiltro = "";
                CarregaGrid();
            }
        }

        #endregion

        #region PreencherComboFisioterapeutas
        private void PreencherComboFisioterapeutas()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            DataTable tblResultado;
            DataRow objLinha;
            try
            {

                cboFisioterapeutas.DisplayMember = "NMFUNCIONARIO";
                cboFisioterapeutas.ValueMember = "CDFUNCIONARIO";

                tblResultado = objConexao.ExecutarComandoSqlDataSet("SELECT CDFUNCIONARIO, UCASE(NMFUNCIONARIO) AS NMFUNCIONARIO FROM TBFUNCIONARIOS ORDER BY NMFUNCIONARIO").Tables[0];
                objLinha = tblResultado.NewRow();
                tblResultado.Rows.InsertAt(objLinha, 0);

                cboFisioterapeutas.DataSource = tblResultado;
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Agendamento/Método PreencherComboFisioterapeuta/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                objLinha = null;
            }

        }

        #endregion

        #region PreencherComboStatus
        private void PreencherComboStatus()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            DataTable tblResultado;
            DataRow objLinha;
            try
            {

                cboStatus.DisplayMember = "DESSTATUS";
                cboStatus.ValueMember = "CDSTATUS";

                tblResultado = objConexao.ExecutarComandoSqlDataSet("SELECT CDSTATUS, UCASE(DESSTATUS) AS DESSTATUS FROM TBSTATUS ORDER BY DESSTATUS").Tables[0];
                objLinha = tblResultado.NewRow();
                tblResultado.Rows.InsertAt(objLinha, 0);

                cboStatus.DataSource = tblResultado;
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Agendamento/Método PreencherComboStatus/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                objLinha = null;
            }

        }

        #endregion

        #region cboFisioterapeutas_SelectedIndexChanged

        private void cboFisioterapeutas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        #endregion

        #region cboStatus_SelectedIndexChanged

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        #endregion

        #region txtHorario_TypeValidationCompleted

        private void txtHorario_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (e.IsValidInput)
            {
                if (txtHorario.Text.Split(':')[1] != "00" && txtHorario.Text.Split(':')[1] != "30")
                {
                    strHorarioFiltro = "";
                    MessageBox.Show("Horário informado deve estar no intervalo de 30 minutos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHorario.Focus();
                }
                else
                {
                    strHorarioFiltro = txtHorario.Text;
                    CarregaGrid();
                }
            }
            else if (txtHorario.Text.Replace(":", "").Trim() != "")
            {
                MessageBox.Show("Horário Informado inválido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                strHorarioFiltro = "";
                txtHorario.Focus();
            }
            else if (txtHorario.Text.Replace(":", "").Trim() == "" && strHorarioFiltro != "")
            {
                strHorarioFiltro = "";
                CarregaGrid();
            }
        }

        #endregion

        #region btnCancelar_Click

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region btnNovoLembrete_Click

        private void btnNovoLembrete_Click(object sender, EventArgs e)
        {
            frmLembrete objFormLembrete = new frmLembrete(dtAgenda.Value);
            objFormLembrete.ShowDialog();
            VerificarNotificacoes();
        }

        #endregion

        #region VerificarNotificacoes
        private void VerificarNotificacoes()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            StringBuilder strSQL = new StringBuilder();

            try
            {
                strSQL.Append(" SELECT COUNT(*) FROM TBLEMBRETES WHERE ");
                strSQL.Append(" YEAR(DTLEMBRETE) = " + dtAgenda.Value.Year);
                strSQL.Append(" AND MONTH(DTLEMBRETE) = " + dtAgenda.Value.Month);
                strSQL.Append(" AND DAY(DTLEMBRETE) = " + dtAgenda.Value.Day);

                if (int.Parse(objConexao.ExecutarComandoSqlDataSet(strSQL.ToString()).Tables[0].Rows[0][0].ToString()) > 0)
                {
                    imgNotificacao.Visible = lblLembrete.Visible = true;
                    lblLembrete.Text = "Você possui " +
                        objConexao.ExecutarComandoSqlDataSet(strSQL.ToString()).Tables[0].Rows[0][0].ToString()
                        + " lembrete(s).";
                }
                else
                    imgNotificacao.Visible = lblLembrete.Visible = false;

            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Agendamento/Método VerificarNotificacoes/ERRO: " + objErro.Message, "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                strSQL = null;
            }

        }
        #endregion

        #region dtgAgenda_DataBindingComplete
        
        private void dtgAgenda_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormtarGrid();
        }

        #endregion

    }
}
