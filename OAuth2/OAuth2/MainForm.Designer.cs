namespace OAuth2
{
    partial class frmMain
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
            this.btnCredentials = new System.Windows.Forms.Button();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubscriptionKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtResource = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCredentials
            // 
            this.btnCredentials.Location = new System.Drawing.Point(94, 197);
            this.btnCredentials.Name = "btnCredentials";
            this.btnCredentials.Size = new System.Drawing.Size(222, 23);
            this.btnCredentials.TabIndex = 0;
            this.btnCredentials.Text = "Get Credentials and Send";
            this.btnCredentials.UseVisualStyleBackColor = true;
            this.btnCredentials.Click += new System.EventHandler(this.btnCredentials_Click);
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(133, 26);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(183, 20);
            this.txtClientID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Client Secret";
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Location = new System.Drawing.Point(133, 66);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.Size = new System.Drawing.Size(183, 20);
            this.txtClientSecret.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subscription Key";
            // 
            // txtSubscriptionKey
            // 
            this.txtSubscriptionKey.Location = new System.Drawing.Point(133, 111);
            this.txtSubscriptionKey.Name = "txtSubscriptionKey";
            this.txtSubscriptionKey.Size = new System.Drawing.Size(183, 20);
            this.txtSubscriptionKey.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Resource";
            // 
            // txtResource
            // 
            this.txtResource.Location = new System.Drawing.Point(133, 151);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(183, 20);
            this.txtResource.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 338);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubscriptionKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClientSecret);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.btnCredentials);
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCredentials;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubscriptionKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResource;
    }
}

