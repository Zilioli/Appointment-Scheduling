namespace Agenda
{
    partial class frmProcedimentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcedimentos));
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoProcediment = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnNovoProcedimento = new System.Windows.Forms.Button();
            this.dtgProcedimentos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtValorProcedimento = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.imgCor = new System.Windows.Forms.PictureBox();
            this.btnCor = new System.Windows.Forms.Button();
            this.chkCor = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcedimentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCor)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Codigo Procedimento";
            // 
            // txtCodigoProcediment
            // 
            this.txtCodigoProcediment.Location = new System.Drawing.Point(12, 26);
            this.txtCodigoProcediment.Name = "txtCodigoProcediment";
            this.txtCodigoProcediment.Size = new System.Drawing.Size(124, 20);
            this.txtCodigoProcediment.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = global::Agenda.Resource.document_save_5;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.Location = new System.Drawing.Point(470, 386);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(67, 26);
            this.btnConfirmar.TabIndex = 17;
            this.btnConfirmar.Text = "Salvar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnNovoProcedimento
            // 
            this.btnNovoProcedimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoProcedimento.Image = global::Agenda.Resource.system_run_31;
            this.btnNovoProcedimento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovoProcedimento.Location = new System.Drawing.Point(461, 68);
            this.btnNovoProcedimento.Name = "btnNovoProcedimento";
            this.btnNovoProcedimento.Size = new System.Drawing.Size(136, 26);
            this.btnNovoProcedimento.TabIndex = 16;
            this.btnNovoProcedimento.Text = "Novo Procediento";
            this.btnNovoProcedimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoProcedimento.UseVisualStyleBackColor = true;
            this.btnNovoProcedimento.Click += new System.EventHandler(this.btnNovoProcedimento_Click);
            // 
            // dtgProcedimentos
            // 
            this.dtgProcedimentos.AllowUserToAddRows = false;
            this.dtgProcedimentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProcedimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProcedimentos.Location = new System.Drawing.Point(12, 100);
            this.dtgProcedimentos.MultiSelect = false;
            this.dtgProcedimentos.Name = "dtgProcedimentos";
            this.dtgProcedimentos.ReadOnly = true;
            this.dtgProcedimentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProcedimentos.Size = new System.Drawing.Size(587, 280);
            this.dtgProcedimentos.TabIndex = 15;
            this.dtgProcedimentos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgProcedimentos_CellPainting);
            this.dtgProcedimentos.Click += new System.EventHandler(this.dtgProcedimentos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Valor (R$)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Descrição do Procedimento";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(147, 26);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(450, 20);
            this.txtDescricao.TabIndex = 11;
            // 
            // txtValorProcedimento
            // 
            this.txtValorProcedimento.Location = new System.Drawing.Point(12, 71);
            this.txtValorProcedimento.Name = "txtValorProcedimento";
            this.txtValorProcedimento.Size = new System.Drawing.Size(89, 20);
            this.txtValorProcedimento.TabIndex = 21;
            this.txtValorProcedimento.Leave += new System.EventHandler(this.txtValorProcedimento_Leave);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(543, 386);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(56, 26);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Sair";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imgCor
            // 
            this.imgCor.BackColor = System.Drawing.SystemColors.Control;
            this.imgCor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCor.Enabled = false;
            this.imgCor.Location = new System.Drawing.Point(147, 71);
            this.imgCor.Name = "imgCor";
            this.imgCor.Size = new System.Drawing.Size(63, 23);
            this.imgCor.TabIndex = 24;
            this.imgCor.TabStop = false;
            // 
            // btnCor
            // 
            this.btnCor.Enabled = false;
            this.btnCor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCor.Image = global::Agenda.Resource.preferences_desktop_color;
            this.btnCor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCor.Location = new System.Drawing.Point(216, 71);
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(30, 26);
            this.btnCor.TabIndex = 25;
            this.btnCor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCor.UseVisualStyleBackColor = true;
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // chkCor
            // 
            this.chkCor.AutoSize = true;
            this.chkCor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCor.Location = new System.Drawing.Point(147, 52);
            this.chkCor.Name = "chkCor";
            this.chkCor.Size = new System.Drawing.Size(45, 17);
            this.chkCor.TabIndex = 26;
            this.chkCor.Text = "Cor";
            this.chkCor.UseVisualStyleBackColor = true;
            this.chkCor.CheckedChanged += new System.EventHandler(this.chkCor_CheckedChanged);
            // 
            // frmProcedimentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 434);
            this.Controls.Add(this.chkCor);
            this.Controls.Add(this.btnCor);
            this.Controls.Add(this.imgCor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtValorProcedimento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoProcediment);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnNovoProcedimento);
            this.Controls.Add(this.dtgProcedimentos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescricao);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(631, 461);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(631, 461);
            this.Name = "frmProcedimentos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANUTENÇÃO DE PROCEDIMENTOS";
            this.Load += new System.EventHandler(this.frmProcedimentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgProcedimentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoProcediment;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnNovoProcedimento;
        private System.Windows.Forms.DataGridView dtgProcedimentos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtValorProcedimento;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.PictureBox imgCor;
        private System.Windows.Forms.Button btnCor;
        private System.Windows.Forms.CheckBox chkCor;
    }
}