using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;
using System.IO.Compression;

using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using System.Threading;
using System.Configuration;
using System.IO;

namespace Agenda
{
    public partial class frmBackup : Form
    {
        private string nome_arquivo_compactado = "";

        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            btnBackup.Enabled = false;
            btnCancelar.Enabled = false;

            // Verifica se existe conexão com a Internet
            lblStatus.Text = "Verificando Conexão com a Internet.";
            this.Refresh();

            if (this.Conexao())
            {

                lblStatus.Text = "Conexão com a Internet OK.";
                progressBar.Value = 5;
                this.Refresh();

                try
                {

                    lblStatus.Text = "Verificando comunicação e credenciais com o Google!";
                    progressBar.Value = 10;
                    this.Refresh();

                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        new ClientSecrets
                        {
                            ClientId = "350067406102-7svgmdm51qo8igst853rbp6qer7ohnp3.apps.googleusercontent.com",
                            ClientSecret = "V9hBPXtEkqyJn-sPXTS5-DJ4",
                        },
                        new[] { DriveService.Scope.Drive },
                        ConfigurationManager.AppSettings["googleAccount"].ToString(),
                        CancellationToken.None).Result;

                    lblStatus.Text = "Conectando aos serviço do Google";
                    progressBar.Value = 30;
                    this.Refresh();

                    //try
                    //{
                    //    CompactarBD();
                    //}
                    //catch (Exception objErro)
                    //{
                    //    MessageBox.Show("Tela Bachup/ Método CompactarDB/ ERRO: " + objErro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}


                    // Create the service.
                    var service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Agenda - Clinica",
                    });


                    lblStatus.Text = "Verificando arquivo do Banco de Dados.";
                    progressBar.Value = 40;
                    this.Refresh();

                    Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
                    body.Title = "Backup BD Agenda Clinica. Dia " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + ".accdb";
                    body.Description = "Backup do Banco de Dados da Agendda da Clinica. Dia " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    body.MimeType = "application/msaccess";//"application/x-gzip";//"application/msaccess";

                    lblStatus.Text = "Criptografando o arquivo.";
                    progressBar.Value = 50;
                    this.Refresh();


                    byte[] byteArray = System.IO.File.ReadAllBytes(ConfigurationManager.AppSettings["caminhoBD"].ToString());
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

                    lblStatus.Text = "Enviando o arquivo para a conta do Google.";
                    progressBar.Value = 60;
                    this.Refresh();

                    FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "application/msaccess");
                    request.Upload();

                    //System.IO.File.Delete(nome_arquivo_compactado);

                    progressBar.Value = 100;
                    lblStatus.Text = "Backup realizado com sucesso!";
                    this.Refresh();

                    MessageBox.Show("Backup realizado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception objErro)
                {
                    lblStatus.Text = "Erro ao realizar o Backup, por favor, realize o Backup manualmente.";
                    progressBar.Value = 0;
                    this.Refresh();

                    MessageBox.Show("Erro ao realizar o Backup, por favor, realize o Backup manualmente. \r\n ERRO: " + objErro.Message, "ERRO",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblStatus.Text = "Problemas de conexão com a Internet, verifique sua conexão.";
                progressBar.Value = 0;
                this.Refresh();

                MessageBox.Show("Problemas de conexão com a Internet, verifique sua conexão.", "ERRO",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnBackup.Enabled = true;
            btnCancelar.Enabled = true;

        }


        private void CompactarBD()
        {
            if (!System.IO.File.Exists(ConfigurationManager.AppSettings["caminhoBD"].ToString()))
            {
                lblStatus.Text = "Banco de Dados não se encontra no caminho especificado.";
                this.Refresh();
                return;
            }

            try
            {
                FileStream sourceFileStream = System.IO.File.OpenRead(ConfigurationManager.AppSettings["caminhoBD"].ToString());
                nome_arquivo_compactado = ConfigurationManager.AppSettings["caminhoBD"].ToString().Replace(".accdb", ".gz") ;
                FileStream destFileStream = System.IO.File.Create(nome_arquivo_compactado  );


                GZipStream compressingStream = new GZipStream(destFileStream,
                                                                    CompressionMode.Compress);


                byte[] bytes = new byte[2048];
                int bytesRead;
                while ((bytesRead = sourceFileStream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    compressingStream.Write(bytes, 0, bytesRead);
                }

                sourceFileStream.Close();
                compressingStream.Close();
                destFileStream.Close();
            }
            catch (Exception objErro)
            {
                throw objErro;
            }
        }


        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        //Criar função para utilizar a API
        public static bool IsConnectedToInternet()
        {

            int Desc;
            return InternetGetConnectedState(out Desc, 0);

        }

        public bool Conexao()
        {
            return IsConnectedToInternet();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            this.ShowIcon = true;
            this.Icon = Resource.document_save_all;
        }
    }
}
