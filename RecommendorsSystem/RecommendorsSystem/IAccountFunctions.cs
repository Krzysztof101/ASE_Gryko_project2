using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IAccountFunctions
    {
        void showRated();
        LinkedList<Book> getBoughtBooks();
        LinkedList<Book> getToBuyBooks();
        void removeBookFromToBuy(Book bookToRemoveFromToBuy);
        void buyBook(Book bookToBuy);
        LinkedList<Book> getRatedBooks();
        void setBookRate(Book ratedBook, int rate);
        void unrateBook(Book ratedBook);
        bool passwordCorrect(string password);
        //void logoutAndGoToLogin();
        void deleteAccount(string userPassword);
        void logout();
        int getBookRate(Book currentBook);
    }
}
