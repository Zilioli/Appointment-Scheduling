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
    public partial class frmIncluirAgendamento_ : Form
    {
        List<CorProcedimento> lstCorProcedimento = new List<CorProcedimento>();
        VWAgenda objAgendamento = new VWAgenda();

        #region frmIncluirAgendamento_

        public frmIncluirAgendamento_()
        {
            InitializeComponent();
        }

        public frmIncluirAgendamento_(VWAgenda p_VWAgendamento)
        {
            InitializeComponent();
            objAgendamento = p_VWAgendamento;
        }

        #endregion

        #region PreencherComboPacientes
        private void PreencherComboPacientes()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            DataTable tblResultado;
            DataRow objLinha;
            try
            {

                cboPaciente.DisplayMember = "NMPACIENTE";
                cboPaciente.ValueMember = "CDPACIENTE";

                tblResultado = objConexao.ExecutarComandoSqlDataSet("SELECT CDPACIENTE, UCASE(NMPACIENTE) AS NMPACIENTE FROM TBPACIENTES WHERE STATUSINATIVO = FALSE ORDER BY NMPACIENTE").Tables[0];
                objLinha = tblResultado.NewRow();
                tblResultado.Rows.InsertAt(objLinha, 0);

                cboPaciente.DataSource = tblResultado;
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Incluir Agendamento/ Método PreencherComboPaciente/ERRO: " + objErro.Message, "ERRO", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                objLinha = null;
            }

        }
        #endregion

        #region frmIncluirAgendamento__Load
        private void frmIncluirAgendamento__Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
            this.Icon = Resource.address_book_new_31;
            PreencherComboPacientes();
            PreencherComboFisioterapeutas();
            PreencherComboStatus();
            PreencherComboProcedimentos();

            if (objAgendamento.cdAgendamento != "")
                CarregarGridProcedimentos();

            MontarTela();
        }
        #endregion

        #region btnCancelarAgendamento_Click

        private void btnCancelarAgendamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region btnIncluirPaciente_Click

        private void btnIncluirPaciente_Click(object sender, EventArgs e)
        {
            frmPaciente objFormPaciente = new frmPaciente();
            objFormPaciente.ShowDialog();
            PreencherComboPacientes();
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
                MessageBox.Show("Tela de Incluir Agendamento/ Método PreencherComboFisioterapeuta/ERRO: " + objErro.Message, "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                objLinha = null;
            }

        }

        #endregion

        #region PreencherComboProcedimentos
        private void PreencherComboProcedimentos()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            DataTable tblResultado;
            DataRow objLinha;
            try
            {

                cboProcedimentos.DisplayMember = "NMPROCEDIMENTO";
                cboProcedimentos.ValueMember = "CDPROCEDIMENTO";

                tblResultado = objConexao.ExecutarComandoSqlDataSet("SELECT CDPROCEDIMENTO, UCASE(CDPROCEDIMENTOUNIMED & ' - ' & NMPROCEDIMENTO) AS NMPROCEDIMENTO, CORPROCEDIMENTO FROM TBPROCEDIMENTOS ORDER BY NMPROCEDIMENTO").Tables[0];
                objLinha = tblResultado.NewRow();
                tblResultado.Rows.InsertAt(objLinha, 0);

                cboProcedimentos.DataSource = tblResultado;

                foreach (DataRow rowTable in tblResultado.Rows)
                    if (rowTable["CORPROCEDIMENTO"].ToString() != "")
                        lstCorProcedimento.Add(new CorProcedimento(rowTable["CDPROCEDIMENTO"].ToString(), rowTable["CORPROCEDIMENTO"].ToString()));

            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Incluir Agendamento/ Método PreencherComboProcedimentos/ERRO: " + objErro.Message, "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Tela de Incluir Agendamento/ Método PreencherComboStatus/ERRO: " + objErro.Message, "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                objLinha = null;
            }

        }

        #endregion

        #region btnConfirmarAgendamento_Click
        private void btnConfirmarAgendamento_Click(object sender, EventArgs e)
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            StringBuilder strSQL = new StringBuilder();

            try
            {
                if (this.ValidarCamposInclusao())
                {

                    // Se for inclusao
                    if (objAgendamento.cdAgendamento == "")
                    {
                        this.InserirAgendamento();
                        MessageBox.Show("Agendamento Realizado", "Incluir Agendamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        strSQL.Append("UPDATE TBAGENDAMENTO SET ");
                        strSQL.Append("DTAGENDAMENTO = #" + dtpDataAgendamento.Value.ToString("yyyy/MM/dd") + " " + txtHoraAgendamento.Text + "#, ");
                        strSQL.Append("CDPACIENTE = " + cboPaciente.SelectedValue + ", ");
                        strSQL.Append("CDSTATUS = " + cboStatus.SelectedValue + ", ");

                        if (cboFisioterapeutas.SelectedValue.ToString() != "")
                            strSQL.Append("CDFUNCIONARIO = " + cboFisioterapeutas.SelectedValue.ToString() + ", ");
                        else
                            strSQL.Append("CDFUNCIONARIO = NULL, ");

                        if (txtAutorizacaoGuia.Text.Replace("/", "").Trim() != "")
                            strSQL.Append("DTAUTORIZACAOGUIA = #" + DateTime.Parse( txtAutorizacaoGuia.Text).ToString("yyyy/MM/dd") + "#, ");

                        if (txtVencimentoGuia.Text.Replace("/", "").Trim() != "")
                            strSQL.Append("DTVENCIMENTOGUIA = #" + DateTime.Parse(txtVencimentoGuia.Text).ToString("yyyy/MM/dd") + "#, ");

                        strSQL.Remove(strSQL.ToString().Length - 2, 1);

                        strSQL.Append(" WHERE CDAGENDAMENTO = " + objAgendamento.cdAgendamento);

                        objConexao.ExecutarComandoSql(strSQL.ToString());

                        try
                        {
                            InserirProcedimentos();
                        }
                        catch
                        {
                            MessageBox.Show("Problem ao inserir os Procedimentos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        MessageBox.Show("Agendamento Alterado", "Alterar Agendamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Incluir Agendamento/ Método AgendamentoClick" + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                strSQL = null;
            }
        }

        #endregion

        #region ValidarCamposInclusao
        private bool ValidarCamposInclusao()
        {
            if (txtHoraAgendamento.Text.Replace(":", "").Trim() == "" || cboPaciente.Text == "" || cboStatus.Text == "")
            {
                MessageBox.Show("Campo(s) obrigatório(s) não preenchido(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (txtSessoes.Text.Trim() != "" && cboPeriodicidade.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione o(s) dia(s) da semana para o agendamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cboPeriodicidade.SelectedIndex > 1)
            {
                if (txtSessoes.Text.Trim() == "")
                {
                    MessageBox.Show("Informe o número de sessões que deverão ser agendadas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                int intNumeroDiasSelecionados = 0;
                foreach (Control objItem in this.Controls.Find("groupDiasSemana", true)[0].Controls)
                    if (((CheckBox)objItem).Checked)
                        intNumeroDiasSelecionados++;

                if (intNumeroDiasSelecionados == 0)
                {
                    MessageBox.Show("Selecione o(s) dia(s) da semana para o agendamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (cboPeriodicidade.Text == "Semanal" && intNumeroDiasSelecionados != 1)
                {
                    MessageBox.Show("Número de dia(s) selecionado(s) não bate com a quantia informada na Periodicidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (cboPeriodicidade.Text == "2x Semana" && intNumeroDiasSelecionados != 2)
                {
                    MessageBox.Show("Número de dia(s) selecionado(s) não bate com a quantia informada na Periodicidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (cboPeriodicidade.Text == "3x Semana" && intNumeroDiasSelecionados != 3)
                {
                    MessageBox.Show("Número de dia(s) selecionado(s) não bate com a quantia informada na Periodicidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (cboStatus.SelectedValue.ToString() == "3")
            {
                if (MessageBox.Show("Depois que você alterar o Status para " + cboStatus.Text +
                    ", esse item agendado não poderá mais ser alterado. Deseja continuar?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {

                    if (cboFisioterapeutas.Text == "" )
                    {
                        MessageBox.Show("Campo(s) obrigatório(s) não preenchido(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (dtgProcedimentos.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum procedimento foi adicionado agendamento, antes de mudar o status do agendamento para " +
                            cboStatus.Text + ", adicione procedimento(s).", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                    return false;
            }

            return true;
        }
        #endregion

        #region MontarTela
        private void MontarTela()
        {
            // Se o objeto for diferente de nul, siginifica que o agendamento ja foi realizado e sera realizado alguma alteracao
            if (objAgendamento.cdAgendamento != "")
            {
                dtpDataAgendamento.Value = objAgendamento.dtAgendamento;
                txtHoraAgendamento.Text = objAgendamento.horaAgendamento;
                cboStatus.SelectedValue = objAgendamento.cdStatus;
                cboPaciente.SelectedValue = objAgendamento.cdPaciente;
                txtAutorizacaoGuia.Text = objAgendamento.dtAutorizacaoGuia;
                txtVencimentoGuia.Text = objAgendamento.dtVencimentoGuia;
                btnExcluir.Enabled = true;

                if (objAgendamento.cdFuncionario != "")
                    cboFisioterapeutas.SelectedValue = objAgendamento.cdFuncionario;

                if (objAgendamento.cdStatus == "3")
                {
                    MessageBox.Show("Cuidado ao alterar esse agendamento, pois ele se encontra no STATUS de " + objAgendamento.desStatus +
                                    ", qualquer alteração pode interferir nos resultados dos Relatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //dtgProcedimentos.Enabled = false;
                    //dtpDataAgendamento.Enabled = false;
                    //txtHoraAgendamento.Enabled = false;
                    //txtSessoes.Enabled = false;
                    //cboPeriodicidade.Enabled = false;
                    //cboPaciente.Enabled = false;
                    //cboFisioterapeutas.Enabled = false;
                    //cboStatus.Enabled = false;
                    //cboProcedimentos.Enabled = false;
                    //btnAdicionarProcedimento.Enabled = false;
                    //btnRemoverProcedimento.Enabled = false;
                    //btnIncluirPaciente.Enabled = false;
                    //btnConfirmarAgendamento.Enabled = false;
                    //txtAutorizacaoGuia.Enabled = false;
                    //txtVencimentoGuia.Enabled = false;
                    //groupDiasSemana.Enabled = false;
                }

            }
            else if (objAgendamento.horaAgendamento != "" && objAgendamento.horaAgendamento != null)
            {
                if(objAgendamento.horaAgendamento != "00:00")
                    txtHoraAgendamento.Text = objAgendamento.horaAgendamento;
                dtpDataAgendamento.Value = objAgendamento.dtAgendamento;
                cboStatus.SelectedValue = "4";
            }
            else
                cboStatus.SelectedValue = "4";

        }
        #endregion

        #region btnAdicionarProcedimento_Click
        private void btnAdicionarProcedimento_Click(object sender, EventArgs e)
        {
            if (cboProcedimentos.SelectedValue.ToString() != "")
            {
                string[] strCor ;
                dtgProcedimentos.Rows.Add(cboProcedimentos.SelectedValue, cboProcedimentos.Text, "1");

                if (lstCorProcedimento.FindIndex(cor => cor.Codigo == cboProcedimentos.SelectedValue.ToString()) >= 0)
                {
                    strCor = lstCorProcedimento.Find(corLinha => corLinha.Codigo == cboProcedimentos.SelectedValue.ToString()).Cor.Split('/');
                    dtgProcedimentos.Rows[dtgProcedimentos.Rows.Count - 1].DefaultCellStyle.BackColor =
                         Color.FromArgb(int.Parse(strCor[0]), int.Parse(strCor[1]), int.Parse(strCor[2]), int.Parse(strCor[3])); 
                }
            }
            else
                MessageBox.Show("Selecione um Procedimento na lista acima.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region btnRemoverProcedimento_Click
        private void btnRemoverProcedimento_Click(object sender, EventArgs e)
        {
            if (dtgProcedimentos.Rows.Count > 0)
                dtgProcedimentos.Rows.RemoveAt(dtgProcedimentos.SelectedRows[0].Index);
        }
        #endregion

        #region InserirProcedimento
        private void InserirProcedimentos()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            StringBuilder strSql = new StringBuilder();

            try
            {
                if (objAgendamento.cdAgendamento == "")
                {
                    strSql.Append("SELECT MAX(CDAGENDAMENTO) FROM TBAGENDAMENTO");
                    objAgendamento.cdAgendamento = objConexao.ExecutarComandoSqlDataSet(strSql.ToString()).Tables[0].Rows[0][0].ToString();
                }

                strSql.Clear();
                strSql.Append("DELETE FROM TBPROCEDIMENTOSAGENDAMENTO WHERE CDAGENDAMENTO = " + objAgendamento.cdAgendamento);
                objConexao.ExecutarComandoSql(strSql.ToString());

                foreach (DataGridViewRow objLinha in dtgProcedimentos.Rows)
                {
                    strSql.Clear();

                    strSql.Append("INSERT INTO TBPROCEDIMENTOSAGENDAMENTO(CDAGENDAMENTO, CDPROCEDIMENTO, QTDPROCEDIMENTO) VALUES(");
                    strSql.Append(objAgendamento.cdAgendamento + ", ");
                    strSql.Append(objLinha.Cells["CodigoProcedimento"].Value.ToString() + ", ");
                    strSql.Append(objLinha.Cells["QuantidadeProcedimento"].Value.ToString());
                    strSql.Append(")");

                    objConexao.ExecutarComandoSql(strSql.ToString());
                }
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Incluir Agendamento/ Método InserirProcedimentos/ERRO: " + objErro.Message, "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                strSql = null;
            }
        }
        #endregion

        #region CarregarGridProcedimentos

        private void CarregarGridProcedimentos()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            DataTable tblResultado;
            StringBuilder strSQL = new StringBuilder();
            string[] strCor;
            try
            {

                strSQL.Append("SELECT ");
                strSQL.Append("A.CDPROCEDIMENTO,  ");
                strSQL.Append("UCASE(B.CDPROCEDIMENTOUNIMED & ' - ' & B.NMPROCEDIMENTO) AS NMPROCEDIMENTO,  ");
                strSQL.Append("A.QTDPROCEDIMENTO,  ");
                strSQL.Append("B.CORPROCEDIMENTO  ");
                strSQL.Append("FROM  ");
                strSQL.Append("TBPROCEDIMENTOSAGENDAMENTO A INNER JOIN TBPROCEDIMENTOS B ON  A.CDPROCEDIMENTO = B.CDPROCEDIMENTO ");
                strSQL.Append("WHERE ");
                strSQL.Append("A.CDAGENDAMENTO =  " + objAgendamento.cdAgendamento);

                tblResultado = objConexao.ExecutarComandoSqlDataSet(strSQL.ToString()).Tables[0];

                foreach (DataRow objLinha in tblResultado.Rows)
                {
                    dtgProcedimentos.Rows.Add(objLinha[0].ToString(), objLinha[1].ToString(), objLinha[2].ToString());

                    if (objLinha[3].ToString() != "")
                    {
                        strCor = objLinha[3].ToString().Split('/');
                        dtgProcedimentos.Rows[dtgProcedimentos.Rows.Count - 1].DefaultCellStyle.BackColor =
                            Color.FromArgb(int.Parse(strCor[0]), int.Parse(strCor[1]), int.Parse(strCor[2]), int.Parse(strCor[3])); 
                    }
                }
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Incluir Agendamento/ Método CarregarGridProcedimento/ERRO: " + objErro.Message, "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                strSQL = null;
            }
        }

        #endregion

        #region txtHoraAgendamento_Leave
        private void txtHoraAgendamento_Leave(object sender, EventArgs e)
        {
            if (txtHoraAgendamento.Text.Length == 5)
            {
                if (txtHoraAgendamento.Text.Split(':')[1].ToString() != "00" &&
                    txtHoraAgendamento.Text.Split(':')[1].ToString() != "30")
                {
                    MessageBox.Show("Agendamentos só podem ser realizados de 30 em 30 minutos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoraAgendamento.Focus();
                }

            }
            else if (txtHoraAgendamento.Text.Length > 0 && txtHoraAgendamento.Text.Length < 5)
            {
                MessageBox.Show("Formato de horário inválido!.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoraAgendamento.Focus();
            }
        }
        #endregion

        #region DiaSemana_CheckedChanged
        private void DiaSemana_CheckedChanged(object sender, EventArgs e)
        {

            if (cboPeriodicidade.Text.Trim() != "" && cboPeriodicidade.Text.Trim() != "Diário")
            {
                int intCont = 0;
                int intAux = 0;

                if (cboPeriodicidade.Text == "Semanal")
                    intCont = 1;
                else if (cboPeriodicidade.Text == "2x Semana")
                    intCont = 2;
                else if (cboPeriodicidade.Text == "3x Semana")
                    intCont = 3;

                foreach (Control objItem in this.Controls.Find("groupDiasSemana", true)[0].Controls)
                    if (((CheckBox)objItem).Checked)
                        intAux++;

                if (intAux > intCont)
                    MessageBox.Show("Quantidade de itens selecionados não é igual a quantidade informada na periodicidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region cboPeriodicidade_SelectedIndexChanged
        private void cboPeriodicidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeriodicidade.Text.Trim() == "" || cboPeriodicidade.Text.Trim() == "Diário")
            {

                foreach (Control objItem in this.Controls.Find("groupDiasSemana", true)[0].Controls)
                    ((CheckBox)objItem).Checked = cboPeriodicidade.Text.Trim() == "Diário" ? true:false ;

                groupDiasSemana.Enabled = false;
            }
            else
                groupDiasSemana.Enabled = true;
        }
        #endregion

        #region InserirAgendamento
        private void InserirAgendamento()
        {
            int intQuantidadeItensAgendados = 1;
            DateTime dtDiaAgendamento = dtpDataAgendamento.Value;
            List<int> lstDiasSemanaAgendar = new List<int>();
            int intNumeroDiaSemanaAux = 0;
            int intNumeroProximoDiaSemana = 0;
            bool blnTratamentoSemanal = true;

            try 
            {
                if (txtSessoes.Text.Trim() != "")
                {
                    intQuantidadeItensAgendados = int.Parse(txtSessoes.Text);


                    foreach (Control objItem in this.Controls.Find("groupDiasSemana", true)[0].Controls)
                    {

                        if (((CheckBox)objItem).Checked)
                            lstDiasSemanaAgendar.Add(int.Parse(((CheckBox)objItem).Name.Replace("chk", "")));

                        lstDiasSemanaAgendar.Sort();
                    }
                }

                // Realiza o número de agendamentos informados
                for (int contador = 0; contador < intQuantidadeItensAgendados; contador++)
                {
                    // Não validar o dia da semana para o primeiro item agendado
                    if (contador == 0)
                    {
                        intNumeroDiaSemanaAux = Convert.ToInt32(dtDiaAgendamento.DayOfWeek) +1;
                        this.InserirAgendamentoBD(dtDiaAgendamento);
                    }
                    else
                    {
                        objAgendamento.cdAgendamento = "";

                        // para os demais itens validar o dia da semana
                        if (lstDiasSemanaAgendar.FindAll(e => e > intNumeroDiaSemanaAux).Count > 0)
                            intNumeroProximoDiaSemana = lstDiasSemanaAgendar.FindAll(e => e > intNumeroDiaSemanaAux)[0];
                        else
                            intNumeroProximoDiaSemana = lstDiasSemanaAgendar[0];

                        while (Convert.ToInt32(dtDiaAgendamento.DayOfWeek) + 1 != intNumeroProximoDiaSemana)
                        {
                            dtDiaAgendamento = dtDiaAgendamento.AddDays(1);
                            blnTratamentoSemanal = false;
                        }


                        if (cboPeriodicidade.Text == "Semanal" && blnTratamentoSemanal)
                            dtDiaAgendamento = dtDiaAgendamento.AddDays(7);
                        else if (cboPeriodicidade.Text == "Semanal")
                            blnTratamentoSemanal = true;

                            

                        this.InserirAgendamentoBD(dtDiaAgendamento);

                        intNumeroDiaSemanaAux = intNumeroProximoDiaSemana;
                    }
                }
            }
            catch (Exception objErro)
            {
                throw objErro;
            }
            finally
            {
                lstDiasSemanaAgendar = null;
            }
        }
        #endregion

        #region InserirAgendamentoBD
        private void InserirAgendamentoBD(DateTime p_DtAgendar)
        {
            StringBuilder strSQL = new StringBuilder();
            clsConexaoBD objConexao = new clsConexaoBD();

            try
            {
                strSQL.Append("INSERT INTO TBAGENDAMENTO ");
                strSQL.Append("( DTAGENDAMENTO, CDPACIENTE, CDFUNCIONARIO, CDSTATUS, DTAUTORIZACAOGUIA, DTVENCIMENTOGUIA) ");
                strSQL.Append("VALUES( ");
                strSQL.Append("#" + p_DtAgendar.Date.ToString("yyyy/MM/dd") + " " + txtHoraAgendamento.Text + "#, ");
                strSQL.Append(cboPaciente.SelectedValue + ",");
                if (cboFisioterapeutas.SelectedValue.ToString() != "")
                    strSQL.Append(cboFisioterapeutas.SelectedValue + ",");
                else
                    strSQL.Append("NULL,");

                strSQL.Append(cboStatus.SelectedValue + ", ");

                if (txtAutorizacaoGuia.Text.Replace("/", "").Trim() != "")
                    strSQL.Append("#" + DateTime.Parse( txtAutorizacaoGuia.Text ).ToString("yyyy/MM/dd")+ "#,");
                else
                    strSQL.Append("NULL,");

                if (txtVencimentoGuia.Text.Replace("/", "").Trim() != "")
                    strSQL.Append("#" + DateTime.Parse(txtVencimentoGuia.Text).ToString("yyyy/MM/dd") + "#");
                else
                    strSQL.Append("NULL");

                strSQL.Append(")");

                objConexao.ExecutarComandoSql(strSQL.ToString());

                try
                {
                    InserirProcedimentos();
                }
                catch
                {
                    MessageBox.Show("Problem ao inserir os Procedimentos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception objErro)
            {
                throw objErro;
            }
            finally
            {
                strSQL = null;
                objConexao = null;
            }
        }
        #endregion

        #region btnExcluir_Click
        
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            clsConexaoBD objConexao = new clsConexaoBD();

            try
            {

                if (objAgendamento.cdAgendamento != "")
                {
                    if (MessageBox.Show("Deseja realmenre excluir esse agendamento?", "Excluir Agendamento", MessageBoxButtons.YesNo) 
                        == System.Windows.Forms.DialogResult.Yes)
                    {
                        objConexao.ExecutarComandoSql("DELETE FROM TBPROCEDIMENTOSAGENDAMENTO WHERE CDAGENDAMENTO = " + objAgendamento.cdAgendamento);
                        objConexao.ExecutarComandoSql("DELETE FROM TBAGENDAMENTO WHERE CDAGENDAMENTO = " + objAgendamento.cdAgendamento);

                        MessageBox.Show("Exclusão do agendamento realizada!", "Exclusão de Agendamento ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Código do Agendamento não informado, por favor, tentar novamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Erro na exclusão do agendamento. ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
            }
        }

        #endregion

        #region txtAutorizacaoGuia_Leave
        private void txtAutorizacaoGuia_Leave(object sender, EventArgs e)
        {
            DateTime dtOut = new DateTime();
            if (txtAutorizacaoGuia.Text.Replace("/", "").Replace("/", "").Trim() != "")
            {
                if (DateTime.TryParse(txtAutorizacaoGuia.Text, out dtOut) )
                {
                    if (txtVencimentoGuia.Text.Replace("/", "").Replace("/", "").Trim() == "")
                        txtVencimentoGuia.Text = DateTime.Parse(txtAutorizacaoGuia.Text).AddMonths(1).ToString("dd/MM/yyyy");
                }
                else
                {
                    MessageBox.Show("Data de Autorização informada não se econtra no formato correto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAutorizacaoGuia.Text = "";
                    txtAutorizacaoGuia.Focus();
                }
            }
            
        }
        #endregion

        #region txtVencimentoGuia_Leave

        private void txtVencimentoGuia_Leave(object sender, EventArgs e)
        {
            DateTime dtOut = new DateTime();
            if (txtVencimentoGuia.Text.Replace("/", "").Replace("/", "").Trim() != "")
            {
                if (DateTime.TryParse(txtVencimentoGuia.Text, out dtOut) )
                {
                    if (txtAutorizacaoGuia.Text.Replace("/", "").Replace("/", "").Trim() == "")
                    txtAutorizacaoGuia.Text = DateTime.Parse(txtVencimentoGuia.Text).AddMonths(-1).ToString("dd/MM/yyyy");
                }
                else 
                {
                    MessageBox.Show("Data de Vencimento informada não se econtra no formato correto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVencimentoGuia.Text = "";
                    txtVencimentoGuia.Focus();
                }
            }
        }

        #endregion

        #region class CorProcedimento
        
        private class CorProcedimento
        {
            public CorProcedimento(string _Codigo, string _Cor)
            {
                this.Codigo = _Codigo;
                this.Cor = _Cor;
            }

            public string Codigo = "";
            public string Cor = "";
        }

        #endregion
    }
}