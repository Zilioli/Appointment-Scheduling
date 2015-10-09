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
    public partial class frmProcedimentos : Form
    {

        private bool blnAlteracao = false;
        private bool blnSelecionouCor = false;
        private string strCodigo = "";

        public frmProcedimentos()
        {
            InitializeComponent();
        }

        private void frmProcedimentos_Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
            this.Icon = Resource.system_run_3;
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            clsConexaoBD objConexao = new clsConexaoBD();

            try
            {
                dtgProcedimentos.DataSource =
                    objConexao.ExecutarComandoSqlDataSet("SELECT CDPROCEDIMENTO, CDPROCEDIMENTOUNIMED, UCASE(NMPROCEDIMENTO) AS NMPROCEDIMENTO, VLPROCEDIMENTO, CORPROCEDIMENTO FROM TBPROCEDIMENTOS ORDER BY 2").Tables[0];

                dtgProcedimentos.Columns["CDPROCEDIMENTO"].Visible = false;
                dtgProcedimentos.Columns["CDPROCEDIMENTOUNIMED"].HeaderText = "Código Procedimento.";
                dtgProcedimentos.Columns["NMPROCEDIMENTO"].HeaderText = "Descrição";
                dtgProcedimentos.Columns["VLPROCEDIMENTO"].HeaderText = "Valor";
                dtgProcedimentos.Columns["VLPROCEDIMENTO"].DefaultCellStyle.Format = "c";
                dtgProcedimentos.Columns["CORPROCEDIMENTO"].Visible = false;


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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            clsConexaoBD objConexao = new clsConexaoBD();
            StringBuilder strSQL = new StringBuilder();

            try
            {

                if (txtCodigoProcediment.Text == "" || txtDescricao.Text == "" || txtValorProcedimento.Text == "")
                    MessageBox.Show("Preencha os campos obrigatórios.");
                else
                {


                    if (!blnAlteracao)
                    {

                        strSQL.Append(" INSERT INTO TBPROCEDIMENTOS(CDPROCEDIMENTOUNIMED, NMPROCEDIMENTO, VLPROCEDIMENTO, CORPROCEDIMENTO) VALUES(");
                        strSQL.Append("'" + txtCodigoProcediment.Text + "',");
                        strSQL.Append("'" + txtDescricao.Text + "',");
                        strSQL.Append("'" + txtValorProcedimento.Text + "',");
                        if (blnSelecionouCor)
                            strSQL.Append("'" + colorDialog.Color.A + "/" + colorDialog.Color.R + "/" + colorDialog.Color.G + "/" + colorDialog.Color.B + "'");
                        else
                            strSQL.Append("''");
                        strSQL.Append(" )");

                        objConexao.ExecutarComandoSql(strSQL.ToString());

                        MessageBox.Show("Procedimento incluido");
                    }
                    else
                    {
                        strSQL.Append("UPDATE TBPROCEDIMENTOS SET ");
                        strSQL.Append("CDPROCEDIMENTOUNIMED = '" + txtCodigoProcediment.Text + "', ");
                        strSQL.Append("NMPROCEDIMENTO = '" + txtDescricao.Text + "', ");
                        strSQL.Append("VLPROCEDIMENTO = '" + txtValorProcedimento.Text + "' ");

                        if (blnSelecionouCor && chkCor.Checked)
                            strSQL.Append(", CORPROCEDIMENTO = '" + colorDialog.Color.A + "/" + colorDialog.Color.R + "/" + colorDialog.Color.G + "/" + colorDialog.Color.B + "'");
                        else
                            strSQL.Append(", CORPROCEDIMENTO = '' ");

                        strSQL.Append("  WHERE CDPROCEDIMENTO = " + strCodigo);

                        objConexao.ExecutarComandoSql(strSQL.ToString());

                        MessageBox.Show("Procedimento alterado");

                        if (dtgProcedimentos.SelectedRows.Count > 0)
                            dtgProcedimentos.SelectedRows[0].Selected = false;
                    }

                    txtCodigoProcediment.Text = "";
                    txtDescricao.Text = "";
                    txtValorProcedimento.Text = "";
                    blnAlteracao = false;
                    strCodigo = "";
                    chkCor.Checked = false;
                    imgCor.Enabled = btnCor.Enabled = false;
                    imgCor.BackColor = Color.FromName("Control");
                    CarregarGrid();

                }


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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgProcedimentos_Click(object sender, EventArgs e)
        {
            blnAlteracao = true;
            txtDescricao.Text = ((DataGridView)sender).SelectedRows[0].Cells["NMPROCEDIMENTO"].Value.ToString();
            txtCodigoProcediment.Text = ((DataGridView)sender).SelectedRows[0].Cells["CDPROCEDIMENTOUNIMED"].Value.ToString();
            txtValorProcedimento.Text = decimal.Parse(((DataGridView)sender).SelectedRows[0].Cells["VLPROCEDIMENTO"].Value.ToString()).ToString("N");
            strCodigo = ((DataGridView)sender).SelectedRows[0].Cells["CDPROCEDIMENTO"].Value.ToString();
            string[] strCor;
            strCor = ((DataGridView)sender).SelectedRows[0].Cells["CORPROCEDIMENTO"].Value.ToString().Split('/');
            if (strCor.Length > 1)
            {
                imgCor.BackColor = Color.FromArgb(int.Parse(strCor[0]), int.Parse(strCor[1]), int.Parse(strCor[2]), int.Parse(strCor[3]));
                chkCor.Checked = true;
                imgCor.Enabled = btnCor.Enabled = true;
            }
            else
            {
                imgCor.BackColor = Color.FromName("Control");
                chkCor.Checked = false;
                imgCor.Enabled = btnCor.Enabled = false;
            }
        }

        private void btnNovoProcedimento_Click(object sender, EventArgs e)
        {
            txtCodigoProcediment.Text = "";
            txtDescricao.Text = "";
            txtValorProcedimento.Text = "";
            strCodigo = "";
            blnAlteracao = false;
            imgCor.BackColor = Color.FromName("Control");
            blnSelecionouCor = false;
            chkCor.Checked = false;
            imgCor.Enabled = btnCor.Enabled = false;

            if (dtgProcedimentos.SelectedRows.Count > 0)
                dtgProcedimentos.SelectedRows[0].Selected = false;
        }

        private bool ValidarValorProcedimento()
        {
            decimal decAux;
            if (decimal.TryParse(txtValorProcedimento.Text, out decAux))
            {
                txtValorProcedimento.Text = decAux.ToString("N");
                return true;
            }
            else
            {
                MessageBox.Show("Valor do Procedimento informado de forma incorreta (Ex 000.00).");
                txtValorProcedimento.Focus();
                return false;
            }

        }

        private void txtValorProcedimento_Leave(object sender, EventArgs e)
        {
            ValidarValorProcedimento();
        }

        private void btnCor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgCor.BackColor = colorDialog.Color;
                blnSelecionouCor = true;
            }
        }

        private void dtgProcedimentos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string[] strCor;
            if (e.RowIndex > 1)
                if (dtgProcedimentos.Rows[e.RowIndex].Cells["CORPROCEDIMENTO"].Value.ToString() != "")
                {
                    strCor = dtgProcedimentos.Rows[e.RowIndex].Cells["CORPROCEDIMENTO"].Value.ToString().Split('/');
                    e.CellStyle.BackColor = Color.FromArgb(int.Parse(strCor[0]), int.Parse(strCor[1]), int.Parse(strCor[2]), int.Parse(strCor[3]));
                }
        }

        private void chkCor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCor.Checked)
                imgCor.Enabled = btnCor.Enabled = true;
            else
            {
                imgCor.Enabled = btnCor.Enabled = false;
                imgCor.BackColor = Color.FromName("Control");
            }
        }




    }
}