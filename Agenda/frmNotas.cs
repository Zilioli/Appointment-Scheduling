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
    public partial class frmNotas : Form
    {
        public frmNotas()
        {
            InitializeComponent();
        }

        private void frmNotas_Load(object sender, EventArgs e)
        {
            clsConexaoBD objConexao = new clsConexaoBD();

            try
            {
                txtNotas.Text = objConexao.ExecutarComandoSqlDataSet("SELECT DESCLEMBRETE FROM TBLEMBRETES WHERE DTLEMBRETE IS NULL").Tables[0].Rows[0][0].ToString();
                this.ShowIcon = true;
                this.Icon = Resource.notepad1;
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela Anotações/Método OnLoad/ERRO: " + objErro.Message , "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            clsConexaoBD objConexao = new clsConexaoBD();

            try
            {
                if(objConexao.ExecutarComandoSqlDataSet("SELECT COUNT(*) FROM TBLEMBRETES WHERE DTLEMBRETE IS NULL").Tables[0].Rows.Count <= 0 )
                    objConexao.ExecutarComandoSql("INSERT INTO TBLEMBRETES(DESCLEMBRETE) VALUES('" + txtNotas.Text + "')");
                else
                    objConexao.ExecutarComandoSql("UPDATE TBLEMBRETES SET  DESCLEMBRETE = '" + txtNotas.Text + "' WHERE DTLEMBRETE IS NULL");
            }
            catch (Exception objErro)
            {
                MessageBox.Show("Tela de Anotações/Método Salvar/ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objConexao = null;
            }
        }
    }
}
