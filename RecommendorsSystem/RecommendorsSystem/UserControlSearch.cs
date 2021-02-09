using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NavigationInterfaces;

namespace RecommendorsSystem
{
    public partial class UserControlSearch : UserControl
    {
        class GuiManager
        {
            DataGridView dgv;
            ComboBox cmb;
            public GuiManager(DataGridView dgv, ComboBox cmb)
            {
                this.dgv = dgv;
                this.cmb = cmb;
            }
            
            public bool cellSelected()
            {
                return dgv.SelectedCells.Count > 0;
            }
            
            public bool cellSelectedAndContainsValue()
            {
                return cellSelected() && dgv.CurrentCell.Value != null;
            }
            
            public void fillWithSearchResults(LinkedList<BookWithAuthors> books)
            {
                dgv.Rows.Clear();
                dgv.Columns[1].Visible = true;
                dgv.Columns[2].Visible = false;
                foreach (Book book in books)
                {
                    BookInfoContainer bookAuthor = new BookContainerAuthors(book);
                    BookInfoContainer bookTitle = new BookContainerTitle(book);
                    dgv.Rows.Add(bookTitle, bookAuthor);
                }
            }
            public void fillWithRecommendations(LinkedList<BookWithAuthorsAndScore> books )
            {
                dgv.Rows.Clear();
                dgv.Columns[1].Visible = false;
                dgv.Columns[2].Visible = true;
                /*
                for(int i=0; i< books.Count; i++)
                {
                    Book toDisplayBook = books.ElementAt(i);
                    int score = scores.ElementAt(i);
                    BookInfoContainer bookTitle = new BookContainerTitle(toDisplayBook);
                    BookInfoContainer bookAuthor = new BookContainerAuthors(toDisplayBook);

                    BookInfoContainer bookScore = new BookContainerScore(score, toDisplayBook);
                    dgv.Rows.Add(bookTitle, bookAuthor, bookScore);
                }
                */
                foreach (BookWithAuthorsAndScore b in books)
                {
                    int score = b.Score;
                    BookInfoContainer bookTitle = new BookContainerTitle(b);
                    BookInfoContainer bookAuthor = new BookContainerAuthors(b);

                    BookInfoContainer bookScore = new BookContainerScore(score, b);
                    dgv.Rows.Add(bookTitle, bookAuthor, bookScore);

                }
                
            }

            public BookWithAuthors getSelectedBook()
            {
                if (cellSelectedAndContainsValue())
                {
                    try
                    {
                        BookWithAuthors toReturn = (dgv.CurrentCell.Value as BookInfoContainer).book;
                        return toReturn;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
                return null;
            }

            internal void clearInterface()
            {
                dgv.Rows.Clear();
                cmb.SelectedIndex = -1;
                
            }
        }

        GuiManager guiManager;
        ISearchPanelFunctions searchFunctions;
        INavSearchPanel navSearchPanel;
        public UserControlSearch(ISearchPanelFunctions iSearchPanelFunctions, INavSearchPanel iNavSearchPanel)
        {
            InitializeComponent();
            searchFunctions = iSearchPanelFunctions;
            navSearchPanel = iNavSearchPanel;
            prepareComboboxSearchOptions();
            prepareRatesCombobox();
            guiManager = new GuiManager(dataGridViewBooks, comboBoxRate);
            
        }

        private void prepareRatesCombobox()
        {
            comboBoxRate.Items.Add("unrate");
            for(int i= 1;i <=10; i++)
            {
                comboBoxRate.Items.Add(i.ToString());
            }
        }

        private void prepareComboboxSearchOptions()
        {
            comboBoxTitleAuthor.Items.Clear();
            comboBoxTitleAuthor.Items.Add("title");
            comboBoxTitleAuthor.Items.Add("author");
            comboBoxTitleAuthor.SelectedIndex = 0;
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            guiManager.clearInterface();
            navSearchPanel.goToAccount();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            

            LinkedList<BookWithAuthors> results;//=new LinkedList<Book>();
            string searchPhrase = textBoxSearch.Text;
            if(comboBoxTitleAuthor.SelectedIndex==0)
            {
                results=searchFunctions.searchByTitle(searchPhrase);
            }
            else //if(comboBoxTitleAuthor.SelectedItem.ToString() == "author")
            {
                results=searchFunctions.searchByAuthor(searchPhrase);
            }

            guiManager.fillWithSearchResults(results);
            dataGridViewBooks_CellContentClick(null, null);


            /*
            dataGridViewBooks.Rows.Clear();
            setDGVScoreColumnVisibilty(false);
            foreach(Book book in results)
            {
                BookWithAuthors bookWithAuthors = book as BookWithAuthors;
                var authors = bookWithAuthors.Authors;
                string authorsConcatanated = "";
                foreach(var author in authors )
                {
                    string singleAuthor = author.FirstName + " " + author.LastName;
                    if(authorsConcatanated !="")
                    {
                        authorsConcatanated += ", ";
                    }
                    authorsConcatanated += singleAuthor;
                }
                if(authorsConcatanated!="")
                {
                    authorsConcatanated =  authorsConcatanated.Remove(authorsConcatanated.Length - 2, 2);
                }
                //dataGridViewBooks.Rows.Add(book.title, authorsConcatanated, "");
                BookInfoContainer bookTitle = new BookContainerTitle(book);
                BookInfoContainer bookAuthors = new BookContainerAuthors(book);
                dataGridViewBooks.Rows.Add(bookTitle.ToString(), bookAuthors.ToString());
            }
                currentBook = getSelectedBook();
            */
            
            
        }
        /*
        void setDGVScoreColumnVisibilty(bool par)
        {
            dataGridViewBooks.Columns[2].Visible = par;
        }
        */
        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!guiManager.cellSelectedAndContainsValue())
            {
                return;
            }

            BookGeneralData currentBook = guiManager.getSelectedBook();
            if (currentBook != null)
            {
                int currentBookRate = searchFunctions.getBookRate(currentBook);
                comboBoxRate.SelectedIndex = currentBookRate;
            }
        }
        /*
        private Book getSelectedBook()
        {
            if(guiManager.cellSelectedAndContainsValue())
            {
                try
                {
                    Book toReturn = (dataGridViewBooks.CurrentCell.Value as BookInfoContainer).book;
                    return toReturn;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
            return null;
        }
        */
        private void comboBoxRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BookGeneralData currentBook = guiManager.getSelectedBook();
            if(currentBook!=null)
            {
                if(comboBoxRate.SelectedIndex==0)
                {
                    searchFunctions.unrateBook(currentBook);
                }
                else
                {
                    searchFunctions.setBookRate( currentBook, comboBoxRate.SelectedIndex);
                }
            }
        }

        private void buttonSaveInToBuy_Click(object sender, EventArgs e)
        {
            BookWithAuthors currentBook = guiManager.getSelectedBook();
            if(currentBook!=null)
            {
                searchFunctions.saveBookInToBuy(currentBook);
            }
        }

        private void buttonViewBook_Click(object sender, EventArgs e)
        {
            BookWithAuthors currentBook = guiManager.getSelectedBook();
            if(currentBook!=null)
            {
                searchFunctions.viewBook(currentBook);
            }
        }

        private void buttonAskRecoms_Click(object sender, EventArgs e)
        {
            LinkedList<BookWithAuthorsAndScore> books = searchFunctions.askForRecommendations();
            guiManager.fillWithRecommendations(books);
        }

        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewBooks_CellContentClick(null, null);
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            BookWithAuthors currentBook = guiManager.getSelectedBook();
            if (currentBook != null)
            {
                searchFunctions.buyBook(currentBook);
            }
        }
    }
}
