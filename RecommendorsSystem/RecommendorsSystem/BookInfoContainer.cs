using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommendorsSystem
{
    class BookInfoContainer
    {
        public BookInfoContainer(Book b)
        { book = b; }
        public Book book { get; set; }
        public override string ToString()
        {
            return book.id.ToString() + ", " + book.title + ", " + book.price.ToString() + ", " + book.priceMinusDiscountInProcent.ToString();
        }
    }
    class BookContainerTitle :BookInfoContainer
    {
        public BookContainerTitle(Book b) :base(b)
        { }
        public override string ToString()
        {
                return book.title;
        }
    }
    class BookContainerId : BookInfoContainer
    {
        public BookContainerId(Book b) :base(b)
        { }
        public override string ToString()
        {
            return book.id.ToString();
        }
    }
    class BookContainerScore : BookInfoContainer
    {
        public BookContainerScore(int bookScore, Book b) : base(b)
        { score = bookScore; }
        int score;
        public override string ToString()
        {
            return score.ToString();
        }
    }

    class BookContainerAuthors : BookInfoContainer
    {
        public BookContainerAuthors( Book b) : base(b)
        { 
            LinkedList<Author> authors = (base.book as BookWithAuthors).Authors;
            string authorsConcated = "";
            int i = 0;
            foreach(Author a in authors)
            {
                string singleAuthor = a.FirstName + " " + a.LastName;
                authorsConcated += singleAuthor;
                if(i<authors.Count -1)
                {
                    authorsConcated += ", ";
                }
                i++;

            }
            this.authors = authorsConcated;
        }
        string authors;
        public override string ToString()
        {
            return authors;
        }
    }

}
