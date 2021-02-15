using System.Collections.Generic;

namespace RecommendorsSystem
{
    public class RecommendationsGenerator
    {
        public static LinkedList<ScoreGeneratingModule> listOfModules()
        {
            LinkedList<ScoreGeneratingModule> scoreModules = new LinkedList<ScoreGeneratingModule>();
            scoreModules.AddLast(new SearchHistoryScoreModule(/*user*/));
            scoreModules.AddLast(new ViewingHistoryModule(/*user*/));
            scoreModules.AddLast(new LikedCategoriesModule(/*user*/));
            scoreModules.AddLast(new RatesModule(/*user*/));
            scoreModules.AddLast(new LatestRecommendationsModule(/*user*/));
            scoreModules.AddLast(new AdminBonusesModule(/*user*/));
            scoreModules.AddLast(new NewBooksModule(/*user*/));
            scoreModules.AddLast(new BoughtBooksModule(/*user*/));
            scoreModules.AddLast(new BooksToBuyModule(/*user*/));
            return scoreModules;
        }
        public RecommendationsGenerator(IRecommendationsComponent recFuns) :this(recFuns, listOfModules() )
        {
        }

        public RecommendationsGenerator(IRecommendationsComponent recFuns, LinkedList<ScoreGeneratingModule> modules)
        {
            recommendationsFunctions = recFuns;
            //this.user = user;
            //scoreModules = new LinkedList<ScoreGeneratingModule>();
            scoreModules = modules;
            //fillScoreModulesList();

        }

        private void fillScoreModulesList(CurrentUser user)
        {
            scoreModules.AddLast(new SearchHistoryScoreModule(/*user*/));
            scoreModules.AddLast(new ViewingHistoryModule(/*user*/));
            scoreModules.AddLast(new LikedCategoriesModule(/*user*/));
            scoreModules.AddLast(new RatesModule(/*user*/));
            scoreModules.AddLast(new LatestRecommendationsModule(/*user*/));
            scoreModules.AddLast(new AdminBonusesModule(/*user*/));
            scoreModules.AddLast(new NewBooksModule(/*user*/));
            scoreModules.AddLast(new BoughtBooksModule(/*user*/));
            scoreModules.AddLast(new BooksToBuyModule(/*user*/));
        }

        private IRecommendationsComponent recommendationsFunctions;
        private LinkedList<ScoreGeneratingModule> scoreModules;
        //public CurrentUser user { get; private set; }



        public LinkedList<BookWithCategoriesAuthorsAndScore> generateRecommendations(CurrentUser user)
        {
            LinkedList<BookWithAuthorsAndCategories> AllBooksWithAuthors = recommendationsFunctions.getAllBookWithAuthors(user);
            BookWithCategoriesAuthorsAndScore[] booksWithAuthoresAndScore = new BookWithCategoriesAuthorsAndScore[AllBooksWithAuthors.Count];
            int i = 0;
            foreach (Book book in AllBooksWithAuthors)
            {
                //BookWithAuthorsAndScore bookAuScr = new BookWithAuthorsAndScore(book as BookWithAuthors);
                BookWithCategoriesAuthorsAndScore bookAuScr = new Book(book);
                bookAuScr.Score = calculateScoreForBook(book, user);
                booksWithAuthoresAndScore[i++] = bookAuScr;
            }
            return buildScoreSortedBooksList(booksWithAuthoresAndScore);
        }

        private LinkedList<BookWithCategoriesAuthorsAndScore> buildScoreSortedBooksList(BookWithCategoriesAuthorsAndScore[] booksWithAuthoresAndScore)
        {
            /*
            int smallest = int.MaxValue;
            int idx = -1;
            LinkedList<BookWithAuthorsAndScore> sortdList = new LinkedList<BookWithAuthorsAndScore>();
            for (int i = 0; i < booksWithAuthoresAndScore.Length; i++)
            {

                for (int j = 0; j < booksWithAuthoresAndScore.Length; j++)
                {
                    if (booksWithAuthoresAndScore[j].Score <= smallest)
                    {
                        smallest = booksWithAuthoresAndScore[j].Score;
                        idx = j;
                    }
                    
                }
                if (idx != -1)
                    sortdList.AddFirst(booksWithAuthoresAndScore[idx]);

                idx = -1;

            }
            return sortdList;
            */
            QuickSort(booksWithAuthoresAndScore, 0, booksWithAuthoresAndScore.Length - 1);
            LinkedList<BookWithCategoriesAuthorsAndScore> sortdList = new LinkedList<BookWithCategoriesAuthorsAndScore>();
            foreach(BookWithCategoriesAuthorsAndScore b in booksWithAuthoresAndScore)
            {
                sortdList.AddLast(b);
            }
            return sortdList;

        }

        void QuickSort(BookWithCategoriesAuthorsAndScore[] booksWithAuthoresAndScore, int left, int right) 
        {
            int i = left;
            int j = right;
            BookWithCategoriesAuthorsAndScore x;

            x = booksWithAuthoresAndScore[(left + right) >> 1];
            do
            {
                while (booksWithAuthoresAndScore[i].Score < x.Score) i++; //items[i] < x
                while (booksWithAuthoresAndScore[j].Score > x.Score) j--; //items[j] > x

                if (i <= j)
                {
                    Swap(booksWithAuthoresAndScore, i, j);
                    i++; j--;
                }
            }
            while (i < j);

            if (left < j) QuickSort(booksWithAuthoresAndScore, left, j);
            if (right > i) QuickSort(booksWithAuthoresAndScore, i, right);
        }

        void Swap(BookWithCategoriesAuthorsAndScore[] list, int left, int right)
        {
            BookWithCategoriesAuthorsAndScore temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }




        private int calculateScoreForBook(BookWithAuthorsAndCategories bookWithAuthors, CurrentUser user)
        {

            int score = 0;
            foreach (ScoreGeneratingModule s in scoreModules)
            {
                string descriptor = s.getDescriptor();
                ScoreModuleInfo mInfo = recommendationsFunctions.fetchMultiplicatorsData(descriptor);
                s.ModuleInfo = mInfo;
                score += s.calculateScore(recommendationsFunctions, bookWithAuthors, user);
            }
            return score;
        }
    }
}
