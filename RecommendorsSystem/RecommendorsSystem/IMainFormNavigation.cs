using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationInterfaces
{
    public interface IMainFormNavigation
    {
        void goToLogin();
        void goToRegister();
        void goToAccount();
        void goToSearch();
        void goToShowCategories();
        void goToEditCategories();
    }
}
