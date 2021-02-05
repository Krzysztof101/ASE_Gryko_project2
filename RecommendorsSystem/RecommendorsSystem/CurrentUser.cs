using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public class CurrentUser
    {
        public int id { get; private set; }
        public string login { get; private set; }
        public string password { get; private set; }
        public string nick { get; private set; }
        public void loginOrRegister(int id, string login, string password, string nick)
        {
            this.id = id;
            this.password = password;
            this.login = login;
            this.nick = nick;
        }
        public void logout()
        {
            id = 0;
            login = "";
            password = "";
            nick = "";
        }
        public CurrentUser()
        {
            id = 0;
            login = "";
            password = "";
            nick = "";
        }
    }
}
