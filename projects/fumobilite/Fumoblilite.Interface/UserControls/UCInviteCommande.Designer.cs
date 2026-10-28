namespace Fumoblilite.Interface.UserControls
{
    partial class UCInviteCommande
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.txtCommande = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.BackColor = System.Drawing.Color.Black;
            this.rtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbConsole.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbConsole.ForeColor = System.Drawing.Color.Lime;
            this.rtbConsole.Location = new System.Drawing.Point(0, 0);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(800, 550);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            // 
            // txtCommande
            // 
            this.txtCommande.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommande.BackColor = System.Drawing.Color.Black;
            this.txtCommande.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommande.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommande.ForeColor = System.Drawing.Color.Lime;
            this.txtCommande.Location = new System.Drawing.Point(0, 550);
            this.txtCommande.Name = "txtCommande";
            this.txtCommande.Size = new System.Drawing.Size(800, 23);
            this.txtCommande.TabIndex = 1;
            this.txtCommande.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommande_KeyDown);
            // 
            // UCInviteCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.txtCommande);
            this.Controls.Add(this.rtbConsole);
            this.Name = "UCInviteCommande";
            this.Size = new System.Drawing.Size(800, 573);
            this.Load += new System.EventHandler(this.UCInviteCommande_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.TextBox txtCommande;
    }
}
