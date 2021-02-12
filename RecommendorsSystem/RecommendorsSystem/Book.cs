using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public class Book :BookWithAuthors, BookWithScore, BookWithAuthorsAndScore, BookGeneralData
    {
        public Book()
        {
            authors = new LinkedList<Author>();
            score = 0;
            id = 0;
            title = "";
            price = 0;
            priceMinusDiscountInProcent = 100;
        }
        public Book(BookGeneralData other) :this()
        {
            this.setGeneralDataFromOtherBook(other);
        }
        public void setGeneralDataFromOtherBook(BookGeneralData otherBook)
        {
            id = otherBook.id;
            title = otherBook.title;
            price = otherBook.price;
            priceMinusDiscountInProcent = otherBook.priceMinusDiscountInProcent;
        }
        private LinkedList<Author> authors;
        private int score;
        private int _id;
        private string _title;
        private decimal _price;
        private int _priceMinusDiscountInProcent;

        public int Score { get { return score; } set { score = value; } }
        public LinkedList<Author> Authors 
        {
            set
            {
                authors.Clear();
                foreach (Author a in value)
                {
                    Author aa = new Author(a.FirstName, a.LastName, a.Id);
                    authors.AddLast(aa);
                }

            }
            get
            { return authors; }

        }

        public int id { get { return _id; } set { _id = value; } }
        public string title { get { return _title; } set { _title = value; } }
        public decimal price { get { return _price; } set { _price = value; } }
        public int priceMinusDiscountInProcent { get { return _priceMinusDiscountInProcent; } set { _priceMinusDiscountInProcent = value; } }
    }
    public interface BookGeneralData
    {
        int id { get; set; }
        string title { get; set; }
        decimal price { get; set; }
        int priceMinusDiscountInProcent { get; set; }
        void setGeneralDataFromOtherBook(BookGeneralData otherBook);
    }

    public interface BookWithAuthors :BookGeneralData
    {
        LinkedList<Author> Authors
        {
            set; get;
        }
    }

    public interface BookWithScore :BookGeneralData
    {
        int Score { get; set; }
    }

    public interface BookWithAuthorsAndScore :BookWithScore, BookWithAuthors
    {

    }

    /*
    public class BookWithAuthorsAndScore : BookWithAuthors
    {
        public int Score { get { return score; } set { score = value; } }
        public BookWithAuthorsAndScore(BookWithAuthors book) : base(book, book.Authors)
        {
            Score = 0;
        }
    }
    */

    /*
    public class BookWithAuthors :Book
    {

        
        public LinkedList<Author> Authors
        {
            set
            {
                authors.Clear();
                foreach (Author a in value)
                {
                    Author aa = new Author(a.FirstName, a.LastName, a.Id);
                    authors.AddLast(aa);
                }

            }
            get
            { return authors; }
        }
        public BookWithAuthors(Book book, LinkedList<Author> authors) : base()
        {
            id = book.id;
            title = book.title;
            price = book.price;
            priceMinusDiscountInProcent = book.priceMinusDiscountInProcent;
            this.authors = authors;
        }
        

    }
    */



    public class Author
    {
        public Author()
        {

        }

        public Author(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { private set; get; }
        public string LastName { private set; get; }
        public int Id { private set; get; }
    }

    public class UserRatesInfoSet
    {
        public int IdBook { private set; get; }
        public int IdUser { private set; get; }
        public int Rate { private set; get; }
        public UserRatesInfoSet( int id_book, int id_user, int rate)
        {
            IdBook = id_book;
            IdUser = id_user;
            Rate = rate;
        }
    }

    public class Bonus
    {
        public int bonus_id;
        public int multiplicator;
        public DateTime begin;
        public DateTime end;
    }

}
