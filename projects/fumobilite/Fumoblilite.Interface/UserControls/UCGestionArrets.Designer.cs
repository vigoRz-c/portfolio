namespace Fumoblilite.Interface.UserControls
{
    partial class UCGestionArrets
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.FlowLayoutPanel flpArrets;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderId;
        private System.Windows.Forms.Label lblHeaderNom;
        private System.Windows.Forms.Label lblHeaderAdresse;
        private System.Windows.Forms.Label lblHeaderCoords;
        private System.Windows.Forms.Label lblHeaderAccessible;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.TextBox txtAdresse;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.CheckBox chkEstAccessible;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnExporterCsv;
        private System.Windows.Forms.Button btnExporterJson;
        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.flpArrets = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderAccessible = new System.Windows.Forms.Label();
            this.lblHeaderCoords = new System.Windows.Forms.Label();
            this.lblHeaderAdresse = new System.Windows.Forms.Label();
            this.lblHeaderNom = new System.Windows.Forms.Label();
            this.lblHeaderId = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.chkEstAccessible = new System.Windows.Forms.CheckBox();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.lblAdresse = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnExporterCsv = new System.Windows.Forms.Button();
            this.btnExporterJson = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitre.Location = new System.Drawing.Point(20, 18);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(248, 37);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion des arrêts";
            // 
            // flpArrets
            // 
            this.flpArrets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpArrets.AutoScroll = true;
            this.flpArrets.BackColor = System.Drawing.Color.White;
            this.flpArrets.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpArrets.Location = new System.Drawing.Point(20, 111);
            this.flpArrets.Margin = new System.Windows.Forms.Padding(4);
            this.flpArrets.Name = "flpArrets";
            this.flpArrets.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.flpArrets.Size = new System.Drawing.Size(600, 425);
            this.flpArrets.TabIndex = 1;
            this.flpArrets.WrapContents = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlHeader.Controls.Add(this.lblHeaderAccessible);
            this.pnlHeader.Controls.Add(this.lblHeaderCoords);
            this.pnlHeader.Controls.Add(this.lblHeaderAdresse);
            this.pnlHeader.Controls.Add(this.lblHeaderNom);
            this.pnlHeader.Controls.Add(this.lblHeaderId);
            this.pnlHeader.Location = new System.Drawing.Point(20, 62);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(600, 49);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblHeaderAccessible
            // 
            this.lblHeaderAccessible.AutoSize = true;
            this.lblHeaderAccessible.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderAccessible.ForeColor = System.Drawing.Color.White;
            this.lblHeaderAccessible.Location = new System.Drawing.Point(493, 16);
            this.lblHeaderAccessible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderAccessible.Name = "lblHeaderAccessible";
            this.lblHeaderAccessible.Size = new System.Drawing.Size(81, 20);
            this.lblHeaderAccessible.TabIndex = 4;
            this.lblHeaderAccessible.Text = "Accessible";
            // 
            // lblHeaderCoords
            // 
            this.lblHeaderCoords.AutoSize = true;
            this.lblHeaderCoords.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderCoords.ForeColor = System.Drawing.Color.White;
            this.lblHeaderCoords.Location = new System.Drawing.Point(333, 16);
            this.lblHeaderCoords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderCoords.Name = "lblHeaderCoords";
            this.lblHeaderCoords.Size = new System.Drawing.Size(101, 20);
            this.lblHeaderCoords.TabIndex = 3;
            this.lblHeaderCoords.Text = "Coordonnées";
            // 
            // lblHeaderAdresse
            // 
            this.lblHeaderAdresse.AutoSize = true;
            this.lblHeaderAdresse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderAdresse.ForeColor = System.Drawing.Color.White;
            this.lblHeaderAdresse.Location = new System.Drawing.Point(200, 16);
            this.lblHeaderAdresse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderAdresse.Name = "lblHeaderAdresse";
            this.lblHeaderAdresse.Size = new System.Drawing.Size(65, 20);
            this.lblHeaderAdresse.TabIndex = 2;
            this.lblHeaderAdresse.Text = "Adresse";
            // 
            // lblHeaderNom
            // 
            this.lblHeaderNom.AutoSize = true;
            this.lblHeaderNom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderNom.ForeColor = System.Drawing.Color.White;
            this.lblHeaderNom.Location = new System.Drawing.Point(67, 16);
            this.lblHeaderNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderNom.Name = "lblHeaderNom";
            this.lblHeaderNom.Size = new System.Drawing.Size(44, 20);
            this.lblHeaderNom.TabIndex = 1;
            this.lblHeaderNom.Text = "Nom";
            // 
            // lblHeaderId
            // 
            this.lblHeaderId.AutoSize = true;
            this.lblHeaderId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderId.ForeColor = System.Drawing.Color.White;
            this.lblHeaderId.Location = new System.Drawing.Point(20, 16);
            this.lblHeaderId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeaderId.Name = "lblHeaderId";
            this.lblHeaderId.Size = new System.Drawing.Size(25, 20);
            this.lblHeaderId.TabIndex = 0;
            this.lblHeaderId.Text = "ID";
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.chkEstAccessible);
            this.grpDetails.Controls.Add(this.txtLongitude);
            this.grpDetails.Controls.Add(this.lblLongitude);
            this.grpDetails.Controls.Add(this.txtLatitude);
            this.grpDetails.Controls.Add(this.lblLatitude);
            this.grpDetails.Controls.Add(this.txtAdresse);
            this.grpDetails.Controls.Add(this.lblAdresse);
            this.grpDetails.Controls.Add(this.txtNom);
            this.grpDetails.Controls.Add(this.lblNom);
            this.grpDetails.Controls.Add(this.txtId);
            this.grpDetails.Controls.Add(this.lblId);
            this.grpDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpDetails.Location = new System.Drawing.Point(640, 62);
            this.grpDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetails.Size = new System.Drawing.Size(407, 369);
            this.grpDetails.TabIndex = 3;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Détails de l\'arrêt";
            // 
            // chkEstAccessible
            // 
            this.chkEstAccessible.AutoSize = true;
            this.chkEstAccessible.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEstAccessible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.chkEstAccessible.Location = new System.Drawing.Point(133, 271);
            this.chkEstAccessible.Margin = new System.Windows.Forms.Padding(4);
            this.chkEstAccessible.Name = "chkEstAccessible";
            this.chkEstAccessible.Size = new System.Drawing.Size(121, 24);
            this.chkEstAccessible.TabIndex = 10;
            this.chkEstAccessible.Text = "Est accessible";
            this.chkEstAccessible.UseVisualStyleBackColor = true;
            // 
            // txtLongitude
            // 
            this.txtLongitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLongitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongitude.Location = new System.Drawing.Point(133, 230);
            this.txtLongitude.Margin = new System.Windows.Forms.Padding(4);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(239, 27);
            this.txtLongitude.TabIndex = 9;
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblLongitude.Location = new System.Drawing.Point(27, 234);
            this.lblLongitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(79, 20);
            this.lblLongitude.TabIndex = 8;
            this.lblLongitude.Text = "Longitude:";
            // 
            // txtLatitude
            // 
            this.txtLatitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLatitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLatitude.Location = new System.Drawing.Point(133, 193);
            this.txtLatitude.Margin = new System.Windows.Forms.Padding(4);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(239, 27);
            this.txtLatitude.TabIndex = 7;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblLatitude.Location = new System.Drawing.Point(27, 197);
            this.lblLatitude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(66, 20);
            this.lblLatitude.TabIndex = 6;
            this.lblLatitude.Text = "Latitude:";
            // 
            // txtAdresse
            // 
            this.txtAdresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdresse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdresse.Location = new System.Drawing.Point(133, 107);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdresse.Multiline = true;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(239, 73);
            this.txtAdresse.TabIndex = 5;
            // 
            // lblAdresse
            // 
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblAdresse.Location = new System.Drawing.Point(27, 111);
            this.lblAdresse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(64, 20);
            this.lblAdresse.TabIndex = 4;
            this.lblAdresse.Text = "Adresse:";
            // 
            // txtNom
            // 
            this.txtNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(133, 70);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(239, 27);
            this.txtNom.TabIndex = 3;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblNom.Location = new System.Drawing.Point(27, 74);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(45, 20);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom:";
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(133, 33);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(239, 27);
            this.txtId.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblId.Location = new System.Drawing.Point(27, 37);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(25, 20);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id:";
            // 
            // btnNouveau
            // 
            this.btnNouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNouveau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnNouveau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNouveau.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnNouveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnNouveau.Location = new System.Drawing.Point(640, 443);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(120, 37);
            this.btnNouveau.TabIndex = 4;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEnregistrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(773, 443);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 37);
            this.btnEnregistrer.TabIndex = 5;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(907, 443);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 37);
            this.btnSupprimer.TabIndex = 6;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnExporterCsv
            // 
            this.btnExporterCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnExporterCsv.FlatAppearance.BorderSize = 0;
            this.btnExporterCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterCsv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExporterCsv.ForeColor = System.Drawing.Color.White;
            this.btnExporterCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporterCsv.Location = new System.Drawing.Point(907, 490);
            this.btnExporterCsv.Margin = new System.Windows.Forms.Padding(5);
            this.btnExporterCsv.Name = "btnExporterCsv";
            this.btnExporterCsv.Size = new System.Drawing.Size(120, 37);
            this.btnExporterCsv.TabIndex = 8;
            this.btnExporterCsv.Text = "Exporter CSV";
            this.btnExporterCsv.Click += new System.EventHandler(this.btnExporterCsv_Click);
            // 
            // btnExporterJson
            // 
            this.btnExporterJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnExporterJson.FlatAppearance.BorderSize = 0;
            this.btnExporterJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporterJson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExporterJson.ForeColor = System.Drawing.Color.White;
            this.btnExporterJson.Location = new System.Drawing.Point(773, 490);
            this.btnExporterJson.Margin = new System.Windows.Forms.Padding(5);
            this.btnExporterJson.Name = "btnExporterJson";
            this.btnExporterJson.Size = new System.Drawing.Size(120, 37);
            this.btnExporterJson.TabIndex = 9;
            this.btnExporterJson.Text = "Exporter JSON";
            this.btnExporterJson.UseVisualStyleBackColor = false;
            this.btnExporterJson.Click += new System.EventHandler(this.btnExporterJson_Click);
            // 
            // UCGestionArrets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.flpArrets);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnExporterCsv);
            this.Controls.Add(this.btnExporterJson);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCGestionArrets";
            this.Size = new System.Drawing.Size(1067, 554);
            this.Load += new System.EventHandler(this.UCGestionArrets_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
