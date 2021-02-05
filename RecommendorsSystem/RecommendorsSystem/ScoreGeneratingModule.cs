using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public abstract class ScoreGeneratingModule
    {
        //protected CurrentUser user;
        public ScoreGeneratingModule(/*CurrentUser user*/) { /*this.user = user;*/ }
        public ScoreModuleInfo ModuleInfo{ get; set; }
        public abstract int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user);
        public abstract string getDescriptor();
    }

    

    public class ViewingHistoryModule :ScoreGeneratingModule
    {
        public ViewingHistoryModule(/*CurrentUser user*/) : base(/*user<fix>*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book,CurrentUser user)
        {
            if (!ModuleInfo.Active)
            {
                int howManySimilarCategsBooksViewedIn05h = dbPackingClass.getNoOfSimilarBooksViewedWithinHalfAnHour(book, user);
                return ModuleInfo.MainMultiplicator * howManySimilarCategsBooksViewedIn05h;
            }
            return 0;
        }
        public override string getDescriptor()
        {
            return "ViewingHistory";
        }
    }
    public class LikedCategoriesModule : ScoreGeneratingModule
    {
        public LikedCategoriesModule(/*CurrentUser user*/) : base(/*user*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if(ModuleInfo.Active)
            {   
                LinkedList<string> likedCategs = dbPackingClass.getLikedCategories(user);
                LinkedList<string> bookcategs = dbPackingClass.getBookCategories(book);
                int categsCount = 0;
                foreach (string categ in bookcategs)
                {
                    if (likedCategs.Contains(categ))
                    {
                        categsCount++;
                    }
                }
            return categsCount * ModuleInfo.MainMultiplicator;
            }
            return 0;
        }
        public override string getDescriptor()
        {
            return "LikedCategories";
        }
       
    }

    class FunctionsUtils
    {
        public static int countSameCategoriesBooks(Book book, LinkedList<Book> boughtBooks, IRecommendationsGetters dbPackingClass)
        {
            int totalSimilarCategsCount = 0;
            LinkedList<string> thisBookCategs = dbPackingClass.getBookCategories(book);
            foreach (Book boughtBook in boughtBooks)
            {
                int categsCount = 0;
                LinkedList<string> bookCategs = dbPackingClass.getBookCategories(boughtBook);
                foreach (string thisBookCateg in thisBookCategs)
                {
                    if (bookCategs.Contains(thisBookCateg))
                    {
                        categsCount++;
                    }
                }
                totalSimilarCategsCount += categsCount;
            }
            return totalSimilarCategsCount;
        }

        public static int countAllSameAuthors(Book thisBook, LinkedList<Book> Books, IRecommendationsGetters dbPackingClass)
        {
            LinkedList<Author> thisBookAuthors = dbPackingClass.getBookAuthors(thisBook);

            int totalAuthorCount = 0;
            foreach (Book boughtBook in Books)
            {
                int authorsCount = countAuthors(boughtBook, thisBookAuthors, dbPackingClass);
                totalAuthorCount += authorsCount;
            }
            return totalAuthorCount;
        }
        public static int countAuthors(Book boughtBook, LinkedList<Author> thisBookAuthors, IRecommendationsGetters dbPackingClass)
        {
            LinkedList<Author> boughtBookAuthors = dbPackingClass.getBookAuthors(boughtBook);
            int authcount = 0;
            foreach (Author tba in thisBookAuthors)
            {
                foreach (Author bba in boughtBookAuthors)
                {
                    if (bba.Id == tba.Id)
                    {
                        authcount++;
                    }
                }
            }
            return authcount;
        }
    }


    public class BoughtBooksModule : ScoreGeneratingModule
    {
        public BoughtBooksModule(/*CurrentUser user*/) : base(/*user*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if (!ModuleInfo.Active)
            {
                LinkedList<Book> boughtBooks = dbPackingClass.getBoughtBooks(user);
                int totalSimilarCategsCount = FunctionsUtils.countSameCategoriesBooks(book, boughtBooks, dbPackingClass);
                
                int boughtBooksWithTheSameAuthor = FunctionsUtils.countAllSameAuthors(book, boughtBooks, dbPackingClass);


                return ModuleInfo.MainMultiplicator* ( totalSimilarCategsCount * ModuleInfo.getMultiplicatorAt("SameCategory") + boughtBooksWithTheSameAuthor * ModuleInfo.getMultiplicatorAt("SameAuthor") );
            }
            return 0;
        }
        
        /*
        private int countAllSameAuthors(Book thisBook, LinkedList<Book> Books, IRecommendationsGetters dbPackingClass)
        {
            LinkedList<Author> thisBookAuthors = dbPackingClass.getBookAuthors(thisBook);

            int totalAuthorCount = 0;
            foreach(Book boughtBook in Books)
            {
                int authorsCount = countAuthors(boughtBook, thisBookAuthors, dbPackingClass);
                totalAuthorCount += authorsCount;
            }
            return totalAuthorCount;
        }
        private int countAuthors(Book boughtBook, LinkedList<Author> thisBookAuthors, IRecommendationsGetters dbPackingClass)
        {
            LinkedList<Author> boughtBookAuthors = dbPackingClass.getBookAuthors(boughtBook);
            int authcount = 0;
            foreach( Author tba in thisBookAuthors )
            {
                foreach(Author bba in boughtBookAuthors)
                {
                    if(bba.Id == tba.Id)
                    {
                        authcount++;
                    }
                }
            }
            return authcount;
        }
        */

        public override string getDescriptor()
        {
            return "BoughtBooks";
            
        }
    }
    public class BooksToBuyModule : ScoreGeneratingModule
    {
        public BooksToBuyModule(/*CurrentUser user*/) : base(/*user*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if(ModuleInfo.Active)
            {
                LinkedList<Book> booksToBuy = dbPackingClass.getToBuyBooks(user);
                int booksWithTheSameCategs = FunctionsUtils.countSameCategoriesBooks(book, booksToBuy, dbPackingClass);

                int booksWithTheSameAuthors = FunctionsUtils.countAllSameAuthors(book, booksToBuy, dbPackingClass);

                return ModuleInfo.MainMultiplicator * (booksWithTheSameCategs * ModuleInfo.getMultiplicatorAt("SameCategory") + booksWithTheSameAuthors * ModuleInfo.getMultiplicatorAt("SameAuthor"));

            }
            return 0;
        }
        public override string getDescriptor()
        {
            return "BooksToBuy";

        }
    }

    public class RatesModule : ScoreGeneratingModule
    {
        class SimilarityMatrix 
        {
            int[,] matrix;

            public int BooksCount { get { return matrix.GetLength(1); } private set { }  }
            public int UsersCount { get { return matrix.GetLength(0); } private set { } }
            public SimilarityMatrix( int noOfUsers,int  noOfBooks)
            {
                matrix = new int[noOfUsers, noOfBooks];
                for(int i = 0; i<noOfUsers;i++)
                {
                    for( int j=0; j<noOfBooks; j++)
                    { matrix[i, j] = 0; }
                }
            }
            public void setScore(int user, int book, int rate)
            {
                matrix[user, book] = rate;
            }
            public int getScore(int user, int book) { return matrix[user, book]; }
        }

        /*
          double upper = 0.0;
                double thisUserAvg = calculateAvgForUser(matrix, currentUserIndex, currentBookIndex);
                for (int i = 0; i < matrix.UsersCount; i++)
                {
                    if (i != currentUserIndex)
                    {
                        double secondUserAvg = calculateAvgForUser(matrix, i,currentBookIndex);
                        for (int j = 0; j < matrix.BooksCount; j++)
                        {
                            if (matrix.getScore(i, j) != 0)
                            {
                                double diffCurrUsr = matrix.getScore(currentBookIndex, j) - thisUserAvg;
                                double diffOtherUsr = matrix.getScore(i, j) - secondUserAvg;
                                upper += (diffCurrUsr * diffOtherUsr);
                            }
                        }
                    }

                }
         */

        public RatesModule(/*CurrentUser user*/) : base(/*user*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if (ModuleInfo.Active)
            {
                LinkedList<UserRatesInfoSet> userBooksRates = dbPackingClass.getAllRowsInRates(); //sorted by userID, bookID
                int sum = 0;
                int count = 0;
                foreach(UserRatesInfoSet u in userBooksRates)
                {
                    if(u.IdBook==book.id)
                    {
                        sum += u.Rate;
                        count++;
                    }

                }
                int avg = 0;
                int retVal = avg;
                if (count > 0)
                {
                    avg = (int)(((double)sum) / count);
                    int offset = -4;
                    avg -= offset;
                    double numberOfBoughtModifier = count / ModuleInfo.getMultiplicatorAt("devider");
                    retVal = (int)(avg * numberOfBoughtModifier);
                }
                return retVal;


                /*
                int currentUserIndex = 0;
                int currentBookIndex = 0;
                SimilarityMatrix matrix = prepareMatrix(userBooksRates,book.id, out currentUserIndex, out currentBookIndex);

                
                double lowerThisUser = calculateRootOfSumOfSquared(matrix, currentUserIndex, currentBookIndex, thisUserAvg);
                */
            }
            return 0;
        }
        /*
        private double calculateSimilarityBetweenTwoUsers(SimilarityMatrix matrix, int mainUserIdx, int otherUserIdx, int excludedBookIdx)
        {
            double thisUserAvg = calculateAvgForUser(matrix, mainUserIdx, excludedBookIdx);


        }
        */

        private double calculateRootOfSumOfSquared(SimilarityMatrix matrix ,int userIndex, int excludedBookIndex, double userAvg)
        {
            double sum = 0.0;
            for(int i=0; i<matrix.BooksCount;i++)
            {
                if(i!=excludedBookIndex && matrix.getScore(userIndex,i)!=0 )
                {
                    sum += (matrix.getScore(userIndex, i) - userAvg) * (matrix.getScore(userIndex, i) - userAvg);
                }
            }
            return Math.Sqrt(sum);
        }

        private double calculateAvgForUser(SimilarityMatrix matrix, int userIndex, int currentBookId)
        {
            int sum = 0;
            int count = 0;
            for(int i=0;i<matrix.BooksCount;i++)
            {
                if(matrix.getScore(userIndex,i)!=0 && i!=currentBookId)
                {
                    sum += matrix.BooksCount;
                    count++;
                }
            }
            double avg = 0.0;
            if(count>0)
            {
                avg = ((double)sum) / count;
            }
            return avg;
        }

        /*
         * 
         * 
          int sum = 0, count=0;
                for(int i=0; i<matrix.BooksCount;i++)
                {
                    if(matrix.getScore(currentUserIndex, i)!=0)
                    {
                        sum += matrix.getScore(currentUserIndex, i);
                        count++;
                    }
                }
                double userAvg = 0.0;
                if(count!=0)
                {
                    userAvg = ((double)sum) / count;
                }


                double score = 0.0;
                int count2 = 0;

                for(int i=0; i<matrix.UsersCount;i++)
                {
                    if(i!= currentUserIndex)
                    {

                    }

                }
         */

        private SimilarityMatrix prepareMatrix(LinkedList<UserRatesInfoSet> userBooksRates,int bookID,out int currentUserIndex, out int currentBookIndex, CurrentUser user)
        {
            int usersCounter = countUsers(userBooksRates);
            int booksCounter = countBooks(userBooksRates);
            int[] usersHashArray = prepareUserHashArray(userBooksRates);
            int[] booksHashArray = prepareBookHashArray(userBooksRates);
            SimilarityMatrix matrix = new SimilarityMatrix(usersCounter, booksCounter);

            currentUserIndex = -1;
            currentBookIndex = -1;
            foreach(UserRatesInfoSet uris in userBooksRates)
            {
                matrix.setScore(usersHashArray[uris.IdUser], booksHashArray[uris.IdBook], uris.Rate );
                if (uris.IdUser == user.id && uris.IdBook == bookID )
                {
                    currentUserIndex = usersHashArray[uris.IdUser];
                    currentBookIndex = booksHashArray[uris.IdBook];
                }

            }
            return matrix;
        }

        private int[] prepareBookHashArray(LinkedList<UserRatesInfoSet> userBooksRates)
        {
            int greatestID = -1;
            foreach (UserRatesInfoSet u in userBooksRates)
            {
                if (greatestID < u.IdBook)
                {
                    greatestID = u.IdBook;
                }
            }
            int[] hashArray = new int[greatestID + 1];
            for (int i = 0; i < greatestID + 1; i++)
            {
                hashArray[i] = -1;
            }
            int j = 0;
            foreach (UserRatesInfoSet u in userBooksRates)
            {
                if(hashArray[u.IdBook]==-1)
                hashArray[u.IdBook] = j++;
            }
            return hashArray;
        }

        private int[] prepareUserHashArray(LinkedList<UserRatesInfoSet> userBooksRates)
        {
            int greatestID = -1;
            foreach(UserRatesInfoSet u in userBooksRates)
            {
                if(greatestID< u.IdUser)
                {
                    greatestID = u.IdUser;
                }
            }
            int[] hashArray = new int[greatestID + 1];
            for(int i=0;i<greatestID+1;i++)
            {
                hashArray[i] = -1;
            }
            int j = 0;
            foreach (UserRatesInfoSet u in userBooksRates)
            {
                if(hashArray[u.IdUser]==-1)
                hashArray[u.IdUser] = j++;
            }
            return hashArray;
        }

        private int countBooks(LinkedList<UserRatesInfoSet> userBooksRates)
        {
            throw new NotImplementedException();
        }

        private int countUsers(LinkedList<UserRatesInfoSet> userBooksRates)
        {
            LinkedList<int> booksIds = new LinkedList<int>();
            foreach(UserRatesInfoSet bris in userBooksRates)
            {
                if(!booksIds.Contains(bris.IdBook))
                {
                    booksIds.AddLast(bris.IdBook);
                }
            }
            return booksIds.Count;
        }

        public override string getDescriptor()
        {
            return "Rates";
            
        }
    }
    public class LatestRecommendationsModule : ScoreGeneratingModule
    {
        public LatestRecommendationsModule(/*CurrentUser user*/) : base(/*user*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if(ModuleInfo.Active)
            {
                LinkedList<Book> recentlyRecommended = dbPackingClass.getBooksRecommendedWithin05h(user);
                int bonus = 0;
                foreach(Book b in recentlyRecommended)
                {
                    if(b.id == book.id)
                    {
                        bonus++;
                    }
                }
                return ModuleInfo.MainMultiplicator * bonus;
            }
            return 0;
        }
        public override string getDescriptor()
        {
            return "LatestRecommendations"; 
        }
    }
    public class SearchHistoryScoreModule : ScoreGeneratingModule
    {
        public SearchHistoryScoreModule(/*CurrentUser user*/) : base(/*user*/) { }

        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if (ModuleInfo.Active)
            {
                LinkedList<BookWithAuthors> booksWithAuthors = dbPackingClass.getBooksWithAuthorsSearchedWithin05hour(user);
                int recentlySearched = 0;
                foreach (BookWithAuthors b in booksWithAuthors)
                {
                    if (b.id == book.id)
                    {
                        recentlySearched++;
                    }
                }

                int recentlySearchedCategs = 0;
                LinkedList<string> bookCategs = dbPackingClass.getBookCategories(book);
                foreach (BookWithAuthors b in booksWithAuthors)
                {
                    LinkedList<string> secondBookCategs = dbPackingClass.getBookCategories(b);
                    foreach (string categ in bookCategs)
                    {
                        if (secondBookCategs.Contains(categ))
                        {
                            recentlySearchedCategs++;
                        }
                    }

                }
                return ModuleInfo.MainMultiplicator * (recentlySearched * ModuleInfo.getMultiplicatorAt("recentlySearched") + recentlySearchedCategs * ModuleInfo.getMultiplicatorAt("categories"));
                

            }
            return 0;
        
        }
        public override string getDescriptor()
        {
            return "SearchHistory"; 
        }
    }

    public class AdminBonusesModule : ScoreGeneratingModule
    {
        public AdminBonusesModule(/*CurrentUser user*/) : base(/*user*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if(ModuleInfo.Active)
            {
                LinkedList<Bonus> bonuses = dbPackingClass.getBonusFromAdmin(book);
                int sum = 0;
                foreach(Bonus b in bonuses)
                {
                    sum += b.multiplicator;
                }
                return sum * ModuleInfo.MainMultiplicator;
            }
            return 0;
        }
        public override string getDescriptor()
        {
            return "AdminBonuses"; 
        }
    }
    public class NewBooksModule : ScoreGeneratingModule
    {
        public NewBooksModule(/*CurrentUser user*/) : base(/*user*/) { }
        public override int calculateScore(IRecommendationsGetters dbPackingClass, BookWithAuthors book, CurrentUser user)
        {
            if(ModuleInfo.Active)
            {
                return ModuleInfo.MainMultiplicator * dbPackingClass.getNewBooksBonus(book);
            }
            return 0;
        }
        public override string getDescriptor()
        {
            return "NewBooks"; 
        }
    }

}
