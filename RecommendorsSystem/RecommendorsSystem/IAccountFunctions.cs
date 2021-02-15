using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IAccountFunctions :IAccountSearchSharedFunctions
    {
        //void showRated();

        //-- latest fix //void buyBook(BookGeneralData bookToBuy);

        //-- latest fix //void setBookRate(BookGeneralData ratedBook, int rate);
        //-- latest fix //void unrateBook(BookGeneralData ratedBook);
        //bool passwordCorrect(string password);
        //void logoutAndGoToLogin();
        LinkedList<BookGeneralData> getBoughtBooks();
        LinkedList<BookGeneralData> getToBuyBooks();
        void removeBookFromToBuy(BookGeneralData bookToRemoveFromToBuy);
        LinkedList<BookGeneralData> getRatedBooks();
        void deleteAccount();
        void logout();
        //-- latest fix // int getBookRate(BookGeneralData currentBook);
    }
}
