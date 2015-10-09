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
    public partial class frmRelatorio : Form
    {
        public frmRelatorio()
        {
            InitializeComponent();
            this.PreencherComboFisioterapeutas();
            this.PreencherComboPacientes();
            this.PreencherComboStatus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            frmReportViewer objFormResultadoRelatorio = new frmReportViewer(Consulta(),
                new VWParametrosRelatorio(txtDtInicio.Text.Replace("/", "").Replace("/", "").Trim() == "" ? "" : txtDtInicio.Text,
                    txtDtFim.Text.Replace("/", "").Replace("/", "").Trim() == "" ? "" : txtDtFim.Text,
                    txtInicioVencGuia.Text.Replace("/", "").Replace("/", "").Trim() == "" ? "" : txtInicioVencGuia.Text,
                    txtFimVencGuia.Text.Replace("/", "").Replace("/", "").Trim() == "" ? "" : txtFimVencGuia.Text,
                    cboFisioterapeutas.Text,
                    cboStatus.Text,
                    cboPaciente.Text), chkProcedimentos.Checked);

            objFormResultadoRelatorio.Show();
        }

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
                MessageBox.Show(objErro.Message);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                objLinha = null;
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
                MessageBox.Show(objErro.Message);
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
                MessageBox.Show(objErro.Message);
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                objLinha = null;
            }

        }

        #endregion

        private DataSet Consulta()
        {

            StringBuilder strSQL = new StringBuilder();
            clsConexaoBD objConexo = new clsConexaoBD();
            DtsRelatorio dtsAux = new DtsRelatorio();

            try
            {
                strSQL.Append(" SELECT ");
                strSQL.Append(" FORMAT(A.DTAGENDAMENTO, 'dd/MM/yyyy HH:mm') AS DATA_AGENDAMENTO, ");
                strSQL.Append(" FORMAT(A.DTAUTORIZACAOGUIA, 'dd/MM/yyyy') AS DATA_AUTORIZACAO_GUIA, ");
                strSQL.Append(" FORMAT(A.DTVENCIMENTOGUIA, 'dd/MM/yyyy') AS DATA_VENCIMENTO_GUIA, ");
                strSQL.Append(" P.CODPACIENTEUNIMED AS    CARTEIRINHA, ");
                strSQL.Append(" UCASE(P.NMPACIENTE) AS NOME_PACIENTE, ");
                strSQL.Append(" UCASE(F.NMFUNCIONARIO) AS NOME_FISIOTERAPEUTA, ");
                strSQL.Append(" UCASE(CDPROCEDIMENTOUNIMED) AS CODIGO_PROCEDIMENTO, ");
                strSQL.Append(" UCASE(NMPROCEDIMENTO) AS NOME_PROCEDIMENTO, ");
                strSQL.Append(" PR.VLPROCEDIMENTO AS VLPROCEDIMENTO  ");
                strSQL.Append(" FROM  ");
                strSQL.Append(" (((((TBAGENDAMENTO A LEFT JOIN TBFUNCIONARIOS F  ON A.CDFUNCIONARIO = F.CDFUNCIONARIO)  ");
                strSQL.Append(" INNER JOIN TBPACIENTES P ON A.CDPACIENTE = P.CDPACIENTE) ");
                strSQL.Append(" LEFT JOIN TBPROCEDIMENTOSAGENDAMENTO PA ON A.CDAGENDAMENTO = PA.CDAGENDAMENTO) ");
                strSQL.Append(" LEFT JOIN TBPROCEDIMENTOS PR ON PR.CDPROCEDIMENTO = PA.CDPROCEDIMENTO)) ");
                strSQL.Append(" WHERE 1=1 ");

                if (txtDtInicio.Text.Replace("/", "").Replace("/", "").Trim() != "")
                {
                    strSQL.Append(" AND YEAR(A.DTAGENDAMENTO) >= " + DateTime.Parse(txtDtInicio.Text).Year);
                    strSQL.Append(" AND MONTH(A.DTAGENDAMENTO) >=  " + DateTime.Parse(txtDtInicio.Text).Month);
                    strSQL.Append(" AND DAY(A.DTAGENDAMENTO) >=  " + DateTime.Parse(txtDtInicio.Text).Day);
                }

                if (txtDtFim.Text.Replace("/", "").Replace("/", "").Trim() != "")
                {
                    strSQL.Append(" AND YEAR(A.DTAGENDAMENTO) <= " + DateTime.Parse(txtDtFim.Text).Year);
                    strSQL.Append(" AND MONTH(A.DTAGENDAMENTO) <=  " + DateTime.Parse(txtDtFim.Text).Month);
                    strSQL.Append(" AND DAY(A.DTAGENDAMENTO) <=  " + DateTime.Parse(txtDtFim.Text).Day);
                }

                if (txtInicioVencGuia.Text.Replace("/", "").Replace("/", "").Trim() != "")
                {
                    strSQL.Append(" AND YEAR(A.dtVencimentoGuia) >= " + DateTime.Parse(txtInicioVencGuia.Text).Year);
                    strSQL.Append(" AND MONTH(A.dtVencimentoGuia) >=  " + DateTime.Parse(txtInicioVencGuia.Text).Month);
                    strSQL.Append(" AND DAY(A.dtVencimentoGuia) >=  " + DateTime.Parse(txtInicioVencGuia.Text).Day);
                }

                if (txtFimVencGuia.Text.Replace("/", "").Replace("/", "").Trim() != "")
                {
                    strSQL.Append(" AND YEAR(A.dtVencimentoGuia) <= " + DateTime.Parse(txtFimVencGuia.Text).Year);
                    strSQL.Append(" AND MONTH(A.dtVencimentoGuia) <=  " + DateTime.Parse(txtFimVencGuia.Text).Month);
                    strSQL.Append(" AND DAY(A.dtVencimentoGuia) <=  " + DateTime.Parse(txtFimVencGuia.Text).Day);
                }


                if (cboFisioterapeutas.SelectedValue.ToString() != "")
                    strSQL.Append(" AND F.CDFUNCIONARIO =  " + cboFisioterapeutas.SelectedValue.ToString());

                if (cboStatus.SelectedValue.ToString() != "")
                    strSQL.Append(" AND A.CDSTATUS =  " + cboStatus.SelectedValue.ToString());


                if (cboPaciente.SelectedValue.ToString() != "")
                    strSQL.Append(" AND P.CDPACIENTE =  " + cboPaciente.SelectedValue.ToString());

                strSQL.Append(" ORDER BY 1,5,7");

                return objConexo.ExecutarComandoSqlDataSet(strSQL.ToString());
            }
            catch (Exception objErro)
            {
                throw objErro;
            }
            finally
            {
                strSQL = null;
                dtsAux = null;
                objConexo = null;
            }

            
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
            this.Icon = Resource.office_chart_area_stacked1;
        }

    }
}
