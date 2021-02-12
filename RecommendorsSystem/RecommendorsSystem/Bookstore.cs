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
    public interface IBookstoreBookstoreUIFunctions :IAccountFunctions, IEditCategoriesFunctions, ILoginFunctions, ISearchPanelFunctions, IShowCategoriesFunctions
    {
        //IAccountFunctions
        /*
        LinkedList<Book> getBoughtBooks();
        LinkedList<Book> getToBuyBooks();
        void removeBookFromToBuy(BookGeneralData bookToRemoveFromToBuy);
        void buyBook(BookGeneralData bookToBuy);
        LinkedList<Book> getRatedBooks();
        void setBookRate(BookGeneralData ratedBook, int rate);
        void unrateBook(BookGeneralData ratedBook);
        void deleteAccount();
        void logout();
        int getBookRate(BookGeneralData currentBook);
        */

        //IEditCategs
        /*
        LinkedList<string> getAllCategories();
        LinkedList<string> getLikedCategories();
        void addCategoryToLikedCategories(string newLikedCategory);
        void removeCategoryFromLikedCategories(string categoryToRemove);
        */
        //ILoginFunctions
        //bool tryToLogin(string login, string password);

        //IRegisterFunctions - nie korzystamy
        //ISearchPanelFunctions - korzystamy
        /*
         LinkedList<BookWithAuthors> searchByAuthor(string authors);
        LinkedList<BookWithAuthors> searchByTitle(string title);
        void buyBook(BookGeneralData bookToBuy);
        void setBookRate(BookGeneralData bookToRate, int rate);
        int getBookRate(BookGeneralData book);
        void unrateBook(BookGeneralData bookToUnrate);
        void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture);
        void viewBook(BookGeneralData bookToView);
        LinkedList<BookWithAuthorsAndScore> askForRecommendations();
        */


        //void addCategoryToLikedCategories(string newLikedCategory);
        //-- from parent interface --//LinkedList<BookWithAuthorsAndScore> askForRecommendations();
        //void buyBook(BookGeneralData bookToBuy);
        
        //void deleteAccount();
        //int getBookRate(BookGeneralData currentBook);
        //LinkedList<string> getAllCategories();
        //LinkedList<Book> getBoughtBooks();
        //LinkedList<string> getLikedCategories();
        //LinkedList<Book> getRatedBooks();
        //LinkedList<Book> getToBuyBooks();
        
        //bool tryToLogin(string login,string password);
        //void removeBookFromToBuy(BookGeneralData bookToRemoveFromToBuy);
        //void removeCategoryFromLikedCategories(string categoryToRemove);
        //-- from parent interface --// void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture);
        
        //-- from parent interface --// LinkedList<BookWithAuthors> searchByTitle(string title);
        //void setBookRate(BookGeneralData ratedBook, int rate);
        //-- from parent interface --// void viewBook(BookGeneralData bookToView);
        //void unrateBook(BookGeneralData ratedBook);
        //void logout();
        //-- from parent interface --// LinkedList<BookWithAuthors> searchByAuthor(string onlyLettersPhrase);

        bool checkIfUserExists(string login);
        bool checkIfNickExists(string nick);
        //-- from parent interface --//LinkedList<BookWithAuthors> searchByAuthor(string onlyLettersPhrase);
        void registerNewUser(string login, string password, string nick);

    }

    public class Bookstore :IBookstoreBookstoreUIFunctions
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

        public void addCategoryToLikedCategories(string newLikedCategory)
        {
            databaseFunctions.addCategoryToLiked(newLikedCategory, User);
        }

        public void buyBook(BookGeneralData bookToBuy)
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
        public LinkedList<BookWithAuthorsAndScore> askForRecommendations()
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

        public LinkedList<string> getLikedCategories()
        {
            return databaseFunctions.getLikedCategories(User);
        }

        public LinkedList<Book> getRatedBooks()
        {
            return databaseFunctions.getRatedBooks(User);
        }

        public LinkedList<Book> getToBuyBooks()
        {
            return databaseFunctions.getToBuyBooks(User);
        }

        public LinkedList<Book> getBoughtBooks()
        {
            return databaseFunctions.getBoughtBooks(User);
        }

        public LinkedList<string> getAllCategories()
        {
            return databaseFunctions.getAllCategories();
        }

        public int getBookRate(BookGeneralData currentBook)
        {
            return databaseFunctions.getBookRate(currentBook, User);
        }

        public static Bookstore getInstance()
        {
            return _instance;
        }




        public bool checkIfUserExists(string login)
        {
            return databaseFunctions.checkIfUserExists(login);
        }

        public void removeCategoryFromLikedCategories(string categoryToRemove)
        {
            databaseFunctions.removeCategoryFromLiked(categoryToRemove, User);
        }

        public void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture)
        {
            databaseFunctions.saveBookInToBuy(bookToBeBoughtInFuture, User);
        }

        public void removeBookFromToBuy(BookGeneralData bookToRemoveFromToBuy)
        {
            databaseFunctions.removeBookfromToBuy(bookToRemoveFromToBuy,User);
        }

        public void deleteAccount()
        {
            databaseFunctions.deleteAccount(User);
            User.logout();
        }

        public LinkedList<BookWithAuthors> searchByAuthor(string onlyLettersPhrase)
        {
            return databaseFunctions.findBooksByAuthor(onlyLettersPhrase, User);
        }

        public bool checkIfNickExists(string nick)
        {
            return databaseFunctions.checkIfNickExists(nick);
        }
        public void registerNewUser(string login, string password, string nick)
        {
            databaseFunctions.registerNewUser(login, password, nick, User);
        }

        public bool tryToLogin(string login, string password)
        {
            return databaseFunctions.tryToLogin(login, password, User);
        }

        public LinkedList<BookWithAuthors> searchByTitle(string title)
        {
            return databaseFunctions.findBooksByTitle(title,User);
        }

        public void setBookRate(BookGeneralData ratedBook, int rate)
        {
            databaseFunctions.setRate(ratedBook, User, rate);
        }

        public void viewBook(BookGeneralData bookToView)
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

        public void unrateBook(BookGeneralData ratedBook)
        {
            databaseFunctions.unrate(ratedBook,User);
        }

        public void logout()
        {
            User.logout();
        }
    }
}
