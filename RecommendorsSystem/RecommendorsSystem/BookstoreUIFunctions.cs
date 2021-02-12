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
            bookstore.addCategoryToLikedCategories(newLikedCategory);
        }

        public LinkedList<BookWithAuthorsAndScore> askForRecommendations()
        {
            return bookstore.askForRecommendations();
        }

        public void buyBook(BookGeneralData bookToBuy)
        {
            bookstore.buyBook(bookToBuy);
        }

        public bool checkIfCredentialsValid(string login, string password1, string password2, string nick)
        {
            string checkResult = checkCredentials(login, password1, password2, nick);
            string allGood = "";
            if(checkResult==allGood)
            {
                bool nickNotTaken = true, loginNotTaken = true;
                if(bookstore.checkIfUserExists(login) )
                {
                    loginNotTaken = false;
                }
                if(bookstore.checkIfNickExists(nick) )
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
            bookstore.deleteAccount(login,pswd);
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

        public int getBookRate(BookGeneralData currentBook)
        {
            return bookstore.getBookRate(currentBook);
        }



        public LinkedList<string> getAllCategories()
        {
            return bookstore.getAllCategories();
        }

        public LinkedList<Book> getBoughtBooks()
        {
            return bookstore.getBoughtBooks();
        }

        public LinkedList<string> getLikedCategories()
        {
            return bookstore.getLikedCategories();
        }

        public string getMessage()
        {
            return registerMessage;
        }

        public LinkedList<Book> getRatedBooks()
        {
            return bookstore.getRatedBooks();
        }

        public LinkedList<Book> getToBuyBooks()
        {
            return bookstore.getToBuyBooks();
        }
        /*
        public void goToAccount()
        {
            throw new NotImplementedException();
        }
        
        public void logoutAndGoToLogin()
        {
            throw new NotImplementedException();
        }
        
        public bool passwordCorrect(string password)
        {
            throw new NotImplementedException();
        }
        */
        



        public void registerNewUser(string login, string password, string nick)
        {
            bookstore.registerNewUser(login, password, nick);
        }

        public bool tryToLogin(string login, string password)
        {
            if(login == "" || password == "")
            {
                return false;
            }
            return bookstore.tryToLogin(login, password);
        }



        public void removeBookFromToBuy(BookGeneralData bookToRemoveFromToBuy)
        {
            bookstore.removeBookfromToBuy(bookToRemoveFromToBuy);
        }

        public void removeCategoryFromLikedCategories(string categoryToRemove)
        {
            bookstore.removeCategoryFromLikedCategories(categoryToRemove);
        }

        public void saveBookInToBuy(BookGeneralData bookToBeBoughtInFuture)
        {
            bookstore.saveBookInToBuy(bookToBeBoughtInFuture);
        }

        public LinkedList<BookWithAuthors> searchByAuthor(string searchPhrase)
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

            return bookstore.searchByAuthor(onlyLettersPhrase);
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

        
        //private String[] separateWords(string words)
        //{
          //  return words.Split(' ');
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
    //    }
    

        public LinkedList<BookWithAuthors> searchByTitle(string title)
        {
            return bookstore.searchByTitle(title);
        }

        public void setBookRate(BookGeneralData ratedBook, int rate)
        {
            bookstore.setBookRate(ratedBook, rate);
        }
        /*
        public void showRated()
        {
            throw new NotImplementedException();
        }
        */
        

        public void viewBook(BookGeneralData bookToView)
        {
            bookstore.viewBook(bookToView);
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
        private bool containsOneOfChars(string pswd, string chars)
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

        public void unrateBook(BookGeneralData ratedBook)
        {
            bookstore.unrateBook(ratedBook);
        }

        public void logout()
        {
            bookstore.logout();
        }
        /*
        public void rateBook(double rate, Book bookToRate)
        {
            //TODO remove that function
            throw new NotImplementedException();
        }
        */
        
    }
}
