using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IRecomGenFunctions : IDatabaseGetters
    {
        ScoreModuleInfo fetchMultiplicatorsData(string descriptor);
        
    }


    public interface IDatabaseGetters
    {
        LinkedList<Book> getBoughtBooks(CurrentUser user);
        LinkedList<Book> getToBuyBooks(CurrentUser user);
        LinkedList<Book> getRatedBooks(CurrentUser user);
        LinkedList<string> getAllCategories();
        LinkedList<string> getLikedCategories(CurrentUser user);
        //bool checkIfCredentialsAreValid(string login, string password);
        LinkedList<Book> findBooksByTitle(string title, CurrentUser user);
        LinkedList<Book> findBooksByAuthor(string authors, CurrentUser user);
        int getBookRate(Book currentBook, CurrentUser user);
        LinkedList<Book> getAllBookWithAuthors(CurrentUser user);
    }
    public interface IRecommendationsGetters :IDatabaseGetters
    {
        int getNoOfSimilarBooksViewedWithinHalfAnHour(Book book, CurrentUser user);
        LinkedList<string> getBookCategories(Book book);
        LinkedList<Author> getBookAuthors(Book book);
        LinkedList<Bonus> getBonusFromAdmin(BookWithAuthors book);
        int getNewBooksBonus(BookWithAuthors book);
        LinkedList<UserRatesInfoSet> getAllRowsInRates();
        LinkedList<BookWithAuthors> getBooksWithAuthorsSearchedWithin05hour(CurrentUser user);
        LinkedList<Book> getBooksRecommendedWithin05h(CurrentUser user);
    }


    public interface IDatabaseSetters
    {
        void setRate(Book book, CurrentUser user, int rate);
        void unrate(Book book, CurrentUser user);
        void saveBookInToBuy(Book book, CurrentUser user);
        void removeBookfromToBuy(Book book, CurrentUser user);
        void buyBook(Book book, CurrentUser user);
        void addCategoryToLiked(string category, CurrentUser user);
        void removeCategoryFromLiked(string category, CurrentUser user);
        void viewBook(Book book, CurrentUser user);
    }
    public interface IAuthenticationFunctions
    {
        bool tryToLogin(string login, string password, CurrentUser user);
        bool checkIfUserExists(string login);
        bool checkIfNickExists(string nick);
        void registerNewUser(string login, string password, string nick, CurrentUser user);
        void deleteAccount(string login, string password);
    }
    public interface IsaveInfoAboutRecommendation
    {
        void saveInfoAboutRecommendation(Book book, CurrentUser user);
    }
      
    public interface IDatabaseFunctions :IDatabaseGetters, IDatabaseSetters, IAuthenticationFunctions, IsaveInfoAboutRecommendation
    {
        

    }
    public interface IRecommendationsComponent :IDatabaseGetters, IRecomGenFunctions, IsaveInfoAboutRecommendation, IRecommendationsGetters
    {

    }
}
