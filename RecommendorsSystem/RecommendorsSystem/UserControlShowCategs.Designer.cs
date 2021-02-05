namespace RecommendorsSystem
{
    partial class UserControlShowCategs
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxLikedCategs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEditCategs = new System.Windows.Forms.Button();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxLikedCategs
            // 
            this.listBoxLikedCategs.FormattingEnabled = true;
            this.listBoxLikedCategs.ItemHeight = 16;
            this.listBoxLikedCategs.Location = new System.Drawing.Point(3, 30);
            this.listBoxLikedCategs.Name = "listBoxLikedCategs";
            this.listBoxLikedCategs.Size = new System.Drawing.Size(230, 84);
            this.listBoxLikedCategs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liked categories";
            // 
            // buttonEditCategs
            // 
            this.buttonEditCategs.AutoSize = true;
            this.buttonEditCategs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEditCategs.Location = new System.Drawing.Point(3, 120);
            this.buttonEditCategs.Name = "buttonEditCategs";
            this.buttonEditCategs.Size = new System.Drawing.Size(111, 27);
            this.buttonEditCategs.TabIndex = 2;
            this.buttonEditCategs.Text = "edit categories";
            this.buttonEditCategs.UseVisualStyleBackColor = true;
            this.buttonEditCategs.Click += new System.EventHandler(this.buttonEditCategs_Click);
            // 
            // buttonAccount
            // 
            this.buttonAccount.AutoSize = true;
            this.buttonAccount.Location = new System.Drawing.Point(122, 120);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(111, 27);
            this.buttonAccount.TabIndex = 3;
            this.buttonAccount.Text = "account";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // UserControlShowCategs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAccount);
            this.Controls.Add(this.buttonEditCategs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxLikedCategs);
            this.Name = "UserControlShowCategs";
            this.Size = new System.Drawing.Size(239, 155);
            this.Load += new System.EventHandler(this.UserControlShowCategs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLikedCategs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditCategs;
        private System.Windows.Forms.Button buttonAccount;
    }
}
