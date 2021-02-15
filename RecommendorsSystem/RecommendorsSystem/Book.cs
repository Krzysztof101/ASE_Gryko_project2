using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public class Book :BookWithAuthorsAndCategories, BookWithScore, BookWithCategoriesAuthorsAndScore, BookGeneralData
    {
        public Book()
        {
            categories = new LinkedList<string>();
            authors = new LinkedList<Author>();
            score = 0;
            id = 0;
            title = "";
            price = 0;
            priceMinusDiscountInProcent = 100;
            quantity = 0;
            startSellingDate = DateTime.Now.Date;
            deleted = false;
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
            quantity = otherBook.Quantity;
            startSellingDate = otherBook.StartSellingDate;
            deleted = otherBook.Deleted;
        }
        private LinkedList<Author> authors;
        private LinkedList<string> categories;
        private int score;
        private int _id;
        private string _title;
        private decimal _price;
        private int _priceMinusDiscountInProcent;
        private int quantity;
        private DateTime startSellingDate;
        private bool deleted;

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

        public LinkedList<string> Categories { get { return categories; } set { if (value != null) { categories = value; } else categories = new LinkedList<string>(); } }

        public int Quantity { get { return quantity; } set { if (value >= 0) quantity = value; } }

        public DateTime StartSellingDate { get { return startSellingDate.AddDays(0); } set { if (value != null) { startSellingDate = value.AddDays(0); } } }

        public bool Deleted { get { return deleted; } set { if (deleted != null) { deleted = value; } } }
    }
    public interface BookGeneralData
    {
        bool Deleted { get; set; }
        DateTime StartSellingDate { get; set; }
        int Quantity { get; set; }
        int id { get; set; }
        string title { get; set; }
        decimal price { get; set; }
        int priceMinusDiscountInProcent { get; set; }
        void setGeneralDataFromOtherBook(BookGeneralData otherBook);
    }

    public interface BookWithAuthorsAndCategories :BookGeneralData, BookWithCategories
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

    public interface BookWithCategoriesAuthorsAndScore :BookWithScore, BookWithAuthorsAndCategories, BookWithCategories
    {

    }
    public interface BookWithCategories
    {
        LinkedList<string> Categories { get; set; }
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
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    public class Category
    {
        public Category()
        { Name = ""; }
        public Category(string nnn)
            { Name = nnn; }
        public string Name { get; set; }
    }

    

}
