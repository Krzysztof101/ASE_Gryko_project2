using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookstorePackage;
using NavigationInterfaces;
using DatabasePackage;

namespace RecommendorsSystem
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 f1 = new Form1();
            DatabasePackagingClass db = DatabasePackagingClass.instance;
            db.initializeAndConnect();
            Bookstore b = Bookstore.initialize(f1,db, db);
            f1.initialize(b);
            Application.Run(f1);
        }
    }
}
