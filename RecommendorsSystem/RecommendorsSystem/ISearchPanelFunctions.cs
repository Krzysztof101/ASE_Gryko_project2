using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface ISearchPanelFunctions :IAccountSearchSharedFunctions
    {
        LinkedList<BookWithAuthors> searchByAuthor(string authors);
        LinkedList<BookWithAuthors> searchByTitle(string title);
        //-- latest fix // void buyBook(BookGeneralData bookToBuy);
        //-- latest fix // void setBookRate( BookGeneralData bookToRate, int rate);
        //-- latest fix // int getBookRate(BookGeneralData book);
        //-- latest fix // void unrateBook(BookGeneralData bookToUnrate);
        void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture);
        void viewBook(BookGeneralData bookToView);
        LinkedList<BookWithAuthorsAndScore> askForRecommendations();
        //void goToAccount();
    }
}
