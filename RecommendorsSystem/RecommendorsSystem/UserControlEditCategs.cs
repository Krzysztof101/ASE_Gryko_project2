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
    public partial class UserControlEditCategs : UserControl
    {
        IEditCategoriesFunctions editCategoriesFunctions;
        INavEditCategories navEditCategories;
        public UserControlEditCategs(IEditCategoriesFunctions iEditCategoriesFunctions, INavEditCategories iNavEditCategories)
        {
            editCategoriesFunctions = iEditCategoriesFunctions;
            navEditCategories = iNavEditCategories;
            InitializeComponent();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            navEditCategories.goToAccount();
        }

        private void UserControlEditCategs_Load(object sender, EventArgs e)
        {
            listBoxLikedCategs.Items.Clear();
            listBoxOtherCategs.Items.Clear();
            LinkedList<string> allCategs = editCategoriesFunctions.getAllCategories();
            LinkedList<string> userCategs = editCategoriesFunctions.getLikedCategories();
            foreach(string categ in userCategs)
            {
                if(allCategs.Contains(categ))
                {
                    allCategs.Remove(categ);
                }
            }
            foreach(string categ in userCategs)
            {
                listBoxLikedCategs.Items.Add(categ);
            }
            foreach(string categ in allCategs)
            {
                listBoxOtherCategs.Items.Add(categ);
            }
        }

        private void listBoxOtherCategs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxOtherCategs.SelectedIndex!=-1)
            listBoxLikedCategs.SelectedIndex = -1;

        }

        private void buttonMoveCateg_Click(object sender, EventArgs e)
        {
            if(listBoxLikedCategs.SelectedIndex!=-1 && listBoxOtherCategs.SelectedIndex==-1)
            {
                removeFromLiked();
            }
            if(listBoxLikedCategs.SelectedIndex == -1 && listBoxOtherCategs.SelectedIndex !=-1)
            {
                addToLiked();
            }
        }

        private void addToLiked()
        {
            string category = listBoxOtherCategs.SelectedItem.ToString();
            editCategoriesFunctions.addCategoryToLikedcategories(category);
            
                listBoxOtherCategs.Items.Remove(category);
                listBoxLikedCategs.Items.Add(category);
            
        }

        private void removeFromLiked()
        {
            string category = listBoxLikedCategs.SelectedItem.ToString();
            editCategoriesFunctions.removeCategoryFromLikedCategories(category);
            listBoxOtherCategs.Items.Add(category);
            listBoxLikedCategs.Items.Remove(category);
        }

        private void listBoxLikedCategs_SelectedIndexChanged(object sender, EventArgs e)
        {
                if(listBoxLikedCategs.SelectedIndex!=-1)
                listBoxOtherCategs.SelectedIndex = -1;           
        }
    }
}
