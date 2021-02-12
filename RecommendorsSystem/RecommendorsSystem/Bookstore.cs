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
        internal LinkedList<BookWithAuthorsAndScore> generateRecommendations()
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
        public static Bookstore getInstance()
        {
            return _instance;
        }
        



        internal bool checkIfUserDoesntExist(string login)
        {
            return !databaseFunctions.checkIfUserExists(login);
        }

        internal void deleteAccount(string login, string pswd)
        {
            databaseFunctions.deleteAccount(login, pswd);
        }

        internal bool checkIfNickDoesntExist(string nick)
        {
            return !databaseFunctions.checkIfNickExists(nick);
        }
        internal void registerUser(string login, string password, string nick)
        {
            databaseFunctions.registerNewUser(login, password, nick, User);
        }

        internal bool tryToLogin(string login, string password)
        {
            return databaseFunctions.tryToLogin(login, password, User);
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
        
    }
}
