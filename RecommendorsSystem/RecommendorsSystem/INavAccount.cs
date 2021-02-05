using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationInterfaces
{
    public interface INavAccount
    {
        void goToLogin();
        void goToSearch();
        void goToShowCategories();
    }
}
