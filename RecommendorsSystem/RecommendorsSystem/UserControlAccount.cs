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
    public partial class UserControlAccount : UserControl
    {
        IAccountFunctions accountInterfaceObject;
        INavAccount navAcc;

        private class GUIMemoryManager
        {
            public GUIMemoryManager(UserControlAccount own)
            {
                owner = own;
                memory = new typeOfLastList();
                setBought();
            }
            public UserControlAccount owner;
            private enum typeOfLastList
            {
                rated,
                toBuy,
                bought,
            }
            typeOfLastList memory;
            public void setRated(){memory = typeOfLastList.rated; disableBuyButtons(); }

            private void disableBuyButtons()
            {
                owner.buttonBuy.Enabled = false;
                owner.buttonRemoveFromToBuy.Enabled = false;
            }

            public void setTobuy() { memory = typeOfLastList.toBuy; activateBuyButtons(); }

            private void activateBuyButtons()
            {
                owner.buttonBuy.Enabled = true;
                owner.buttonRemoveFromToBuy.Enabled = true;
            }

            public void setBought() { memory = typeOfLastList.bought; disableBuyButtons(); }
            public void reloadLastOperation()
            {
                switch (memory)
                {
                    case typeOfLastList.bought:
                        owner.getBoughtBooks();
                        break;
                    case typeOfLastList.toBuy:
                        owner.getToBuyBooks();
                        break;
                    case typeOfLastList.rated:
                        owner.getRatedBooks();
                        break;
                }
            }
            public bool isShowingToBuyBooks()
            {
                return memory == typeOfLastList.toBuy;
            }

            internal bool DGVhasSelectedCell()
            {
                return owner.dataGridViewBooks.SelectedCells.Count > 0;
            }
        }
        private GUIMemoryManager memoryManager;

        

        public UserControlAccount(IAccountFunctions iafcs, INavAccount inavacc)
        {
            InitializeComponent();
            accountInterfaceObject = iafcs;
            navAcc = inavacc;
            memoryManager = new GUIMemoryManager(this);
            buttonBuy.Enabled = false;
            buttonRemoveFromToBuy.Enabled = false;
            //accountInterfaceObject.showRated(); -- nie wiem czemu to tu było
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            accountInterfaceObject.logout();
            navAcc.goToLogin();
        }

        private void buttonLikedCategs_Click(object sender, EventArgs e)
        {
            navAcc.goToShowCategories();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            navAcc.goToSearch();
        }

        private void buttonDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("delete account?", "Delete account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                accountInterfaceObject.deleteAccount("dummy password");
                navAcc.goToLogin();
            }

        }

        

        private void buttonToBuyBooks_Click(object sender, EventArgs e)
        {
            memoryManager.setTobuy();
            getToBuyBooks();
        }
        void getToBuyBooks()
        {
            dataGridViewBooks.Rows.Clear();
            LinkedList<Book> booksToBuy = accountInterfaceObject.getToBuyBooks();
            foreach (Book book in booksToBuy)
            {
                dataGridViewBooks.Rows.Add(new BookContainerId(book), new BookContainerTitle(book));
            }
            dataGridViewBooks.ClearSelection();
            comboBox1.SelectedIndex = -1;
            labelTitle.Text = "Books to buy";
        }

        private void buttonRated_Click(object sender, EventArgs e)
        {
            memoryManager.setRated();
            getRatedBooks();
        }
        private void getRatedBooks()
        {
            dataGridViewBooks.Rows.Clear();
            LinkedList<Book> ratedBooks = accountInterfaceObject.getRatedBooks();
            foreach (Book book in ratedBooks)
            {
                dataGridViewBooks.Rows.Add(new BookContainerId(book), new BookContainerTitle(book));
            }
            dataGridViewBooks.ClearSelection();
            comboBox1.SelectedIndex = -1;
            labelTitle.Text = "Rated books";
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                Book ratedBook = getSelectedBook();
                if (ratedBook == null)
                {
                    return;
                }

                if (comboBox1.SelectedIndex == 0)
                {
                    accountInterfaceObject.unrateBook(ratedBook);
                }
                else
                {
                    accountInterfaceObject.setBookRate(ratedBook, comboBox1.SelectedIndex);
                }
            }
            memoryManager.reloadLastOperation();
        }



        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Book currentBook = getSelectedBook();
            if (currentBook != null)
            {
                int currentBookRate = accountInterfaceObject.getBookRate(currentBook);
                prepareComboBox();
                comboBox1.SelectedIndex = currentBookRate;
                comboBox1.Refresh();
            }
        }

        private void buttonBoughtBooks_Click(object sender, EventArgs e)
        {
            memoryManager.setBought();
            getBoughtBooks();
        }
        void getBoughtBooks()
        {
            dataGridViewBooks.Rows.Clear();
            LinkedList<Book> boughtBooks = accountInterfaceObject.getBoughtBooks();
            foreach (Book book in boughtBooks)
            {
                dataGridViewBooks.Rows.Add(new BookContainerId(book), new BookContainerTitle(book));
            }
            dataGridViewBooks.ClearSelection();
            comboBox1.SelectedIndex = -1;
            labelTitle.Text = "Bought books";
        }

        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            
            
        }
        private Book getSelectedBook()
        {
            if ( memoryManager.DGVhasSelectedCell())
            {
                try
                {
                    Book toReturn = (dataGridViewBooks.CurrentCell.Value as BookInfoContainer).book;
                    return toReturn;
                }
                catch
                {
                    return null;
                }
                
            }
            return null;
        }

        private void prepareComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("unrate");
            for(int i=1;i<=10;i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }

        private void buttonRemoveFromToBuy_Click(object sender, EventArgs e)
        {
            if(memoryManager.isShowingToBuyBooks() & memoryManager.DGVhasSelectedCell())
            {
                Book toRemove = getSelectedBook();
                if (toRemove != null)
                {
                    accountInterfaceObject.removeBookFromToBuy(toRemove);
                    memoryManager.reloadLastOperation();
                }
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (memoryManager.DGVhasSelectedCell())
            {
                Book toBuy = getSelectedBook();
                if (toBuy != null)
                {
                    accountInterfaceObject.buyBook(toBuy);
                    memoryManager.reloadLastOperation();

                }

            }
        }
    }
}
