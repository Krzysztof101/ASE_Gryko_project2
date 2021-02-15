using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IAccountSearchSharedFunctions
    {

        string buyBook(BookGeneralData bookToBuy, int quantity);
        void setBookRate(BookGeneralData bookToRate, int rate);
        int getBookRate(BookGeneralData book);
        void unrateBook(BookGeneralData bookToUnrate);
        string operationSuccesful();
    }
   
}
