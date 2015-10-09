using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Agenda
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private DataSet objDataSetRelatorio;
        private VWParametrosRelatorio objParametrosRelatorio;
        private bool blnSimplificado = false;

        public frmReportViewer(DataSet p_rel, VWParametrosRelatorio p_parametros, bool p_Simplificado)
        {
            InitializeComponent();
            objDataSetRelatorio = p_rel;
            objParametrosRelatorio = p_parametros;
            blnSimplificado = p_Simplificado;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {

            this.ShowIcon = true;
            this.Icon = Resource.office_chart_area_stacked1;

            ReportDataSource objDataSource = new ReportDataSource("DtsRelatorio", objDataSetRelatorio.Tables[0]);
            reportViewer.LocalReport.ReportPath = (blnSimplificado == true ? "rptAgendamentosSimplificado.rdlc" : "rptAgendamentos.rdlc");
            reportViewer.LocalReport.DataSources.Add(objDataSource);


            reportViewer.LocalReport.SetParameters(new ReportParameter("DataInicioAgendamento", objParametrosRelatorio.DataInicioPeriodo));
            reportViewer.LocalReport.SetParameters(new ReportParameter("DataFimAgendamento", objParametrosRelatorio.DataFimPeriodo));
            reportViewer.LocalReport.SetParameters(new ReportParameter("DataInicioVencGuia", objParametrosRelatorio.DataInicioVencimentoGuia));
            reportViewer.LocalReport.SetParameters(new ReportParameter("DataFimVencGuia", objParametrosRelatorio.DataFimVencimentoGuia));
            reportViewer.LocalReport.SetParameters(new ReportParameter("Fisioterapeuta", objParametrosRelatorio.Fisioterapeuta));
            reportViewer.LocalReport.SetParameters(new ReportParameter("Paciente", objParametrosRelatorio.Paciente));
            reportViewer.LocalReport.SetParameters(new ReportParameter("Status", objParametrosRelatorio.Status));

            reportViewer.RefreshReport();
        }
    }
}
