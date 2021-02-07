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
        LinkedList<BookWithAuthors> findBooksByTitle(string title, CurrentUser user);
        LinkedList<BookWithAuthors> findBooksByAuthor(string authors, CurrentUser user);
        int getBookRate(BookGeneralData currentBook, CurrentUser user);
        LinkedList<BookWithAuthors> getAllBookWithAuthors(CurrentUser user);
    }
    public interface IRecommendationsGetters :IDatabaseGetters
    {
        int getNoOfSimilarBooksViewedWithinHalfAnHour(BookGeneralData book, CurrentUser user);
        LinkedList<string> getBookCategories(BookGeneralData book);
        LinkedList<Author> getBookAuthors(BookGeneralData book);
        LinkedList<Bonus> getBonusFromAdmin(BookGeneralData book);
        int getNewBooksBonus(BookGeneralData book);
        LinkedList<UserRatesInfoSet> getAllRowsInRates(BookGeneralData book);
        LinkedList<BookGeneralData> getBooksWithGeneralDataWithin05hour(CurrentUser user);
        LinkedList<Book> getBooksRecommendedWithin05h(CurrentUser user);
    }


    public interface IDatabaseSetters
    {
        void setRate(BookGeneralData book, CurrentUser user, int rate);
        void unrate(BookGeneralData book, CurrentUser user);
        void saveBookInToBuy(BookGeneralData book, CurrentUser user);
        void removeBookfromToBuy(BookGeneralData book, CurrentUser user);
        void buyBook(BookGeneralData book, CurrentUser user);
        void addCategoryToLiked(string category, CurrentUser user);
        void removeCategoryFromLiked(string category, CurrentUser user);
        void viewBook(BookGeneralData book, CurrentUser user);
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
