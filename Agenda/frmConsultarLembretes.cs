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
    public partial class frmConsultarLembretes : Form
    {
        #region frmConsultarLembretes
        
        public frmConsultarLembretes()
        {
            InitializeComponent();
        }

        #endregion

        #region btnCancelar_Click
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region frmConsultarLembretes_Load
        
        private void frmConsultarLembretes_Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
            this.Icon = Resource.system_search;
        }

        #endregion

        #region btnConsultar_Click
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            StringBuilder strSQL = new StringBuilder();
            clsConexaoBD objConexao = new clsConexaoBD();

            try
            {
                strSQL.Append(" SELECT  CDLEMBRETE, DTLEMBRETE, DESCLEMBRETE, STNOTIFICACAO, STDESCARTAR FROM  TBLEMBRETES WHERE 1= 1 ");

                if (txtData.Text.Replace("/", "").Replace("/", "").Trim() != "")
                {
                    strSQL.Append(" AND YEAR(DTLEMBRETE) = " + txtData.Text.Split('/')[2]);
                    strSQL.Append(" AND MONTH(DTLEMBRETE) = " + txtData.Text.Split('/')[1]);
                    strSQL.Append(" AND DAY(DTLEMBRETE) = " + txtData.Text.Split('/')[0]);
                }

                strSQL.Append(" ORDER BY 2");

                dtgLembrete.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgLembrete.DataSource = objConexao.ExecutarComandoSqlDataSet(strSQL.ToString()).Tables[0];
                dtgLembrete.Columns["CDLEMBRETE"].Visible = false;
                dtgLembrete.Columns["DESCLEMBRETE"].HeaderText = "Lembrete";
                dtgLembrete.Columns["DTLEMBRETE"].HeaderText = "Data do Lembrete";
                dtgLembrete.Columns["DTLEMBRETE"].Width = 40;
                dtgLembrete.Columns["STNOTIFICACAO"].Visible = false;
                dtgLembrete.Columns["STDESCARTAR"].Visible = false;
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de ConsultaLembretes/Método Consultar/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                strSQL = null;
                objConexao = null;
            }
        }

        #endregion

        #region txtData_Leave
        
        private void txtData_Leave(object sender, EventArgs e)
        {
            DateTime dtOut = new DateTime();
            if (txtData.Text.Replace("/", "").Replace("/", "").Trim() != "")
            {
                if (!DateTime.TryParse(txtData.Text, out dtOut))
                {
                    MessageBox.Show("Data de Autorização informada não se econtra no formato correto.", "Informação", MessageBoxButtons.OK , MessageBoxIcon.Warning);
                    txtData.Text = "";
                    txtData.Focus();
                }
            }
        }

        #endregion
    }
}
