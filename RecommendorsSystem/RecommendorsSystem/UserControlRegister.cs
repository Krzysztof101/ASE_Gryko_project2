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
    public partial class UserControlRegister : UserControl
    {
        IRegisterFunctions iRegFunctions;
        INavRegister iNavRegister;
        public UserControlRegister(IRegisterFunctions iregfuns, INavRegister inavreg)
        {
            InitializeComponent();
            iNavRegister = inavreg;
            iRegFunctions = iregfuns;
            textBoxPassword1.PasswordChar = '*';
            textBoxPassword2.PasswordChar = '*';
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            iNavRegister.goToLogin();
        }
        private void clearTextBoxes()
        {
            textBoxNick.Text = "";
            textBoxUser.Text = "";
            textBoxPassword1.Text = "";
            textBoxPassword2.Text = "";
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string user = textBoxUser.Text;
            string pswd1 = textBoxPassword1.Text;
            string pswd2 = textBoxPassword2.Text;
            string nick = textBoxNick.Text;
            if (iRegFunctions.checkIfCredentialsValid(user,pswd1,pswd2, nick))
            {
                iRegFunctions.registerNewUser(user, pswd1, nick);
                iNavRegister.goToEditCategories();
            }
            else
            {
                string msg = iRegFunctions.getMessage();
                MsgBoxUtils.showMsgBox("Register", msg);
            }
        }
        /*
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControlRegister
            // 
            this.Name = "UserControlRegister";
            this.ResumeLayout(false);

        }
        */
    }
}
