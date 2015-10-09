namespace Agenda
{
    partial class frmLembrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLembrete));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataLembrete = new System.Windows.Forms.TextBox();
            this.chkNotificacao = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNovoLembrete = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmarAgendamento = new System.Windows.Forms.Button();
            this.txtLembrete = new System.Windows.Forms.TextBox();
            this.dtgLembrete = new System.Windows.Forms.DataGridView();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLembrete)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data Lembrete";
            // 
            // txtDataLembrete
            // 
            this.txtDataLembrete.Enabled = false;
            this.txtDataLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataLembrete.Location = new System.Drawing.Point(9, 43);
            this.txtDataLembrete.Name = "txtDataLembrete";
            this.txtDataLembrete.Size = new System.Drawing.Size(114, 18);
            this.txtDataLembrete.TabIndex = 10;
            // 
            // chkNotificacao
            // 
            this.chkNotificacao.AutoSize = true;
            this.chkNotificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotificacao.Location = new System.Drawing.Point(316, 43);
            this.chkNotificacao.Name = "chkNotificacao";
            this.chkNotificacao.Size = new System.Drawing.Size(254, 17);
            this.chkNotificacao.TabIndex = 11;
            this.chkNotificacao.Text = "Desejo que o sistema emita notificações";
            this.chkNotificacao.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpData);
            this.groupBox1.Controls.Add(this.btnNovoLembrete);
            this.groupBox1.Controls.Add(this.btnExcluir);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnConfirmarAgendamento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkNotificacao);
            this.groupBox1.Controls.Add(this.txtLembrete);
            this.groupBox1.Controls.Add(this.txtDataLembrete);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 197);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lembrete";
            // 
            // btnNovoLembrete
            // 
            this.btnNovoLembrete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoLembrete.Enabled = false;
            this.btnNovoLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoLembrete.Image = global::Agenda.Resource.note_add;
            this.btnNovoLembrete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoLembrete.Location = new System.Drawing.Point(9, 158);
            this.btnNovoLembrete.Name = "btnNovoLembrete";
            this.btnNovoLembrete.Size = new System.Drawing.Size(124, 26);
            this.btnNovoLembrete.TabIndex = 47;
            this.btnNovoLembrete.Text = "Novo Lembrete";
            this.btnNovoLembrete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoLembrete.UseVisualStyleBackColor = true;
            this.btnNovoLembrete.Click += new System.EventHandler(this.btnNovoLembrete_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Image = global::Agenda.Resource.document_close;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(437, 158);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(71, 26);
            this.btnExcluir.TabIndex = 46;
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
            this.btnCancelar.Location = new System.Drawing.Point(514, 158);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(56, 26);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Sair";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmarAgendamento
            // 
            this.btnConfirmarAgendamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarAgendamento.Image = global::Agenda.Resource.document_save_5;
            this.btnConfirmarAgendamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarAgendamento.Location = new System.Drawing.Point(364, 158);
            this.btnConfirmarAgendamento.Name = "btnConfirmarAgendamento";
            this.btnConfirmarAgendamento.Size = new System.Drawing.Size(67, 26);
            this.btnConfirmarAgendamento.TabIndex = 21;
            this.btnConfirmarAgendamento.Text = "Salvar";
            this.btnConfirmarAgendamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarAgendamento.UseVisualStyleBackColor = true;
            this.btnConfirmarAgendamento.Click += new System.EventHandler(this.btnConfirmarAgendamento_Click);
            // 
            // txtLembrete
            // 
            this.txtLembrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLembrete.Location = new System.Drawing.Point(9, 79);
            this.txtLembrete.Multiline = true;
            this.txtLembrete.Name = "txtLembrete";
            this.txtLembrete.Size = new System.Drawing.Size(561, 73);
            this.txtLembrete.TabIndex = 13;
            // 
            // dtgLembrete
            // 
            this.dtgLembrete.AllowUserToAddRows = false;
            this.dtgLembrete.AllowUserToDeleteRows = false;
            this.dtgLembrete.AllowUserToOrderColumns = true;
            this.dtgLembrete.AllowUserToResizeColumns = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.dtgLembrete.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgLembrete.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgLembrete.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgLembrete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLembrete.Location = new System.Drawing.Point(15, 215);
            this.dtgLembrete.MaximumSize = new System.Drawing.Size(576, 254);
            this.dtgLembrete.MinimumSize = new System.Drawing.Size(576, 254);
            this.dtgLembrete.MultiSelect = false;
            this.dtgLembrete.Name = "dtgLembrete";
            this.dtgLembrete.ReadOnly = true;
            this.dtgLembrete.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgLembrete.Size = new System.Drawing.Size(576, 254);
            this.dtgLembrete.TabIndex = 14;
            this.dtgLembrete.Click += new System.EventHandler(this.dtgLembrete_Click);
            // 
            // dtpData
            // 
            this.dtpData.Location = new System.Drawing.Point(9, 43);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(260, 20);
            this.dtpData.TabIndex = 15;
            this.dtpData.Visible = false;
            this.dtpData.ValueChanged += new System.EventHandler(this.dtpData_ValueChanged);
            // 
            // frmLembrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 492);
            this.Controls.Add(this.dtgLembrete);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(619, 519);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(619, 519);
            this.Name = "frmLembrete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Lembrete";
            this.Load += new System.EventHandler(this.frmLembrete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLembrete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataLembrete;
        private System.Windows.Forms.CheckBox chkNotificacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLembrete;
        private System.Windows.Forms.DataGridView dtgLembrete;
        private System.Windows.Forms.Button btnConfirmarAgendamento;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovoLembrete;
        private System.Windows.Forms.DateTimePicker dtpData;
    }
}