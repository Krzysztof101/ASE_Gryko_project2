namespace RecommendorsSystem
{
    partial class UserControlEditCategs
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
            this.listBoxOtherCategs = new System.Windows.Forms.ListBox();
            this.buttonMoveCateg = new System.Windows.Forms.Button();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxLikedCategs
            // 
            this.listBoxLikedCategs.FormattingEnabled = true;
            this.listBoxLikedCategs.ItemHeight = 16;
            this.listBoxLikedCategs.Location = new System.Drawing.Point(3, 32);
            this.listBoxLikedCategs.Name = "listBoxLikedCategs";
            this.listBoxLikedCategs.Size = new System.Drawing.Size(120, 84);
            this.listBoxLikedCategs.TabIndex = 0;
            this.listBoxLikedCategs.SelectedIndexChanged += new System.EventHandler(this.listBoxLikedCategs_SelectedIndexChanged);
            // 
            // listBoxOtherCategs
            // 
            this.listBoxOtherCategs.FormattingEnabled = true;
            this.listBoxOtherCategs.ItemHeight = 16;
            this.listBoxOtherCategs.Location = new System.Drawing.Point(255, 32);
            this.listBoxOtherCategs.Name = "listBoxOtherCategs";
            this.listBoxOtherCategs.Size = new System.Drawing.Size(120, 84);
            this.listBoxOtherCategs.TabIndex = 1;
            this.listBoxOtherCategs.SelectedIndexChanged += new System.EventHandler(this.listBoxOtherCategs_SelectedIndexChanged);
            // 
            // buttonMoveCateg
            // 
            this.buttonMoveCateg.AutoSize = true;
            this.buttonMoveCateg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMoveCateg.Location = new System.Drawing.Point(143, 63);
            this.buttonMoveCateg.Name = "buttonMoveCateg";
            this.buttonMoveCateg.Size = new System.Drawing.Size(93, 27);
            this.buttonMoveCateg.TabIndex = 2;
            this.buttonMoveCateg.Text = "add/remove";
            this.buttonMoveCateg.UseVisualStyleBackColor = true;
            this.buttonMoveCateg.Click += new System.EventHandler(this.buttonMoveCateg_Click);
            // 
            // buttonAccount
            // 
            this.buttonAccount.Location = new System.Drawing.Point(4, 123);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(75, 23);
            this.buttonAccount.TabIndex = 3;
            this.buttonAccount.Text = "account";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Liked categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "other categories";
            // 
            // UserControlEditCategs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAccount);
            this.Controls.Add(this.buttonMoveCateg);
            this.Controls.Add(this.listBoxOtherCategs);
            this.Controls.Add(this.listBoxLikedCategs);
            this.Name = "UserControlEditCategs";
            this.Size = new System.Drawing.Size(378, 156);
            this.Load += new System.EventHandler(this.UserControlEditCategs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLikedCategs;
        private System.Windows.Forms.ListBox listBoxOtherCategs;
        private System.Windows.Forms.Button buttonMoveCateg;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
