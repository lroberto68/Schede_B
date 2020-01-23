namespace WindowsFormsApp2
{
    partial class Form2
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
            this.lstModelli = new System.Windows.Forms.ListView();
            this.coluCOD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluDESC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluLOGOTIPO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtModello = new System.Windows.Forms.TextBox();
            this.btnRicerca = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.btnAggiungi = new System.Windows.Forms.Button();
            this.lstSchede = new System.Windows.Forms.ListView();
            this.coluCODICE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluDES = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluLOGO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluASSE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluQTY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblConn = new System.Windows.Forms.Label();
            this.lstAss = new System.Windows.Forms.ListBox();
            this.btnCrea = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.lblAssemb = new System.Windows.Forms.Label();
            this.lblModelli = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.coluIND = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstModelli
            // 
            this.lstModelli.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coluCOD,
            this.coluDESC,
            this.coluLOGOTIPO});
            this.lstModelli.FullRowSelect = true;
            this.lstModelli.GridLines = true;
            this.lstModelli.Location = new System.Drawing.Point(295, 57);
            this.lstModelli.Margin = new System.Windows.Forms.Padding(4);
            this.lstModelli.MultiSelect = false;
            this.lstModelli.Name = "lstModelli";
            this.lstModelli.Size = new System.Drawing.Size(546, 312);
            this.lstModelli.TabIndex = 0;
            this.lstModelli.UseCompatibleStateImageBehavior = false;
            this.lstModelli.View = System.Windows.Forms.View.Details;
            // 
            // coluCOD
            // 
            this.coluCOD.Text = "Codice";
            this.coluCOD.Width = 122;
            // 
            // coluDESC
            // 
            this.coluDESC.Text = "Descrizione";
            this.coluDESC.Width = 260;
            // 
            // coluLOGOTIPO
            // 
            this.coluLOGOTIPO.Text = "Logotipo";
            this.coluLOGOTIPO.Width = 80;
            // 
            // txtModello
            // 
            this.txtModello.Location = new System.Drawing.Point(295, 423);
            this.txtModello.Margin = new System.Windows.Forms.Padding(4);
            this.txtModello.Name = "txtModello";
            this.txtModello.Size = new System.Drawing.Size(175, 22);
            this.txtModello.TabIndex = 1;
            // 
            // btnRicerca
            // 
            this.btnRicerca.Location = new System.Drawing.Point(295, 478);
            this.btnRicerca.Margin = new System.Windows.Forms.Padding(4);
            this.btnRicerca.Name = "btnRicerca";
            this.btnRicerca.Size = new System.Drawing.Size(100, 30);
            this.btnRicerca.TabIndex = 2;
            this.btnRicerca.Text = "Ricerca";
            this.btnRicerca.UseVisualStyleBackColor = true;
            this.btnRicerca.Click += new System.EventHandler(this.BtnRicerca_Click);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(897, 244);
            this.txtQty.Margin = new System.Windows.Forms.Padding(4);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(132, 22);
            this.txtQty.TabIndex = 3;
            // 
            // btnAggiungi
            // 
            this.btnAggiungi.Location = new System.Drawing.Point(897, 314);
            this.btnAggiungi.Margin = new System.Windows.Forms.Padding(4);
            this.btnAggiungi.Name = "btnAggiungi";
            this.btnAggiungi.Size = new System.Drawing.Size(100, 28);
            this.btnAggiungi.TabIndex = 4;
            this.btnAggiungi.Text = "Aggiungi";
            this.btnAggiungi.UseVisualStyleBackColor = true;
            this.btnAggiungi.Click += new System.EventHandler(this.BtnAggiungi_Click);
            // 
            // lstSchede
            // 
            this.lstSchede.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coluCODICE,
            this.coluDES,
            this.coluLOGO,
            this.coluASSE,
            this.coluQTY,
            this.coluIND});
            this.lstSchede.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstSchede.FullRowSelect = true;
            this.lstSchede.GridLines = true;
            this.lstSchede.Location = new System.Drawing.Point(882, 57);
            this.lstSchede.Margin = new System.Windows.Forms.Padding(4);
            this.lstSchede.MultiSelect = false;
            this.lstSchede.Name = "lstSchede";
            this.lstSchede.Size = new System.Drawing.Size(577, 118);
            this.lstSchede.TabIndex = 5;
            this.lstSchede.UseCompatibleStateImageBehavior = false;
            this.lstSchede.View = System.Windows.Forms.View.Details;
            // 
            // coluCODICE
            // 
            this.coluCODICE.Text = "Codice";
            this.coluCODICE.Width = 89;
            // 
            // coluDES
            // 
            this.coluDES.Text = "Descrizione";
            this.coluDES.Width = 185;
            // 
            // coluLOGO
            // 
            this.coluLOGO.Text = "Logotipo";
            this.coluLOGO.Width = 86;
            // 
            // coluASSE
            // 
            this.coluASSE.Text = "Assemblatore";
            this.coluASSE.Width = 91;
            // 
            // coluQTY
            // 
            this.coluQTY.Text = "Qty";
            // 
            // lblConn
            // 
            this.lblConn.AutoSize = true;
            this.lblConn.Location = new System.Drawing.Point(1181, 578);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(108, 17);
            this.lblConn.TabIndex = 6;
            this.lblConn.Text = "Stato database:";
            // 
            // lstAss
            // 
            this.lstAss.FormattingEnabled = true;
            this.lstAss.ItemHeight = 16;
            this.lstAss.Location = new System.Drawing.Point(40, 57);
            this.lstAss.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstAss.Name = "lstAss";
            this.lstAss.Size = new System.Drawing.Size(224, 84);
            this.lstAss.TabIndex = 7;
            // 
            // btnCrea
            // 
            this.btnCrea.Location = new System.Drawing.Point(1300, 314);
            this.btnCrea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCrea.Name = "btnCrea";
            this.btnCrea.Size = new System.Drawing.Size(88, 28);
            this.btnCrea.TabIndex = 8;
            this.btnCrea.Text = "Crea";
            this.btnCrea.UseVisualStyleBackColor = true;
            this.btnCrea.Click += new System.EventHandler(this.BtnCrea_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(1143, 315);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(90, 27);
            this.btnElimina.TabIndex = 9;
            this.btnElimina.Text = "Elimina";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // lblAssemb
            // 
            this.lblAssemb.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssemb.Location = new System.Drawing.Point(37, 27);
            this.lblAssemb.Name = "lblAssemb";
            this.lblAssemb.Size = new System.Drawing.Size(200, 17);
            this.lblAssemb.TabIndex = 10;
            this.lblAssemb.Text = "Elenco ASSEMBLATORI";
            // 
            // lblModelli
            // 
            this.lblModelli.AutoSize = true;
            this.lblModelli.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModelli.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelli.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblModelli.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblModelli.Location = new System.Drawing.Point(295, 33);
            this.lblModelli.Name = "lblModelli";
            this.lblModelli.Size = new System.Drawing.Size(129, 17);
            this.lblModelli.TabIndex = 11;
            this.lblModelli.Text = "Elenco MODELLI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(882, 27);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Schede da creare";
            // 
            // coluIND
            // 
            this.coluIND.Text = "Status";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1577, 660);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblModelli);
            this.Controls.Add(this.lblAssemb);
            this.Controls.Add(this.btnElimina);
            this.Controls.Add(this.btnCrea);
            this.Controls.Add(this.lstAss);
            this.Controls.Add(this.lblConn);
            this.Controls.Add(this.lstSchede);
            this.Controls.Add(this.btnAggiungi);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.btnRicerca);
            this.Controls.Add(this.txtModello);
            this.Controls.Add(this.lstModelli);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstModelli;
        private System.Windows.Forms.ColumnHeader coluCOD;
        private System.Windows.Forms.ColumnHeader coluDESC;
        private System.Windows.Forms.TextBox txtModello;
        private System.Windows.Forms.Button btnRicerca;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Button btnAggiungi;
        private System.Windows.Forms.ListView lstSchede;
        private System.Windows.Forms.ColumnHeader coluCODICE;
        private System.Windows.Forms.ColumnHeader coluDES;
        private System.Windows.Forms.ColumnHeader coluLOGO;
        private System.Windows.Forms.ColumnHeader coluASSE;
        private System.Windows.Forms.ColumnHeader coluQTY;
        private System.Windows.Forms.ColumnHeader coluLOGOTIPO;
        private System.Windows.Forms.Label lblConn;
        private System.Windows.Forms.ListBox lstAss;
        private System.Windows.Forms.Button btnCrea;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Label lblAssemb;
        private System.Windows.Forms.Label lblModelli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader coluIND;
    }
}