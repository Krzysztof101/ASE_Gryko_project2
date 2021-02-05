using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NavigationInterfaces;

namespace RecommendorsSystem
{
    public partial class UserControlLogin : UserControl
    {
        INavLogin loginNavigation;
        ILoginFunctions loginFunctions;
        public UserControlLogin( ILoginFunctions functionsLogin, INavLogin navLogin )
        {
            
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            loginFunctions = functionsLogin;
            loginNavigation = navLogin;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            loginNavigation.goToRegister();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string loginText = textBoxUser.Text;
            string passwordText = textBoxPassword.Text;
            if(loginText.Length==0 || passwordText.Length==0)
            {
                MsgBoxUtils.showMsgBox("Login", "Login and password cannot be empty.");
                return;
            }
            if(loginFunctions.tryToLogin(loginText,passwordText))
            {
                textBoxUser.Text = "";
                textBoxPassword.Text = "";
                loginNavigation.goToAccount();
            }
            else
            {
                MsgBoxUtils.showMsgBox("Login", "Incorrect login or password.");
            }
            
        }
    }
}
