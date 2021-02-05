using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    public class Book
    {
        public int id;
        public string title;
        public decimal price;
        public int priceMinusDiscountInProcent=100;
        
    }
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
    
    public class BookWithAuthors :Book
    {

        private LinkedList<Author> authors;
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

    public class BookWithAuthorsAndScore : BookWithAuthors
    {
        public int Score { get; set; }
        public BookWithAuthorsAndScore(BookWithAuthors book) : base(book, book.Authors)
        {
            Score = 0;
        }
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
