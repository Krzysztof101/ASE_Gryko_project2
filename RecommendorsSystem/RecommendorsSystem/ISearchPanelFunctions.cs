using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface ISearchPanelFunctions :IAccountSearchSharedFunctions
    {
        LinkedList<BookWithAuthorsAndCategories> searchByAuthor(string authors);
        LinkedList<BookWithAuthorsAndCategories> searchByTitle(string title);
        //-- latest fix // void buyBook(BookGeneralData bookToBuy);
        //-- latest fix // void setBookRate( BookGeneralData bookToRate, int rate);
        //-- latest fix // int getBookRate(BookGeneralData book);
        //-- latest fix // void unrateBook(BookGeneralData bookToUnrate);
        void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture);
        void viewBook(BookGeneralData bookToView);
        LinkedList<BookWithCategoriesAuthorsAndScore> askForRecommendations();
        //void goToAccount();
    }
}
