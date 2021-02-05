using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookstorePackage;
using NavigationInterfaces;

namespace RecommendorsSystem
{
    public partial class Form1 : Form, IMainFormNavigation
    {
        UserControlLogin uclog;
        UserControlRegister ucreg;
        UserControlAccount ucAcc;
        UserControlSearch ucSea;
        UserControlShowCategs ucShCategs;
        UserControlEditCategs ucEditCategs;
      
        public Form1()
        {
            InitializeComponent();
            /*
            ucAcc = new UserControlAccount(Bookstore.Instance.accObj);
            ucreg = new UserControlRegister();
            ucSea = new UserControlSearch();
            uclog = new UserControlLogin();
            panel1.Controls.Add(uclog);
            panel2.Controls.Add(ucreg);
            panel3.Controls.Add(ucAcc);
            panel4.Controls.Add(ucSea);
            */

            



        }
        public void initialize(Bookstore b)
        {
            uclog = new UserControlLogin(b.BookstoreFunctions, b.BookstoreNavigation);
            ucreg = new UserControlRegister(b.BookstoreFunctions, b.BookstoreNavigation);
            ucAcc = new UserControlAccount(b.BookstoreFunctions, b.BookstoreNavigation);
            ucShCategs = new UserControlShowCategs(b.BookstoreFunctions,b.BookstoreNavigation);
            ucEditCategs = new UserControlEditCategs(b.BookstoreFunctions, b.BookstoreNavigation);
            ucSea = new UserControlSearch(b.BookstoreFunctions, b.BookstoreNavigation);
            this.Controls.Clear();
            this.Controls.Add(uclog);
            this.Refresh();
        }

        public void goToAccount()
        {
            switchControl(ucAcc);
        }

        public void goToEditCategories()
        {
            switchControl(ucEditCategs);
        }

        public void goToLogin()
        {
            switchControl(uclog);
        }

        public void goToRegister()
        {
            switchControl(ucreg);
        }

        public void goToSearch()
        {
            switchControl(ucSea);
        }

        public void goToShowCategories()
        {
            switchControl(ucShCategs);
        }
        private void switchControl(Control ccc)
        {
            this.Controls.Clear();
            this.Controls.Add(ccc);
            this.Refresh();
        }
    }
}
