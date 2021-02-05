namespace RecommendorsSystem
{
    partial class UserControlSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAccount = new System.Windows.Forms.Button();
            this.buttonAskRecoms = new System.Windows.Forms.Button();
            this.buttonViewBook = new System.Windows.Forms.Button();
            this.buttonSaveInToBuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRate = new System.Windows.Forms.ComboBox();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTitleAuthor = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "search";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(60, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(172, 22);
            this.textBoxSearch.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAccount);
            this.panel1.Controls.Add(this.buttonAskRecoms);
            this.panel1.Controls.Add(this.buttonViewBook);
            this.panel1.Controls.Add(this.buttonSaveInToBuy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxRate);
            this.panel1.Controls.Add(this.buttonBuy);
            this.panel1.Controls.Add(this.dataGridViewBooks);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxTitleAuthor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 321);
            this.panel1.TabIndex = 2;
            // 
            // buttonAccount
            // 
            this.buttonAccount.AutoSize = true;
            this.buttonAccount.Location = new System.Drawing.Point(472, 291);
            this.buttonAccount.Name = "buttonAccount";
            this.buttonAccount.Size = new System.Drawing.Size(129, 27);
            this.buttonAccount.TabIndex = 13;
            this.buttonAccount.Text = "account";
            this.buttonAccount.UseVisualStyleBackColor = true;
            this.buttonAccount.Click += new System.EventHandler(this.buttonAccount_Click);
            // 
            // buttonAskRecoms
            // 
            this.buttonAskRecoms.Location = new System.Drawing.Point(472, 241);
            this.buttonAskRecoms.Name = "buttonAskRecoms";
            this.buttonAskRecoms.Size = new System.Drawing.Size(129, 44);
            this.buttonAskRecoms.TabIndex = 12;
            this.buttonAskRecoms.Text = "ask for recommendations";
            this.buttonAskRecoms.UseVisualStyleBackColor = true;
            this.buttonAskRecoms.Click += new System.EventHandler(this.buttonAskRecoms_Click);
            // 
            // buttonViewBook
            // 
            this.buttonViewBook.AutoSize = true;
            this.buttonViewBook.Location = new System.Drawing.Point(475, 143);
            this.buttonViewBook.Name = "buttonViewBook";
            this.buttonViewBook.Size = new System.Drawing.Size(106, 27);
            this.buttonViewBook.TabIndex = 11;
            this.buttonViewBook.Text = "view book";
            this.buttonViewBook.UseVisualStyleBackColor = true;
            this.buttonViewBook.Click += new System.EventHandler(this.buttonViewBook_Click);
            // 
            // buttonSaveInToBuy
            // 
            this.buttonSaveInToBuy.AutoSize = true;
            this.buttonSaveInToBuy.Location = new System.Drawing.Point(475, 109);
            this.buttonSaveInToBuy.Name = "buttonSaveInToBuy";
            this.buttonSaveInToBuy.Size = new System.Drawing.Size(106, 27);
            this.buttonSaveInToBuy.TabIndex = 10;
            this.buttonSaveInToBuy.Text = "save in to buy";
            this.buttonSaveInToBuy.UseVisualStyleBackColor = true;
            this.buttonSaveInToBuy.Click += new System.EventHandler(this.buttonSaveInToBuy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "rate";
            // 
            // comboBoxRate
            // 
            this.comboBoxRate.FormattingEnabled = true;
            this.comboBoxRate.Location = new System.Drawing.Point(511, 79);
            this.comboBoxRate.Name = "comboBoxRate";
            this.comboBoxRate.Size = new System.Drawing.Size(70, 24);
            this.comboBoxRate.TabIndex = 8;
            this.comboBoxRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxRate_SelectedIndexChanged);
            // 
            // buttonBuy
            // 
            this.buttonBuy.AutoSize = true;
            this.buttonBuy.Location = new System.Drawing.Point(472, 46);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(109, 27);
            this.buttonBuy.TabIndex = 6;
            this.buttonBuy.Text = "buy";
            this.buttonBuy.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Author,
            this.Score});
            this.dataGridViewBooks.Location = new System.Drawing.Point(6, 46);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.RowTemplate.Height = 24;
            this.dataGridViewBooks.Size = new System.Drawing.Size(460, 272);
            this.dataGridViewBooks.TabIndex = 5;
            this.dataGridViewBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBooks_CellContentClick);
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 6;
            this.Title.Name = "Title";
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Title.Width = 41;
            // 
            // Author
            // 
            this.Author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Author.HeaderText = "Author";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            this.Author.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Author.Width = 56;
            // 
            // Score
            // 
            this.Score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Score.HeaderText = "Score";
            this.Score.MinimumWidth = 6;
            this.Score.Name = "Score";
            this.Score.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Score.Width = 51;
            // 
            // buttonSearch
            // 
            this.buttonSearch.AutoSize = true;
            this.buttonSearch.Location = new System.Drawing.Point(394, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(112, 27);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "start searching";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "by";
            // 
            // comboBoxTitleAuthor
            // 
            this.comboBoxTitleAuthor.FormattingEnabled = true;
            this.comboBoxTitleAuthor.Location = new System.Drawing.Point(267, 3);
            this.comboBoxTitleAuthor.Name = "comboBoxTitleAuthor";
            this.comboBoxTitleAuthor.Size = new System.Drawing.Size(121, 24);
            this.comboBoxTitleAuthor.TabIndex = 2;
            // 
            // UserControlSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlSearch";
            this.Size = new System.Drawing.Size(612, 331);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAccount;
        private System.Windows.Forms.Button buttonAskRecoms;
        private System.Windows.Forms.Button buttonViewBook;
        private System.Windows.Forms.Button buttonSaveInToBuy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxRate;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTitleAuthor;
    }
}
