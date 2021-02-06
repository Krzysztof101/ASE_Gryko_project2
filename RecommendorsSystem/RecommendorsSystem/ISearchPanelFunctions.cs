using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface ISearchPanelFunctions
    {
        LinkedList<BookWithAuthors> searchByAuthor(string authors);
        LinkedList<BookWithAuthors> searchByTitle(string title);
        void buyBook(BookGeneralData bookToBuy);
        void setBookRate( BookGeneralData bookToRate, int rate);
        int getBookRate(BookGeneralData book);
        void unrateBook(BookGeneralData bookToUnrate);
        void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture);
        void viewBook(BookGeneralData bookToView);
        LinkedList<BookWithAuthorsAndScore> askForRecommendations();
        //void goToAccount();
    }
}
