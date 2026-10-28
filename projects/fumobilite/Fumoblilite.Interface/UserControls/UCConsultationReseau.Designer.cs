namespace Fumoblilite.Interface.UserControls
{
    partial class UCConsultationReseau
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlReseau;
        private System.Windows.Forms.FlowLayoutPanel flpLignes;
        private System.Windows.Forms.Label lblLignes;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnResetZoom;

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlReseau = new System.Windows.Forms.Panel();
            this.flpLignes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLignes = new System.Windows.Forms.Label();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnResetZoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(15, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(156, 24);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Réseau complet";
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // pnlReseau
            // 
            this.pnlReseau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReseau.BackColor = System.Drawing.Color.White;
            this.pnlReseau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReseau.Location = new System.Drawing.Point(180, 50);
            this.pnlReseau.Name = "pnlReseau";
            this.pnlReseau.Size = new System.Drawing.Size(605, 385);
            this.pnlReseau.TabIndex = 1;
            this.pnlReseau.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlReseau_Paint);
            // 
            // flpLignes
            // 
            this.flpLignes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpLignes.AutoScroll = true;
            this.flpLignes.BackColor = System.Drawing.Color.White;
            this.flpLignes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpLignes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLignes.Location = new System.Drawing.Point(15, 70);
            this.flpLignes.Name = "flpLignes";
            this.flpLignes.Size = new System.Drawing.Size(150, 330);
            this.flpLignes.TabIndex = 2;
            this.flpLignes.WrapContents = false;
            // 
            // lblLignes
            // 
            this.lblLignes.AutoSize = true;
            this.lblLignes.Location = new System.Drawing.Point(15, 50);
            this.lblLignes.Name = "lblLignes";
            this.lblLignes.Size = new System.Drawing.Size(43, 13);
            this.lblLignes.TabIndex = 3;
            this.lblLignes.Text = "Lignes :";
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomIn.Location = new System.Drawing.Point(15, 410);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(40, 25);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.ForeColor = System.Drawing.Color.White;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomOut.Location = new System.Drawing.Point(65, 410);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(40, 25);
            this.btnZoomOut.TabIndex = 5;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.ForeColor = System.Drawing.Color.White;
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetZoom.Location = new System.Drawing.Point(115, 410);
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(50, 25);
            this.btnResetZoom.TabIndex = 6;
            this.btnResetZoom.Text = "Reset";
            this.btnResetZoom.UseVisualStyleBackColor = true;
            this.btnResetZoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnResetZoom.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnResetZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetZoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // UCConsultationReseau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResetZoom);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.lblLignes);
            this.Controls.Add(this.flpLignes);
            this.Controls.Add(this.pnlReseau);
            this.Controls.Add(this.lblTitre);
            this.Name = "UCConsultationReseau";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.UCConsultationReseau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
