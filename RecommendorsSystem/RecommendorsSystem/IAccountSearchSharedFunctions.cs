using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IAccountSearchSharedFunctions
    {

        void buyBook(BookGeneralData bookToBuy);
        void setBookRate(BookGeneralData bookToRate, int rate);
        int getBookRate(BookGeneralData book);
        void unrateBook(BookGeneralData bookToUnrate);

    }
}
