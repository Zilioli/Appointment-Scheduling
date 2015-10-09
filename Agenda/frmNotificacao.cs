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
    public partial class frmNotificacao : Form
    {
        private string strMensagem;
        private string strCodigo;

        public frmNotificacao()
        {
            InitializeComponent();
        }

        public frmNotificacao(string p_strMensagem, string p_strCodigo)
        {
            InitializeComponent();
            strMensagem = p_strMensagem;
            strCodigo = p_strCodigo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotificacao_Load(object sender, EventArgs e)
        {
            this.Icon = Resource.mail_message_new_3;
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblMensagem.Text = strMensagem;
        }

        private void btnConfirmarAgendamento_Click(object sender, EventArgs e)
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            StringBuilder strSQL = new StringBuilder();

            try
            {
                strSQL.Append(" UPDATE TBLEMBRETES SET STDESCARTAR = TRUE WHERE CDLEMBRETE = " + strCodigo);
                objConexao.ExecutarComandoSql(strSQL.ToString());
                this.Close();
            }
            catch (Exception objErro)
            {
                MessageBox.Show(objErro.Message);
            }
            finally
            {
                objConexao = null;
                strSQL = null;
            }
        }
    }
}
