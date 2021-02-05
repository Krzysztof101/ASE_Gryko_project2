using RecommendorsSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendorsSystem;


namespace DatabasePackage
{
    public class DatabasePackagingClass :IDatabaseFunctions, IDisposable, IRecomGenFunctions, IRecommendationsGetters, IRecommendationsComponent
    {
        private static Lazy<DatabasePackagingClass> instanceLazy = new Lazy<DatabasePackagingClass>(() => new DatabasePackagingClass()); 

        private DatabasePackagingClass()
        {
        
        }
        public static DatabasePackagingClass instance { get { return instanceLazy.Value; }  private set { } }


        private string connectionString;
        private SqlConnection cnn;
        private int userID;
        public void initializeAndConnect()
        {
            string computerName = Environment.MachineName;
            connectionString = @"Data Source=" + computerName +
                @"; Initial Catalog=BookstoreASE; User ID=userASE;Password=userASEpswd";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            makeConsoleLog("connection open" );            
            
        }

        public void Dispose()
        {
            cnn.Close();
        }

        public static void makeConsoleLog(string log)
        {
            Console.WriteLine(log);
        }

        public void addCategoryToLiked(string category, CurrentUser user)
        {
            try
            {
                string commandText = "insert into UserLikedCategories (id_user,id_categNaMe) values (@par_user_id,@categ_name);";
                SqlCommand cmd = new SqlCommand(commandText, cnn);
                cmd.Parameters.AddWithValue("@categ_name", category);
                cmd.Parameters.AddWithValue("@par_user_id", user.id);
                int rowAffected = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
        }

        

        public void buyBook(Book book, CurrentUser user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("buyBook", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bookId", book.id);
                cmd.Parameters.AddWithValue("@userId", user.id);
                cmd.Parameters.AddWithValue("@howMany", 1);

                int rowAffected = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
        }
        /*
        public bool checkIfCredentialsAreValid(string login, string password)
        {
            throw new NotImplementedException();
        }
        */
        public void deleteAccount(string login, string password)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Users WHERE UserLogin = '" + login + "' and UserPassword= '" + password+"'", cnn))
                {
                    makeConsoleLog("delete - before query");
                    command.ExecuteNonQuery();
                    makeConsoleLog("delete - after query");
                }
            }
            catch(Exception e)
            {
                makeConsoleLog(e.Message);
            }
        }

        

        public LinkedList<Book> getBoughtBooks(CurrentUser user)
        {
            
            string query = "select distinct b.ID_book, b.Title, b.Price, b.PriceMinusDiscountInProcent from Books b join" +
                " ListOfBoughtBooks L on L.ID_book=b.ID_book join Transactions t on L.id_tran = t.ID_tran" +
                " where t.ID_User=@userID";

            SqlCommand oCmd = new SqlCommand(query, cnn);
            oCmd.Parameters.AddWithValue("@userID", user.id);
            
            LinkedList<Book> result = new LinkedList<Book>();
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Book book = new Book();
                    book.id = oReader.GetInt32(0);
                    book.title = oReader.GetString(1);
                    book.price = (decimal) oReader.GetSqlMoney(2);
                    book.priceMinusDiscountInProcent = (int)oReader.GetSqlInt32(3);

                    result.AddLast(book);
                }
            }
            return result;
        }

        public LinkedList<string> getLikedCategories(CurrentUser user)
        {
            LinkedList<string> likedCategs = new LinkedList<string>();
            string query = "select id_categName from UserLikedCategories where id_user=@loggedUser;";

            SqlCommand oCmd = new SqlCommand(query, cnn);
            oCmd.Parameters.AddWithValue("@loggedUser", user.id);

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    string category = oReader.GetString(0);

                    likedCategs.AddLast(category);
                }
            }
            return likedCategs;

        }

        public LinkedList<Book> getRatedBooks(CurrentUser user)
        {
            LinkedList<Book> result = new LinkedList<Book>();
            string query = "select distinct b.ID_book, b.Title, b.Price, b.PriceMinusDiscountInProcent from Books b join " +
                " UsersBooksRates a on a.ID_book= b.ID_book where a.ID_user=@loggedUser";

            SqlCommand oCmd = new SqlCommand(query, cnn);
            oCmd.Parameters.AddWithValue("@loggedUser", user.id);

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Book book = new Book();
                    book.id = oReader.GetInt32(0);
                    book.title = oReader.GetString(1);
                    book.price = (decimal)oReader.GetSqlMoney(2);
                    book.priceMinusDiscountInProcent = (int)oReader.GetSqlInt32(3);

                    result.AddLast(book);
                }
            }
            return result;
        }

        public LinkedList<Book> getToBuyBooks(CurrentUser user)
        {
            LinkedList<Book> result = new LinkedList<Book>();
            string query = "select distinct b.ID_book, b.Title, b.Price, b.PriceMinusDiscountInProcent from Books b join " +
                " UserBooksToBuy a on a.ID_book= b.ID_book where a.ID_user=@loggedUser";

            SqlCommand oCmd = new SqlCommand(query, cnn);
            oCmd.Parameters.AddWithValue("@loggedUser", user.id);

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Book book = new Book();
                    book.id = oReader.GetInt32(0);
                    book.title = oReader.GetString(1);
                    book.price = (decimal)oReader.GetSqlMoney(2);
                    book.priceMinusDiscountInProcent = (int)oReader.GetSqlInt32(3);

                    result.AddLast(book);
                }
            }
            return result;
        }

        

        public void removeBookfromToBuy(Book book, CurrentUser user)
        {
            string commandText = "delete from UserBooksToBuy where ID_user=@par_user_id and ID_book=@par_book_id;";
            SqlCommand cmd = new SqlCommand(commandText, cnn);
            cmd.Parameters.AddWithValue("@par_book_id", book.id);
            cmd.Parameters.AddWithValue("@par_user_id", user.id);
            int rowAffected = cmd.ExecuteNonQuery();
        }

        public void removeCategoryFromLiked(string category, CurrentUser user)
        {
            string commandText = "delete from UserLikedCategories where id_user=@par_user_id and id_categName=@categ_to_remove";
            SqlCommand cmd = new SqlCommand(commandText, cnn);
            cmd.Parameters.AddWithValue("@categ_to_remove", category);
            cmd.Parameters.AddWithValue("@par_user_id", user.id);
            cmd.ExecuteNonQuery();
        }

        public void saveBookInToBuy(Book book, CurrentUser user)
        {
            string cmdText = "Insert into UserBooksToBuy (ID_user, ID_book) values (@id_user, @id_book)";
            SqlCommand cmd = new SqlCommand(cmdText, cnn);
            cmd.Parameters.AddWithValue("@id_user", user.id);
            cmd.Parameters.AddWithValue("@id_book", book.id);
            cmd.ExecuteNonQuery();

        }

        public void setRate(Book book, CurrentUser user, int rate )
        {
            SqlCommand cmd = new SqlCommand("deleteAndInsertNewRate", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@par_book_id", book.id);
            cmd.Parameters.AddWithValue("@par_user_id", user.id);
            cmd.Parameters.AddWithValue("@par_new_rate", rate);
           
            int rowAffected = cmd.ExecuteNonQuery();
            
        }

        public void unrate(Book book, CurrentUser user)
        {
            String query = "delete from UsersBooksRates where ID_user=@curr_usr and ID_book=@unrated_book_id";

            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.Add("@curr_usr", user.id);
            command.Parameters.Add("@unrated_book_id", book.id);
            command.ExecuteNonQuery();

        }

        public void viewBook(Book book,CurrentUser user)
        {
            String query = "insert into ViewingHistory (ID_user,ID_book, DateOfViewing) values (@curr_usr, @viewed_book, GETDATE())";

            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.Add("@curr_usr", user.id);
            command.Parameters.Add("@viewed_book", book.id);
            command.ExecuteNonQuery();
        }



        public bool checkIfUserExists(string login)
        {
            makeConsoleLog("Attempt to check if login exists");
            string oString = "Select * from Users where UserLogin=@newLogin";
            SqlCommand oCmd = new SqlCommand(oString, cnn);
            oCmd.Parameters.AddWithValue("@newLogin", login);
            bool result = false;

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                if (oReader.Read())
                {
                    result = true;
                }
            }
            string t = result.ToString();
            makeConsoleLog("Attempt to check if login exists - result: "+t);
            return result;
        }

        public bool checkIfNickExists(string nick)
        {
            makeConsoleLog("Attempt to check if nick exists");
            string oString = "Select * from Users where UserNick=@newNick";
            SqlCommand oCmd = new SqlCommand(oString, cnn);
            oCmd.Parameters.AddWithValue("@newNick", nick);
            bool result = false;

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                if (oReader.Read())
                {
                    result = true;
                }
            }
            string t = result.ToString();
            makeConsoleLog("Attempt to check if nick exists - result: "+t);
            return result;
        }
        /*
        public void registerNewUser(string login, string password, string nick)
        {

            
        }
        */
        public void registerNewUser(string login, string password, string nick, CurrentUser user)
        {
            String query = "INSERT INTO Users (UserLogin,UserPassword,UserNick) VALUES (@username,@password, @nick)";

            makeConsoleLog("Attempt to add new user");
            SqlCommand command = new SqlCommand(query, cnn);
            command.Parameters.Add("@username", login);
            command.Parameters.Add("@password", password);
            command.Parameters.Add("@nick", nick);

            command.ExecuteNonQuery();

            int id = getUserID(login);
            if(id!=0)
            {
                user.loginOrRegister(id, login, password, nick);
            }

        }
        public bool tryToLogin(string login, string password, CurrentUser user)
        {
            makeConsoleLog("right before querrying db");
            string oString = "Select * from Users where UserLogin=@usrLogin and UserPassword=@usrPswd";
            SqlCommand oCmd = new SqlCommand(oString, cnn);
            oCmd.Parameters.AddWithValue("@usrLogin", login);
            oCmd.Parameters.AddWithValue("@usrPswd", password);
            bool result = false;

            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                makeConsoleLog("after query1");
                if (oReader.Read())
                {
                    makeConsoleLog("after query2");
                    bool deleted = oReader.GetBoolean(4);
                    makeConsoleLog("deleted: " + deleted.ToString());
                    if (!deleted)
                    {

                        result = true;
                        int id = oReader.GetInt32(0);
                        string usrLog = oReader.GetString(1);
                        string usrPswd = oReader.GetString(2);
                        string usrNick = oReader.GetString(3);
                        user.loginOrRegister(id, usrLog, usrPswd, usrNick);
                        makeConsoleLog("Logged in");
                    }
                    else
                    {
                        result = false;
                        user.logout();
                    }

                }
               
            }
            return result;
        }



        private int getUserID(string login)
        {
            int id = 0;
            string oString = "Select ID from Users where UserLogin=@newLogin";
            SqlCommand oCmd = new SqlCommand(oString, cnn);
            oCmd.Parameters.AddWithValue("@newLogin", login);
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                if (oReader.Read())
                {
                    id = oReader.GetInt32(1);
                }
            }
            return id;
        }

        public int getBookRate(Book currentBook, CurrentUser user)
        {
            int bookRate = 0;
            string oString = "Select Rate from UsersBooksRates ubr join  Books b on b.ID_book = ubr.ID_book join Users u on u.ID=ubr.ID_user where u.ID=@currUsrID and b.ID_book=@currBook";
            SqlCommand oCmd = new SqlCommand(oString, cnn);
            oCmd.Parameters.AddWithValue("@currUsrID", user.id);
            oCmd.Parameters.AddWithValue("@currBook", currentBook.id);
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                if (oReader.Read())
                {
                    bookRate = oReader.GetInt32(0);
                }
            }
            return bookRate;

        }

        public LinkedList<string> getAllCategories()
        {
            LinkedList<string> allCategories = new LinkedList<string>();
            string command = "select CategName from Categories";
            SqlCommand oCmd = new SqlCommand(command, cnn);
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    string category = oReader.GetString(0);
                    allCategories.AddLast(category);
                }
            }
            return allCategories;

        }

        private LinkedList<Book> getBooksUsingQueryID(int queryID)
        {
            string commandText = "select * from getNumberSearchByTitleResults(" + queryID.ToString() + ")";
            SqlCommand command = new SqlCommand(commandText, cnn);
            command.CommandType = CommandType.Text;
            LinkedList<Book> books = new LinkedList<Book>();

            using (SqlDataReader oReader = command.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Book book = new Book();
                    book.id = oReader.GetInt32(0);
                    book.title = oReader.GetString(1);
                    book.price = (decimal)oReader.GetSqlMoney(2);
                    book.priceMinusDiscountInProcent = (int)oReader.GetSqlInt32(3);
                    //var listOfBookAuthors = getBookAuthors(book);
                    //book.Authors = listOfBookAuthors;
                    books.AddLast(book);
                }
            }
            LinkedList<Book> listBooksAuthors =  getBooksWithAuthors(books);



            return listBooksAuthors;
        }
        private LinkedList<Book> getBooksWithAuthors(LinkedList<Book> books)
        {
            LinkedList<Book> listOfBooksWithAuthors = new LinkedList<Book>();
            foreach (Book book in books)
            {
                int bookID = book.id;
                string commandText2 = "select AuthorName, AuthorLastName, Authors.id_author from Authors join AuthorsList on Authors.id_author = AuthorsList.id_author where AuthorsList.id_book=@book_id ";
                SqlCommand command2 = new SqlCommand(commandText2, cnn);
                command2.Parameters.AddWithValue("@book_id", bookID);
                command2.CommandType = CommandType.Text;
                LinkedList<Author> authors = new LinkedList<Author>();
                using (SqlDataReader oReader = command2.ExecuteReader())
                {

                    while (oReader.Read())
                    {
                        string authName = oReader.GetString(0);
                        string authLastName = oReader.GetString(1);
                        int id = oReader.GetInt32(2);
                        authors.AddLast(new Author(authName, authLastName,id));

                    }
                }
                BookWithAuthors bookAuthors = new BookWithAuthors(book, authors);
                listOfBooksWithAuthors.AddLast(bookAuthors);

            }

            return listOfBooksWithAuthors;
        }
        
        public LinkedList<Book> findBooksByTitle(string title, CurrentUser user)
        {
            title = title.Trim(' ');
            if (title == "")
            {
                return new LinkedList<Book>();
            }

            int queryID = getQueryIdFromFindByTitleStoredProcedure(title, user);

            if(queryID==0)
            {
                //queryID = 0 ----- query didn't find any books
                return new LinkedList<Book>();
            }

            LinkedList<Book> booksWithAuthors = getBooksUsingQueryID(queryID);

            foreach (Book book in booksWithAuthors)
            {
                var listOfAuthors = getBookAuthors(book);
                (book as BookWithAuthors).Authors = listOfAuthors;

            }



            /*
            
            string query = "select ID_book, Title, Price, PriceMinusDiscountInProcent from Books where Title like '%" + title +"%'";
            SqlCommand oCmd = new SqlCommand(query, cnn);
            oCmd.Parameters.AddWithValue("@par_title", title);
           
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    BookWithAuthors book = new BookWithAuthors();
                    book.id = oReader.GetInt32(0);
                    book.title = oReader.GetString(1);
                    book.price = (decimal)oReader.GetSqlMoney(2);
                    book.priceMinusDiscountInProcent = (int)oReader.GetSqlInt32(3);
                    //var listOfBookAuthors = getBookAuthors(book);
                    //book.Authors = listOfBookAuthors;
                    booksWithAuthors.AddLast(book);
                }
            }
            foreach (Book book in booksWithAuthors)
            {
                var listOfAuthors = getBookAuthors(book);
                (book as BookWithAuthors).Authors = listOfAuthors;

            }
            */
            return booksWithAuthors;
        }
        private int getQueryIdFromFindByTitleStoredProcedure(string title, CurrentUser user)
        {
            SqlCommand cmd = new SqlCommand("writeQueryResultsAndGetItsID", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@searchPhrase", title);
            cmd.Parameters.AddWithValue("@userID", user.id);
            
            var returnParameter = new SqlParameter("@query_id", SqlDbType.Int);  
            returnParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnParameter);
            cmd.ExecuteNonQuery();
            var queryIDSQL = returnParameter.Value;
            Console.WriteLine("queryIDSQL: " + queryIDSQL.ToString());
            //int queryID = (int)cmd.Parameters["@query_id"].Value;
            int queryID = Convert.ToInt32(cmd.Parameters["@query_id"].Value);
            return queryID;
        }

        private LinkedList<Author> getBookAuthors(Book book)
        {
            int id = book.id;
            string query = "select a.AuthorName, a.AuthorLastName, a.id_author from Authors a join AuthorsList al on a.id_author=al.id_author where al.id_book = @par_id_book;";
            SqlCommand oCmd = new SqlCommand(query, cnn);
            oCmd.Parameters.AddWithValue("@par_id_book", id);
            LinkedList<Author> authors = new LinkedList<Author>();
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {

                while (oReader.Read())
                {
                    string name = oReader.GetString(0);
                    string lastName = oReader.GetString(1);
                    int id2 = oReader.GetInt32(2);
                    Author author = new Author(name, lastName,id2);
                    authors.AddLast(author);
                }
            }
            return authors;
        }
        private int getQueryIdFromFindByAuthorsStoredProcedure(string authors, CurrentUser user)
        {
            SqlCommand cmd = new SqlCommand("writeAuthorQueryResultsAndGetItsID", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@searchPhrase", authors);
            cmd.Parameters.AddWithValue("@userID", user.id);
            var returnParameter = new SqlParameter("@query_id", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnParameter);


            cmd.ExecuteNonQuery();
            //var queryIDSQL = returnParameter.Value;
           // Console.WriteLine("queryIDSQL: " + queryIDSQL.ToString());
            //int queryID = (int)cmd.Parameters["@query_id"].Value;
            int queryID = Convert.ToInt32(cmd.Parameters["@query_id"].Value);
            //Console.WriteLine("queryIDSQL: " + queryID.ToString());
            return queryID;

        }

        

        public LinkedList<Book> findBooksByAuthor(string authors, CurrentUser user)
        {
            if(authors=="")
            {
                return new LinkedList<Book>();
            }
            int queryID = getQueryIdFromFindByAuthorsStoredProcedure(authors, user);
            if(queryID==0)
            {
                return new LinkedList<Book>();
            }
            LinkedList<Book> booksWithAuthors = getBooksUsingQueryID(queryID);
            foreach (Book book in booksWithAuthors)
            {
                var listOfAuthors = getBookAuthors(book);
                (book as BookWithAuthors).Authors = listOfAuthors;

            }
            return booksWithAuthors;

            /*
            string[] authorsArray = new string[authors.Count];
            int i = 0;
            foreach(Author a in authors)
            {
                authorsArray[i++] = a.LastName;    
            }
            string condition = buildCondition(authorsArray);
            string commandText = "select b.ID_book, b.Title, b.Price, b.PriceMinusDiscountInProcent " +
                " from books b join AuthorsList al on b.ID_book = al.id_book join Authors a on a.id_author=al.id_author where a.AuthorLastName in (" +condition+")";
            SqlCommand oCmd = new SqlCommand(commandText, cnn);
            LinkedList<Book> list = new LinkedList<Book>();
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    int id = oReader.GetInt32(0);
                    string title = oReader.GetString(1);
                    decimal price = (decimal)oReader.GetSqlMoney(2);
                    int priceMinusDiscountInProcent = oReader.GetInt32(3);
                    BookWithAuthors book = new BookWithAuthors();
                    book.id = id;
                    book.title = title;
                    book.price = price;
                    book.priceMinusDiscountInProcent = priceMinusDiscountInProcent;
                    //book.Authors = getBookAuthors(book);
                    list.AddLast(book);
                }
            }
            foreach(Book book in list)
            {
                var authors2 = getBookAuthors(book);
                (book as BookWithAuthors).Authors = authors2;

            }

            return list;
            */


        }


        private string buildCondition(string[] authorsArray)
        {
            StringBuilder iNcondition = new StringBuilder();
            for(int i =0; i< authorsArray.Length; i++)
            {
                iNcondition.Append("'" + authorsArray[i] + "'");
                if (i < authorsArray.Length - 1)
                    iNcondition.Append(",");
            }
            return iNcondition.ToString();
        }

        public void saveInfoAboutRecommendation(Book book, CurrentUser user)
        {
            throw new NotImplementedException();
        }

        public LinkedList<Book> getAllBookWithAuthors(CurrentUser user)
        {
            LinkedList<Book> books = new LinkedList<Book>();
            SqlCommand command1 = new SqlCommand("Select * from Books", cnn);
            command1.CommandType = CommandType.Text;
            
            using (SqlDataReader oReader = command1.ExecuteReader())
            {

                while (oReader.Read())
                {
                    int id = oReader.GetInt32(0);
                    string title = oReader.GetString(1);
                    decimal price = (decimal)oReader.GetSqlMoney(2);
                    int priceMinusDiscountInProcent = oReader.GetInt32(3);
                    Book b = new Book();
                    b.id = id;
                    b.title = title;
                    b.price = price;
                    b.priceMinusDiscountInProcent = priceMinusDiscountInProcent;
                    books.AddLast(b);
                     
                }
            }
            return getBooksWithAuthors(books);

        }

        public ScoreModuleInfo fetchMultiplicatorsData(string descriptor)
        {
            string commandText = "select * from RecommendationsModules where descriptor='" + descriptor+"'";

            SqlCommand command1 = new SqlCommand(commandText, cnn);
            command1.CommandType = CommandType.Text;
            int mainMultiplicator=0;
            string desc = "";
            string active = "";


            using (SqlDataReader oReader = command1.ExecuteReader())
            {

                if (oReader.Read())
                {
                    desc = oReader.GetString(0);
                    active = oReader.GetString(1);
                    mainMultiplicator = oReader.GetInt32(2);
                    
                }
            }

            string commandText2 = " select moduleDescriptor, descriptor, multpicator from subRecommendators where moduleDescriptor='" + desc+"'";
            SqlCommand command2 = new SqlCommand(commandText2, cnn);
            command2.CommandType = CommandType.Text;
            LinkedList<int> vals = new LinkedList<int>();
            LinkedList<string> descs = new LinkedList<string>();
            using (SqlDataReader oReader = command1.ExecuteReader())
            {

                while(oReader.Read())
                {
                    string desc2 = oReader.GetString(1);
                    int multip = oReader.GetInt32(2);
                    vals.AddLast(multip);
                    descs.AddLast(desc2);
                }
            }
            bool b = true;
            if(active.ToLower() !="y")
            {
                b = false;
            }
            return new ScoreModuleInfo(mainMultiplicator, desc, descs, vals,b);

        }

        public LinkedList<string> getBookCategories(Book book)
        {
            string commandText2 = "select categName from Categories join Bookcategories on CategName=categoryName where id_book=@book_id ";
            SqlCommand command2 = new SqlCommand(commandText2, cnn);
            command2.Parameters.AddWithValue("@book_id", book.id);
            command2.CommandType = CommandType.Text;
            LinkedList<string> categories = new LinkedList<string>();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                while (oReader.Read())
                {
                    string category = oReader.GetString(0);
                    categories.AddLast(category);

                }
            }
            return categories;
        }

        public int getNoOfSimilarBooksViewedWithinHalfAnHour(Book book, CurrentUser user)
        {
            SqlCommand cmd = new SqlCommand("viewsWithinMinutes", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@argUserID", user.id);
            cmd.Parameters.AddWithValue("@argBookID", book.id);
            cmd.Parameters.AddWithValue("@time", 30);

            var returnParameter = new SqlParameter("@count", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(returnParameter);
            cmd.ExecuteNonQuery();
            var countSQL = returnParameter.Value;
            int count = Convert.ToInt32(cmd.Parameters["@count"].Value);


            return count;

        }

        LinkedList<Author> IRecommendationsGetters.getBookAuthors(Book book)
        {
            string commandText = "select AuthorName, AuthorLastName, id_author from Authors join AuthorsList on Authors.id_author = AuthorsList.id_author where id_book=@book_id";

            SqlCommand command2 = new SqlCommand(commandText, cnn);
            command2.Parameters.AddWithValue("@book_id", book.id);
            command2.CommandType = CommandType.Text;
            LinkedList<Author> authors = new LinkedList<Author>();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                while (oReader.Read())
                {
                    string name = oReader.GetString(0);
                    string lastName = oReader.GetString(1);
                    int id = oReader.GetInt32(2);
                    Author a = new Author(name, lastName, id);
                    authors.AddLast(a);
                }
            }
            return authors;
        }

        public LinkedList<Bonus> getBonusFromAdmin(BookWithAuthors book)
        {
            string commandText = "select multiplicator, bonusPeriodStart, bonusPeriodEnd, id_bonus from bonuses where id_book =@book_id and bonusPeriodStart <= GETDATE() and bonusPeriodEnd >= GETDATE()";

            SqlCommand command2 = new SqlCommand(commandText, cnn);
            command2.Parameters.AddWithValue("@book_id", book.id);
            command2.CommandType = CommandType.Text;
            LinkedList<Bonus> bonuses = new LinkedList<Bonus>();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                while (oReader.Read())
                {
                    int multiplicator = oReader.GetInt32(0);
                    DateTime begin = oReader.GetDateTime(1);
                    DateTime end = oReader.GetDateTime(2);
                    int id = oReader.GetInt32(3);
                    Bonus b = new Bonus();
                    b.multiplicator = multiplicator;
                    b.begin = begin;
                    b.end = end;
                    b.bonus_id = id;
                    bonuses.AddLast(b);
                }
            }
            return bonuses;
        }

        public int getNewBooksBonus(BookWithAuthors book)
        {
            
            string commandText = "select 1 from books where DATEDIFF(day, start_selling_date, getdate()) <=@timeWhenBookNew and id_book=@book_id;";
            SqlCommand command2 = new SqlCommand(commandText, cnn);
            command2.Parameters.AddWithValue("@book_id", book.id);
            command2.Parameters.AddWithValue("@timeWhenBookNew", 60);
            command2.CommandType = CommandType.Text;
            LinkedList<Bonus> bonuses = new LinkedList<Bonus>();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                if(oReader.Read())
                {
                    return 1;
                }
            }
            return 0;
        }

        public LinkedList<UserRatesInfoSet> getAllRowsInRates()
        {
            string commandText = "select ID_user, ID_book, Rate from UsersBooksRates;";
            SqlCommand command2 = new SqlCommand(commandText, cnn);
            command2.CommandType = CommandType.Text;
            LinkedList<UserRatesInfoSet> rates = new LinkedList<UserRatesInfoSet>();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                while (oReader.Read())
                {
                    int id_user = oReader.GetInt32(0);
                    int id_book = oReader.GetInt32(1);
                    int rate = oReader.GetInt32(2);
                    UserRatesInfoSet uris = new UserRatesInfoSet(id_book, id_user, rate);
                    rates.AddLast(uris);
                }
            }
            return rates;
        }

        public LinkedList<BookWithAuthors> getBooksWithAuthorsSearchedWithin05hour(CurrentUser user)
        {
            string commandText = "select books.ID_book, title, price, priceMinusDiscountInProcent from books join SearchResHist on books.ID_book =  SearchResHist.ID_book where id_user=@userId and DATEDIFF(MINUTE, dateOfSearch, getDate())<=@minutes";
            SqlCommand command2 = new SqlCommand(commandText, cnn);
            command2.Parameters.AddWithValue("@userId", user.id);
            command2.Parameters.AddWithValue("@minutes", 120);
            command2.CommandType = CommandType.Text;
            LinkedList<BookWithAuthors> recentlySearchedBooks = new LinkedList<BookWithAuthors>();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                while (oReader.Read())
                {
                    int book_id = oReader.GetInt32(0);
                    string title = oReader.GetString(1);
                    decimal price = (decimal)(oReader.GetSqlMoney(2));
                    int priceMinusdiscount = oReader.GetInt32(3);

                    Book b = new Book();
                    b.id = book_id;
                    b.title = title;
                    b.price = price;
                    b.priceMinusDiscountInProcent = priceMinusdiscount;
                    BookWithAuthors book = new BookWithAuthors(b, new LinkedList<Author>());
                    recentlySearchedBooks.AddLast(book);
                }
            }
            return recentlySearchedBooks;


        }

        public LinkedList<Book> getBooksRecommendedWithin05h(CurrentUser user)
        {
            string commandText = "select books.ID_book, title, price, priceMinusDiscountInProcent from books join UserBooksRecommendations on books.ID_book =  UserBooksRecommendations.ID_book where id_user=@userId and DATEDIFF(MINUTE, DateOfRecommendating, getDate())<=@minutes";
            SqlCommand command2 = new SqlCommand(commandText, cnn);
            command2.Parameters.AddWithValue("@userId", user.id);
            command2.Parameters.AddWithValue("@minutes", 120);
            command2.CommandType = CommandType.Text;
            LinkedList<Book> recentlyRecommendedBooks = new LinkedList<Book>();
            using (SqlDataReader oReader = command2.ExecuteReader())
            {

                while (oReader.Read())
                {
                    int book_id = oReader.GetInt32(0);
                    string title = oReader.GetString(1);
                    decimal price = (decimal)(oReader.GetSqlMoney(2));
                    int priceMinusdiscount = oReader.GetInt32(3);

                    Book b = new Book();
                    b.id = book_id;
                    b.title = title;
                    b.price = price;
                    b.priceMinusDiscountInProcent = priceMinusdiscount;
                    recentlyRecommendedBooks.AddLast(b);
                }
            }
            return recentlyRecommendedBooks;
        }
        /*
LinkedList<Author> IRecomGenFunctions.getBookAuthors(Book book)
{
throw new NotImplementedException();
}
*/
    }

    
}
