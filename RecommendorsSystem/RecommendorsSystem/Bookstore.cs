using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabasePackage;
using RecommendorsSystem;
using NavigationInterfaces;

namespace BookstorePackage
{
    public interface IBookstoreBookstoreUIFunctions
    {
        void addCategoryToLikedCategories(string newLikedCategory);
        LinkedList<BookWithAuthorsAndScore> askForRecommendations();
        void buyBook(BookGeneralData bookToBuy);
        bool checkIfUserExists(string login);
        bool checkIfNickExists(string nick);
        void deleteAccount(string login, string pswd);
        int getBookRate(BookGeneralData currentBook);
        LinkedList<string> getAllCategories();
        LinkedList<Book> getBoughtBooks();
        LinkedList<string> getLikedCategories();
        LinkedList<Book> getRatedBooks();
        LinkedList<Book> getToBuyBooks();
        void registerNewUser(string login, string password, string nick);
        bool tryToLogin(string login,string password);
        void removeBookfromToBuy(BookGeneralData bookToRemoveFromToBuy);
        void removeCategoryFromLikedCategories(string categoryToRemove);
        void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture);
        LinkedList<BookWithAuthors> seaarchByAuthor(string onlyLettersPhrase);
        LinkedList<BookWithAuthors> searchByTitle(string title);
        void setBookRate(BookGeneralData ratedBook, int rate);
        void viewBook(BookGeneralData bookToView);
        void unrateBook(BookGeneralData ratedBook);
        void logout();
    }

    public class Bookstore
    {
        private Bookstore(IMainFormNavigation imfn, IDatabaseFunctions idbfuns, IRecommendationsComponent irecComp)
        {
            BookstoreNavigation = new BookstoreNavFunctions(imfn);
            BookstoreFunctions = new BookstoreUIFunctions(this);
            recommendationsFunctions = irecComp;
            databaseFunctions = idbfuns;
            User = new CurrentUser();
            recommendationsGenerator = new RecommendationsGenerator(irecComp/*, listOfModules()*/);
        }

        internal void addCategoryToLikedCategories(string newLikedCategory)
        {
            databaseFunctions.addCategoryToLiked(newLikedCategory, User);
        }

        internal void buyBook(BookGeneralData bookToBuy)
        {
            databaseFunctions.buyBook(bookToBuy, User);
        }

        /*
        private LinkedList<ScoreGeneratingModule> listOfModules()
        {
            LinkedList<ScoreGeneratingModule> scoreModules = new LinkedList<ScoreGeneratingModule>();
            scoreModules.AddLast(new SearchHistoryScoreModule());
            scoreModules.AddLast(new ViewingHistoryModule());
            scoreModules.AddLast(new LikedCategoriesModule());
            scoreModules.AddLast(new RatesModule());
            scoreModules.AddLast(new LatestRecommendationsModule());
            scoreModules.AddLast(new AdminBonusesModule());
            scoreModules.AddLast(new NewBooksModule());
            scoreModules.AddLast(new BoughtBooksModule());
            scoreModules.AddLast(new BooksToBuyModule());
            return scoreModules;
        }
    */
        internal LinkedList<BookWithAuthorsAndScore> askForRecommendations()
        {
            return recommendationsGenerator.generateRecommendations(User);
        }



        //private static Lazy<Bookstore> instance = new Lazy<Bookstore>(() => new Bookstore());
        private static Bookstore _instance = null;
        private static Object _mutex = new Object();
        public static Bookstore initialize(IMainFormNavigation imfn, IDatabaseFunctions idbfuns, IRecommendationsComponent irecComp)
        {
            if(_instance==null)
            {
                lock(_mutex)
                {
                    if(_instance==null)
                    {
                        _instance = new Bookstore(imfn, idbfuns, irecComp);
                    }
                }
            }
            return _instance;
        }

        internal LinkedList<string> getLikedCategories()
        {
            return databaseFunctions.getLikedCategories(User);
        }

        internal LinkedList<Book> getRatedBooks()
        {
            return databaseFunctions.getRatedBooks(User);
        }

        internal LinkedList<Book> getToBuyBooks()
        {
            return databaseFunctions.getToBuyBooks(User);
        }

        internal LinkedList<Book> getBoughtBooks()
        {
            return databaseFunctions.getBoughtBooks(User);
        }

        internal LinkedList<string> getAllCategories()
        {
            return databaseFunctions.getAllCategories();
        }

        internal int getBookRate(BookGeneralData currentBook)
        {
            return databaseFunctions.getBookRate(currentBook, User);
        }

        public static Bookstore getInstance()
        {
            return _instance;
        }
        



        internal bool checkIfUserExists(string login)
        {
            return databaseFunctions.checkIfUserExists(login);
        }

        internal void removeCategoryFromLikedCategories(string categoryToRemove)
        {
            databaseFunctions.removeCategoryFromLiked(categoryToRemove, User);
        }

        internal void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture)
        {
            databaseFunctions.saveBookInToBuy(bookToBeBoughtInFuture, User);
        }

        internal void removeBookfromToBuy(BookGeneralData bookToRemoveFromToBuy)
        {
            databaseFunctions.removeBookfromToBuy(bookToRemoveFromToBuy,User);
        }

        internal void deleteAccount(string login, string pswd)
        {
            User.logout();
            databaseFunctions.deleteAccount(login, pswd);
        }

        internal LinkedList<BookWithAuthors> searchByAuthor(string onlyLettersPhrase)
        {
            return databaseFunctions.findBooksByAuthor(onlyLettersPhrase, User);
        }

        internal bool checkIfNickExists(string nick)
        {
            return databaseFunctions.checkIfNickExists(nick);
        }
        internal void registerNewUser(string login, string password, string nick)
        {
            databaseFunctions.registerNewUser(login, password, nick, User);
        }

        internal bool tryToLogin(string login, string password)
        {
            return databaseFunctions.tryToLogin(login, password, User);
        }

        internal LinkedList<BookWithAuthors> searchByTitle(string title)
        {
            return databaseFunctions.findBooksByTitle(title,User);
        }

        internal void setBookRate(BookGeneralData ratedBook, int rate)
        {
            databaseFunctions.setRate(ratedBook, User, rate);
        }

        internal void viewBook(BookGeneralData bookToView)
        {
            databaseFunctions.viewBook(bookToView , User);
        }


        /*
        public class Singleton 
{ 
    private static Singleton _instance = null; 

    private static Object _mutex = new Object();

    private Singleton(object arg1, object arg2) 
    { 
        // whatever
    } 

    public static Singleton GetInstance(object arg1, object arg2)
    { 
        if (_instance == null) 
        { 
          lock (_mutex) // now I can claim some form of thread safety...
          {
              if (_instance == null) 
              { 
                  _instance = new Singleton(arg1, arg2);
              }
          } 
        }

        return _instance;
    }
} 
        */


        /*
        private static Lazy<Bookstore> instance;
        private static Lazy<Bookstore> instance2(IMainFormNavigation imfn)
        {
            instance = new Lazy<Bookstore>(() => new Bookstore(imfn));
            return instance;
        }
        public static Bookstore Instance => instance.Value;
        */



        public CurrentUser User { get; set; }

        public BookstoreNavFunctions BookstoreNavigation { get; private set; }
        public BookstoreUIFunctions BookstoreFunctions { get; private set; }
        public IDatabaseFunctions databaseFunctions { get; private set; }
        public IRecommendationsComponent recommendationsFunctions { get; private set; }
        public RecommendationsGenerator recommendationsGenerator { get; private set; }

        internal void unrateBook(BookGeneralData ratedBook)
        {
            databaseFunctions.unrate(ratedBook,User);
        }

        internal void logout()
        {
            User.logout();
        }
    }
}
