namespace OAuth2
{
    partial class Selection
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
            this.btnClaims = new System.Windows.Forms.Button();
            this.btnMSAs = new System.Windows.Forms.Button();
            this.txtConnection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUploadMSA = new System.Windows.Forms.Button();
            this.btnUploadRebate = new System.Windows.Forms.Button();
            this.lblMSA = new System.Windows.Forms.Label();
            this.lblREBATE = new System.Windows.Forms.Label();
            this.btnTEST = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClaims
            // 
            this.btnClaims.Location = new System.Drawing.Point(331, 66);
            this.btnClaims.Margin = new System.Windows.Forms.Padding(4);
            this.btnClaims.Name = "btnClaims";
            this.btnClaims.Size = new System.Drawing.Size(200, 28);
            this.btnClaims.TabIndex = 0;
            this.btnClaims.Text = "UPLOAD REBATE (LIVE)";
            this.btnClaims.UseVisualStyleBackColor = true;
            this.btnClaims.Click += new System.EventHandler(this.btnClaims_Click);
            // 
            // btnMSAs
            // 
            this.btnMSAs.Location = new System.Drawing.Point(86, 66);
            this.btnMSAs.Margin = new System.Windows.Forms.Padding(4);
            this.btnMSAs.Name = "btnMSAs";
            this.btnMSAs.Size = new System.Drawing.Size(173, 28);
            this.btnMSAs.TabIndex = 1;
            this.btnMSAs.Text = "MSA Upload";
            this.btnMSAs.UseVisualStyleBackColor = true;
            this.btnMSAs.Click += new System.EventHandler(this.btnMSAs_Click);
            // 
            // txtConnection
            // 
            this.txtConnection.Location = new System.Drawing.Point(16, 246);
            this.txtConnection.Margin = new System.Windows.Forms.Padding(4);
            this.txtConnection.Multiline = true;
            this.txtConnection.Name = "txtConnection";
            this.txtConnection.Size = new System.Drawing.Size(655, 46);
            this.txtConnection.TabIndex = 3;
            this.txtConnection.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 226);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connection";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "PRODUCTION MODE";
            // 
            // btnUploadMSA
            // 
            this.btnUploadMSA.Location = new System.Drawing.Point(158, 214);
            this.btnUploadMSA.Margin = new System.Windows.Forms.Padding(4);
            this.btnUploadMSA.Name = "btnUploadMSA";
            this.btnUploadMSA.Size = new System.Drawing.Size(173, 28);
            this.btnUploadMSA.TabIndex = 6;
            this.btnUploadMSA.Text = "MSA test";
            this.btnUploadMSA.UseVisualStyleBackColor = true;
            this.btnUploadMSA.Visible = false;
            this.btnUploadMSA.Click += new System.EventHandler(this.btnUploadMSA_Click);
            // 
            // btnUploadRebate
            // 
            this.btnUploadRebate.Location = new System.Drawing.Point(359, 214);
            this.btnUploadRebate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUploadRebate.Name = "btnUploadRebate";
            this.btnUploadRebate.Size = new System.Drawing.Size(200, 28);
            this.btnUploadRebate.TabIndex = 7;
            this.btnUploadRebate.Text = "REBATE test";
            this.btnUploadRebate.UseVisualStyleBackColor = true;
            this.btnUploadRebate.Visible = false;
            // 
            // lblMSA
            // 
            this.lblMSA.AutoSize = true;
            this.lblMSA.Location = new System.Drawing.Point(22, 136);
            this.lblMSA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMSA.Name = "lblMSA";
            this.lblMSA.Size = new System.Drawing.Size(452, 16);
            this.lblMSA.TabIndex = 8;
            this.lblMSA.Text = "https://apim.chevron.com/sales-management/delivery-confirmation/v2/msa";
            // 
            // lblREBATE
            // 
            this.lblREBATE.AutoSize = true;
            this.lblREBATE.Location = new System.Drawing.Point(22, 168);
            this.lblREBATE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblREBATE.Name = "lblREBATE";
            this.lblREBATE.Size = new System.Drawing.Size(450, 16);
            this.lblREBATE.TabIndex = 9;
            this.lblREBATE.Text = "https://apim.chevron.com/sales-management/rebates/v1/C2RebatesClaim";
            // 
            // btnTEST
            // 
            this.btnTEST.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTEST.ForeColor = System.Drawing.Color.Blue;
            this.btnTEST.Location = new System.Drawing.Point(557, 156);
            this.btnTEST.Margin = new System.Windows.Forms.Padding(4);
            this.btnTEST.Name = "btnTEST";
            this.btnTEST.Size = new System.Drawing.Size(100, 28);
            this.btnTEST.TabIndex = 68;
            this.btnTEST.Text = "TEST";
            this.btnTEST.UseVisualStyleBackColor = true;
            this.btnTEST.Visible = false;
            this.btnTEST.Click += new System.EventHandler(this.btnTEST_Click);
            // 
            // Selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 305);
            this.Controls.Add(this.btnTEST);
            this.Controls.Add(this.lblREBATE);
            this.Controls.Add(this.lblMSA);
            this.Controls.Add(this.btnUploadRebate);
            this.Controls.Add(this.btnUploadMSA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnection);
            this.Controls.Add(this.btnMSAs);
            this.Controls.Add(this.btnClaims);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Selection";
            this.Text = "Chevron MSA / Rebate Upload (ver 06/03/2024)";
            this.Load += new System.EventHandler(this.Selection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClaims;
        private System.Windows.Forms.Button btnMSAs;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUploadMSA;
        private System.Windows.Forms.Button btnUploadRebate;
        private System.Windows.Forms.Label lblMSA;
        private System.Windows.Forms.Label lblREBATE;
        private System.Windows.Forms.Button btnTEST;
    }
}