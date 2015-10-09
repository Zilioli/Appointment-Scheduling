namespace Agenda
{
    partial class frmIncluirAgendamento_
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncluirAgendamento_));
            this.cboPaciente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFisioterapeutas = new System.Windows.Forms.ComboBox();
            this.btnIncluirPaciente = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtpDataAgendamento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoraAgendamento = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSessoes = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPeriodicidade = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboProcedimentos = new System.Windows.Forms.ComboBox();
            this.dtgProcedimentos = new System.Windows.Forms.DataGridView();
            this.CodigoProcedimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeProcedimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionarProcedimento = new System.Windows.Forms.Button();
            this.btnRemoverProcedimento = new System.Windows.Forms.Button();
            this.btnConfirmarAgendamento = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAutorizacaoGuia = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVencimentoGuia = new System.Windows.Forms.MaskedTextBox();
            this.groupDiasSemana = new System.Windows.Forms.GroupBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcedimentos)).BeginInit();
            this.groupDiasSemana.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPaciente
            // 
            this.cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaciente.FormattingEnabled = true;
            this.cboPaciente.Location = new System.Drawing.Point(12, 131);
            this.cboPaciente.Name = "cboPaciente";
            this.cboPaciente.Size = new System.Drawing.Size(420, 21);
            this.cboPaciente.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fisioterapeuta";
            // 
            // cboFisioterapeutas
            // 
            this.cboFisioterapeutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFisioterapeutas.FormattingEnabled = true;
            this.cboFisioterapeutas.Location = new System.Drawing.Point(12, 180);
            this.cboFisioterapeutas.Name = "cboFisioterapeutas";
            this.cboFisioterapeutas.Size = new System.Drawing.Size(420, 21);
            this.cboFisioterapeutas.TabIndex = 2;
            // 
            // btnIncluirPaciente
            // 
            this.btnIncluirPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluirPaciente.Image = global::Agenda.Resource.user_add;
            this.btnIncluirPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluirPaciente.Location = new System.Drawing.Point(438, 129);
            this.btnIncluirPaciente.Name = "btnIncluirPaciente";
            this.btnIncluirPaciente.Size = new System.Drawing.Size(65, 26);
            this.btnIncluirPaciente.TabIndex = 4;
            this.btnIncluirPaciente.Text = "Novo";
            this.btnIncluirPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluirPaciente.UseVisualStyleBackColor = true;
            this.btnIncluirPaciente.Click += new System.EventHandler(this.btnIncluirPaciente_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(15, 214);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(12, 230);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(420, 21);
            this.cboStatus.TabIndex = 5;
            // 
            // dtpDataAgendamento
            // 
            this.dtpDataAgendamento.Location = new System.Drawing.Point(12, 39);
            this.dtpDataAgendamento.Name = "dtpDataAgendamento";
            this.dtpDataAgendamento.Size = new System.Drawing.Size(235, 20);
            this.dtpDataAgendamento.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data Agendamento";
            // 
            // txtHoraAgendamento
            // 
            this.txtHoraAgendamento.Location = new System.Drawing.Point(253, 39);
            this.txtHoraAgendamento.Mask = "90:00";
            this.txtHoraAgendamento.Name = "txtHoraAgendamento";
            this.txtHoraAgendamento.Size = new System.Drawing.Size(102, 20);
            this.txtHoraAgendamento.TabIndex = 9;
            this.txtHoraAgendamento.Leave += new System.EventHandler(this.txtHoraAgendamento_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hora Agendamento";
            // 
            // txtSessoes
            // 
            this.txtSessoes.Location = new System.Drawing.Point(376, 39);
            this.txtSessoes.Mask = "00";
            this.txtSessoes.Name = "txtSessoes";
            this.txtSessoes.Size = new System.Drawing.Size(87, 20);
            this.txtSessoes.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(373, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sessoes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(469, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Periodicidade";
            // 
            // cboPeriodicidade
            // 
            this.cboPeriodicidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriodicidade.FormattingEnabled = true;
            this.cboPeriodicidade.Items.AddRange(new object[] {
            "",
            "Diário",
            "Semanal",
            "2x Semana",
            "3x Semana"});
            this.cboPeriodicidade.Location = new System.Drawing.Point(469, 38);
            this.cboPeriodicidade.Name = "cboPeriodicidade";
            this.cboPeriodicidade.Size = new System.Drawing.Size(121, 21);
            this.cboPeriodicidade.TabIndex = 13;
            this.cboPeriodicidade.SelectedIndexChanged += new System.EventHandler(this.cboPeriodicidade_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Procedimentos";
            // 
            // cboProcedimentos
            // 
            this.cboProcedimentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcedimentos.FormattingEnabled = true;
            this.cboProcedimentos.Location = new System.Drawing.Point(12, 281);
            this.cboProcedimentos.Name = "cboProcedimentos";
            this.cboProcedimentos.Size = new System.Drawing.Size(420, 21);
            this.cboProcedimentos.TabIndex = 15;
            // 
            // dtgProcedimentos
            // 
            this.dtgProcedimentos.AllowUserToAddRows = false;
            this.dtgProcedimentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProcedimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProcedimentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoProcedimento,
            this.CodigoNome,
            this.QuantidadeProcedimento});
            this.dtgProcedimentos.Location = new System.Drawing.Point(12, 328);
            this.dtgProcedimentos.MultiSelect = false;
            this.dtgProcedimentos.Name = "dtgProcedimentos";
            this.dtgProcedimentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgProcedimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProcedimentos.Size = new System.Drawing.Size(569, 86);
            this.dtgProcedimentos.TabIndex = 17;
            // 
            // CodigoProcedimento
            // 
            this.CodigoProcedimento.HeaderText = "CodigoProcedimento";
            this.CodigoProcedimento.Name = "CodigoProcedimento";
            this.CodigoProcedimento.Visible = false;
            // 
            // CodigoNome
            // 
            this.CodigoNome.HeaderText = "Codigo/Nome Procediemto";
            this.CodigoNome.Name = "CodigoNome";
            // 
            // QuantidadeProcedimento
            // 
            this.QuantidadeProcedimento.HeaderText = "Quantidade Procedimento";
            this.QuantidadeProcedimento.Name = "QuantidadeProcedimento";
            // 
            // btnAdicionarProcedimento
            // 
            this.btnAdicionarProcedimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarProcedimento.Image = global::Agenda.Resource.dialog_more;
            this.btnAdicionarProcedimento.Location = new System.Drawing.Point(444, 279);
            this.btnAdicionarProcedimento.Name = "btnAdicionarProcedimento";
            this.btnAdicionarProcedimento.Size = new System.Drawing.Size(41, 26);
            this.btnAdicionarProcedimento.TabIndex = 18;
            this.btnAdicionarProcedimento.UseVisualStyleBackColor = true;
            this.btnAdicionarProcedimento.Click += new System.EventHandler(this.btnAdicionarProcedimento_Click);
            // 
            // btnRemoverProcedimento
            // 
            this.btnRemoverProcedimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverProcedimento.Image = global::Agenda.Resource.dialog_fewer;
            this.btnRemoverProcedimento.Location = new System.Drawing.Point(487, 279);
            this.btnRemoverProcedimento.Name = "btnRemoverProcedimento";
            this.btnRemoverProcedimento.Size = new System.Drawing.Size(41, 26);
            this.btnRemoverProcedimento.TabIndex = 19;
            this.btnRemoverProcedimento.Text = "-";
            this.btnRemoverProcedimento.UseVisualStyleBackColor = true;
            this.btnRemoverProcedimento.Click += new System.EventHandler(this.btnRemoverProcedimento_Click);
            // 
            // btnConfirmarAgendamento
            // 
            this.btnConfirmarAgendamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarAgendamento.Image = global::Agenda.Resource.document_save_5;
            this.btnConfirmarAgendamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarAgendamento.Location = new System.Drawing.Point(361, 417);
            this.btnConfirmarAgendamento.Name = "btnConfirmarAgendamento";
            this.btnConfirmarAgendamento.Size = new System.Drawing.Size(85, 26);
            this.btnConfirmarAgendamento.TabIndex = 20;
            this.btnConfirmarAgendamento.Text = "Confirmar";
            this.btnConfirmarAgendamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarAgendamento.UseVisualStyleBackColor = true;
            this.btnConfirmarAgendamento.Click += new System.EventHandler(this.btnConfirmarAgendamento_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Aut. Guia";
            // 
            // txtAutorizacaoGuia
            // 
            this.txtAutorizacaoGuia.Location = new System.Drawing.Point(12, 82);
            this.txtAutorizacaoGuia.Mask = "00/00/0000";
            this.txtAutorizacaoGuia.Name = "txtAutorizacaoGuia";
            this.txtAutorizacaoGuia.Size = new System.Drawing.Size(102, 20);
            this.txtAutorizacaoGuia.TabIndex = 22;
            this.txtAutorizacaoGuia.ValidatingType = typeof(System.DateTime);
            this.txtAutorizacaoGuia.Leave += new System.EventHandler(this.txtAutorizacaoGuia_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(142, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Venc. Guia";
            // 
            // txtVencimentoGuia
            // 
            this.txtVencimentoGuia.Location = new System.Drawing.Point(139, 83);
            this.txtVencimentoGuia.Mask = "00/00/0000";
            this.txtVencimentoGuia.Name = "txtVencimentoGuia";
            this.txtVencimentoGuia.Size = new System.Drawing.Size(102, 20);
            this.txtVencimentoGuia.TabIndex = 24;
            this.txtVencimentoGuia.ValidatingType = typeof(System.DateTime);
            this.txtVencimentoGuia.Leave += new System.EventHandler(this.txtVencimentoGuia_Leave);
            // 
            // groupDiasSemana
            // 
            this.groupDiasSemana.Controls.Add(this.chk3);
            this.groupDiasSemana.Controls.Add(this.chk6);
            this.groupDiasSemana.Controls.Add(this.chk5);
            this.groupDiasSemana.Controls.Add(this.chk4);
            this.groupDiasSemana.Controls.Add(this.chk2);
            this.groupDiasSemana.Enabled = false;
            this.groupDiasSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDiasSemana.Location = new System.Drawing.Point(361, 68);
            this.groupDiasSemana.Name = "groupDiasSemana";
            this.groupDiasSemana.Size = new System.Drawing.Size(232, 39);
            this.groupDiasSemana.TabIndex = 26;
            this.groupDiasSemana.TabStop = false;
            this.groupDiasSemana.Text = "Dias da Semana";
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(46, 18);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(34, 17);
            this.chk3.TabIndex = 4;
            this.chk3.Text = "T";
            this.chk3.UseVisualStyleBackColor = true;
            this.chk3.CheckedChanged += new System.EventHandler(this.DiaSemana_CheckedChanged);
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.Location = new System.Drawing.Point(166, 17);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(34, 17);
            this.chk6.TabIndex = 3;
            this.chk6.Text = "S";
            this.chk6.UseVisualStyleBackColor = true;
            this.chk6.CheckedChanged += new System.EventHandler(this.DiaSemana_CheckedChanged);
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.Location = new System.Drawing.Point(126, 18);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(35, 17);
            this.chk5.TabIndex = 2;
            this.chk5.Text = "Q";
            this.chk5.UseVisualStyleBackColor = true;
            this.chk5.CheckedChanged += new System.EventHandler(this.DiaSemana_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(86, 18);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(35, 17);
            this.chk4.TabIndex = 1;
            this.chk4.Text = "Q";
            this.chk4.UseVisualStyleBackColor = true;
            this.chk4.CheckedChanged += new System.EventHandler(this.DiaSemana_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(6, 19);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(34, 17);
            this.chk2.TabIndex = 0;
            this.chk2.Text = "S";
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.CheckedChanged += new System.EventHandler(this.DiaSemana_CheckedChanged);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::Agenda.Resource.document_close;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(451, 417);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(71, 26);
            this.btnExcluir.TabIndex = 27;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(525, 417);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(56, 26);
            this.btnCancelar.TabIndex = 44;
            this.btnCancelar.Text = "Sair";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelarAgendamento_Click);
            // 
            // frmIncluirAgendamento_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 452);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.groupDiasSemana);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVencimentoGuia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAutorizacaoGuia);
            this.Controls.Add(this.btnConfirmarAgendamento);
            this.Controls.Add(this.btnRemoverProcedimento);
            this.Controls.Add(this.btnAdicionarProcedimento);
            this.Controls.Add(this.dtgProcedimentos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboProcedimentos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboPeriodicidade);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSessoes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoraAgendamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDataAgendamento);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.btnIncluirPaciente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboFisioterapeutas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPaciente);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(619, 490);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(619, 490);
            this.Name = "frmIncluirAgendamento_";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incluir Agendamento";
            this.Load += new System.EventHandler(this.frmIncluirAgendamento__Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcedimentos)).EndInit();
            this.groupDiasSemana.ResumeLayout(false);
            this.groupDiasSemana.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPaciente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFisioterapeutas;
        private System.Windows.Forms.Button btnIncluirPaciente;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpDataAgendamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtHoraAgendamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtSessoes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboPeriodicidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboProcedimentos;
        private System.Windows.Forms.DataGridView dtgProcedimentos;
        private System.Windows.Forms.Button btnAdicionarProcedimento;
        private System.Windows.Forms.Button btnRemoverProcedimento;
        private System.Windows.Forms.Button btnConfirmarAgendamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProcedimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeProcedimento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtAutorizacaoGuia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtVencimentoGuia;
        private System.Windows.Forms.GroupBox groupDiasSemana;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.CheckBox chk6;
        private System.Windows.Forms.CheckBox chk5;
        private System.Windows.Forms.CheckBox chk4;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelar;
    }
}