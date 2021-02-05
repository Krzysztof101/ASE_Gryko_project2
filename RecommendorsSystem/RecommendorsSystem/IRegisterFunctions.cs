using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public interface IRegisterFunctions
    {
        bool checkIfCredentialsValid(string login, string password1, string password2,string nick);
        string getMessage();
        void registerNewUser(string user, string password, string nick);
        
    }
}
