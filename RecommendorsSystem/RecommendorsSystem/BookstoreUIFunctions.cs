using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstorePackage;

namespace RecommendorsSystem
{
    public class BookstoreUIFunctions : IAccountFunctions, IEditCategoriesFunctions, ILoginFunctions, 
        IRegisterFunctions, ISearchPanelFunctions, IShowCategoriesFunctions 
    {
        private Bookstore bookstore;
        private string registerMessage;

        public BookstoreUIFunctions(Bookstore b)
        {
            bookstore = b;
            registerMessage = "";
        }
        public void addCategoryToLikedcategories(string newLikedCategory)
        {
            bookstore.databaseFunctions.addCategoryToLiked(newLikedCategory, bookstore.User);
        }

        public LinkedList<BookWithAuthorsAndScore> askForRecommendations()
        {
            return bookstore.recommendationsGenerator.generateRecommendations(bookstore.User);
        }

        public void buyBook(Book bookToBuy)
        {
            bookstore.databaseFunctions.buyBook(bookToBuy, bookstore.User);
        }

        public bool checkIfCredentialsValid(string login, string password1, string password2, string nick)
        {
            string checkResult = checkCredentials(login, password1, password2, nick);
            string allGood = "";
            if(checkResult==allGood)
            {
                bool nickNotTaken = true, loginNotTaken = true;
                if(!bookstore.checkIfUserDoesntExist(login) )
                {
                    loginNotTaken = false;
                }
                if(!bookstore.checkIfNickDoesntExist(nick) )
                {
                    nickNotTaken = false;
                }
                if(nickNotTaken && loginNotTaken)
                {

                    return true;
                }
                if(!nickNotTaken && !loginNotTaken)
                {
                    checkResult = "Both nick and login already exist";
                }
                else if(!nickNotTaken)
                {
                    checkResult = "Nick already exist";
                }
                else
                {
                    checkResult = "Login already exist";
                }
            }
            registerMessage = checkResult;
            return false;
        }

        public void deleteAccount(string userPassword)
        {
            string pswd = bookstore.User.password;
            string login = bookstore.User.login;
            bookstore.User.logout();
            bookstore.databaseFunctions.deleteAccount(login,pswd);
        }
        /*
        public void eraseBookRate(Book bookToUnrate)
        {
            
        }
        */
        /*
        public void rateBook(int rate, Book bookToRate)
        {
            
        }
        */

        public int getBookRate(Book currentBook)
        {
            return bookstore.databaseFunctions.getBookRate(currentBook, bookstore.User);
        }



        public LinkedList<string> getAllCategories()
        {
            return bookstore.databaseFunctions.getAllCategories();
        }

        public LinkedList<Book> getBoughtBooks()
        {
            return bookstore.databaseFunctions.getBoughtBooks(bookstore.User);
        }

        public LinkedList<string> getLikedCategories()
        {
            return bookstore.databaseFunctions.getLikedCategories(bookstore.User);
        }

        public string getMessage()
        {
            return registerMessage;
        }

        public LinkedList<Book> getRatedBooks()
        {
            return bookstore.databaseFunctions.getRatedBooks(bookstore.User);
        }

        public LinkedList<Book> getToBuyBooks()
        {
            return bookstore.databaseFunctions.getToBuyBooks(bookstore.User);
        }
        /*
        public void goToAccount()
        {
            throw new NotImplementedException();
        }
        */
        public void logoutAndGoToLogin()
        {
            throw new NotImplementedException();
        }

        public bool passwordCorrect(string password)
        {
            throw new NotImplementedException();
        }

        



        public void registerNewUser(string login, string password, string nick)
        {
            bookstore.registerUser(login, password, nick);
        }

        public bool tryToLogin(string login, string password)
        {
            return bookstore.tryToLogin(login, password);
        }



        public void removeBookFromToBuy(Book bookToRemoveFromToBuy)
        {
            bookstore.databaseFunctions.removeBookfromToBuy(bookToRemoveFromToBuy, bookstore.User);
        }

        public void removeCategoryFromLikedCategories(string categoryToRemove)
        {
            bookstore.databaseFunctions.removeCategoryFromLiked(categoryToRemove,bookstore.User);
        }

        public void saveBookInToBuy(Book bookToBeBoughtInFuture)
        {
            bookstore.databaseFunctions.saveBookInToBuy(bookToBeBoughtInFuture, bookstore.User);
        }

        public LinkedList<Book> searchByAuthor(string searchPhrase)
        {
            string onlyLettersPhrase = getRidOfNoise(searchPhrase);
            /*
            var wordsSeparated = separateWords(searchPhrase);
            LinkedList<Author> authors = new LinkedList<Author>();
            int i = 0;
            while(i<wordsSeparated.Length   )
            {
                string name =anyString();
                string lastname = wordsSeparated[i++];
                authors.AddLast(new Author(name, lastname));
            }
            */

            return bookstore.databaseFunctions.findBooksByAuthor(onlyLettersPhrase, bookstore.User);
        }
        private string anyString() { return "%"; }
        private string getRidOfNoise(string searchPhrase)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string allowedCharacters = " ZXCVBNMASDFGHJKLQWERTYUIOPzxcvbnmasdfghjklqwertyuiopżźćńąłęóŻŹĆŃĄŁĘÓ";
            foreach(char c in searchPhrase)
            {
                if( allowedCharacters.Contains(c))
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    stringBuilder.Append(' ');
                }
            }
            return stringBuilder.ToString();
        }


        private String[] separateWords(string words)
        {
            return words.Split(' ');
            /*
            words += " ";
            LinkedList<string> wordsList = new LinkedList<string>();
            int spacePos1 = 0;
            int spacePos2 = 0;
            try
            {
                

                while (spacePos1!=words.Length)
                {
                    spacePos2 = words.IndexOf(' ', spacePos1 + 1);
                    string word = words.Substring(spacePos1, spacePos2 - spacePos1);
                    if (!word.Contains(' '))
                        wordsList.AddLast(word);

                    spacePos1 = spacePos2 +1;

                }
                
            }
            catch (ArgumentOutOfRangeException e)
            {

            }
            return wordsList;
            */
        }

        public LinkedList<Book> searchByTitle(string title)
        {
            return bookstore.databaseFunctions.findBooksByTitle(title, bookstore.User);
        }

        public void setBookRate(Book ratedBook, int rate)
        {
            bookstore.databaseFunctions.setRate(ratedBook,bookstore.User, rate);
        }

        public void showRated()
        {
            throw new NotImplementedException();
        }

        

        public void viewBook(Book bookToView)
        {
            bookstore.databaseFunctions.viewBook(bookToView, bookstore.User);
        }

        private string checkCredentials(string user, string pswd1, string pswd2, string nick)
        {
            
            if (user.Length == 0 || pswd1.Length == 0 || pswd2.Length == 0 || nick.Length == 0)
            {
                return "All text fields must be filled";
            }
            if (pswd1 != pswd2)
            {
                return "Passwords not matching";
            }
            if (!passwordStrong(pswd1))
            {
                return "Password must contain min. 8 characters, one upper and one lower case letter, digit and special character";
            }
            return "";
        }
        private bool passwordStrong(string pswd)
        {
            if (pswd.Length < 8)
            {
                return false;
            }
            string specialChars = "!@#$%^&*()";
            string numbers = "1234567890";
            string lowerCaseLetters = "zxcvbnmasdfghjklqwertyuiop";
            string uppercaseLetters = lowerCaseLetters.ToUpper();
            if (!containsOneOfChars(pswd, specialChars))
            {
                return false;
            }
            if (!containsOneOfChars(pswd, numbers))
            {
                return false;
            }
            if (!containsOneOfChars(pswd, lowerCaseLetters))
            {
                return false;
            }
            if (!containsOneOfChars(pswd, uppercaseLetters))
            {
                return false;
            }
            return true;
        }
        bool containsOneOfChars(string pswd, string chars)
        {
            foreach (char c in chars)
            {
                if (pswd.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        public void unrateBook(Book ratedBook)
        {
            bookstore.databaseFunctions.unrate(ratedBook, bookstore.User);
        }

        public void logout()
        {
            bookstore.User.logout();
        }

        public void rateBook(double rate, Book bookToRate)
        {
            //TODO remove that function
            throw new NotImplementedException();
        }

        
    }
}
