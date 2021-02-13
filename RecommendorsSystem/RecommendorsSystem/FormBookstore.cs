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
        BookstoreNavFunctions navigation;

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
            navigation = new BookstoreNavFunctions(this);
            uclog = new UserControlLogin(b, navigation);
            ucreg = new UserControlRegister(b, navigation);
            ucAcc = new UserControlAccount(b, navigation);
            ucShCategs = new UserControlShowCategs(b, navigation);
            ucEditCategs = new UserControlEditCategs(b, navigation);
            ucSea = new UserControlSearch(b, navigation);
            funEditCategs = b;
            navEditCategs = navigation;
            showCategs = b;
            navShowCategs = navigation;
            funLogin = b;
            navLogin = navigation;
            funRegister = b;
            navRegister = navigation;
            
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
