using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IAccountFunctions
    {
        //void showRated();
        LinkedList<Book> getBoughtBooks();
        LinkedList<Book> getToBuyBooks();
        void removeBookFromToBuy(BookGeneralData bookToRemoveFromToBuy);
        void buyBook(BookGeneralData bookToBuy);
        LinkedList<Book> getRatedBooks();
        void setBookRate(BookGeneralData ratedBook, int rate);
        void unrateBook(BookGeneralData ratedBook);
        bool passwordCorrect(string password);
        //void logoutAndGoToLogin();
        void deleteAccount(string userPassword);
        void logout();
        int getBookRate(BookGeneralData currentBook);
    }
}
