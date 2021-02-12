using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IAccountFunctions :IAccountSearchSharedFunctions
    {
        //void showRated();
        LinkedList<Book> getBoughtBooks();
        LinkedList<Book> getToBuyBooks();
        void removeBookFromToBuy(BookGeneralData bookToRemoveFromToBuy);
        //-- latest fix //void buyBook(BookGeneralData bookToBuy);
        LinkedList<Book> getRatedBooks();
        //-- latest fix //void setBookRate(BookGeneralData ratedBook, int rate);
        //-- latest fix //void unrateBook(BookGeneralData ratedBook);
        //bool passwordCorrect(string password);
        //void logoutAndGoToLogin();
        void deleteAccount();
        void logout();
        //-- latest fix // int getBookRate(BookGeneralData currentBook);
    }
}
