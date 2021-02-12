using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IEditCategoriesFunctions :IShowCategoriesFunctions
    {
        LinkedList<string> getAllCategories();
        //latest fix //LinkedList<string> getLikedCategories();
        void addCategoryToLikedCategories(string newLikedCategory);
        void removeCategoryFromLikedCategories(string categoryToRemove);
    }
}
