using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem 
{
    public class RecommendationsGenerator 
    {

        public RecommendationsGenerator(IRecommendationsComponent recFuns, LinkedList<ScoreGeneratingModule> modules )
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



        public LinkedList<BookWithAuthorsAndScore> generateRecommendations(CurrentUser user)
        {
            LinkedList<Book> AllBooksWithAuthors = recommendationsFunctions.getAllBookWithAuthors(user);
            BookWithAuthorsAndScore[] booksWithAuthoresAndScore = new BookWithAuthorsAndScore[AllBooksWithAuthors.Count];
            int i = 0;
            foreach(Book book in AllBooksWithAuthors)
            {
                BookWithAuthorsAndScore bookAuScr = new BookWithAuthorsAndScore(book as BookWithAuthors);
                bookAuScr.Score = calculateScoreForBook(book as BookWithAuthors, user);
                booksWithAuthoresAndScore[i++] = bookAuScr;
            }
            return buildScoreSortedBooksList(booksWithAuthoresAndScore);
        }

        private LinkedList<BookWithAuthorsAndScore> buildScoreSortedBooksList(BookWithAuthorsAndScore[] booksWithAuthoresAndScore)
        {
            int smallest = int.MaxValue;
            int idx = -1;
            LinkedList<BookWithAuthorsAndScore> sortdList = new LinkedList<BookWithAuthorsAndScore>();
            for(int i =0; i< booksWithAuthoresAndScore.Length; i++)
            {
                for(int j=0;j<booksWithAuthoresAndScore.Length;j++)
                {
                    if(booksWithAuthoresAndScore[j].Score<=smallest)
                    {
                        smallest = booksWithAuthoresAndScore[j].Score;
                        idx = j;
                    }
                    if(j!=-1)
                    sortdList.AddFirst(booksWithAuthoresAndScore[j]);
                }

            }
            return sortdList;
        }

        private int calculateScoreForBook(BookWithAuthors bookWithAuthors, CurrentUser user)
        {
            
            int score = 0;
            foreach(ScoreGeneratingModule s in scoreModules)
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
