using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecommendorsSystem
{
    public partial class FormViewBook : Form
    {
        public FormViewBook(BookWithAuthorsAndCategories book)
        {
            InitializeComponent();
            labelTitle.Text = book.title;
            labelPrice.Text = book.price.ToString();
            labelDiscount.Text = book.priceMinusDiscountInProcent.ToString();
            labelQuantity.Text = book.Quantity.ToString();
            labelStartSell.Text = book.StartSellingDate.Date.ToString();
            labelAvailable.Text = "yes";
            if(book.Deleted)
            {
                labelAvailable.Text = "no";
            }
            foreach(Author a in book.Authors)
            {
                listBoxAuthors.Items.Add(a);
            }
            foreach(string c in book.Categories)
            {
                listBoxCategories.Items.Add(c);
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Dispose();
            this.Close();
        }
        
    }
}
