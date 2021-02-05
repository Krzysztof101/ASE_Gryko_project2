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
    public partial class UserControlShowCategs : UserControl
    {
        IShowCategoriesFunctions showCategoriesFunctions;
        INavShowCategories navShowCategories;
        public UserControlShowCategs(IShowCategoriesFunctions iShowCategoriesFunctions, INavShowCategories iNavShowCategories)
        {
            InitializeComponent();
            showCategoriesFunctions = iShowCategoriesFunctions;
            navShowCategories = iNavShowCategories;
        }

        private void buttonEditCategs_Click(object sender, EventArgs e)
        {
            navShowCategories.goToEditCategories();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            navShowCategories.goToAccount();
        }

        private void UserControlShowCategs_Load(object sender, EventArgs e)
        {
            listBoxLikedCategs.Items.Clear();
            LinkedList<string> categories = showCategoriesFunctions.getLikedCategories();
            foreach(string s in categories)
            {
                listBoxLikedCategs.Items.Add(s);
            }
            //listBoxLikedCategs.Refresh();
        }
    }
}
