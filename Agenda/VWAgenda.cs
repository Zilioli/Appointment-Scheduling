using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda
{
    public class VWAgenda
    {

        private string _horaAgendamento;
        public string horaAgendamento
        {
            get { return _horaAgendamento; }
            set { _horaAgendamento = value; }
        }

        private string _cdPaciente;
        public string cdPaciente
        {
            get { return _cdPaciente; }
            set { _cdPaciente = value; }
        }
        private string _nmPaciente = "";
        public string nmPaciente
        {
            get { return _nmPaciente.ToUpper(); }
            set { _nmPaciente = value; }
        }

        private string _telPaciente;
        public string telPaciente
        {
            get { return _telPaciente; }
            set { _telPaciente = value; }
        }

        private string _telPaciente2;
        public string telPaciente2
        {
            get { return _telPaciente2; }
            set { _telPaciente2 = value; }
        }

        private string _cdFuncionario;
        public string cdFuncionario
        {
            get { return _cdFuncionario; }
            set { _cdFuncionario = value; }
        }

        private string _nmFuncionario = "";
        public string nmFuncionario
        {
            get { return _nmFuncionario.ToUpper(); }
            set { _nmFuncionario = value; }
        }

        private string _cdStatus;
        public string cdStatus
        {
            get { return _cdStatus; }
            set { _cdStatus = value; }
        }

        private string _desStatus = "";
        public string desStatus
        {
            get { return _desStatus.ToUpper(); }
            set { _desStatus = value; }

        }

        private DateTime _dtAgendamento;
        public DateTime dtAgendamento
        {
            get { return _dtAgendamento; }
            set { _dtAgendamento = value; }
        }

        private string _cdAgendamento = "";
        public string cdAgendamento
        {
            get { return _cdAgendamento; }
            set { _cdAgendamento = value; }
        }

        private List<VWProcedimentos> _lstProcedimento = new List<VWProcedimentos>();
        public List<VWProcedimentos> lstProcedimento
        {
            get { return _lstProcedimento; }
            set { _lstProcedimento = value; }
        }

        private string _dtAutorizacaoGuia;
        public string dtAutorizacaoGuia
        {
            get { return _dtAutorizacaoGuia; }
            set { _dtAutorizacaoGuia = value; }
        }

        private string _dtVencimentoGuia;
        public string dtVencimentoGuia
        {
            get { return _dtVencimentoGuia; }
            set { _dtVencimentoGuia = value; }
        }

        private string _cor;
        public string cor
        {
            get { return _cor; }
            set { _cor = value; }
        }

    }

    public class VWProcedimentos
    {
        private string _cdProcedimento;
        public string cdProcedimento
        {
            get { return _cdProcedimento; }
            set { _cdProcedimento = value; }
        }

        private string _vlProcedimento;
        public string vlProcedimento
        {
            get { return _vlProcedimento; }
            set { _vlProcedimento = value; }
        }

        private string _nmProcedimento;
        public string nmProcedimento
        {
            get { return _nmProcedimento; }
            set { _nmProcedimento = value; }
        }

        private string _cdProcedimentoUnimed;
        public string cdProcedimentoUnimed
        {
            get { return _cdProcedimentoUnimed; }
            set { _cdProcedimentoUnimed = value; }
        }

    }

    public class VWParametrosRelatorio
    {
        public VWParametrosRelatorio(string p_DtInicioPeriodo,
            string p_DtFimPeriodo,
            string p_InicioVencGuia,
            string p_FimVencGuia,
            string p_Fisioterapeuta,
            string p_Status,
            string p_Paciente)
        {
            this.p_Status = p_Status;
            this.p_DtFimPeriodo = p_DtFimPeriodo;
            this.p_DtInicioPeriodo = p_DtInicioPeriodo;
            this.p_InicioVencGuia = p_InicioVencGuia;
            this.p_FimVencGuia = p_FimVencGuia;
            this.p_Fisioterapeuta = p_Fisioterapeuta;
        }

        private string p_DtInicioPeriodo = "";
        private string p_DtFimPeriodo = "";
        private string p_InicioVencGuia = "";
        private string p_FimVencGuia = "";
        private string p_Fisioterapeuta = "";
        private string p_Status = "";
        private string p_Paciente = "";


        public string DataInicioPeriodo
        {
            get { return p_DtInicioPeriodo; }
        }

        public string DataFimPeriodo
        {
            get { return p_DtFimPeriodo; }
        }

        public string DataInicioVencimentoGuia
        {
            get { return p_InicioVencGuia; }
        }

        public string DataFimVencimentoGuia
        {
            get { return p_FimVencGuia; }
        }

        public string Fisioterapeuta
        {
            get { return p_Fisioterapeuta; }
        }

        public string Paciente
        {
            get { return p_Paciente; }
        }

        public string Status
        {
            get { return p_Status; }
        }
    }
}
