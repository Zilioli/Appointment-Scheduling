using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace Agenda
{
    public class clsConexaoBD
    {

        private OleDbConnection objConnection;

        public clsConexaoBD()
        {
            try
            {
                objConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                    ConfigurationManager.AppSettings["caminhoBD"].ToString());
            }
            catch (Exception objErro)
            {
                throw objErro;
            }

        }

        private void AbrirConexao()
        {
            if (objConnection.State != System.Data.ConnectionState.Open)
                objConnection.Open();
        }

        private void FecharConexao()
        {
            if (objConnection.State != System.Data.ConnectionState.Closed)
                objConnection.Close();
        }

        public int ExecutarComandoSql(string p_sql)
        {
            OleDbCommand objCommand;
            try
            {
                this.AbrirConexao();

                objCommand = new OleDbCommand(p_sql, objConnection);

                return objCommand.ExecuteNonQuery();
            }
            catch (Exception objErro)
            {
                throw objErro;
            }
            finally
            {
                this.FecharConexao();
                objCommand = null;
            }
        }

        public DataSet ExecutarComandoSqlDataSet(string p_sql)
        {
            OleDbDataAdapter objDataAdapter;
            DataSet objDsResultado = new DataSet();
            try
            {
                this.AbrirConexao();

                objDataAdapter = new OleDbDataAdapter(p_sql, objConnection);

                objDataAdapter.Fill(objDsResultado);

                return objDsResultado;
            }
            catch (Exception objErro)
            {
                throw objErro;
            }
            finally
            {
                this.FecharConexao();
                objDataAdapter = null;
            }
        }

    }
}
