using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecommendorsSystem
{
    public class MsgBoxUtils
    {
        public static void showMsgBox(string title, string text)
        {
            MessageBox.Show(text, title);
        }
    }
}
