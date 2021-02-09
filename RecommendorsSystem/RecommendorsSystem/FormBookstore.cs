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
    public partial class FormBookstore : Form, IMainFormNavigation
    {
        UserControlLogin uclog;
        UserControlRegister ucreg;
        UserControlAccount ucAcc;
        UserControlSearch ucSea;
        UserControlShowCategs ucShCategs;
        UserControlEditCategs ucEditCategs;
        ILoginFunctions funLogin;
        INavLogin navLogin;
        IEditCategoriesFunctions funEditCategs;
        INavEditCategories navEditCategs;
        IShowCategoriesFunctions showCategs;
        INavShowCategories navShowCategs;
        IRegisterFunctions funRegister;
        INavRegister navRegister;

        public FormBookstore()
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
            funEditCategs = b.BookstoreFunctions;
            navEditCategs = b.BookstoreNavigation;
            showCategs = b.BookstoreFunctions;
            navShowCategs = b.BookstoreNavigation;
            funLogin = b.BookstoreFunctions;
            navLogin = b.BookstoreNavigation;
            funRegister = b.BookstoreFunctions;
            navRegister = b.BookstoreNavigation;
            
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
            ucEditCategs = new UserControlEditCategs(funEditCategs, navEditCategs);
            switchControl(ucEditCategs);
        }

        public void goToLogin()
        {
            uclog = new UserControlLogin(funLogin, navLogin);
            switchControl(uclog);
        }

        public void goToRegister()
        {
            ucreg = new UserControlRegister(funRegister, navRegister);
            switchControl(ucreg);
        }

        public void goToSearch()
        {
            switchControl(ucSea);
        }

        public void goToShowCategories()
        {
            ucShCategs = new UserControlShowCategs(showCategs, navShowCategs);
            switchControl(ucShCategs);
        }
        private void switchControl(Control ccc)
        {
            this.Controls.Clear();
            this.Controls.Add(ccc);
            this.Refresh();
        }

        public void clearInterfaces()
        {
            ucEditCategs.clearInterface();
            ucShCategs.clearInterface();
        }
    }
}
