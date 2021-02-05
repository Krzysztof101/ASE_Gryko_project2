using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavigationInterfaces;

namespace RecommendorsSystem
{
    public class BookstoreNavFunctions : INavAccount, INavEditCategories, INavLogin, INavRegister, INavSearchPanel, INavShowCategories
    {
        public BookstoreNavFunctions(IMainFormNavigation mainFormNav)
        {
            mainFormNavigation = mainFormNav;
        }

        private IMainFormNavigation mainFormNavigation;

        public void goToAccount()
        {
            mainFormNavigation.goToAccount();
        }

        public void goToEditCategories()
        {
            mainFormNavigation.goToEditCategories();
        }

        public void goToLogin()
        {
            mainFormNavigation.goToLogin();
        }

        public void goToRegister()
        {
            mainFormNavigation.goToRegister();
        }

        public void goToSearch()
        {
            mainFormNavigation.goToSearch();
        }

        public void goToShowCategories()
        {
            mainFormNavigation.goToShowCategories();
        }
    }
}
