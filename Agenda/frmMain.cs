using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Agenda
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup objFromBackup = new frmBackup();
            objFromBackup.ShowDialog();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgenda objAgenda = new frmAgenda();
            objAgenda.MdiParent = this;
            objAgenda.Show();
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcedimentos objFormProcedimentos = new frmProcedimentos();
            objFormProcedimentos.ShowDialog();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaciente objFormPaciente = new frmPaciente();
            objFormPaciente.ShowDialog();
        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorio objFormParametrosRelatorio = new frmRelatorio();
            objFormParametrosRelatorio.ShowDialog();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                frmHelp objFormHelp = new frmHelp();
                objFormHelp.ShowDialog();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Icon = Resource.documentation;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.MaximumSize = this.Size ;
            timerLembretes.Interval = (int)TimeSpan.FromMinutes(double.Parse(
                    ConfigurationManager.AppSettings["intervaloNoticicaoesLembretes"].ToString())).TotalMilliseconds;
            timerLembretes.Start();
            VerificarNotificacoes();
        }

        private void lembretesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarLembretes objFormConsultaLembrete = new frmConsultarLembretes();
            objFormConsultaLembrete.ShowDialog();
        }

        private void timerLembretes_Tick(object sender, EventArgs e)
        {
            VerificarNotificacoes();
        }

        #region VerificarNotificacoes
        private void VerificarNotificacoes()
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            StringBuilder strSQL = new StringBuilder();
            DataTable tblResultado;
            frmNotificacao objForm;

            try
            {
                strSQL.Append(" SELECT DESCLEMBRETE, CDLEMBRETE FROM TBLEMBRETES WHERE ");
                strSQL.Append(" YEAR(DTLEMBRETE) = " + DateTime.Now.Year);
                strSQL.Append(" AND MONTH(DTLEMBRETE) = " + DateTime.Now.Month);
                strSQL.Append(" AND DAY(DTLEMBRETE) = " + DateTime.Now.Day);
                strSQL.Append(" AND STNOTIFICACAO = TRUE AND STDESCARTAR = FALSE" );

                tblResultado = objConexao.ExecutarComandoSqlDataSet(strSQL.ToString()).Tables[0];

                if (tblResultado.Rows.Count > 0)
                {
                    foreach (DataRow rowLinha in tblResultado.Rows)
                    {
                        objForm = new frmNotificacao(rowLinha[0].ToString(), rowLinha[1].ToString());
                        objForm.ShowDialog();
                        objForm = null;
                    }
                }

            }
            catch (Exception objErro)
            {
                throw objErro;
            }
            finally
            {
                objConexao = null;
                tblResultado = null;
                strSQL = null;
            }

        }
        #endregion

        private void lembretesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLembrete objFormLembrete = new frmLembrete();
            objFormLembrete.ShowDialog();
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotas objFormNotas = new frmNotas();
            objFormNotas.ShowDialog();

        }
    }
}
