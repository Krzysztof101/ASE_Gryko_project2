using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IEditCategoriesFunctions
    {
        LinkedList<string> getAllCategories();
        LinkedList<string> getLikedCategories();
        void addCategoryToLikedcategories(string newLikedCategory);
        void removeCategoryFromLikedCategories(string categoryToRemove);
    }
}
