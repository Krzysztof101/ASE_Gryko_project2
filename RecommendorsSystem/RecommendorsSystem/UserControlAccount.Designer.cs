namespace RecommendorsSystem
{
    partial class UserControlAccount
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
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonLikedCategs = new System.Windows.Forms.Button();
            this.buttonRated = new System.Windows.Forms.Button();
            this.buttonRemoveFromToBuy = new System.Windows.Forms.Button();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.buttonToBuyBooks = new System.Windows.Forms.Button();
            this.buttonBoughtBooks = new System.Windows.Forms.Button();
            this.buttonDeleteAccount = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Title});
            this.dataGridViewBooks.Location = new System.Drawing.Point(262, 26);
            this.dataGridViewBooks.MultiSelect = false;
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.RowTemplate.Height = 24;
            this.dataGridViewBooks.Size = new System.Drawing.Size(337, 309);
            this.dataGridViewBooks.TabIndex = 0;
            this.dataGridViewBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBooks_CellContentClick);
            this.dataGridViewBooks.SelectionChanged += new System.EventHandler(this.dataGridViewBooks_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Width = 40;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Title.Width = 41;
            // 
            // buttonSearch
            // 
            this.buttonSearch.AutoSize = true;
            this.buttonSearch.Location = new System.Drawing.Point(3, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(122, 27);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search panel";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonLikedCategs
            // 
            this.buttonLikedCategs.AutoSize = true;
            this.buttonLikedCategs.Location = new System.Drawing.Point(3, 36);
            this.buttonLikedCategs.Name = "buttonLikedCategs";
            this.buttonLikedCategs.Size = new System.Drawing.Size(122, 27);
            this.buttonLikedCategs.TabIndex = 2;
            this.buttonLikedCategs.Text = "Liked categories";
            this.buttonLikedCategs.UseVisualStyleBackColor = true;
            this.buttonLikedCategs.Click += new System.EventHandler(this.buttonLikedCategs_Click);
            // 
            // buttonRated
            // 
            this.buttonRated.Location = new System.Drawing.Point(3, 3);
            this.buttonRated.Name = "buttonRated";
            this.buttonRated.Size = new System.Drawing.Size(122, 46);
            this.buttonRated.TabIndex = 3;
            this.buttonRated.Text = "show rated books";
            this.buttonRated.UseVisualStyleBackColor = true;
            this.buttonRated.Click += new System.EventHandler(this.buttonRated_Click);
            // 
            // buttonRemoveFromToBuy
            // 
            this.buttonRemoveFromToBuy.Location = new System.Drawing.Point(3, 36);
            this.buttonRemoveFromToBuy.Name = "buttonRemoveFromToBuy";
            this.buttonRemoveFromToBuy.Size = new System.Drawing.Size(87, 46);
            this.buttonRemoveFromToBuy.TabIndex = 4;
            this.buttonRemoveFromToBuy.Text = "Remove from to buy";
            this.buttonRemoveFromToBuy.UseVisualStyleBackColor = true;
            this.buttonRemoveFromToBuy.Click += new System.EventHandler(this.buttonRemoveFromToBuy_Click);
            // 
            // buttonBuy
            // 
            this.buttonBuy.Location = new System.Drawing.Point(96, 36);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(87, 46);
            this.buttonBuy.TabIndex = 5;
            this.buttonBuy.Text = "buy book";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // buttonToBuyBooks
            // 
            this.buttonToBuyBooks.AutoSize = true;
            this.buttonToBuyBooks.Location = new System.Drawing.Point(3, 3);
            this.buttonToBuyBooks.Name = "buttonToBuyBooks";
            this.buttonToBuyBooks.Size = new System.Drawing.Size(180, 27);
            this.buttonToBuyBooks.TabIndex = 6;
            this.buttonToBuyBooks.Text = "show to buy books";
            this.buttonToBuyBooks.UseVisualStyleBackColor = true;
            this.buttonToBuyBooks.Click += new System.EventHandler(this.buttonToBuyBooks_Click);
            // 
            // buttonBoughtBooks
            // 
            this.buttonBoughtBooks.Location = new System.Drawing.Point(3, 69);
            this.buttonBoughtBooks.Name = "buttonBoughtBooks";
            this.buttonBoughtBooks.Size = new System.Drawing.Size(122, 42);
            this.buttonBoughtBooks.TabIndex = 7;
            this.buttonBoughtBooks.Text = "View bought books";
            this.buttonBoughtBooks.UseVisualStyleBackColor = true;
            this.buttonBoughtBooks.Click += new System.EventHandler(this.buttonBoughtBooks_Click);
            // 
            // buttonDeleteAccount
            // 
            this.buttonDeleteAccount.AutoSize = true;
            this.buttonDeleteAccount.Location = new System.Drawing.Point(3, 242);
            this.buttonDeleteAccount.Name = "buttonDeleteAccount";
            this.buttonDeleteAccount.Size = new System.Drawing.Size(113, 36);
            this.buttonDeleteAccount.TabIndex = 8;
            this.buttonDeleteAccount.Text = "Delete account";
            this.buttonDeleteAccount.UseVisualStyleBackColor = true;
            this.buttonDeleteAccount.Click += new System.EventHandler(this.buttonDeleteAccount_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonToBuyBooks);
            this.panel1.Controls.Add(this.buttonRemoveFromToBuy);
            this.panel1.Controls.Add(this.buttonBuy);
            this.panel1.Location = new System.Drawing.Point(3, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 86);
            this.panel1.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "edit rate";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonRated);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(131, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 101);
            this.panel2.TabIndex = 12;
            // 
            // buttonLogout
            // 
            this.buttonLogout.AutoSize = true;
            this.buttonLogout.Location = new System.Drawing.Point(3, 209);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(113, 27);
            this.buttonLogout.TabIndex = 13;
            this.buttonLogout.Text = "logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(266, 6);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(0, 17);
            this.labelTitle.TabIndex = 14;
            // 
            // UserControlAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonDeleteAccount);
            this.Controls.Add(this.buttonBoughtBooks);
            this.Controls.Add(this.buttonLikedCategs);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewBooks);
            this.Name = "UserControlAccount";
            this.Size = new System.Drawing.Size(606, 338);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonLikedCategs;
        private System.Windows.Forms.Button buttonRated;
        private System.Windows.Forms.Button buttonRemoveFromToBuy;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Button buttonToBuyBooks;
        private System.Windows.Forms.Button buttonBoughtBooks;
        private System.Windows.Forms.Button buttonDeleteAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.Label labelTitle;
    }
}
