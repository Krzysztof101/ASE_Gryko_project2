using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface ISearchPanelFunctions
    {
        LinkedList<Book> searchByAuthor(string authors);
        LinkedList<Book> searchByTitle(string title);
        void buyBook(Book bookToBuy);
        void setBookRate( Book bookToRate, int rate);
        int getBookRate(Book book);
        void unrateBook(Book bookToUnrate);
        void saveBookInToBuy(Book bookToBeBoughtInFuture);
        void viewBook(Book bookToView);
        LinkedList<BookWithAuthorsAndScore> askForRecommendations();
        //void goToAccount();
    }
}
